<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

if($data['type']=="del"):
	CheckJsonParams($data,$iv,$secretKey, array('cod'));

	$query=$db->getquery("select file, db_table from photos where cod_photo='".$data['cod']."'");
	if($query[0][0]<>''):
		if($query[0][1]=='site_delivery'):
			$dir='delivery';
		elseif($query[0][1]=='site_ocurrences'):
			$dir='ocurrences';
		elseif($query[0][1]=='site_journal'):
			$dir='journal';
		endif;
		if (unlink(dirname(dirname(__FILE__))."/files/".$dir."/". $query[0][0])):
			$db->setquery("delete from photos where cod_photo='".$data['cod']."'");
			$response['message'] = 'photo deleted';				
			$response['error'] = false;
		else:
			$response['message'] = 'photo file not found';				
			$response['error'] = true;
		endif;
		else:
		$response['message'] = $photos_del_photo_not_found;				
		$response['error'] = true;
	endif;
else:
	CheckGet(array('db','cod'));
	$date=(isset($data['date'])) ? $data['date'] : date('Y-m-d', time());

	if($data['db']=='delivery'):
		$dir='delivery';
		$dbTable='site_delivery';
	elseif($data['db']=='ocurrences'):
		$dir='ocurrences';
		$dbTable='site_ocurrences';
	elseif($data['db']=='journal'):
		$dir='journal';
		$dbTable='site_journal';
	else:
		$response['message'] = 'Invalid GET request';				
		$response['error'] = true;
		$db->connect(false);

		echo json_encode($response);
		die();
	endif;

	if(isset($_FILES['file'])):
		if($_FILES['file']['error']===UPLOAD_ERR_OK):
			$fileName=generateRandomString().'.jpg';
			$uploadfile = dirname(dirname(__FILE__))."/files/".$dir."/". $fileName;
			while (is_file($uploadfile)):
				$fileName=generateRandomString().'.jpg';
				$uploadfile = dirname(dirname(__FILE__))."/files/".$dir."/". $fileName;
			endwhile;

			if(move_uploaded_file($_FILES['file']['tmp_name'], $uploadfile)):
				$db->setquery("insert into photos set file='".$fileName."', cod_table='".$data['cod']."', db_table='".$dbTable."'");
				$response['error'] = false; 
				$response['message'] = $photos_photo_added;
			else:
				$response['message'] = $photos_upload_error;
			endif;
		elseif($_FILES['file']['error']===UPLOAD_ERR_INI_SIZE):
			$response['message'] = $photos_upload_max_size;
		elseif($_FILES['file']['error']===UPLOAD_ERR_FORM_SIZE):
			$response['message'] = $photos_upload_max_size_html_form;
		elseif($_FILES['file']['error']===UPLOAD_ERR_PARTIAL):
			$response['message'] = $photos_upload_partial_file;
		elseif($_FILES['file']['error']===UPLOAD_ERR_NO_FILE):
			$response['message'] = $photos_no_file_found_on_data_post;				
		endif;
	else:
		$response['message'] = $photos_no_file_found_on_data_post.' (2)';				
		$response['error'] = true; 
	endif;

endif;
?>