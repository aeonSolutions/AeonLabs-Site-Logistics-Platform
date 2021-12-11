<?php
$server['root']['path']=substr(__FILE__,0,strpos(__FILE__,"csaml"))."csaml/"; // file system path
if(isset($_GET['task'])):
	switch($_GET['task']):
		case 'office': 
			include_once($server['root']['path']."update/versionOffice.txt");
			$filename="setup.exe";
			$response['version']=$version;
			$response['url']="http://".$_SERVER['HTTP_HOST']."/csaml/update/".$filename;
			$response['changelog']="http://".$_SERVER['HTTP_HOST']."/csaml/update/changesOffice.txt";
			$response['checksum']=md5_file($server['root']['path']."update/".$filename);
			$response['mandatory']=true;
			$response['error'] = false; 
			$response['message'] = 'update request';
			break;
	endswitch;
	$response['error'] = true; 
	$response['message'] = 'invalid get request';
endif;
echo json_encode($response);
?>