<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

$query=$db->getquery("select name, contact, contact112, email, photo, cod_nfc from worker where cod_worker='".$data['cod']."'");
$query2=$db->getquery("select site.name, site.address from site left join record on record.cod_site=site.cod_site where record.cod_worker='".$data['cod']."' and record.date='".date('Y-m-d', time())."' and record.status<>'EP' and record.status<>'MO'");
$query3=$db->getquery("select distinct site.name from record left join site on record.cod_site=site.cod_site where record.cod_worker='".$data['cod']."' and record.date between '".date('Y-m-01',time())."' and '".date('Y-m-t',time())."' and record.status<>'' and record.status<>'EP' and record.status<>'MO'");

$response['data'][0]['name']=$query[0][0];
$response['data'][0]['contacto']=$query[0][1];
$response['data'][0]['emergencia']=$query[0][2];
$response['data'][0]['email']=$query[0][3];
$response['data'][0]['cartao']=$query[0][5];
$response['data'][0]['photo']=$query[0][4];
if($query2[0][0]<>''):
	$response['data'][0]['site']=$query2[0][0];
	$response['data'][0]['address']=$query2[0][1];
else:
	$response['data'][0]['site']=$worker_details_not_working_today;
	$response['data'][0]['address']="";
endif;
if($query3[0][0]<>''):
	for($i=0;$i<count($query3);$i++):
		$response['data'][0]['sites'][$i]['name']=$query3[$i][0];
	endfor;
endif;
$response['error'] = false; 
$response['message'] = $checkCredentials_welcome;
?>