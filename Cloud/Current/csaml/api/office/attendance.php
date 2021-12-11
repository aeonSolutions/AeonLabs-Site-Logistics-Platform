<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

$date=date("Y-m-01", strtotime($data['startdate']));
$endDate=date("Y-m-t", strtotime($data['startdate']));

$qempresa= $data['company']=="all" ? "" : " and worker.cod_entreprise='".$data['company']."'";
$orderEmpresa= $data['company']=="all" ? " worker.cod_entreprise asc," : "";

if(strpos($data['site'],"-")===false):
	$qsite=$data['site']=="all" ? "" : " and record.cod_site='".$data['site']."'";
	$qsection="";
else:
	$items=explode(",",$data['site']);
	$qsite=" and (";
	$counter2=0;
	foreach( $items as $siteSection):
		$subItems=explode("-",$siteSection);

		$qsite.= $counter2==0 ? "record.cod_site='".$subItems[0]."'" : " or record.cod_site='".$subItems[0]."'";
		$qsection= $subItems[1]=="all" ? "" : " and record.cod_section='".$subItems[1]."'";
		$counter2++;
	endforeach;
	$qsite.=")";
	$qsection= $counter2>1 ? "" : $qsection;
endif;

$query = "select worker.cod_worker, worker.name, worker.contact, worker.cod_nfc, COALESCE(NULLIF(record.cod_category,''), worker.cod_category) , worker.cod_entreprise, record.cod_site, worker.contact112, record.cod_section, worker.photo, categories.reference from record left join worker on worker.cod_worker=record.cod_worker left join categories on record.cod_category=categories.cod_category where (record.date between '".$date."' and '".$endDate."') ".$qsite.$qempresa.$qsection." group by record.cod_site, record.cod_section, worker.cod_worker order by record.cod_site asc, record.cod_section asc, ".$orderEmpresa." COALESCE(NULLIF(record.cod_category,''), worker.cod_category)  asc";

$query=$db->getquery($query);

if($query[0][0]<>''):
	$response['error'] = false; 
	$response['message'] = $checkCredentials_welcome;

	for($i=0;$i<count($query);$i++):	
		$response['workers'][$i]['code']=$query[$i][0];
		$response['workers'][$i]['name']=encodeString($query[$i][1]);
		$response['workers'][$i]['contact']=$query[$i][2];
		$response['workers'][$i]['nfc']=$query[$i][3];
		$response['workers'][$i]['company']=$query[$i][5];
		$response['workers'][$i]['cat']=$query[$i][4];
		$response['workers'][$i]['site']=$query[$i][6];
		$response['workers'][$i]['112']=$query[$i][7];
		$response['workers'][$i]['section']=$query[$i][8];
		$response['workers'][$i]['photo']=$query[$i][9];
		$response['workers'][$i]['ref']=$query[$i][10];
		
		$query2=$db->getquery("select cod_ausencia, inicio, fim from worker_ausencia where cod_worker='".$query[$i][0]."' and inicio>='".$data['startdate']."'");
		if($query2[0][0]<>''):
			for($j=0;$j<count($query2);$j++):
				$response['workers'][$i]['absense'][$j]['start']=$query2[$j][1];
				$response['workers'][$i]['absense'][$j]['end']=$query2[$j][2];
			endfor;
		endif;

		$query2=$db->getquery("select record.cod_record, record.checkin, record.checkout, record.date, record.status, record.absense, record.notas, record.validation_reason, record.tasks, COALESCE(NULLIF(record.cod_category,''), worker.cod_category), record.cod_site, record.cod_section from record left join worker on record.cod_worker=worker.cod_worker where (record.date BETWEEN '".$data['startdate']."' AND '".$data['enddate']."') and record.cod_worker='".$query[$i][0]."'");

		if($query2[0][0]<>''):
			for($j=0;$j<count($query2);$j++):
					$response['workers'][$i]['record'][$j]['checkin']=$query2[$j][1];
					$response['workers'][$i]['record'][$j]['checkout']=$query2[$j][2];
					$response['workers'][$i]['record'][$j]['date']=$query2[$j][3];
					$response['workers'][$i]['record'][$j]['status']=$query2[$j][4];
					$response['workers'][$i]['record'][$j]['absense']=$query2[$j][5];
					$response['workers'][$i]['record'][$j]['notas']=encodeString($query2[$j][6]);
					$response['workers'][$i]['record'][$j]['reason']=encodeString($query2[$j][7]);
					$response['workers'][$i]['record'][$j]['assignments']=$query2[$j][8];
					$response['workers'][$i]['record'][$j]['category']=$query2[$j][9];
					$response['workers'][$i]['record'][$j]['site']=$query2[$j][10];
					$response['workers'][$i]['record'][$j]['section']=$query2[$j][11];
					$response['workers'][$i]['record'][$j]['record']=$query2[$j][0];
			endfor;
		endif;
		
		$query3=$db->getquery("select cod_chef_equipe, date from site_chef_equipe where (date BETWEEN '".$data['startdate']."' AND '".$data['enddate']."') and cod_worker='".$query[$i][0]."' and cod_site='".$query[$i][6]."' and cod_section='".$query[$i][8]."'");
		if($query3[0][0]<>''):
			for($j=0;$j<count($query3);$j++):
				$response['workers'][$i]['foreman'][$j]['date']=$query3[$j][1];
			endfor;
		endif;

	endfor;

	$query2=$db->getquery("select cod_closure, start, end from site_closure where cod_site='".$query[$i][6]."' and start>='".$data['startdate']."'");
	if($query2[0][0]<>''):
		for($j=0;$j<count($query2);$j++):
			$response['closure'][$j]['start']=$query2[$j][1];
			$response['closure'][$j]['end']=$query2[$j][2];
		endfor;
	endif;

	$query=$db->getquery("select date from holidays where (date BETWEEN '".$data['startdate']."' AND '".$data['enddate']."')");
	if($query[0][0]<>''):
		for($i=0;$i<count($query);$i++):
			$response['holidays'][$i]['date']=$query[$i][0];
		endfor;
	endif;
else:
	$response['error'] = true; 
	$response['message'] = $workers_no_workers_on_site;
endif;	

?>