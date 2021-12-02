<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['request']=='file'):
	CheckFile($db, $data, $iv, $secretKey);
	CheckJsonParams($data,$iv,$secretKey,array('cod'));
	$fileName=generateRandomString().'.jpg';
	$uploadDir = $server['root']['photos'];
	while (is_file($uploadDir. $fileName)):
		$fileName=generateRandomString().'.jpg';
	endwhile;

	if(move_uploaded_file($_FILES['file']['tmp_name'], $uploadDir.$fileName)):
		$response=[];
		$query=$db->getquery("select photo from site_manager where cod_manager='".$data['cod']."'");
		if($query[0][0]<>""):
			unlink($uploadDir.$query[0][0]);
		endif;
		$query=$db->setquery("update site_manager set photo='".$fileName."' where cod_manager='".$data['cod']."'");
		$response['error'] = false; 
		$response['message'] = 'DB request OK';
	else:
		$response['error'] = true; 
		$response['message'] = $photo_error_upload;
	endif;
elseif($data['request']=='add' or $data['request']=='edit'):
	CheckJsonParams($data,$iv,$secretKey,array('nome','email','funcao','contact','nfc','site', 'section'));
	$idKey= $data['idkey']=="" ? "" : ", auth_string='".$data['idkey']."'";
	if($data['request']=='add'):
		$query="insert into site_manager set name='".$data['nome']."', email='".$data['email']."', job='".$data['funcao']."', telef='".$data['contact']."', cod_nfc='".$data['nfc']."', cod_site='".$data['site']."', cod_section='".$data['section']."'".$idKey;
	else:
		CheckJsonParams($data,$iv,$secretKey,array('cod'));
		$query="update site_manager set name='".$data['nome']."', email='".$data['email']."', job='".$data['funcao']."', telef='".$data['contact']."', cod_nfc='".$data['nfc']."', cod_site='".$data['site']."', cod_section='".$data['section']."'".$idKey." where cod_manager='".$data['cod']."'";
	endif;
	$db->setquery($query);
	$response['error'] = false; 
	$response['message'] = $regie_add_success;
else:
	CheckJsonParams($data,$iv,$secretKey,array('del'));
	$db->setquery("delete from site_manager where cod_manager='".$data['del']."'");
	$response['error'] = false; 
	$response['message'] = $regie_del_success;
endif;

?>