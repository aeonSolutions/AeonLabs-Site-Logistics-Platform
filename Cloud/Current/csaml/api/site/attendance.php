<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

$query2=$db->getquery("select cod_worker,cod_category, name from worker where cod_nfc='".$data['worker']."'");
if($query2[0][0]<>''):
	$exploded=explode(" ",$query2[0][2]);
	if(isset($exploded[1])):
		$name=$exploded[0]." ".$exploded[count($exploded)-1];
	else:
		$name=$exploded[0];
	endif;
	$response['error'] = false; 
	$response['message'] ='Registo efetuado';		
	$response['data']['name']=encodeString($name);

	$query3=$db->getquery("select cod_worker from teams where cod_worker='".$query2[0][0]."' and cod_site='".$data['site']."' and cod_section='".$data['section']."' and date='".date("Y-m")."-01'");
	if($query3[0][0]<>$query2[0][0]):// trabalhador nao esta na equipa desta obra-> adicionar
		$db->setquery("insert into teams set cod_worker='".$query2[0][0]."', cod_site='".$data['site']."', cod_section='".$data['section']."', date='".date("Y-m")."-01', cod_category='".$query2[0][1]."'");
	endif;

	$query3=$db->getquery("select cod_worker, checkin, checkout from record where date='".date('Y-m-d', time())."' and cod_worker='".$query2[0][0]."' and cod_site='".$data['site']."' and cod_section='".$data['section']."'");
	if($query3[0][0]<>''): //existe registo
		if($query3[0][1]<>'00:00:00'): // ja tem checkin esta a fazer o checkout
			$db->setquery("update record set checkout='".date('G:i', time())."', type=CONCAT(type, '-".$data['logtype']."'), media_format=CONCAT(media_format, '-".$data['logformat']."') where cod_site='".$data['site']."' and cod_section='".$data['section']."' and cod_worker='".$query2[0][0]."'and date='".date('Y-m-d', time())."'");
			$response['data']['checkin']=$query3[0][1];
			$response['data']['checkout']=date('G:i', time());
		else: // primeira vez do dia
			$db->setquery("update record set checkin='".date('G:i', time())."', type=CONCAT(type, '-".$data['logtype']."'), media_format=CONCAT(media_format, '-".$data['logformat']."') where cod_site='".$data['site']."' and cod_section='".$data['section']."' and cod_worker='".$query2[0][0]."'and date='".date('Y-m-d', time())."'");
			$response['data']['checkin']=date('G:i', time());
			$response['data']['checkout']=$attendance_without_checkout;
		endif;
	else: // nao existe registo
		$db->setquery("insert into record set checkin='".date('G:i', time())."', cod_site='".$data['site']."', cod_section='".$data['section']."',  cod_worker='".$query2[0][0]."', date='".date('Y-m-d', time())."', type=CONCAT(type, '-".$data['logtype']."'), media_format=CONCAT(media_format, '-".$data['logformat']."')");
		$response['data']['checkin']=date('G:i', time());
		$response['data']['checkout']=$attendance_without_checkout;
	endif;
else:
	$response['error'] = true; 
	 $response['message'] = $attendance_worker_not_found;			
endif;

?>