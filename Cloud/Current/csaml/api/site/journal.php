<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

if($data['type']=='list'):
	if(isset($data['cod'])):
		$query=$db->getquery("select time, note, photo from site_journal where cod_journal='".$data['cod']."'");
		if($query[0][0]<>''): // results found
			$response['error'] = false; 
			$response['message'] ='Bem vindo';
			$response['data'][0]['nota']=encodeString($query[0][1]);
			$response['data'][0]['hora']=$query[0][0];

			$query2=$db->getquery("select file, cod_photo from photos where db_table='site_journal' and cod_table='".$data['cod']."'");
			if($query2[0][0]<>''):
				for($k=0; $k<count($query2);$k++):
					$response['data'][$i]['photos'][$k]['file']=$query2[$k][0];
					$response['data'][$i]['photos'][$k]['code']=$query2[$k][1];
				endfor;
			endif;
		else:
			$response['error'] = true; 
			$response['message'] =$journal_entry_not_found;
		endif;				
	else:
		CheckJsonParams($data,$iv,$secretKey, array('date'));
		$query=$db->getquery("select site_journal.cod_journal, site_journal.time, site_journal.note, worker.name from site_journal left join worker on site_journal.cod_worker=worker.cod_worker where site_journal.cod_site='".$data['site']."' and site_journal.cod_section='".$data['section']."' and site_journal.date='".$data['date']."' order by site_journal.time ASC");
		if($query[0][0]<>''): // results found
			$response['error'] = false; 
			$response['message'] ='Bem vindo';
			$pos=0;
			for($i = 0; $i < count($query); $i++):
				$response['data'][$i]['name']=encodeString($query[$i][3]);
				$response['data'][$i]['code']=$query[$i][0];
				$response['data'][$i]['hora']=$query[$i][1];
				$response['data'][$i]['note']=$query[$i][2];

				$query2=$db->getquery("select file, cod_photo from photos where db_table='site_journal' and cod_table='".$query[$i][0]."'");
				if($query2[0][0]<>''):
					for($k=0; $k<count($query2);$k++):
						$response['data'][$i]['photos'][$k]['file']=$query2[$k][0];
						$response['data'][$i]['photos'][$k]['code']=$query2[$k][1];
					endfor;
				endif;
			endfor;
		else:
			$response['error'] = true; 
			$response['message'] =$journal_entry_not_found_selected_day;
		endif;
	endif;

elseif($data['type']=='add'):
	CheckJsonParams($data,$iv,$secretKey, array('nota'));

	if(isset($data['cod'])):
		$query=$db->getquery("select cod_worker from worker where cod_nfc='".$data['sn']."'");
		$time= isset($data['time']) ? $data['time'] : date('H:i', time());
		$db->setquery("update site_journal set note='".encodeString16($data['nota'])."', cod_site='".$data['site']."', cod_section='".$data['section']."', time='".$time."', date='".$data['date']."', cod_worker='".$query[0][0]."' where cod_journal='".$data['cod']."'");			
		$response['code'] = $data['cod'];
		$code=$data['cod'];
	else:
		$query=$db->getquery("select cod_worker from worker where cod_nfc='".$data['sn']."'");
		$time= isset($data['time']) ? $data['time'] : date('H:i', time());
		$db->setquery("insert into site_journal set note='".encodeString16($data['nota'])."', cod_site='".$data['site']."', cod_section='".$data['section']."',  time='".$time."', date='".$data['date']."', cod_worker='".$query[0][0]."'");
		$query=$db->getquery("select cod_journal from site_journal where note='".encodeString16($data['nota'])."' and cod_site='".$data['site']."' and cod_section='".$data['section']."' and time='".$time."' and date='".$data['date']."' and cod_worker='".$query[0][0]."'");				
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
			$uploadfile = dirname(dirname(dirname(__FILE__)))."/files/journal/". $fileName;
			while (is_file($uploadfile)):
				$fileName=generateRandomString().'.jpg';
				$uploadfile = dirname(dirname(dirname(__FILE__)))."/files/journal/". $fileName;
			endwhile;
			if(move_uploaded_file($file['tmp_name'], $uploadfile)):
				$db->setquery("insert into photos set file='".$fileName."', cod_table='".$code."', db_table='site_journal'");
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

elseif($data['type']=='del'):
	CheckJsonParams($data,$iv,$secretKey, array('cod'));
	$query=$db->getquery("select file, db_table from photos where cod_photo='".$data['cod']."'");
	if($query[0][0]<>''):
		if (unlink(dirname(dirname(dirname(__FILE__)))."/files/journal/". $query[0][0])): // replace dirname dirname for a more easy to see path
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