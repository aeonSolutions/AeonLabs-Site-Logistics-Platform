<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['request']=='delimosa'):
	CheckJsonParams($data,$iv,$secretKey, array('cod'));
	$db->connect(true);
	$response=[];
	$query=$db->getquery("select file, qrcode from worker_limosa where cod_limosa='".$data['cod']."'");
	if(is_file($server['root']['files']."limosas/".$query[0][0])):
		unlink($server['root']['files']."limosas/".$query[0][0]);
	endif;
	if(is_file($server['root']['files']."limosas/qrcode/".$query[0][1])):
		unlink($server['root']['files']."limosas/qrcode/".$query[0][1]);
	endif;
	$query=$db->setquery("delete from worker_limosa where cod_limosa='".$data['cod']."'");
	$response['error'] = false; 
	$response['message'] = $checkCredentials_welcome;

elseif($data['request']=='addlimosa'):
	if(isset($data['type'])):
		CheckJsonParams($data,$iv,$secretKey, array('cod'));
		CheckFile($db, $data, $iv, $secretKey);
		$fileName=generateRandomString().'.jpg';
		$uploadfile = $server['root']['files']."limosas/qrcode/". $fileName;
		while (is_file($uploadfile)):
			$fileName=generateRandomString().'.jpg';
			$uploadfile = $server['root']['files']."limosas/qrcode/". $fileName;
		endwhile;
		if(move_uploaded_file($_FILES['file']['tmp_name'], $uploadfile)):
			$db->connect(true);
			$response=[];
			$db->setquery("update worker_limosa set qrcode='".$fileName."' where cod_limosa='".$data['cod']."'");

			$response['error'] = false; 
			$response['message'] = $regie_add_success;
			$db->connect(false);
		else:
			$response['error'] = true; 
			$response['message'] = $photos_upload_error;
		endif;

	else:
		CheckJsonParams($data,$iv,$secretKey, array('user','inicio','fim','site'));
		CheckFile();
		$fileName=generateRandomString().'.pdf';
		$uploadfile = $server['root']['files']."limosas/". $fileName;
		while (is_file($uploadfile)):
			$fileName=generateRandomString().'.pdf';
			$uploadfile = $server['root']['files']."limosas/". $fileName;
		endwhile;

		if(move_uploaded_file($_FILES['file']['tmp_name'], $uploadfile)):
			$db->connect(true);
			$response=[];
			$db->setquery("insert into worker_limosa set cod_worker='".$data['user']."', inicio='".$data['inicio']."', fim='".$data['fim']."', cod_site='".$data['site']."', file='".$fileName."'");
			$query=$db->getquery("select cod_limosa from worker_limosa where cod_worker='".$data['user']."' and inicio='".$data['inicio']."' and fim='".$data['fim']."' and cod_site='".$data['site']."' and file='".$fileName."'");
			$response['message'] = $query[0][0];		
			$response['error'] = false; 
			$db->connect(false);
		else:
			$response['error'] = true; 
			$response['message'] = $photos_upload_error;
		endif;
	endif;
else:
	$response['error'] = true; 
	$response['message'] = $invalid_request;
endif;
?>