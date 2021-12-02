<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response['error'] = false;
$response['message'] ="bem vindo";
if($data['type']=='regie'):
	$query=$db->getquery("select distinct date from site_regie where cod_site='".$data['site']."' and cod_section='".$data['section']."'");
	if($query[0][0]<>''):
		$response['error'] = false; 
		$response['message'] ='Bem vindo';
		for($i = 0; $i < count($query); $i++):
			$response['data'][$i]['date']=$query[$i][0];
		endfor;
	else:
		$response['error'] = true;
		$response['message'] =$regie_work_regie_list_not_found;
	endif;
elseif($data['type']=='journal'):
	$query=$db->getquery("select distinct date from site_journal where cod_site='".$data['site']."' and cod_section='".$data['section']."'");
	if($query[0][0]<>''):
		$response['error'] = false; 
		$response['message'] ='Bem vindo';
		for($i = 0; $i < count($query); $i++):
			$response['data'][$i]['date']=$query[$i][0];
		endfor;
	else:
		$response['error'] = true;
		$response['message'] =$journal_entry_not_found;
	endif;
else:
	$response['error'] = true;
	$response['message'] ='invalid request';
endif;
?>