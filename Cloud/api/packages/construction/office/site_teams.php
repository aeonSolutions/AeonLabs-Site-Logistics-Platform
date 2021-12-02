<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if ($data['type']=='del'):
	CheckJsonParams($data,$iv,$secretKey,array('site','worker','date','section'));
	$query=$db->getquery("select cod_worker from record where cod_site ='".$data['site']."' and (date between '".date('Y-m',strtotime($data['date']))."-01' and '".date('Y-m-t',strtotime($data['date']))."') and cod_section='".$data['section']."' and cod_worker='".$data['worker']."' and (checkin<>'00:00:00' or checkout<>'00:00:00' or (status<>'EP' and status<>'MO' and status<>''))");
	if ($query[0][0]<>''):
		$response['error'] = true; 
		$response['message'] = $unable_to_del_records_present;
	else:
		$db->setquery("delete from record where cod_site ='".$data['site']."' and (date between '".date('Y-m',strtotime($data['date']))."-01' and '".date('Y-m-t',strtotime($data['date']))."')  and cod_section='".$data['section']."' and (checkin='00:00:00' or checkin='') and (checkout='00:00:00' or checkout='') and (status='EP' or status='MO' or status='') and cod_worker='".$data['worker']."'");
		$response['error'] = false; 
		$response['message'] = $regie_del_success;
	endif;
elseif($data['type']=='add'):
	CheckJsonParams($data,$iv,$secretKey,array('site','worker','date','codcat','section'));
	$response=[];

	$isForeman=$db->getquery("select reference from worker_categories where cod_category='".$data['codcat']."'");	
	
	//to be deleted
	$db->setquery("insert into teams set cod_site ='".$data['site']."', cod_category ='".$data['codcat']."', cod_worker='".$data['worker']."', date='".$data['date']."', cod_section='".$data['section']."'");
	//end
	
	$numDays=date("t", strtotime($data['date']));
	$iniDate=date("Y-m-", strtotime($data['date']));
	if ((date('m',strtotime($data['date'] )) == date('m')) and (date('Y',strtotime($data['date'] )) == date('Y'))):
		$pos=date('d');
	else:
		$pos=1;
	endif;

	for($i=$pos; $i<=$numDays;$i++):		
		$date= $i<10 ? $iniDate."0".$i : $iniDate.$i;
		if(!isWeekend($date)):
			$exists=$db->getquery("select cod_record from record where cod_site ='".$data['site']."' and cod_worker='".$data['worker']."' and date='".$date."' and cod_section='".$data['section']."'");
			if($exists[0][0]<>''):
			
			else:
				$db->setquery("insert into record set cod_site ='".$data['site']."', cod_worker='".$data['worker']."', date='".$date."', cod_section='".$data['section']."', status='EP'");
			endif;
			if($isForeman[0][0]=='frm' or $isForeman[0][0]=='gfrm'):
				$existsChef=$db->getquery("select cod_chef_equipe from site_chef_equipe where cod_site ='".$data['site']."' and cod_worker='".$data['worker']."' and date='".$date."' and cod_section='".$data['section']."' ");
				if($existsChef[0][0]<>''):

				else:
					$db->setquery("insert into site_chef_equipe set cod_site ='".$data['site']."', cod_worker='".$data['worker']."', date='".$date."', cod_section='".$data['section']."' ");
				endif;
			endif;
		endif;
	endfor;
	$response['error'] = false; 
	$response['message'] = $regie_add_success;
elseif($data['type']=='copy'):
	CheckJsonParams($data,$iv,$secretKey,array('site','date','section'));
		
	//check if theres already records
	$query=$db->getquery("select cod_worker from record where cod_site ='".$data['site']."' and (date between '".date('Y-m',strtotime($data['date']))."-01' and '".date('Y-m-t',strtotime($data['date']))."') and cod_section='".$data['section']."' and (checkin<>'00:00:00' or checkout<>'00:00:00' or (status<>'EP' and status<>'MO' and status<>''))");		
	if ($query[0][0]<>''):
		$response['error'] = true; 
		$response['message'] = $unable_to_del_records_present;
	else:
		$lastMonth = date('Y-m-d', strtotime('-1 months', strtotime($data['date']))); 
		$query=$db->getquery("select record.cod_worker, worker_categories.reference from record left join worker on record.cod_worker=worker.cod_worker left join worker_categories on COALESCE(NULLIF(record.cod_category,''), worker.cod_category)=worker_categories.cod_category where record.cod_site ='".$data['site']."' and (record.date between '".date('Y-m',strtotime($lastMonth ))."-01' and '".date('Y-m-t',strtotime($lastMonth))."') and record.cod_section='".$data['section']."' and (record.checkin<>'00:00:00' or record.checkout<>'00:00:00' or (record.status<>'EP' and record.status<>'MO' and record.status<>''))");
		
		if ($query[0][0]<>''):
			$numDays=date("t", strtotime($data['date']));
			$iniDate=date("Y-m-", strtotime($data['date']));
			for($j=0;$j<count($query);$j++):
				for($i=1; $i<=$numDays;$i++):		
					$date= $i<10 ? $iniDate."0".$i : $iniDate.$i;
					if(!isWeekend($date)):
						$exists=$db->getquery("select cod_record from record where cod_site ='".$data['site']."' and cod_worker='".$query[$j][0]."' and date='".$date."' and cod_section='".$data['section']."'");
						if($exists[0][0]<>''):

						else:
							$db->setquery("insert into record set cod_site='".$data['site']."', cod_worker='".$query[$j][0]."', date='".$date."', cod_section='".$data['section']."', status='EP'");
						endif;
						if($query[$j][1]=='frm' or $query[$j][1]=='gfrm'):
							$existsChef=$db->getquery("select cod_chef_equipe from site_chef_equipe where cod_site ='".$data['site']."' and cod_worker='".$query[$j][0]."' and date='".$date."' and cod_section='".$data['section']."' ");
							if($existsChef[0][0]<>''):

							else:
								$db->setquery("insert into site_chef_equipe set cod_site ='".$data['site']."', cod_worker='".$query[$j][0]."', date='".$date."', cod_section='".$data['section']."' ");
							endif;
						endif;
					endif;
				endfor;
			endfor;
			$response['error'] = false; 
			$response['message'] = $regie_add_success;
		else:
			$response['error'] = true; 
			$response['message'] = $workers_no_workers_on_site;
		endif;
	endif;
endif;

?>