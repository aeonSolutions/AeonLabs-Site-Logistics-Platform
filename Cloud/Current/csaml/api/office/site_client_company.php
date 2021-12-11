<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['request']=='file'):
	CheckFile();
	CheckJsonParams($data,$iv,$secretKey,array('cod'));
	$fileName=generateRandomString().'.jpg';
	$uploadDir = $server['root']['photos'];
	while (is_file($uploadDir. $fileName)):
		$fileName=generateRandomString().'.jpg';
	endwhile;

	if(move_uploaded_file($_FILES['file']['tmp_name'], $uploadDir.$fileName)):
		$query=$db->getquery("select logo from site_contractor where cod_company='".$data['cod']."'");
		if($query[0][0]<>""):
			unlink($uploadDir.$query[0][0]);
		endif;
		$query=$db->setquery("update site_contractor set logo='".$fileName."' where cod_company='".$data['cod']."'");
		$response['error'] = false; 
		$response['message'] = 'DB request OK';
	else:
		$response['error'] = true; 
		$response['message'] = $photo_error_upload;
	endif;
elseif($data['request']=='add' or $data['request']=='edit'):
	CheckJsonParams($data,$iv,$secretKey,array('nome','email','address','contact','tva'));
	if($data['request']=='add'):
		$query="insert into site_contractor set nome='".$data['nome']."', email='".$data['email']."', address='".$data['address']."', tva='".$data['tva']."', phone='".$data['contact']."'";
	else:
		CheckJsonParams($data,$iv,$secretKey,array('cod'));
		$query="update site_contractor set nome='".$data['nome']."', email='".$data['email']."', address='".$data['address']."', tva='".$data['tva']."', phone='".$data['contact']."' where cod_company='".$data['cod']."'";
	endif;
	$db->setquery($query);
	$response['error'] = false; 
	$response['message'] =$regie_add_success;
else:
	CheckJsonParams($data,$iv,$secretKey,array('del'));
	$query=$db->getquery("select cod_site from site where cod_company='".$data['del']."'");
	if($query[0][0]<>''):
		$response['error'] = true; 
		$response['message'] = $company_error_del;
	else:
		$db->setquery("delete from site_contractor where cod_company='".$data['del']."'");
		$response['error'] = false; 
		$response['message'] = $regie_del_success;
	endif;
endif;

?>