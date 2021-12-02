<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

$response = array();
if($data['type']=='del'):
	CheckJsonParams($data,$iv,$secretKey,array('cod'));
	$query=$db->setquery("delete from site_closure where cod_closure='".$data['cod']."'");
elseif($data['type']=='add'):
	CheckJsonParams($data,$iv,$secretKey,array('site','inicio','fim','motivo'));
	$motivo = ($data['motivo']=="null") ? "" : $data['motivo'];
	$query=$db->setquery("insert into site_closure set cod_site='".$data['site']."', start='".$data['inicio']."', end='".$data['fim']."', motivo='".$motivo."'");
elseif($data['type']=='edit'):
	CheckJsonParams($data,$iv,$secretKey,array('cod','inicio','fim','motivo'));
	$motivo = ($data['motivo']=="null") ? "" : $data['motivo'];
	$query=$db->setquery("update site_closure set start='".$data['inicio']."', end='".$data['fim']."', motivo='".$motivo."' where cod_closure='".$data['cod']."'");
endif;

$response['error'] = false; 
$response['message'] = 'DB request OK';
?>