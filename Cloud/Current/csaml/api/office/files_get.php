<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$filename="";
if($data['type']=='limosa'):
	$query=$db->getquery("select file from worker_limosa where cod_limosa='".$data['cod']."'");
	if($query[0][0]<>''):
		$filename = $server['root']['files']."limosas/". $query[0][0];
	endif;
endif;
if($data['type']=='contrato'):
	$query=$db->getquery("select contrato_file from worker where cod_worker='".$data['cod']."'");
	if($query[0][0]<>''):
		$filename = $server['root']['files']."contratos/". $query[0][0];
	endif;
endif;
if($data['type']=='act'):
	$query=$db->getquery("select act_file from worker where cod_worker='".$data['cod']."'");
	if($query[0][0]<>''):
		$filename = $server['root']['files']."act/". $query[0][0];
	endif;
endif;
if($data['type']=='a1'):
	$query=$db->getquery("select a1_file from worker where cod_worker='".$data['cod']."'");
	if($query[0][0]<>''):
		$filename = $server['root']['files']."a1/". $query[0][0];
	endif;
endif;
if($data['type']=='destacamento'):
	$query=$db->getquery("select destacamento_file from worker where cod_worker='".$data['cod']."'");
	if($query[0][0]<>''):
		$filename = $server['root']['files']."destacamento/". $query[0][0];
	endif;
endif;
if($data['type']=='medico'):
	$query=$db->getquery("select medico_file from worker where cod_worker='".$data['cod']."'");
	if($query[0][0]<>''):
		$filename = $server['root']['files']."medico/". $query[0][0];
	endif;
endif;
if($data['type']=='mutuelle'):
	$query=$db->getquery("select mutuelle_file from worker where cod_worker='".$data['cod']."'");
	if($query[0][0]<>''):
		$filename = $server['root']['files']."mutuelle/". $query[0][0];
	endif;
endif;
if($data['type']=='gruista'):
	$query=$db->getquery("select gruista_file from worker where cod_worker='".$data['cod']."'");
	if($query[0][0]<>''):
		$filename = $server['root']['files']."gruista/". $query[0][0];
	endif;
endif;
if($data['type']=='cc'):
	$query=$db->getquery("select cc_file from worker where cod_worker='".$data['cod']."'");
	if($query[0][0]<>''):
		$filename = $server['root']['files']."cc/". $query[0][0];
	endif;
endif;
if($data['type']=='csaude'):
	$query=$db->getquery("select csaude_file from worker where cod_worker='".$data['cod']."'");
	if($query[0][0]<>''):
		$filename = $server['root']['files']."csaude/". $query[0][0];
	endif;
endif;

$db->connect(false);
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
	echo "File not found:";
	die();
endif;
?>