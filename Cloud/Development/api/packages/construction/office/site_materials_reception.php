<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['type']=='del'):
	CheckJsonParams($data,$iv,$secretKey,array('cod'));
	$query=$db->setquery("delete from site_materials_reception where cod_materials_reception='".$data['cod']."'");
elseif($data['type']=='add'):
	CheckJsonParams($data,$iv,$secretKey,array('site','section', 'start','end', 'date', 'qtd', 'units', 'material'));
	$motivo = ($data['notes']=="") ? "" : $data['notes'];
	$query=$db->setquery("insert into site_materials_reception set cod_site='".$data['site']."', cod_section='".$data['section']."',start='".$data['start']."', end='".$data['end']."', notas='".$motivo."', data='".$data['date']."', qtd='".$data['qtd']."', units='".$data['units']."', material='".$data['material']."'");
elseif($data['type']=='edit'):
	CheckJsonParams($data,$iv,$secretKey,array('cod','site','section', 'start','end', 'date', 'qtd', 'units', 'material'));
	$motivo = ($data['notes']=="") ? "" : $data['notes'];

	$query=$db->setquery("update site_materials_reception set cod_site='".$data['site']."', cod_section='".$data['section']."',start='".$data['start']."', end='".$data['end']."', notas='".$motivo."', data='".$data['date']."', qtd='".$data['qtd']."', units='".$data['units']."', material='".$data['material']."' where cod_materials_reception='".$data['cod']."'");
endif;

$response['error'] = false; 
$response['message'] = 'DB request OK';
?>