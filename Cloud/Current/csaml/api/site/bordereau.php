<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;


if($data['type']=="add"):
	CheckJsonParams($data,$iv,$secretKey, array('activity','units'));
	$db->setquery("insert into bordereau set cod_site='".$data['site']."', cod_section='".$data['section']."', avenant='s', descricao='".encodeString16($data['activity'])."', units='".$data['units']."', enabled='1'");
	$response['error'] = false; 
	$response['message'] =$bordereau_avenant_registed;
elseif($data['type']=="list"):
	$query=$db->getquery("select cod_task, descricao, units, enabled, qtd, contractor_ref, translations from bordereau where cod_site='".$data['site']."' and cod_section='".$data['section']."' and avenant='n'");
	if($query[0][0]<>''): // results found
		$response['error'] = false; 
		$response['message'] ='Bem vindo';
		$pos=0;
		for($i = 0; $i < count($query); $i++):
			if(isJson(utf8_encode ($query[$i][6]))):
				$language= isset($data["language"]) ? $data["language"] : "en";
				$translations = json_decode(utf8_encode ($query[$i][6]), true);
				if(isset($translations[$language])):
					$response['data'][$pos]['name']=encodeString($translations[$language]); 
				else:
					$response['data'][$pos]['name']=encodeString($query[$i][1]); 				
				endif;
			else:
				$response['data'][$pos]['name']=encodeString($query[$i][1]); 
			endif;
			$response['data'][$pos]['code']=$query[$i][0];
			$response['data'][$pos]['ref']=encodeString($query[$i][5]);
			$response['data'][$pos]['units']=$query[$i][2];
			$response['data'][$pos]['qtd']=$query[$i][4];
			$response['data'][$pos]['enabled']=$query[$i][3];
			$qtd_feito=0;
			$done=$db->getquery("select qtd from site_qtd_jour where cod_task='".$query[$i][0]."' and cod_site='".$data['site']."' and cod_section='".$data['section']."'");
			for($k=0;$k<count($done);$k++):
				$qtd_feito=is_numeric($done[$k][0]) ? $qtd_feito+floatval($done[$k][0]) : $qtd_feito;
			endfor;
			$qtd_falta=$query[$i][4]-$qtd_feito;
			$response['data'][$pos]['qtdfalta']=strval(round($qtd_falta,1,PHP_ROUND_HALF_UP));
			$response['data'][$pos]['qtdfeito']=strval(round($qtd_feito,1,PHP_ROUND_HALF_UP));
			$pos++;
		endfor;
		$response['data'][$pos]['name']=$bordereau_add_avenant_title; 
		$response['data'][$pos]['code']="";
		$response['data'][$pos]['ref']="";
		$response['data'][$pos]['units']="";
		$response['data'][$pos]['qtd']="";
		$response['data'][$pos]['enabled']="0";
		$response['data'][$pos]['qtdfalta']="";
		$response['data'][$pos]['qtdfeito']="";
		$pos++;
		$query=$db->getquery("select cod_task, descricao, units, enabled, qtd, contractor_ref, translations from bordereau where cod_site='".$data['site']."' and cod_section='".$data['section']."' and avenant='s'");				
		if($query[0][0]<>''):
			for($i = 0; $i < count($query); $i++):
				if(isJson($query[$i][6])):
					$language= isset($data["language"]) ? $data["language"] : "en";
					$translations = json_decode($query[$i][6], true);
					if(isset($translations[$language])):
						$response['data'][$pos]['name']=encodeString($translations[$language]); 
					else:
						$response['data'][$pos]['name']=encodeString($query[$i][1]); 				
					endif;
				else:
					$response['data'][$pos]['name']=encodeString($query[$i][1]); 
				endif;
				$response['data'][$pos]['code']=$query[$i][0];
				$response['data'][$pos]['ref']=encodeString($query[$i][5]);
				$response['data'][$pos]['units']=$query[$i][2];
				$response['data'][$pos]['qtd']=$query[$i][4];
				$response['data'][$pos]['enabled']=$query[$i][3];
				$qtd_feito=0;
				$done=$db->getquery("select qtd from site_qtd_jour where cod_task='".$query[$i][0]."' and cod_site='".$data['site']."' and cod_section='".$data['section']."'");
				for($k=0;$k<count($done);$k++):
					$qtd_feito=is_numeric($done[$k][0]) ? $qtd_feito+floatval($done[$k][0]) : $qtd_feito;
				endfor;
				
				$qtd_falta=is_numeric($query[$i][4]) ? floatval($query[$i][4])-$qtd_feito : 0;

				$response['data'][$pos]['qtdfalta']=strval(round($qtd_falta,1,PHP_ROUND_HALF_UP));
				$response['data'][$pos]['qtdfeito']=strval(round($qtd_feito,1,PHP_ROUND_HALF_UP));
				$pos++;
			endfor;
		endif;
		if(isset($data['avenant'])):
			$response['data'][$pos]['name']="[newline]".$bordereau_add_avenant_tag."[newline]"; 
			$response['data'][$pos]['code']="-1";
			$response['data'][$pos]['ref']="";
			$response['data'][$pos]['units']="";
			$response['data'][$pos]['qtd']="";
			$response['data'][$pos]['enabled']="1";
			$response['data'][$pos]['qtdfalta']="";
			$response['data'][$pos]['qtdfeito']="";
		endif;
	else:
		$response['error'] = true; 
		$response['message'] =$bordereau_missing;
	endif;
else:
	$response['error'] = true; 
	$response['message'] ='invalid request';
endif;
?>