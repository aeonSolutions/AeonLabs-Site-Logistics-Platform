<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();
if($data['request']=='file'):
	CheckFile($db, $data, $iv, $secretKey);
	CheckJsonParams($data,$iv,$secretKey,array('cod'));
	$fileName=generateRandomString().'.jpg';
	$uploadDir = $server['root']['path']."photos/";
	while (is_file($uploadDir. $fileName)):
		$fileName=generateRandomString().'.jpg';
	endwhile;
	
	if(move_uploaded_file($_FILES['file']['tmp_name'], $uploadDir.$fileName)):
		$response=[];
		$query=$db->getquery("select photo from users where cod_user='".$data['cod']."'");
		if($query[0][0]<>""):
			unlink($uploadDir.$query[0][0]);
		endif;
		$query=$db->setquery("update users set photo='".$fileName."' where cod_user='".$data['cod']."'");
		$response['error'] = false; 
		$response['message'] = 'DB request OK';
	else:
		$response['error'] = true; 
		$response['message'] = $photo_error_upload;
	endif;
elseif($data['request']=='edit' ):
	CheckJsonParams($data,$iv,$secretKey,array('name','email','contact','cod'));
	$auth="";
	if(isset($data['auth'])):		
		$auth= strlen($data['auth'])==12 ? ", card_auth_key='".$data['auth']."'" : "";
	endif;
	$query="update users set name='".$data['name']."', email='".$data['email']."', contact='".$data['contact']."'".$auth." where cod_user='".$data['cod']."'";
	$db->setquery($query);
	$response['error'] = false; 
	$response['message'] = $regie_add_success;
else:
	$response['error'] = true; 
	$response['message'] = $invalid_request;
endif;
?>