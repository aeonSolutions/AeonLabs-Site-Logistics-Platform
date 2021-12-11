<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();
$filename=$server['root']['path']."api/config/addons.php";
if(is_file($filename)):
	include($filename);
	for($i=0;$i<count($addons);$i++):
		$response['addons'][$i]['type']=$addons[$i]['type'];
		$response['addons'][$i]['url']=$addons[$i]['url'];
		$response['addons'][$i]['name']=$addons[$i]['name'];
		$response['addons'][$i]['key']=$addons[$i]['apikey'];
	endfor;
	$response['error'] = false; 
	$response['message'] = $addons_found;
else:
	$response['error'] = true; 
	$response['message'] = $addons_not_found;
endif;
?>