<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

if($data['type']=='list'):
	if(isset($data['cod'])):
		$query=$db->getquery("select designation, quantity, requested, delivery_date, cod_diy, requested_qty from site_materials_diy where site_materials_diy.cod_diy='".$data['cod']."'");
		if($query[0][0]<>''): // results found
			$response['error'] = false; 
			$response['message'] =$welcome_msg;

			$response['data'][0]['requestqty']=$query[0][5];
			$response['data'][0]['stock']=$query[0][1];
			$response['data'][0]['designation']=$query[0][0];
			$response['data'][0]['request']=$query[0][2];
			$response['data'][0]['delivery']=$query[0][3];
			$response['data'][0]['code']=$query[0][4];

			$query2=$db->getquery("select file, cod_photo from photos where db_table='site_materials_diy' and cod_table='".$data['cod']."'");
			if($query2[0][0]<>''):
				for($k=0; $k<count($query2);$k++):
					$response['data'][$i]['photos'][$k]['file']=$query2[$k][0];
					$response['data'][$i]['photos'][$k]['code']=$query2[$k][1];
				endfor;
			endif;
		else:
			$response['error'] = true; 
			$response['message'] =$entry_not_found;
		endif;				
	else:
		CheckJsonParams($data,$iv,$secretKey, array('date'));
		$query=$db->getquery("select designation, quantity, requested, delivery_date, cod_diy, requested_qty from site_materials_diy where cod_site='".$data['site']."' and cod_section='".$data['section']."' order by designation ASC");
		if($query[0][0]<>''): // results found
			$response['error'] = false; 
			$response['message'] =$welcome_msg;
			$pos=0;
			for($i = 0; $i < count($query); $i++):
				$response['data'][$i]['requestqty']=$query[0][5];
				$response['data'][$i]['stock']=$query[0][1];
				$response['data'][$i]['designation']=$query[0][0];
				// 0 no request , 1 request made
				$response['data'][$i]['request']=$query[0][2];
				$response['data'][$i]['delivery']=$query[0][3];
				$response['data'][$i]['code']=$query[0][4];

				$query2=$db->getquery("select file, cod_photo from photos where db_table='site_materials_diy' and cod_table='".$query[$i][0]."'");
				if($query2[0][0]<>''):
					for($k=0; $k<count($query2);$k++):
						$response['data'][$i]['photos'][$k]['file']=$query2[$k][0];
						$response['data'][$i]['photos'][$k]['code']=$query2[$k][1];
					endfor;
				endif;
			endfor;
		else:
			$response['error'] = true; 
			$response['message'] =$entry_not_found;
		endif;
	endif;

elseif($data['type']=='record'):
	CheckJsonParams($data,$iv,$secretKey, array('designation','stock'));
	if(isset($data['request'])):
		 $request=", requested='".$data['request']."', requested_qty='".$data['requestqty']."'";
	else:
		$request="";
	endif;
	$query=$db->getquery("select cod_diy from site_materials where designation='".encodeString16($data['designation'])."'");
	if($query[0][0]<>""):
		$data['designation'].=" ".rand(0,100);	
	endif;
	if(isset($data['cod'])):
		$db->setquery("update site_materials_diy set designation='".encodeString16($data['designation'])."', cod_site='".$data['site']."', cod_section='".$data['section']."', quantity='".$data['stock']."', date='".date('Y-m-d', time())."'".$request."  where cod_diy='".$data['cod']."'");			
		$response['code'] = $data['cod'];
		$code=$data['cod'];
	else:
		$date=date('Y-m-d', time());
		$db->setquery("insert into site_materials_diy set designation='".encodeString16($data['designation'])."', cod_site='".$data['site']."', cod_section='".$data['section']."', quantity='".$data['stock']."', date='".$date."'".$request);
		$query=$db->getquery("select cod_diy from site_materials_diy where designation='".encodeString16($data['designation'])."' and cod_site='".$data['site']."' and cod_section='".$data['section']."' and date='".$date."'");				
		$code = $query[0][0];				
	endif;
	$response['error'] = false; 
	$response['message'] = 'OK';

	foreach($_FILES as $file):
		if($file['error']===UPLOAD_ERR_OK):
			$fileName=generateRandomString().'.jpg';
			$uploadfile = $server['root']['files']."materials/". $fileName;
			while (is_file($uploadfile)):
				$fileName=generateRandomString().'.jpg';
				$uploadfile = $server['root']['files']."materials/". $fileName;
			endwhile;
			if(move_uploaded_file($file['tmp_name'], $uploadfile)):
				$db->setquery("insert into photos set file='".$fileName."', cod_table='".$code."', db_table='site_materials_diy'");
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
		if (unlink($server['root']['files']."materials/". $query[0][0])): 
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