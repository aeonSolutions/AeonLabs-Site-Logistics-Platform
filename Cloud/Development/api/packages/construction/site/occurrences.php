<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

if($data['type']=='list'):
	$cod=(isset($data['cod'])) ? " and cod_ocurrence='".$data['cod']."'" : "";

	$query=$db->getquery("select cod_ocurrence, description, date from site_ocurrences where cod_site='".$data['site']."' and cod_section='".$data['section']."'".$cod." order by date ASC");
	if($query[0][0]<>''): // results found
		$response['error'] = false; 
		$response['message'] ='Bem vindo';
		$pos=0;
		for($i = 0; $i < count($query); $i++):
			$response['data'][$i]['notas']=encodeString($query[$i][1]);
			$response['data'][$i]['code']=$query[$i][0];
			$response['data'][$i]['data']=$query[$i][2];
			$query2=$db->getquery("select file, cod_photo from photos where db_table='site_ocurrences' and cod_table='".$query[$i][0]."'");
			if($query2[0][0]<>''):
				for($k=0; $k<count($query2);$k++):
					$response['data'][$i]['photos'][$k]['file']=$query2[$k][0];
					$response['data'][$i]['photos'][$k]['code']=$query2[$k][1];
				endfor;
			endif;
		endfor;
	else:
		$response['error'] = true; 
		$response['message'] =$occurrences_missing;
	endif;

elseif($data['type']=='add'):
	CheckJsonParams($data,$iv,$secretKey, array('notas','snc'));
	$query=$db->getquery("select cod_manager from site_manager where cod_site='".$data['site']."' and cod_section='".$data['section']."' and cod_nfc='".$data['snc']."'");
	if($query[0][0]<>''):
		$notas=(isset($data['notas'])) ? $data['notas'] : "";
		$date=(isset($data['date'])) ? $data['date'] : date('Y-m-d', time());

		if(isset($data['cod'])):
			$query=$db->setquery("update site_ocurrences set cod_site='".$data['site']."', cod_section='".$data['section']."', date='".$date."', description='".encodeString16($notas)."' where cod_ocurrence='".$data['cod']."'");					
			$response['code'] = $data['cod'];
			$code=$data['cod'];
		else:
			$time= isset($data['time']) ? $data['time'] : date('H:i', time());
			$query=$db->setquery("insert into site_ocurrences set time='".$time."', cod_site='".$data['site']."', cod_section='".$data['section']."', date='".$date."', description='".encodeString16($notas)."'");
			$query=$db->getquery("select cod_ocurrence from site_ocurrences where cod_site='".$data['site']."' and cod_section='".$data['section']."'and date='".$date."' and description='".encodeString16($notas)."' and time='".$time."'");
			$code = $query[0][0];
		endif;
		$response['error'] = false; 
		$response['message'] = 'DB request OK';

    	//  [name] => array( /* these arrays are the size you expect */ )
    	//  [type] => array( /* these arrays are the size you expect */ )
    	//  [tmp_name] => array( /* these arrays are the size you expect */ )
    	//  [error] => array( /* these arrays are the size you expect */ )
    	//  [size] => array( /* these arrays are the size you expect */ )

		foreach($_FILES as $file):
			if($file['error']===UPLOAD_ERR_OK):
				$fileName=generateRandomString().'.jpg';
				$uploadfile = dirname(dirname(dirname(__FILE__)))."/files/ocurrences/". $fileName;
				while (is_file($uploadfile)):
					$fileName=generateRandomString().'.jpg';
					$uploadfile = dirname(dirname(dirname(__FILE__)))."/files/ocurrences/". $fileName;
				endwhile;
				if(move_uploaded_file($file['tmp_name'], $uploadfile)):
					$db->setquery("insert into photos set file='".$fileName."', cod_table='".$code."', db_table='site_ocurrences'");
				else:
					$response['error'] = true; 
					$response['message'] = $photos_upload_error;
				endif;
			elseif($_FILES['file']['error']===UPLOAD_ERR_INI_SIZE):
				$response['error'] = true; 
				$response['message'] = $photos_upload_max_size;
			elseif($_FILES['file']['error']===UPLOAD_ERR_FORM_SIZE):
				$response['error'] = true; 
				$response['message'] = $photos_upload_max_size_html_form;
			elseif($_FILES['file']['error']===UPLOAD_ERR_PARTIAL):
				$response['error'] = true; 
				$response['message'] = $photos_upload_partial_file;
			elseif($_FILES['file']['error']===UPLOAD_ERR_NO_FILE):
				$response['error'] = true; 
				$response['message'] = $photos_no_file_found_on_data_post;				
			endif;
		endforeach;
	else:
		$response['error'] = true; 
		$response['message'] =$occurrences_missing_site_manager;
	endif;
elseif($data['type']=='del'):
	CheckJsonParams($data,$iv,$secretKey, array('cod'));
	$query=$db->getquery("select file, db_table from photos where cod_photo='".$data['cod']."'");
	if($query[0][0]<>''):
		if (unlink(dirname(dirname(dirname(__FILE__)))."/files/ocurrences/". $query[0][0])): // replace dirname dirname for a more easy to see path
			$db->setquery("delete from photos where cod_photo='".$data['cod']."'");
			$response['message'] = 'photo deleted';				
			$response['error'] = false;
		else:
			$response['message'] = $photo_file_not_found;				
			$response['error'] = true;
		endif;
	else:
		$response['message'] = $photo_not_found_db;				
		$response['error'] = true;
	endif;
else:
	$response['error'] = true; 
	$response['message'] ="Invalid request";
endif;
?>