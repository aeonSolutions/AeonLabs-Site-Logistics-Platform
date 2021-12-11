<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['type']=='journal'):
	$date=date("Y-m-01", strtotime($data['date']));
	$query=$db->getquery("select distinct worker.name as worker, categories.namefr as category, entreprise.name as entreprise from record left join worker on record.cod_worker=worker.cod_worker left join teams on teams.cod_worker=record.cod_worker and teams.cod_site='".$data['site']."' and teams.cod_section='".$data['section']."' and teams.date='".$date."' left join categories on teams.cod_category=categories.cod_category left join entreprise on worker.cod_entreprise=entreprise.cod_entreprise where record.cod_site='".$data['site']."' and record.cod_section='".$data['section']."' and record.date='".$data['date']."' order by entreprise.name ASC, categories.cod_category ASC");
	if($query[0][0]<>''):
		$response['error'] = false; 
		$response['message'] = $invalid_request;
		$lastCat="";
		$lastEnt="";
		$posEnt=-1;
		$posCat=-1;
		$totalEnt=0;
		$totalCat=0;
		for($i = 0; $i < count($query); $i++):
			if ($lastEnt<>$query[$i][2]):
				$lastEnt=$query[$i][2];
				$posEnt++;
				$response['data'][$posEnt]['total']=$totalEnt;
				$totalEnt=0;
				$response['data'][$posEnt]['entreprise']=encodeString($query[$i][2]);
				$response['data'][$posEnt]['soustraitant']= (strpos($query[$i][2],"Quality")===false) ? true : false;
			endif;
			if ($lastCat<>$query[$i][1]):
				$lastCat=$query[$i][1];
				$pos= ($posCat==-1) ? 0 : $posCat;
				$response['data'][$posEnt]['category'][$pos]['total']=$totalCat;
				$posCat++;
				$totalCat=0;
				$response['data'][$posEnt]['category'][$posCat]['name']=encodeString($query[$i][1]);
				$response['data'][$posEnt]['category'][$posCat]['workers']="";
			endif;
			$response['data'][$posEnt]['category'][$posCat]['workers'].=encodeString($query[$i][0]."[newline]");
			$totalCat++;
			$totalEnt++;
		endfor;
		$response['data'][$posEnt]['total']=$totalEnt;
		$response['data'][$posEnt]['category'][$posCat]['total']=$totalCat;

	else:
		$response['error'] = true; 
		$response['message'] =$workers_no_workers_on_site;				
	endif;
else:
	$query=$db->getquery("select worker.cod_worker, worker.name, worker.photo, record.checkin, record.checkout, record.status, record.absense, categories.name as cat_name from record left join worker on worker.cod_worker=record.cod_worker left join teams on record.cod_worker=teams.cod_worker left join categories on teams.cod_category=categories.cod_category where record.date='".$data['date']."' and record.cod_site='".$data['site']."'  and record.cod_section='".$data['section']."' and (record.checkin<>'00:00:00' or record.checkout<>'00:00:00') group by worker.cod_worker order by teams.cod_category DESC ");
	if($query[0][0]<>''):
		if($data['type']=='workers'):
			$response['error'] = false; 
			$response['message'] = $invalid_request;
			for($i = 0; $i < count($query); $i++):
				$response['data'][$i]['coduser']=$query[$i][0];
				$response['data'][$i]['name']=encodeString($query[$i][1]);
				$response['data'][$i]['checkin']=$query[$i][3];
				$response['data'][$i]['checkout']=$query[$i][4];
				$response['data'][$i]['imgURL']=$query[$i][2];
				$response['data'][$i]['validacao']=$query[$i][5];
				$response['data'][$i]['faltou']=$query[$i][6];	
			endfor;
		elseif($data['type']=='categories'):
			$response['error'] = false; 
			$response['message'] = $invalid_request;
			$pos=-1;
			$lastCat="";
			for($i = 0; $i < count($query); $i++):
				if ($lastCat<>$query[$i][7]):
					$lastCat=$query[$i][7];
					$pos++;
					$response['data'][$pos]['category']=encodeString($query[$i][7]);
					$response['data'][$pos]['name']="";
				endif;
				$response['data'][$pos]['name'].=encodeString($query[$i][1])."[newline]";
			endfor;	 			
		endif;
	else:
		$response['error'] = true; 
		$response['message'] = $workers_no_workers_on_site;
	endif;
endif;
?>