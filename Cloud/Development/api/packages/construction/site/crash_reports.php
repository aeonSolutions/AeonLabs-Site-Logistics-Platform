<?php
$response['error'] = true; 
$response['message'] = 'report submitted';
$query=$db->getquery("select cod_nfc from crash_report where report='".$data['report']."'");
if ($query[0][0]==""):
	$db->setquery("insert into crash_report set cod_nfc='".$data['sn']."', report='".$data['report']."', date='".date('Y-m-d', time())."' , time='".date('H:i:s', time())."'");
	$response['error'] = false; 
	$response['message'] = 'success';
else:
	$response['error'] = false; 
	$response['message'] = 'already logged';
endif;
?>