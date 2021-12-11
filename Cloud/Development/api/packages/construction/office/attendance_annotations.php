<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

$query=$db->getquery("select cod_record from record where cod_worker='".$data['worker']."'and date='".$data['date']."' and cod_site='".$data['site']."' and cod_section='".$data['section']."'");

if($query[0][0]<>""): // edit
	$db->setquery("update record set notas='".$data['note']."' where cod_worker='".$data['worker']."'and date='".$data['date']."' and cod_site='".$data['site']."' and cod_section='".$data['section']."'");

	$response['error'] = false; 
	$response['message'] = $attendance_add_success;
else:
	$db->setquery("insert into record set cod_worker='".$data['worker']."', date='".$data['date']."', cod_site='".$data['site']."', notas='".$data['note']."', cod_section='".$data['section']."'");
	$response['error'] = false; 
	$response['message'] = $attendance_add_success;
endif;
?>