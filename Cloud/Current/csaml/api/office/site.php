<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['request']=='add' or $data['request']=='edit'):
	CheckJsonParams($data,$iv,$secretKey,array('nome','ref','address','sig','company','dinicio','dfim', 'active', 'regie', 'craneman', 'machinist', 'regie_extra', 'craneman_extra', 'machinist_extra', 'regie_weekends', 'craneman_weekends', 'machinist_weekends', 'project_lang','primary_lang'));
	if($data['request']=='add'):
		$query=$db->getquery("select initials from site where initials='".$data['sig']."'");
		if($query[0][0]<>''):
			$response['error'] = true; 
			$response['message'] = $site_initials_duplicate;
		else:
			$query="insert into site set name ='".$data['nome']."', address='".$data['address']."', initials='".$data['sig']."', ref_contrato='".$data['ref']."', active='".$data['active']."', regie_hourly='".$data['regie']."', craneman_hourly='".$data['craneman']."', machinist_hourly='".$data['machinist']."', regie_after_hours='".$data['regie_extra']."', craneman_after_hours='".$data['craneman_extra']."', machinist_after_hours='".$data['machinist_extra']."', regie_weekends='".$data['regie_weekends']."', craneman_weekends='".$data['craneman_weekends']."', machinist_weekends='".$data['machinist_weekends']."', project_languages='".$data['project_lang']."', primary_lang='".$data['primary_lang']."'";
			$db->setquery($query);
			$code=$db->getquery("select cod_site from site where initials='".$data['sig']."'");
			$db->setquery("insert into site_section set cod_site='".$code[0][0]."', description='Seccao 1'");
		endif;
	else:
		CheckJsonParams($data,$iv,$secretKey,array('cod'));
		$query="update site set name ='".$data['nome']."', address='".$data['address']."', initials='".$data['sig']."', ref_contrato='".$data['ref']."', cod_company='".$data['company']."', data_inicio='".$data['dinicio']."', data_fim='".$data['dfim']."', active='".$data['active']."', regie_hourly='".$data['regie']."', craneman_hourly='".$data['craneman']."', machinist_hourly='".$data['machinist']."', regie_after_hours='".$data['regie_extra']."', craneman_after_hours='".$data['craneman_extra']."', machinist_after_hours='".$data['machinist_extra']."', regie_weekends='".$data['regie_weekends']."', craneman_weekends='".$data['craneman_weekends']."', machinist_weekends='".$data['machinist_weekends']."', project_languages='".$data['project_lang']."', primary_lang='".$data['primary_lang']."'  where cod_site='".$data['cod']."'";
		$db->setquery($query);
	endif;
	$response['error'] = false; 
	$response['message'] = $regie_add_success;
else:
	CheckJsonParams($data,$iv,$secretKey,array('del'));
	$db->setquery("delete from site where cod_site='".$data['del']."'");
	$db->setquery("delete from record where cod_site='".$data['del']."'");
	$db->setquery("delete from teams where cod_site='".$data['del']."'");
	$db->setquery("delete from site_manager where cod_site='".$data['del']."'");
	$db->connect(false);
	$response['error'] = false; 
	$response['message'] = $regie_del_success;
endif;

?>