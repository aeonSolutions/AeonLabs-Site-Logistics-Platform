<?php
require("initializer.php"); // always first before all
require("api_specific_functions.php");

$response['error'] = true; 
$response['message'] = 'report submitted';
CheckGet(array('uuid','report'));
$response=[];

$db->connect(true);
$query=$db->getquery("select cod_nfc from crash_report where report='".$_GET['report']."'");
if ($query[0][0]==""):
	$db->setquery("insert into crash_report set cod_nfc='".$_GET['sn']."', report='".$_GET['report']."', date='".date('Y-m-d', time())."' , time='".date('H:i:s', time())."'");
	$response['error'] = false; 
	$response['message'] = 'success';
else:
	$response['error'] = false; 
	$response['message'] = 'already logged';
endif;

$db->connect(false);
$response['error'] = false; 
$response['message'] = 'success';

//displaying the response in json structure 
echo safe_json_encode($response,0,512,false);
?>