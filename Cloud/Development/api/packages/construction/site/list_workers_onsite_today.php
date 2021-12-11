<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;


$date= (isset($data['date'])) ? $data['date'] : date('Y-m-d', time());
$query=$db->getquery("select worker.cod_worker, record.checkin, record.checkout, worker.name, worker.photo from record left join worker on record.cod_worker=worker.cod_worker where record.cod_site='".$data['site']."' and record.cod_section='".$data['section']."' and date='".$date."' and (record.checkin<>'00:00:00' or record.status='P') group by worker.cod_worker");
if($query[0][0]<>''):
	$response['error'] = false; 
	$response['message'] ='Bem vindo';
	for($i = 0; $i < count($query); $i++):
		$exploded=explode(" ",$query[$i][3]);
		if(isset($exploded[1])):
			$name=$exploded[0]." ".$exploded[count($exploded)-1];
		else:
			$name=$exploded[0];
		endif;

		$response['data'][$i]['coduser']=$query[$i][0];
		$response['data'][$i]['name']=encodeString($name);
		$response['data'][$i]['checkin']=($query[$i][1]=="" or $query[$i][1]=="00:00:00") ? $attendance_without_checkout: $attendance_with_checkout;
		$response['data'][$i]['checkout']=($query[$i][2]=="" or $query[$i][2]=="00:00:00") ? $attendance_without_checkout: $attendance_with_checkout;
				
		if($query[$i][4]<>''):
			$response['data'][$i]['imgURL']=$query[$i][4];
		else:
			$response['data'][$i]['imgURL']="";
		endif;
	endfor;
	$response['error'] = false; 
	$response['message'] = 'Bem vindo';
else:
	$response['error'] = true; 
	$response['message'] = $list_workers_onsite_today_no_records_found;
endif;
?>