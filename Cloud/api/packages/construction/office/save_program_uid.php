<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

$response = array(); 
$response['error'] = false; 
$response['message']=$device_pc_added;// Application UUID authorizations 
$query=$db->getquery("select cod_pc from devices_pc where pc_id='".$data['pid']."'");
if($query[0][0]==''): // results not found
	$user= $db->getquery("select cod_user from users where cod_nfc='".$data['id']."'");
	$db->setquery("insert into devices_pc set pc_id='".$data['pid']."', cod_user='".$user[0][0]."'");
endif;
?>