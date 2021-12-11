<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['request']=='add' or $data['request']=='edit'):
	CheckJsonParams($data,$iv,$secretKey,array('desc','site'));
	if($data['request']=='add'):
		$query="insert into site_section set description='".$data['desc']."', cod_site='".$data['site']."', latitude='".$data['lat']."', longitude='".$data['lon']."', distance='".$data['dist']."', authentication_radius='".$data['range']."'";
	else:
		CheckJsonParams($data,$iv,$secretKey,array('cod'));
		$query="update site_section set description='".$data['desc']."', cod_site='".$data['site']."', latitude='".$data['lat']."', longitude='".$data['lon']."', distance='".$data['dist']."', authentication_radius='".$data['range']."' where cod_section='".$data['cod']."'";
	endif;
	$db->setquery($query);
	$response['error'] = false; 
	$response['message'] = $regie_add_success;
else:
	CheckJsonParams($data,$iv,$secretKey,array('del'));
	$db->setquery("delete from site_section where cod_section='".$data['del']."'");
	$response['error'] = false; 
	$response['message'] = $regie_del_success;
endif;
?>