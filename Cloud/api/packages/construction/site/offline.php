<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

$query=$db->getquery("select cod_worker, name, cod_nfc, contact, contact112, email, nib, photo, morada from worker where cod_nfc='".$data['sn']."' and activo='1'");	
if($query[0][0]<>''):
	$response['error'] = false;
	$response['message'] = 'Welcome';
	$response['name'] = encodeString($query[0][1]);				
	$response['nfc'] = $query[0][2];				
	$response['mobile'] = $query[0][3];								
	$response['email'] = $query[0][5];							
	$response['photo'] = $query[0][7]<>"" ? $query[0][7] : "person.png";
else:
	$response['error'] = true; 
	$response['message'] = 'User not found';				
endif;
?>