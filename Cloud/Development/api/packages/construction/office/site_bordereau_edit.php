<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['request']=='add' or $data['request']=='edit'):
	CheckJsonParams($data,$iv,$secretKey,array('qtd','ref','description','units','price', 'tasktype', 'previoustask'));
	$taskOnPrevious=$db->getquery("select cod_task, avenant, previous_task from bordereau where cod_task='".$data['previoustask']."'");

	$taskOnNext=$db->getquery("select cod_task, avenant, previous_task from bordereau where previous_task='".$data['previoustask']."'");

	if($data['request']=='add'):
		$query="insert into bordereau set qtd='".$data['qtd']."', pu='".$data['price']."', contractor_ref='".$data['ref']."', descricao='".$data['description']."', units='".$data['units']."', translations='".$data['translations']."', enabled='".$data['tasktype']."', previous_task='".$data['previoustask']."', cod_site='".$data['site']."', cod_section='".$data['section']."', avenant='".$taskOnPrevious[0][1]."'";
	else:
		CheckJsonParams($data,$iv,$secretKey,array('cod'));
		$query="update bordereau set qtd='".$data['qtd']."', pu='".$data['price']."', contractor_ref='".$data['ref']."', descricao='".$data['description']."', units='".$data['units']."', translations='".$data['translations']."', enabled='".$data['tasktype']."', previous_task='".$data['previoustask']."', avenant='".$taskOnPrevious[0][1]."' where cod_task='".$data['cod']."'";		
	endif;
	$db->setquery($query);
	$codTask= $db->getquery("select last_insert_id()");
	if($taskOnNext[0][0]<>''):
		$db->setquery("update bordereau set previous_task='".$codTask[0][0]."' where cod_task='".$taskOnNext[0][0]."'");
	endif;

	$response['error'] = false; 
	$response['message'] = $regie_add_success;
elseif($data['request']=="del"):
	CheckJsonParams($data,$iv,$secretKey,array('cod'));
	$hasRecords=$db->getquery("select cod_qtd from site_qtd_jour where cod_task='".$data['cod']."'");
	if($hasRecords[0][0]<>""):
		$response['error'] = true; 
		$response['message'] = $bordereau_has_production_records;
	else:
		$db->setquery("delete from bordereau where cod_task='".$data['cod']."'");
		$response['error'] = false; 
		$response['message'] = $regie_del_success;
	endif;
else:
	$response['error'] = true; 
	$response['message'] = 'Invalid task request:';
endif;
?>