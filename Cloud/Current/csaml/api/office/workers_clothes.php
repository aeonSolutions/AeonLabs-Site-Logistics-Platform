<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

$response = array();
$response['error'] = false; 
$response['message'] = 'DB request OK';

if($data['type']=='del'):
	CheckJsonParams($data,$iv,$secretKey,array('cod'));
	$query=$db->setquery("delete from worker_clothes where cod_clothes='".$data['cod']."'");
elseif($data['type']=='add'):
	CheckJsonParams($data,$iv,$secretKey,array('worker','date','nota','vest'));
	$nota = ($data['nota']=="null") ? "" : $data['nota'];
	$query=$db->setquery("insert into worker_clothes set cod_worker='".$data['worker']."', data='".$data['date']."', request_date='".$data['date']."', delivered='1', clothes='".$data['vest']."', note='".$nota."'");
elseif($data['type']=='edit'):
	CheckJsonParams($data,$iv,$secretKey,array('cod','date','vest','nota'));
	$nota = ($data['nota']=="null") ? "" : $data['nota'];
	$query=$db->setquery("update worker_clothes set data='".$data['date']."', clothes='".$data['vest']."', note='".$nota."' where cod_clothes='".$data['cod']."'");
elseif($data['type']=='load'):
	if(isset($data['site'])):
		if($data['site']=='all'):		
			$query=$db->getquery("select worker.name, worker_clothes.data, worker_clothes.clothes, worker_clothes.note, worker_clothes.request_date, worker_clothes.delivered from worker_clothes left join worker on worker.cod_worker=worker_clothes.cod_worker where worker_clothes.data between '".$data['sdate']."' and '".$data['edate']."' order by worker_clothes.delivered ASC, worker.name ASC");
			$response['error'] = false; 
			$response['message'] = $checkCredentials_welcome;
		elseif($data['site']<>'all'):
			$response['error'] = false; 
			$response['message'] = $checkCredentials_welcome;		
			$section= $data['section']=='all' ? "":" and teams.cod_section='".$data['section']."'";
			$query=$db->getquery("select worker.name, worker_clothes.data, worker_clothes.clothes, worker_clothes.note, worker_clothes.request_date, worker_clothes.delivered from worker_clothes left join teams on teams.cod_worker=worker_clothes.cod_worker left join worker on worker.cod_worker=worker_clothes.cod_worker where (worker_clothes.data between '".$data['sdate']."' and '".$data['edate']."') and teams.cod_site='".$data['site']."'".$section." and (teams.date between '".date("Y-m-01", strtotime($data['sdate']))."' and '".date("Y-m-01", strtotime($data['edate']))."') order by worker.name ASC");
		endif;
		for($i=0;$i<count($query);$i++):
			$response['clothes'][$i]['name']=$query[$i][0];
			$response['clothes'][$i]['date']=$query[$i][1];
			$response['clothes'][$i]['clothes']=$query[$i][2];
			$response['clothes'][$i]['note']=$query[$i][3];
			$response['clothes'][$i]['requestdate']=$query[$i][4];
			$response['clothes'][$i]['delivered']=$query[$i][5];
		endfor;
	elseif(isset($data['worker'])):
			$response['error'] = false; 
			$response['message'] = $checkCredentials_welcome;
			$worker= $data['worker']=="all" ? "" : "and worker_clothes.cod_worker='".$data['worker']."'";
			$query=$db->getquery("select worker.name, worker_clothes.data, worker_clothes.clothes, worker_clothes.note, worker_clothes.request_date, worker_clothes.delivered from worker_clothes left join worker on worker.cod_worker=worker_clothes.cod_worker where (worker_clothes.data between '".$data['sdate']."' and '".$data['edate']."') ".$worker." order by worker_clothes.delivered ASC, worker.name ASC");

			$response['error'] = false; 
			$response['message'] = $checkCredentials_welcome;
			for($i=0;$i<count($query);$i++):
				$response['clothes'][$i]['name']=$query[$i][0];
				$response['clothes'][$i]['date']=$query[$i][1];
				$response['clothes'][$i]['clothes']=$query[$i][2];
				$response['clothes'][$i]['note']=$query[$i][3];
			endfor;
	else:
		$response['error'] = false; 
		$response['message'] = $invalid_request;
	endif;
else:
	$response['error'] = false; 
	$response['message'] = $invalid_request;
endif;
?>