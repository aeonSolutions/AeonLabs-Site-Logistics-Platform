<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

if($data['type']=='list'):
	if(isset($data['cod'])):
		$query=$db->getquery("select site_hardware.designation, site_hardware.state, worker.name, site_hardware.requested, site_hardware.delivery_date, site_hardware.cod_hardware from site_hardware left join worker on site_hardware.cod_worker=worker.cod_worker where site_hardware.cod_hardware='".$data['cod']."'");
		if($query[0][0]<>''): // results found
			$response['error'] = false; 
			$response['message'] =$welcome_msg;
			$exploded=  explode(" ",$query[0][2]);
			if(isset($exploded[1])):
				$name=$exploded[0]." ".$exploded[count($exploded)-1];
			else:
				$name=$exploded[0];
			endif;

			$response['data'][0]['worker']=encodeString($name);
			$response['data'][0]['state']=$query[0][1];
			$response['data'][0]['designation']=$query[0][0];
			$response['data'][0]['request']=$query[0][3];
			$response['data'][0]['delivery']=$query[0][4];
			$response['data'][0]['code']=$query[0][5];

			$query2=$db->getquery("select file, cod_photo from photos where db_table='site_hardware' and cod_table='".$data['cod']."'");
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
		$query=$db->getquery("select site_hardware.designation, site_hardware.state, worker.name, site_hardware.requested, site_hardware.delivery_date, site_hardware.cod_hardware from site_hardware left join worker on site_hardware.cod_worker=worker.cod_worker where site_hardware.cod_site='".$data['site']."' and site_hardware.cod_section='".$data['section']."' order by site_hardware.designation ASC");
		if($query[0][0]<>''): // results found
			$response['error'] = false; 
			$response['message'] =$welcome_msg;
			$pos=0;
			for($i = 0; $i < count($query); $i++):
				$exploded=  explode(" ",$query[$i][2]);
				if(isset($exploded[1])):
					$name=$exploded[0]." ".$exploded[count($exploded)-1];
				else:
					$name=$exploded[0];
				endif;
	
				$response['data'][$i]['worker']=encodeString($name);
				// 0 broken, 1 working, -1 stolen or missing
				$response['data'][$i]['state']=$query[$i][1];
				$response['data'][$i]['designation']=$query[$i][0];
				// 0 no request , 1 requested, 2 delivered
				$response['data'][$i]['request']=$query[$i][3];
				$response['data'][$i]['delivery']=$query[$i][4];
				$response['data'][$i]['code']=$query[$i][5];

				$query2=$db->getquery("select file, cod_photo from photos where db_table='site_hardware' and cod_table='".$query[$i][0]."'");
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
	CheckJsonParams($data,$iv,$secretKey, array('designation','state'));
	$request = isset($data['request']) ? ", requested='".$data['request']."'" : "";
	$query=$db->getquery("select cod_hardware from site_hardware where designation='".encodeString16($data['designation'])."'");
	if($query[0][0]<>""):
		$data['designation'].=" ".rand(0,100);	
	endif;
	if(isset($data['cod'])):
		$db->setquery("update site_hardware set designation='".encodeString16($data['designation'])."', cod_site='".$data['site']."', cod_section='".$data['section']."', state='".$data['state']."', date='".date('Y-m-d', time())."'".$request."  where cod_hardware='".$data['cod']."'");			
		$response['code'] = $data['cod'];
		$code=$data['cod'];
	else:
		$date=date('Y-m-d', time());
		$db->setquery("insert into site_hardware set designation='".encodeString16($data['designation'])."', cod_site='".$data['site']."', cod_section='".$data['section']."', state='".$data['state']."', date='".$date."'".$request);
		$query=$db->getquery("select cod_hardware from site_hardware where designation='".encodeString16($data['designation'])."' and cod_site='".$data['site']."' and cod_section='".$data['section']."' and date='".$date."'");				
		$code = $query[0][0];				
	endif;
	$response['error'] = false; 
	$response['message'] = 'OK';

	foreach($_FILES as $file):
		if($file['error']===UPLOAD_ERR_OK):
			$fileName=generateRandomString().'.jpg';
			$uploadfile = $server['root']['files']."hardware/". $fileName;
			while (is_file($uploadfile)):
				$fileName=generateRandomString().'.jpg';
				$uploadfile = $server['root']['files']."hardware/". $fileName;
			endwhile;
			if(move_uploaded_file($file['tmp_name'], $uploadfile)):
				$db->setquery("insert into photos set file='".$fileName."', cod_table='".$code."', db_table='site_hardware'");
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
		if (unlink($server['root']['files']."hardware/". $query[0][0])): 
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