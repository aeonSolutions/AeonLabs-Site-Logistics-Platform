<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

$fileName=generateRandomString().'.pdf';
$uploadDir = $server['root']['files']."dailyreports/";

while (is_file($uploadDir. $fileName)):
	$fileName=generateRandomString().'.pdf';
endwhile;

if(move_uploaded_file($_FILES['file']['tmp_name'], $uploadDir.$fileName)):
	$db->connect(true);
	$response=[];
	$query=$db->getquery("select file from site_daily_report where date='".$data['date']."'");
	if($query[0][0]<>""):
		unlink($uploadDir.$query[0][0]);
		$db->setquery("update site_daily_report set activities='".$data['activity']."', ocurrences='".$data['ocurrence']."', file='".$fileName."' where date='".$data['date']."' and cod_site='".$data['site']."' and cod_section='".$data['section']."'");
	else:
		$db->setquery("insert into site_daily_report set activities='".$data['activity']."', ocurrences='".$data['ocurrence']."', file='".$fileName."', date='".$data['date']."', cod_site='".$data['site']."', cod_section='".$data['section']."'");
	endif;
	$response['error'] = false; 
	$response['message'] = $invalid_request;
	$db->connect(false);
else:
	$response['error'] = true; 
	$response['message'] = $journal_error_upload;
endif;

?>