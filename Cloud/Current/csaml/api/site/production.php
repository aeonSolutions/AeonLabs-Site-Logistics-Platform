<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

if($data['type']=="add"):

	CheckJsonParams($data, $iv,$secretKey, array('users','codcat','qtd','activity'));
	$response['error'] = false; 
	$response['message'] =$production_success_add_qtd;
	$date=$data['date'];
	if($data['codcat']<>"null" and isset($data['nota'])):
		$workers=$db->getquery("select DISTINCT teams.cod_worker from teams left join record on teams.cod_worker=record.cod_worker where teams.cod_site='".$data['site']."' and teams.cod_section='".$data['section']."' and record.date='".$date."' and teams.cod_category='".$data['codcat']."' and (record.status='' or record.status='P')");
		for($k=0; $k<count($workers); $k++):
			$work.= ($k==0 ? $workers[$k][0] : ",".$workers[$k][0]);
		endfor;
		$db->setquery("insert into site_qtd_jour set log_time='".date('G:i', time())."', cod_site='".$data['site']."', cod_section='".$data['section']."', date='".$date."', workers='".$work."', notas='".encodeString16($data['nota'])."', cod_task='".$data['activity']."', qtd='".$data['qtd']."'");
	elseif($data['users']<>"null" and isset($data['nota'])):
		$db->setquery("insert into site_qtd_jour set log_time='".date('G:i', time())."', cod_site='".$data['site']."', cod_section='".$data['section']."', date='".$date."', workers='".$data['users']."', notas='".encodeString16($data['nota'])."', cod_task='".$data['activity']."', qtd='".$data['qtd']."'");				
	else:
		$response['error'] = true; 
		$response['message'] ='invalid request ';				
	endif;
elseif($data['type']=="edit"):
	CheckJsonParams($data,$iv,$secretKey, array('nota','qtd','cod'));
	$response['error'] = false; 
	$response['message'] ='quantidade editada com sucesso';
	$db->setquery("update site_qtd_jour set notas='".encodeString16($data['nota'])."', qtd='".$data['qtd']."' where cod_qtd='".$data['cod']."'");				
elseif($data['type']="list"):
	if(isset($data['cod'])):
		 $query=$db->getquery("select site_qtd_jour.qtd, bordereau.units, site_qtd_jour.notas, site_qtd_jour.date from site_qtd_jour left join bordereau on site_qtd_jour.cod_task=bordereau.cod_task where site_qtd_jour.cod_qtd='".$data['cod']."'");
		if($query[0][0]<>''):
			$response['data']['qtd']=$query[0][0];
			$response['data']['data']=$query[0][3];
			$response['data']['units']=$query[0][1];
			$response['data']['nota']=encodeString($query[0][2]);
		else:
			$response['error'] = true; 
			$response['message'] =$production_qtd_not_found;				
		endif;
	else:
		$m = date('Y-m-d',strtotime(endCycle(date('Y-m-d',strtotime($data['date'])), 0)));
		$end=date('Y-m',strtotime($m)).'-'.cal_days_in_month(CAL_GREGORIAN, date('m',strtotime($m)), date('Y',strtotime($m)));
		$start=date('Y-m',strtotime($m)).'-01';
		$qtd[$j]=0;

		$query=$db->getquery("select site_qtd_jour.qtd, bordereau.descricao, bordereau.units, site_qtd_jour.workers, site_qtd_jour.cod_qtd, site_qtd_jour.date from site_qtd_jour left join bordereau on site_qtd_jour.cod_task=bordereau.cod_task where site_qtd_jour.cod_site='".$data['site']."' and site_qtd_jour.cod_section='".$data['section']."'");
		if($query[0][0]<>''): // results found
			$response['error'] = false; 
			$response['message'] ='Bem vindo';
			$pos=0;
			for($i = 0; $i < count($query); $i++):
				$arr=explode(",",$query[$i][3]);
				$string="";
				for($k=0;$k<count($arr);$k++):
					$string.= ($k==0) ? "cod_worker='".$arr[$k]."'" : "or cod_worker='".$arr[$k]."' ";
				endfor;
				$workers=$db->getquery("select name from worker where ".$string);
				$string="";
				for($k=0; $k<count($workers); $k++):
					$exploded=explode(" ",$workers[$k][0]);
					if(isset($exploded[1])):
						$name=$exploded[0]." ".$exploded[count($exploded)-1];
					else:
						$name=$exploded[0];
					endif;
					$string.= ($k==(count($workers)-1)) ? $name : $name.", ";
				endfor;
				$response['data'][$pos]['code']=$query[$i][4];
				$response['data'][$pos]['date']=$query[$i][5];
				$response['data'][$pos]['activity']=encodeString($query[$i][1]);
				$response['data'][$pos]['workers']=encodeString($string);
				$response['data'][$pos]['qtd']=encodeString($query[$i][0]." ".$query[$i][2]);
				$response['data'][$pos]['units']=$query[$i][2];
				$pos++;
			endfor;
		else:
			$response['error'] = true; 
			$response['message'] =$production_list_qtd_not_found;
		endif;
	endif;
else:
	$response['error'] = true; 
	$response['message'] ='invalid request';				
endif;
?>