<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

$filename = $server['root']['path']."dlls/".$data['file'];

if(file_exists($filename)):
	header('Content-Description: File Transfer');
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
	readfile($filename);
	ob_clean();
	flush();
	die();
else:
	header("HTTP/1.0 404 Not Found");
	$response['error'] = true; 
	$response['message'] = $file_not_found;
endif;

?>