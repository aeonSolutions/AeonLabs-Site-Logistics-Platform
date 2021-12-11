<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

if($data['type']=='list'):
	$cod=(isset($data['cod'])) ? " and cod_project='".$data['cod']."'" : "";

	$query=$db->getquery("select cod_project, description, date, file from site_project where cod_site='".$data['site']."' and cod_section='".$data['section']."'".$cod." order by date ASC");
	if($query[0][0]<>''): // results found
		$response['error'] = false; 
		$response['message'] ='Bem vindo';
		for($i = 0; $i < count($query); $i++):
			$response['data'][$i]['description']=encodeString($query[$i][1]);
			$response['data'][$i]['code']=$query[$i][0];
			$response['data'][$i]['data']=$query[$i][2];
			$response['data'][$i]['file']=$query[$i][3];
		endfor;
	else:
		$response['error'] = true; 
		$response['message'] =$project_missing;
	endif;
else:
	$response['error'] = true; 
	$response['message'] ='Invalid GET request';
endif;
?>