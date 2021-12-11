<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();
$response['error'] = false; 
$response['message'] = 'DB request OK';

if($data['type']=='del'):
	CheckJsonParams($data,$iv,$secretKey,array('cod'));
	$query=$db->setquery("delete from worker_ausencia where cod_ausencia='".$data['cod']."'");
elseif($data['type']=='add'):
	CheckJsonParams($data,$iv,$secretKey,array('worker','inicio','fim','tipo','viagem','motivo'));
	$motivo = ($data['motivo']=="null") ? "" : $data['motivo'];
	$query=$db->setquery("insert into worker_ausencia set cod_worker='".$data['worker']."', inicio='".$data['inicio']."', fim='".$data['fim']."', tipo='".$data['tipo']."', viagem='".$data['viagem']."', motivo='".$motivo."'");
elseif($data['type']=='edit'):
	CheckJsonParams($data,$iv,$secretKey,array('cod','inicio','fim','tipo','viagem','motivo'));
	$motivo = ($data['motivo']=="null") ? "" : $data['motivo'];
	$query=$db->setquery("update worker_ausencia set inicio='".$data['inicio']."', fim='".$data['fim']."', tipo='".$data['tipo']."', viagem='".$data['viagem']."', motivo='".$motivo."' where cod_ausencia='".$data['cod']."'");
elseif($data['type']=='load'):
	if($data['site']=='all'):
		$query=$db->getquery("select worker.name, worker_ausencia.inicio, worker_ausencia.fim, worker_ausencia.tipo, worker_ausencia.viagem, worker_ausencia.motivo from worker_ausencia left join worker on worker.cod_worker=worker_ausencia.cod_worker where worker_ausencia.inicio>='".$data['sdate']."'");
		$response['error'] = false; 
		$response['message'] = $checkCredentials_welcome;
		for($i=0;$i<count($query);$i++):
			$response['absense'][$i]['name']=$query[$i][0];
			$response['absense'][$i]['sdate']=$query[$i][1];
			$response['absense'][$i]['edate']=$query[$i][2];
			$response['absense'][$i]['type']=$query[$i][3];
			$response['absense'][$i]['trip']=$query[$i][4];
			$response['absense'][$i]['motif']=$query[$i][5];
		endfor;
	elseif($data['site']<>'all'):
		$response['error'] = false; 
		$response['message'] = $checkCredentials_welcome;
	
		$section= $data['section']=='all' ? "":" and teams.cod_section='".$data['section']."'";
		$query=$db->getquery("select worker.name, worker_ausencia.inicio, worker_ausencia.fim, worker_ausencia.tipo, worker_ausencia.viagem, worker_ausencia.motivo from worker_ausencia left join teams on teams.cod_worker=worker_ausencia.cod_worker left join worker on worker.cod_worker=worker_ausencia.cod_worker where  worker_ausencia.inicio>='".$data['sdate']."' and teams.cod_site='".$data['site']."'".$section." and teams.date between '".date("Y-m-01", strtotime($data['sdate']))."' and '".date("Y-m-01", strtotime($data['edate']))."'");
		
		for($i=0;$i<count($query);$i++):
			$response['absense'][$i]['name']=$query[$i][0];
			$response['absense'][$i]['sdate']=$query[$i][1];
			$response['absense'][$i]['edate']=$query[$i][2];
			$response['absense'][$i]['type']=$query[$i][3];
			$response['absense'][$i]['trip']=$query[$i][4];
			$response['absense'][$i]['motif']=$query[$i][5];
		endfor;
	endif;
else:
	$response['error'] = false; 
	$response['message'] = $invalid_request;
endif;

?>