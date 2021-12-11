<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();
if($data['type']=="new"):
	CheckJsonParams($data,$iv,$secretKey,array('id', 'active','pin','mobile','serial','puk','email'));
	$db->setquery("insert into tablets set pin ='".$data['pin']."', mobile='".$data['mobile']."', serial='".$data['serial']."', tablet_id='".$data['id']."', puk='".$data['puk']."', active='".$data['active']."', email='".$data['email']."'");
	$response['error'] = false; 
	$response['message'] = $regie_add_success;
elseif($data['type']=="edit"):
	CheckJsonParams($data,$iv,$secretKey,array('id', 'active','cod','pin','mobile','serial','puk','email'));
	$db->setquery("update tablets set pin ='".$data['pin']."', mobile='".$data['mobile']."', serial='".$data['serial']."', tablet_id='".$data['id']."', puk='".$data['puk']."', active='".$data['active']."', email='".$data['email']."' where cod_tablet='".$data['cod']."'");

	$response['error'] = false; 
	$response['message'] = $regie_edit_success;
elseif($data['type']=="del"):
	CheckJsonParams($data,$iv,$secretKey,array('cod'));
	$db->setquery("delete from tablets where cod_tablet='".$data['cod']."'");
	$response['error'] = false; 
	$response['message'] = $regie_del_success;
else:
	$response['error'] = true; 
	$response['message'] = $invalid_request;
endif;	
?>