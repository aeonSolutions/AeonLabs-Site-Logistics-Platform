<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

$query=$db->getquery("select gps_lat, gps_lon from site where cod_site='".$data['site']."' and cod_section='".$data['section']."'");
$ch = curl_init();
curl_setopt($ch, CURLOPT_SSL_VERIFYPEER, false);
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
//can change lang here 
curl_setopt($ch, CURLOPT_URL, 'http://api.openweathermap.org/data/2.5/weather?appid=7c18fcf0c019a0859fc974d45f6f9d29&units=metric&lang=pt&lat='.$query[0][0].'&lon='.$query[0][1]);
$result = curl_exec($ch);
curl_close($ch);
if (! $result):
	$response['error'] = true; 
	$response['message'] =$weather_error_log_info;
else:
	$json = json_decode(utf8_encode($result));
	if (empty($json) || json_last_error() !== JSON_ERROR_NONE):
		$response['error'] = true; 
		$response['message'] =$weather_error_log_info;
	else:
		//$obj = json_decode($result);
		//echo $obj->access_token;

		$db->setquery("insert into site_weather set cod_site='".$data['site']."', cod_section='".$data['section']."', weather='".$result."'");
		$response['error'] = true; 
		$response['message'] =$weather_sucess_log_info;
	endif;
endif;
?>