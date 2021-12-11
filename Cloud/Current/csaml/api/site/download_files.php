<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

$queryStr="";
$path="";
if($data['where']=='worker'):
	$queryStr="select photo from worker where cod_worker='".$data['cod']."'";
	$query=$db->getquery($queryStr);				
	$filename = dirname(dirname(dirname(__FILE__)))."/photos/". $query[0][0];
if($data['where']=='project'):
	$queryStr="select file from site_project where cod_project='".$data['cod']."'";
	$query=$db->getquery($queryStr);				
	$filename = dirname(dirname(dirname(__FILE__)))."/files/project/". $query[0][0];
else:
	$response['error'] = true; 
	$response['message'] ='invalid request';
endif;

if($queryStr<>"")
	$query=$db->getquery($queryStr);				
	$filename = $path.$query[0][0];
	if(file_exists($filename)):
		//Get file type and set it as Content Type
		$finfo = finfo_open(FILEINFO_MIME_TYPE);
		header('Content-Type: ' . finfo_file($finfo, $filename));
		finfo_close($finfo);

		//Use Content-Disposition: attachment to specify the filename
		header('Content-Disposition: attachment; filename='.basename($filename));

		//No cache
		header('Expires: 0');
		header('Cache-Control: must-revalidate');
		header('Pragma: public');

		//Define file size
		header('Content-Length: ' . filesize($filename));

		ob_clean();
		flush();
		readfile($filename);
		exit;
	else:
		$response['error'] = true; 
		$response['message'] ='file not found';
	endif;
endif;
?>