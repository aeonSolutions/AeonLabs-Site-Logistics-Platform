<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['request']=='load'):
	CheckJsonParams($data,$iv,$secretKey,array('site','section'));

	$section= $data['section']=="all" ? " order by site_delivery.date asc" : " and site_delivery.cod_section='".$data['section']."' order by site_delivery.cod_section, site_delivery.date asc";
	$date= !isset($data['sdate']) ? "" : "date between '".$data['sdate']."' and '".$data['edate']."' and";

	$query=$db->getquery("select site_delivery.cod_delivery, site_delivery.ref_doc, site_delivery.material, site_delivery.qtd, site_delivery.units, site_delivery.notas, site_delivery.date, site_section.description, site_delivery.cod_section from site_delivery left join site_section on site_delivery.cod_section=site_section.cod_section where ".$date." site_delivery.cod_site='".$data['site']."'".$section);


	if($query[0][0]<>''):
		$response['error'] = false; 
		$response['message'] = $checkCredentials_welcome;

		$section=0;
		$counter=0;
		$prevSection=$query[0][8];
		$response['data'][$section]['name']=$query[0][7];

		for($i=0;$i<count($query);$i++):
			if($prevSection<>$query[$i][8]):
				$section++;
				$counter=0;
				$prevSection=$query[$i][8];
				$response['data'][$section]['name']=$query[$i][9];
			endif;
			$response['data'][$section]['delivery'][$counter]['code']=$query[$i][0];
			$response['data'][$section]['delivery'][$counter]['ref']=encodeString($query[$i][1]);
			$response['data'][$section]['delivery'][$counter]['material']=encodeString($query[$i][2]);
			$response['data'][$section]['delivery'][$counter]['units']=$query[$i][4];
			$response['data'][$section]['delivery'][$counter]['qtd']=$query[$i][3];
			$response['data'][$section]['delivery'][$counter]['data']=$query[$i][6];
			$response['data'][$section]['delivery'][$counter]['note']=encodeString($query[$i][5]);
			$response['data'][$section]['delivery'][$counter]['section']=$query[$i][8];

			$query2=$db->getquery("select cod_photo, file from photos where db_table='site_delivery' and cod_table='".$query[$i][0]."'");
			if($query2[0][0]<>''):
				for($j=0;$j<count($query2);$j++):
					$response['data'][$section]['delivery'][$counter]['photos'][$j]['code']=$query2[$j][0];
					$response['data'][$section]['delivery'][$counter]['photos'][$j]['file']=$query2[$j][1];
				endfor;
			endif;
			$counter++;
		endfor;

	else:
		$response['error'] = false; 
		$response['empty'] = true; 
		$response['message'] = $delivery_no_data;
	endif;
elseif($data['request']=='edit'):
	CheckJsonParams($data,$iv,$secretKey,array('ref','qtd','und','mat','cod','date'));
	$note= isset($data['note']) ? $data['note'] : "";
	$db->setquery("update site_delivery set ref_doc='".$data['ref']."', material='".$data['mat']."', units='".$data['und']."', qtd='".$data['qtd']."', notas='".$note."', date='".$data['date']."' where cod_delivery='".$data['cod']."'");
	$response['error'] = false; 
	$response['message'] = $regie_edit_success;
elseif($data['request']=='add'):
	CheckJsonParams($data,$iv,$secretKey,array('ref','qtd','und','mat','site','section', 'date'));
	$note= isset($data['note']) ? $data['note'] : "";
	$db->setquery("insert into site_delivery set ref_doc='".$data['ref']."', material='".$data['mat']."', units='".$data['und']."', qtd='".$data['qtd']."', notas='".$note."', cod_site='".$data['site']."', cod_section='".$data['section']."', date='".$data['date']."', log_time='".date('G:i', time())."'");
	$response['error'] = false; 
	$response['message'] = $regie_add_success;
elseif($data['request']=='del'):
	CheckJsonParams($data,$iv,$secretKey,array('cod'));
	$db->setquery("delete from site_delivery where cod_delivery='".$data['cod']."'");
	$query=$db->getquery("select file, cod_photo from photos where db_table='site_delivery' and cod_table='".$data['cod']."'");
	if ($query[0][0]<>''):
		for($i=0;$i<count($query);$i++):
			@unlink(dirname(dirname(__FILE__))."/files/delivery/". $query[$i][0]);
			$db->setquery("delete from photos where cod_photo='".$query[$i][1]."'");
		endfor;
	endif;
	$response['error'] = false; 
	$response['message'] = $regie_del_success;
else:
	$response['error'] = true; 
	$response['message'] = $invalid_request;
endif;

?>