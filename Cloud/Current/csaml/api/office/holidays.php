<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

$query=$db->getquery("select date from holidays where date='".$data['date']."'");
if($query[0][0]<>"" and $data['type']=='add'):
	$response['error'] = false; 
	$response['message'] = $holidays_alreaday_exists;
elseif($query[0][0]<>"" and $data['type']=='del'):
	$response['error'] = false; 
	$response['message'] = $holidays_alreaday_del;
elseif($data['type']=='del'):
		$db->setquery("delete from holidays where date ='".$data['date']."'");
		$response['error'] = false; 
		$response['message'] = $holidays_del;
elseif($data['type']=='add'):
		$db->setquery("insert into holidays set date='".$data['date']."'");
		$response['error'] = false; 
		$response['message'] = $holidays_add;
endif;


?>