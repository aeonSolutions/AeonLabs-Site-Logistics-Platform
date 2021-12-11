<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['request']=='del'):
	CheckGet(array('cod'));
	$query=$db->getquery("select file, db_table from photos where cod_photo='".$data['cod']."'");
	if ($query[0][0]<>''):
		if($query[0][1]=="site_journal"):
			$dir="journal";
		elseif($query[0][1]=="site_delivery"):
			$dir="delivery";
		elseif($query[0][1]=="site_regie"):
			$dir="regie";
		elseif($query[0][1]=="site_occurrences"):
			$dir="occurrences";
		endif;
		@unlink($server['root']['files'].$dir."/". $query[0][0]);
		$db->setquery("delete from photos where cod_photo='".$data['cod']."'");
	endif;
	$response['error'] = false; 
	$response['message'] = $regie_del_success;
elseif($data['request']=="add"):
	CheckGet(array('where','cod'));
	$response['error'] = true;

	if($data['where']=='delivery'):
		$dir='delivery';
		$dbTable='site_delivery';
	elseif($data['where']=='ocurrences'):
		$dir='ocurrences';
		$dbTable='site_ocurrences';
	elseif($data['where']=='journal'):
		$dir='journal';
		$dbTable='site_journal';
	elseif($data['where']=='regie'):
		$dir='regie';
		$dbTable='site_regie';
	else:
		$response['message'] = $invalid_request;				
		$db->connect(false);
		echo json_encode($response);
		die();
	endif;

	if(isset($_FILES['file'])):
		if($_FILES['file']['error']===UPLOAD_ERR_OK):
			$fileName=generateRandomString().'.jpg';
			$uploadfile = $server['root']['files'].$dir."/". $fileName;
			while (is_file($uploadfile)):
				$fileName=generateRandomString().'.jpg';
				$uploadfile = $server['root']['files'].$dir."/". $fileName;
			endwhile;

			if(move_uploaded_file($_FILES['file']['tmp_name'], $uploadfile)):
				$db->setquery("insert into photos set file='".$fileName."', cod_table='".$data['cod']."', db_table='".$dbTable."'");
				$response['error'] = false; 
				$response['message'] = $photos_photo_added;
			else:
				$response['message'] = $photos_upload_error;
			endif;
		elseif($_FILES['file']['error']===UPLOAD_ERR_INI_SIZE):
			$response['message'] =$photos_upload_max_size;
		elseif($_FILES['file']['error']===UPLOAD_ERR_FORM_SIZE):
			$response['message'] = $photos_upload_max_size_html_form;
		elseif($_FILES['file']['error']===UPLOAD_ERR_PARTIAL):
			$response['message'] = $photos_upload_partial_file;
		elseif($_FILES['file']['error']===UPLOAD_ERR_NO_FILE):
			$response['message'] = $photos_no_file_found_on_data_post;				
		endif;
	else:
		$response['message'] = $photo_file_not_found;				
		$response['error'] = true; 
	endif;
else:
	$response['error'] = true; 
	$response['message'] = $invalid_request;
endif;

?>