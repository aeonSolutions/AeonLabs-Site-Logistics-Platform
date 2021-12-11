<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

$filename="";
if($data['file']=='contract'):
	$filename = $server['root']['path']."templates/contrato.rtf";
endif;
if($data['file']=='destacamento'):
	$filename = $server['root']['path']."templates/destacamento.rtf";
endif;
if($data['file']=='act'):
	$filename = $server['root']['path']."templates/act.rtf";
endif;
if($data['file']=='ficha'):
	$filename = $server['root']['path']."templates/ficha.rtf";
endif;
if($data['file']=='journal'):
	$filename = $server['root']['path']."templates/journal.rtf";
endif;


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