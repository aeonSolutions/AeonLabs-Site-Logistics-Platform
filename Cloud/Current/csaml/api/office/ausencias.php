<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['type']=='del'):
	CheckJsonParams($data,$iv,$secretKey, array('cod'));
	$query=$db->setquery("delete from worker_ausencia where cod_ausencia='".$data['cod']."'");
elseif($data['type']=='add'):
	CheckJsonParams($data,$iv,$secretKey, array('worker','inicio','fim','tipo','viagem','motivo'));
	$motivo = ($data['motivo']=="null") ? "" : $data['motivo'];
	$query=$db->setquery("insert into worker_ausencia set cod_worker='".$data['worker']."', inicio='".$data['inicio']."', fim='".$data['fim']."', tipo='".$data['tipo']."', viagem='".$data['viagem']."', motivo='".$motivo."'");
elseif($data['type']=='edit'):
	CheckJsonParams($data,$iv,$secretKey, array('cod','inicio','fim','tipo','viagem','motivo'));
	$motivo = ($data['motivo']=="null") ? "" : $data['motivo'];
	$query=$db->setquery("update worker_ausencia set inicio='".$data['inicio']."', fim='".$data['fim']."', tipo='".$data['tipo']."', viagem='".$data['viagem']."', motivo='".$motivo."' where cod_ausencia='".$data['cod']."'");
endif;

$response['error'] = false; 
$response['message'] = $checkCredentials_welcome;

?>