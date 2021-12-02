<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$temp=$secretKey;
$response = array(); 
if(is_file("config/office.key.php")):
	include("config/office.key.php");
	$response['error'] = false; 
	$response['message'] = "";
	$response['key']=$secretKey;
else:
	$response['error'] = true; 
	$response['message'] = $secretKey_not_found;
endif;
$secretKey=$temp;
?>