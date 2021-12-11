<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

$exploded=explode(",",$data['request']);
foreach( $exploded as $request):
	unset($query);
	$notfound=true;
	if($request=='settings'):
		CheckJsonParams($data,$iv,$secretKey,array('id'));
		$query=$db->getquery("select disable_checkin, disable_checkout, max_days_delay_validation, work_hours, company_name from settings");
		$notfound=false;
	endif;
	if($request=='profile'):
		CheckJsonParams($data,$iv,$secretKey,array('id'));
		$query=$db->getquery("select name, email, photo, contact, cod_user, card_auth_key as pin from users where cod_nfc='".$data['id']."'");
		if($query[0][0]<>""):
			$query[0][5]=substr($query[0][5],0,4);
		endif;
		$notfound=false;
	endif;
	if($request=='bordereau'):
		CheckJsonParams($data,$iv,$secretKey,array('site','section'));
		$section= is_numeric($data['section']) ? " and cod_section='".$data['section']."'" : "";
		$query=$db->getquery("select cod_task, descricao, enabled, units, previous_task, translations, contractor_ref,pu, qtd from bordereau where cod_site='".$data['site']."'".$section." order by previous_task asc");
		$notfound=false;
	endif;
	if($request=='clothes'):
		CheckJsonParams($data,$iv,$secretKey,array('cod'));
		if(isset($data['date'])):
			$str=" and data='".$data['date']."'";
		else:
			$str="";
		endif;
		$query=$db->getquery("select cod_clothes, cod_worker, data, clothes, note, request_date, delivered from worker_clothes where cod_worker='".$data['cod']."'".$str." order by delivered ASC");
		$notfound=false;
	endif;
	if($request=='siteclosure'):
		CheckJsonParams($data,$iv,$secretKey,array('cod'));
		if(isset($data['startdate']) and isset($data['enddate'])):
			$str=" and start>='".$data['startdate']."' and end<='".$data['enddate']."'";
		else:
			$str="";
		endif;
		$query=$db->getquery("select cod_closure, cod_site, start, end, motivo from site_closure where cod_site='".$data['cod']."'".$str);
		$notfound=false;
	endif;
	if($request=='sitematreception'):
		CheckJsonParams($data,$iv,$secretKey,array('site','section'));
		if(isset($data['startdate']) and isset($data['enddate'])):
			$str=" data between '".$data['startdate']."' and '".$data['enddate']."'";
		else:
			$str="";
		endif;
		if($data['site']=="all"):
			  $where= $str<>"" ? "where ".$str : "";
		else:
			$where=" where cod_site='".$data['site']."'";
			$where= $data['section']<>"all" ? $where." and cod_section='".$data['section']."'" : $where;
			$where= $str<>"" ? $where." and ".$str : $where;
		endif;
		$query=$db->getquery("select cod_materials_reception, cod_site, cod_section, data, start, end, qtd, units, material, notas from site_materials_reception ".$where);
		$notfound=false;
	endif;
	if($request=='ausencias'):
		CheckJsonParams($data,$iv,$secretKey,array('cod'));
		if(isset($data['startdate']) and isset($data['enddate'])):
			$str=" and inicio>='".$data['startdate']."' and fim<='".$data['enddate']."'";
		else:
			$str="";
		endif;
		$query=$db->getquery("select cod_ausencia, cod_worker, inicio, fim, tipo, viagem, motivo from worker_ausencia where cod_worker='".$data['cod']."'".$str);
		$notfound=false;
	endif;
	if($request=='mobiledevices'):
		$query=$db->getquery("select tablets.cod_tablet, IFNULL(worker.name, ''), tablets.pin, tablets.tablet_id, tablets.puk, tablets.mobile,tablets.name, tablets.sw_version, tablets.serial, IFNULL(site.name, ''), IFNULL(site_section.description, ''), tablets.active, tablets.date, tablets.email from tablets left join worker on tablets.cod_worker=worker.cod_worker left join site on tablets.cod_site=site.cod_site left join site_section on tablets.cod_section=site_section.cod_section");
		$notfound=false;
	endif;
	if($request=='dailyreport')://done
		CheckJsonParams($data,$iv,$secretKey,array('site','date','section'));
		$query=$db->getquery("select activities, ocurrences from site_daily_report where cod_site='".$data['site']."' and date='".$data['date']."' and cod_section='".$data['section']."'");
		$notfound=false;
	endif;
	if($request=='limosa')://done
		CheckJsonParams($data,$iv,$secretKey,array('cod'));
		$query=$db->getquery("select worker_limosa.cod_limosa, worker_limosa.inicio, worker_limosa.fim, worker_limosa.file, site.name, worker_limosa.qrcode from worker_limosa left join site on worker_limosa.cod_site=site.cod_site where worker_limosa.cod_worker='".$data['cod']."'");
		$notfound=false;
	endif;
	if($request=='workers')://done
		$type= isset($data['type']) ? $data['type']=="active" ? " where activo='1'": "" : "";
		$query=$db->getquery("select cod_worker, name, contact, cod_nfc, cod_category, cod_entreprise, contact112, photo, DATE_FORMAT(data_nascimento, '%Y-%m-%e'), idade, estado_civil, nacionalidade, cc, DATE_FORMAT(cc_validade, '%Y-%m-%e'), nif, niss, filhos, filhos_encargo, email,DATE_FORMAT(data_inicio_trabalho, '%Y-%m-%e') , morada, prob_saude, nib, peso, altura, calcas, pe, casaco, DATE_FORMAT(contrato_inicio, '%Y-%m-%e'), DATE_FORMAT(contrato_fim, '%Y-%m-%e'), contrato_file, DATE_FORMAT(destacamento_inicio, '%Y-%m-%e'), DATE_FORMAT(destacamento_fim, '%Y-%m-%e'), destacamento_file, DATE_FORMAT(act_inicio, '%Y-%m-%e'), DATE_FORMAT(act_fim, '%Y-%m-%e'), act_file, DATE_FORMAT(a1_inicio, '%Y-%m-%e'), DATE_FORMAT(a1_fim, '%Y-%m-%e'), a1_file, DATE_FORMAT(mutuelle_inicio, '%Y-%m-%e'), mutuelle_file, DATE_FORMAT(medico_inicio, '%Y-%m-%e'), medico_file, gruista_file, refeicao, ajudascusto, salario, classificacao, localizacao, naturalidade, concelho, cc_file, csaude_file, activo, activo_date, csaude_validade, cod_meal_place, cod_lodging, notes, room, card_auth_key from worker ".$type." order by activo desc, name asc");
		$notfound=false;
	endif;
	if($request=='workersonsite'):
		CheckJsonParams($data,$iv,$secretKey,array('site','section'));
		if (!isset($data['edate'])):
			CheckJsonParams($data,$iv,$secretKey,array('date'));
			$date= (isset($data['date'])) ? "record.date='".$data['date']."'" : "record.date='".date('Y-m-d', time())."'";
		else:
			CheckJsonParams($data,$iv,$secretKey,array('sdate','edate'));
			$date="(record.date between '".$data['sdate']."' and '".$data['edate']."')";
		endif;
		if(isset($data['options'])):
			$options=", worker.pe, worker.calcas, worker.casaco, worker.peso, worker.altura";
		else:
			$options="";
		endif;
		$section= $data['section']=="all" ? " " : " and record.cod_section='".$data['section']."' ";

		$query=$db->getquery("select distinct(worker.cod_worker), worker.name, worker.photo".$options." from record left join worker on worker.cod_worker=record.cod_worker where record.cod_site='".$data['site']."' ".$section." and ".$date." and (record.status='P' or record.status='PI' or record.checkin<>'00:00:00') order by worker.name ASC");

		file_put_contents("qery.txt", "select distinct(worker.cod_worker), worker.name, worker.photo".$options." from record left join worker on worker.cod_worker=record.cod_worker where record.cod_site='".$data['site']."' ".$section." and ".$date." and (record.status='P' or record.status='PI' or record.checkin<>'00:00:00') order by worker.name ASC");
		$notfound=false;				
	endif;
	if($request=='categories'): //done
		$queryDB=$db->getquery("select cod_category, designation,reference, translations from worker_categories");
		for($i=0;$i<count($queryDB);$i++):
			$query[$i][0]=$queryDB[$i][0];
			$query[$i][2]=$queryDB[$i][2];
			if(mb_detect_encoding($queryDB[$i][3], "UTF-8", true)===false):
				$JsonStr=utf8_encode($queryDB[$i][3]);  // beware: utf8_encode is for latin1 charset
			else:
				$JsonStr=$queryDB[$i][3];
			endif;
			if(isJson($JsonStr)):				
				$language= isset($data["language"]) ? $data["language"] : "en";
				$translations = json_decode($JsonStr, true);
				if(isset($translations[$language])):
					$query[$i][1]=($translations[$language]);
				else:
					$query[$i][1]=($queryDB[$i][1]);
				endif;
			else:
				$query[$i][1]=($queryDB[$i][1]);
			endif;
		endfor;
		$notfound=false;
	endif;
	if($request=='lodging'):
		$query=$db->getquery("select cod_lodging, name from worker_lodging where enabled='1'");
		$notfound=false;
	endif;
	if($request=='meals'):
		$query=$db->getquery("select cod_meal_place, name from worker_meal_place where enabled='1'");
		$notfound=false;
	endif;

	if($request=='team')://done
		CheckJsonParams($data,$iv,$secretKey,array('site','date','section'));
		$query=$db->getquery("select cod_worker, cod_category from teams where cod_site='".$data['site']."' and date='".$data['date']."' and cod_section='".$data['section']."'");
		$notfound=false;
	endif;
	if($request=='record'):
		CheckJsonParams($data,$iv,$secretKey,array('worker','site','enddate','startdate','section'));
		if(isset($data['type'])):
			if($data['type']=="readnote"):
				$query=$db->getquery("select notas from record where cod_worker='".$data['worker']."' and date='".$data['startdate']."' and cod_site='".$data['site']."' and cod_section='".$data['section']."'");
			elseif($data['type']=="details"):
				$query=$db->getquery("select checkin, checkout, date, status, absense, cod_site, notas from record where date='".$data['startdate']."' and cod_worker='".$data['worker']."' and cod_site='".$data['site']."' and cod_section='".$data['section']."'");
			endif;
		else:
			$qsite= $data['site']=="all" ? "" : " and cod_site='".$data['site']."'";
			$qsection= $data['section']=="all" ? "" : " and cod_section='".$data['section']."'";

			$query=$db->getquery("select checkin, checkout, date, status, absense, notas, cod_site, cod_section, validation_reason from record where (date BETWEEN '".$data['startdate']."' AND '".$data['enddate']."') and cod_worker='".$data['worker']."'".$qsite.$qsection." group by cod_site, cod_section, date");
		endif;
		$notfound=false;
	endif;
	if($request=='sites'): //done
		$site="";
		$active= isset($data['override']) ? "" : " where active='1' ";
		if(isset($data['date'])):
			$query=$db->getquery("select cod_site from site");
			if($query[0][0]<>""):
				if($active==""):
					$site=" where (";
				else:
					$site=" and (";
				endif;
				$counter=0;
				for($i=0;$i<count($query);$i++):
					$record=$db->getquery("select cod_worker from record where cod_site ='".$query[$i][0]."' and (date between '".date('Y-m',strtotime($data['date']))."-01' and '".date('Y-m-t',strtotime($data['date']))."') and (checkin<>'00:00:00' or checkout<>'00:00:00' or (status<>'EP' and status<>'MO' and status<>''))");

					if ($record[0][0]<>''):
						$site.= $counter==0 ? " cod_site='".$query[$i][0]."'" : " or cod_site='".$query[$i][0]."'";
						$counter++;
					endif;
				endfor;
				if($active==""):
					$site= ($site==" where (") ? "" : $site.")";
				else:
					$site= ($site==" and (") ? "" : $site.")";
				endif;
			endif;
		endif;


		$query=$db->getquery("select cod_site, name, address, initials, gps_lat, gps_lon, ref_contrato, cod_company, data_inicio, data_fim, distancia, authentication_radius, active, regie_hourly, craneman_hourly, machinist_hourly, regie_weekends, machinist_weekends, craneman_weekends, regie_after_hours, machinist_after_hours, craneman_after_hours, project_languages, primary_lang from site ".$active.$site."order by active DESC, name ASC");
		$notfound=false;
	endif;
	if($request=='company')://done
		$query=$db->getquery(" select cod_company, nome, phone, tva, address, email, logo from site_contractor");
		$notfound=false;
	endif;
	if($request=='manager')://done
		$site= isset($data['site']) ? " where cod_site='".$data['site']."'" : "";
		$str= $site=="" ? " where" : " and";
		$section= isset($data['section']) ? $str." cod_section='".$data['section']."'" : "";
		$query=$db->getquery("select cod_manager, telef, email, name, cod_site, job, cod_nfc, cod_section, photo, auth_string from site_manager".$site.$section);
		$notfound=false;
	endif;
	if($request=='sections')://done
		$site= isset($data['site']) ? " where cod_site='".$data['site']."'" : "";
		$query=$db->getquery("select cod_section, cod_site, description, attendances_last_close from site_section".$site);
		$notfound=false;
	endif;
	if($request=='report'):
		CheckJsonParams($data,$iv,$secretKey,array('empresa','cat','site','date','section'));
		$str[0]='';
		$str[1]='';
		$str[2]='';
		if($data['site']=="none" and $data['empresa']=="none" and $data['cat']=="none"):
			$query = "select worker.cod_worker, worker.name, worker.contact, worker.cod_nfc, worker.cod_category, worker.cod_entreprise from worker order by worker.name asc";
		else:
			if($data['site']=='all' or $data['site']=='none'):
				$str[0] = "";
			else:
			   $str[0] = " and teams.cod_site='".$data['site']."'";
			endif;
			if($data['empresa']=='all' or $data['empresa']=='none'):
				$str[1] = "";
			else:
			   $str[1] = " and worker.cod_entreprise='".$data['empresa']."'";
			endif;
			if($data['cat']=='all' or $data['cat']=='none'):
				$str[2] = "";
			else:
			   $str[2] = " and worker.cod_category='".$data['cat']."'";
			endif;
			if($data['section']=='all'):
				$str[3] = "";
			else:
			   $str[3] = " and teams.cod_section='".$data['section']."'";
			endif;

			if($data['site']<>"none"):
				$query = "select worker.cod_worker, worker.name, worker.contact, worker.cod_nfc, worker.cod_category, worker.cod_entreprise, teams.cod_site, teams.cod_section from worker left join teams on worker.cod_worker=teams.cod_worker where (worker.activo='1' or (worker.activo_date>'".$data['date']."' and worker.activo='0')) and teams.date='".$data['date']."'".$str[0].$str[1].$str[2].$str[3]." order by teams.cod_site asc, teams.cod_section asc, worker.cod_entreprise asc, teams.cod_category asc, worker.name ASC";

			else:					
				if($str[1]=="" and $str[2]==""):
					if($data['empresa']<>"none"):
						$query = "select cod_worker, name, contact, cod_nfc, cod_category, cod_entreprise from worker where (worker.activo='1' or (worker.activo_date>'".$data['date']."' and worker.activo='0')) order by cod_entreprise asc, cod_category asc, name asc";
					else:
						$query = "select cod_worker, name, contact, cod_nfc, cod_category, cod_entreprise from worker where (worker.activo='1' or (worker.activo_date>'".$data['date']."' and worker.activo='0')) order by cod_category asc, name asc";
					endif;
				else:
					$query = "select cod_worker, name, contact, cod_nfc, cod_category, cod_entreprise from worker where (worker.activo='1' or (worker.activo_date>'".$data['date']."' and worker.activo='0')) ".$str[1].$str[2]." order by cod_entreprise asc, cod_category asc, name asc";
				endif;				
			endif;
		endif;
		$query=$db->getquery($query);
		$notfound=false;
	endif;
	if($request=='transportvehicle'):
		if(isset($data['active'])):
			$active=" where active='1' ";
		else:
			$active="";
		endif; 
		if(isset($data['rental'])):					
			$rental= $active<>"" ? " and rental='1' " : " where rental='1' ";
		else:
			$rental="";
		endif; 

		$query=$db->getquery("select cod_vehicle, designation, initials, active, rental from transport_vehicle ".$active.$rental." order by designation");
		$notfound=false;
	endif;
	if($request=='nonvalidatedentries'):
		$query=$db->getquery("select record.cod_site, site.name, record.date, record.cod_worker from record left join site on record.cod_site=site.cod_site where record.checkin<>'' and record.checkout<>'' and record.status=''");
		$notfound=false;
	endif;
	if($request=='logger'):
		CheckJsonParams($data,$iv,$secretKey,array('empresa','site','date'));
		$qempresa= $data['empresa']=="all" ? "" : " and worker.cod_entreprise='".$data['empresa']."'";
		$qsite=$data['site']=="all" ? "" : " and teams.cod_site='".$data['site']."'";
		$qsection=$data['section']=="all" ? "" : " and teams.cod_section='".$data['section']."'";

		$query = "select worker.cod_worker, worker.name, worker.contact, worker.cod_nfc, teams.cod_category, worker.cod_entreprise, teams.cod_site, worker.contact112, teams.cod_section from worker left join teams on worker.cod_worker=teams.cod_worker where teams.date='".$data['date']."'".$qsite.$qempresa.$qsection." order by teams.cod_site asc, teams.cod_section asc, worker.cod_entreprise asc, teams.cod_category asc";
		$query=$db->getquery($query);
		$notfound=false;
	endif;

	if($request=='holidays'): //done
		CheckJsonParams($data,$iv,$secretKey,array('startdate','enddate'));


		if($data['startdate']=='null' and $data['enddate']=='null'):
			$query=$db->getquery("select date from holidays");
		elseif($data['startdate']<>'null' and $data['enddate']=='null'):
			$query=$db->getquery("select date from holidays where date='".$data['startdate']."'");
		else:
			$query=$db->getquery("select date from holidays where (date BETWEEN '".$data['startdate']."' AND '".$data['enddate']."')");
		endif;
		$notfound=false;
	endif;
	if($request=='duplicates'):
		CheckJsonParams($data,$iv,$secretKey,array('data','worker'));
		$query=$db->getquery("select record.cod_site, site.name, site_section.description from record left join site on record.cod_site=site.cod_site left join site_section on record.cod_section=site_section.cod_section where date='".$data['data']."' and cod_worker='".$data['worker']."' and record.status<>'EP' and record.status<>'MO'");
		$notfound=false;
	endif;
	if($request=='entreprises'): // done
		$query=$db->getquery("select cod_entreprise, name, contact from entreprise");
		$notfound=false;
	endif;


	if ($notfound):
		$response['error']=true;
		$response['message']='Invalid request';
	elseif($query[0][0]==""):
		$response['error'] = false; 
		$response['message'] = '1001';
	else:
		for($i=0;$i<count($query);$i++):
			for($j=0;$j<count($query[$i]);$j++):
				$response[$request][$i][$j]=$query[$i][$j];						
			endfor;
		endfor;
		$response['error'] = false; 
		$response['message'] = 'DB request OK';
	endif;
endforeach;
?>