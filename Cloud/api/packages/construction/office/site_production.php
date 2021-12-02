<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['request']=='load'):
	CheckJsonParams($data,$iv,$secretKey,array('type'));
	if($data['type']=='main'):
		CheckJsonParams($data,$iv,$secretKey,array('site','section','sdate','edate'));
		$section= $data['section']=="all" ? " order by site_qtd_jour.date asc" : " and site_qtd_jour.cod_section='".$data['section']."' order by site_qtd_jour.cod_section, site_qtd_jour.date asc";
		$date= $data['sdate']=="null" ? "" : " and date between '".$data['sdate']."' and '".$data['edate']."'";
		$query=$db->getquery("select site_qtd_jour.cod_qtd, bordereau.descricao, site_qtd_jour.workers, site_qtd_jour.qtd, site_qtd_jour.notas, site_qtd_jour.cod_section, site_section.description, site_qtd_jour.date, bordereau.units, bordereau.cod_task from site_qtd_jour left join bordereau on site_qtd_jour.cod_task=bordereau.cod_task left join site_section on site_qtd_jour.cod_section= site_section.cod_section where site_qtd_jour.cod_site='".$data['site']."'".$date.$section);


		if($query[0][0]<>''):
			$response['error'] = false; 
			$response['message'] = $checkCredentials_welcome;

			$section=0;
			$counter=0;
			$prevSection=$query[0][6];
			$response['data'][$section]['name']=$query[0][6];
			$response['data'][$section]['code']=$query[0][5];

			for($i=0;$i<count($query);$i++):
				if($prevSection<>$query[$i][6]):
					$section++;
					$counter=0;
					$prevSection=$query[$i][8];
					$response['data'][$section]['name']=$query[$i][6];
					$response['data'][$section]['code']=$query[0][5];
				endif;
				$response['data'][$section]['production'][$counter]['code']=$query[$i][0];
				$response['data'][$section]['production'][$counter]['task']=$query[$i][1];
				$response['data'][$section]['production'][$counter]['taskcode']=$query[$i][9];
				$response['data'][$section]['production'][$counter]['qtd']=$query[$i][3];
				$response['data'][$section]['production'][$counter]['date']=$query[$i][7];
				$response['data'][$section]['production'][$counter]['units']=$query[$i][8];
				$response['data'][$section]['production'][$counter]['note']=encodeString($query[$i][4]);

				$exploded=explode(",",$query[$i][2]);
				$name="";
				$pos=0;
				foreach( $exploded as $worker):
					$query2=$db->getquery("select cod_worker, name, photo from worker where cod_worker='".$worker."'");

					if($query2[0][0]<>''):
						$exploded=explode(" ",$query2[0][1]);
						if(isset($exploded[1])):
							$name.=$exploded[0]." ".$exploded[count($exploded)-1].", ";
						else:
							$name.=$exploded[0].", ";
						endif;
						$response['data'][$section]['production'][$counter]['workers'][$pos]['code']=$query2[0][0];
						$response['data'][$section]['production'][$counter]['workers'][$pos]['name']=$query2[0][1];
					else: // worker is no longer on DB
						$name.=encodeString("Trabalhador não encontrado").", ";
						$response['data'][$section]['production'][$counter]['workers'][$pos]['code']=-1;
						$response['data'][$section]['production'][$counter]['workers'][$pos]['name']=encodeString("Trabalhador não encontrado");
					endif;
					$pos++;
				endforeach;
				$response['data'][$section]['production'][$counter]['workersList']=encodeString($name);

				$counter++;
			endfor;
		else:
			$response['error'] = false; 
			$response['empty'] = true; 
			$response['message'] = $production_no_data;
		endif;

	else:

		$response['error'] = true; 
		$response['message'] = $invalid_request;
	endif;
elseif($data['request']=='edit'):
	CheckJsonParams($data,$iv,$secretKey,array('workers','date', 'qtd', 'cod','bordereau'));
	$note= isset($data['notes']) ? encodeString($data['notes']) : "";
	$db->setquery("update site_qtd_jour set qtd='".$data['qtd']."', cod_task='".$data['bordereau']."', workers='".$data['workers']."', notas='".$note."', date='".$data['date']."' where cod_qtd='".$data['cod']."'");
	$response['error'] = false; 
	$response['message'] = $attendance_edit_success;
elseif($data['request']=='add'):
	CheckJsonParams($data,$iv,$secretKey,array('workers','date', 'qtd', 'site', 'section','bordereau'));
	$note= isset($data['notes']) ? encodeString($data['notes']) : "";
	$db->setquery("insert into site_qtd_jour set qtd='".$data['qtd']."', cod_task='".$data['bordereau']."', workers='".$data['workers']."', notas='".$note."', date='".$data['date']."', cod_site='".$data['site']."', cod_section='".$data['section']."'");

	$response['error'] = false; 
	$response['message'] = $attendance_add_success;
elseif($data['request']=='del'):
	CheckJsonParams($data,$iv,$secretKey,array('cod'));
	$db->setquery("delete from site_qtd_jour where cod_qtd='".$data['cod']."'");
	$response['error'] = false; 
	$response['message'] = $attendance_del_success;
else:
	$response['error'] = true; 
	$response['message'] = $invalid_request;
endif;

?>