<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();
$db->setquery("update settings set disable_checkin='".$data['checkin']."', disable_checkout='".$data['checkout']."', work_hours='".$data['hours']."', max_days_delay_validation='".$data['maxdelay']."'");

$response['error'] = false; 
$response['message'] = $checkCredentials_welcome;
?>