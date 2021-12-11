<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['request']=='load'):
	CheckJsonParams($data,$iv,$secretKey, array('type'));
	if($data['type']=='main'):
		CheckJsonParams($data,$iv,$secretKey, array('site','section','sdate','edate'));
		$section= $data['section']=="all" ? " order by site_regie.date asc" : " and site_regie.cod_section='".$data['section']."' order by site_regie.cod_section, site_regie.date asc";
		$date= $data['sdate']=="null" ? "" : " and (date between '".$data['sdate']."' and '".$data['edate']."')";
		$query=$db->getquery("select site_regie.cod_regie, site_regie.date, site_regie.start, site_regie.end, site_regie.workers, site_regie.notas, site_regie.cod_section, site_section.description from site_regie left join site_section on site_regie.cod_section=site_section.cod_section where site_regie.cod_site='".$data['site']."'".$date.$section);

		if($query[0][0]<>''):
			$response['error'] = false; 
			$response['message'] = $checkCredentials_welcome;

			$section=0;
			$counter=0;
			$prevSection=$query[0][6];
			$response['data'][$section]['name']=$query[0][7];

			for($i=0;$i<count($query);$i++):
				if($prevSection<>$query[$i][6]):
					$section++;
					$counter=0;
					$prevSection=$query[$i][8];
					$response['data'][$section]['name']=$query[$i][7];
				endif;
				$response['data'][$section]['regie'][$counter]['code']=$query[$i][0];
				$response['data'][$section]['regie'][$counter]['date']=$query[$i][1];
				$response['data'][$section]['regie'][$counter]['start']=$query[$i][2];
				$response['data'][$section]['regie'][$counter]['end']=$query[$i][3];
				$response['data'][$section]['regie'][$counter]['note']=encodeString($query[$i][5]);
				$response['data'][$section]['regie'][$counter]['section']=$query[$i][6];

				if(($query[$i][3]=="" or $query[$i][3]=="00:00:00")and($query[$i][2]=="" or $query[$i][2]=="00:00:00")): // regie is deleted
					$response['data'][$section]['regie'][$counter]['completed']=5; //$regie_deleted
				elseif($query[$i][3]=="" or $query[$i][3]=="00:00:00"): // regie is not closed
					$site_section= is_numeric($data['section']) ? " and cod_Section='".$data['section']."'" : "";
					$exploded=explode(",",$query[$i][4]);
					$str=" and (";
					$counter2=0;
					foreach( $exploded as $worker):
						$str.= $counter2==0 ? " cod_worker='".$worker."'" : " or cod_worker='".$worker."'";
						$counter2++;
					endforeach;
					$str= $str==" and (" ? "" : $str.")";

					$record=$db->getquery("select cod_worker, checkout from record where cod_site='".$data['site']."' ".$site_section." and date='".$query[$i][1]."'".$str." order by checkout desc");

					if ($record[0][1]<>"" and $record[0][1]<>"00:00:00"): // with checkout 
						$response['data'][$section]['regie'][$counter]['completed']=1; //$regie_checkout_eod
						$response['data'][$section]['regie'][$counter]['end']=$record[0][1];
					elseif(($record[0][1]=="" or $record[0][1]=="00:00:00") and $query[$i][1] <> date("Y-m-d")): //no checkout and not today
						$response['data'][$section]['regie'][$counter]['completed']=2; //$regie_default_eod
						$response['data'][$section]['regie'][$counter]['end']="17:30:00";
					else: // no checkout and still today
						$response['data'][$section]['regie'][$counter]['completed']=3; //$regie_ongoing
					endif;
				else:
					$response['data'][$section]['regie'][$counter]['completed']=4; //$regie_completed								
				endif;


				$query2=$db->getquery("select cod_photo, file from photos where db_table='site_regie' and cod_table='".$query[$i][0]."'");
				if($query2[0][0]<>''):
					for($j=0;$j<count($query2);$j++):
						$response['data'][$section]['regie'][$counter]['photos'][$j]['code']=$query2[$j][0];
						$response['data'][$section]['regie'][$counter]['photos'][$j]['file']=$query2[$j][1];
					endfor;
				endif;

				$exploded=explode(",",$query[$i][4]);
				$pos=0;
				$name="";
				foreach( $exploded as $worker):
					$query2=$db->getquery("select cod_worker, name, photo from worker where cod_worker='".$worker."'");
					$exploded=explode(" ",$query2[0][1]);
					if(isset($exploded[1])):
						$name.=$exploded[0]." ".$exploded[count($exploded)-1].", ";
					else:
						$name.=$exploded[0].", ";
					endif;
					$response['data'][$section]['regie'][$counter]['workers'][$pos]['coduser']=$query2[0][0];
					$response['data'][$section]['regie'][$counter]['workers'][$pos]['name']=encodeString($query2[0][1]);
					$response['data'][$section]['regie'][$counter]['workers'][$pos]['imgURL']=$query2[0][2];
					$pos++;
				endforeach;
				$response['data'][$section]['regie'][$counter]['workerlist']=encodeString($name);

				$counter++;
			endfor;
		else:
			$response['error'] = false; 
			$response['empty'] = true; 
			$response['message'] = $regie_no_records;
		endif;
	elseif($data['type']=="edit"):
		CheckJsonParams($data,$iv,$secretKey, array('cod'));
		$response['error'] = false; 
		$response['message'] = $checkCredentials_welcome;
		if($data['cod']<>'null'):
			$regie=$db->getquery("select start, end, workers, cod_site, cod_section, date, notas, final_duration, reason from site_regie where cod_regie='".$data['cod']."'");
			if($regie[0][0]<>''):
				$response['regie']['start']=$regie[0][0];
				$response['regie']['end']=$regie[0][1];
				$response['regie']['date']=$regie[0][5];
				$response['regie']['notes']=encodeString($regie[0][6]);
				$response['regie']['validated']=encodeString($regie[0][7]);
				$response['regie']['reason']=encodeString($regie[0][8]);

				$workers="cod_worker='".str_replace(",","' or cod_worker='",$regie[0][2])."'";
				$query3=$db->getquery("select name, cod_worker,photo from worker where ".$workers." order by name ASC");

				if ($query3[0][0]<>''):
					for($i=0;$i<count($query3);$i++):
						$response['regie']['workers'][$i]['name']=encodeString($query3[$i][0]);
						$response['regie']['workers'][$i]['code']=$query3[$i][1];			
						$response['regie']['workers'][$i]['photo']=$query3[$i][2];	
					endfor;
				endif;

				if(($regie[0][0]=="" or $regie[0][0]=="00:00:00")and($regie[0][1]=="" or $regie[0][1]=="00:00:00")): // regie is deleted
						$response['regie']['completed']=5; //$regie_deleted
				elseif($regie[0][1]=="" or $regie[0][1]=="00:00:00"): // regie is not closed
					$record=$db->getquery("select cod_worker, checkout from record where cod_site='".$regie[0][3]."' and cod_section='".$regie[0][4]."' and date='".$regie[0][5]."' order by checkout desc");							

					if ($record[0][1]<>"" and $record[0][1]<>"00:00:00"): // with checkout 
						$response['regie']['completed']=1; //$regie_checkout_eod
						$response['regie']['end']=$record[0][1];
					elseif(($record[0][1]=="" or $record[0][1]=="00:00:00") and $regie[0][5] <> date("Y-m-d")): //no checkout and not today
						$response['regie']['completed']=2; //$regie_default_eod
						$response['regie']['end']="17:30:00";
					else: // no checkout and still today
						$response['regie']['completed']=3; //$regie_ongoing
					endif;
				else:
					$response['regie']['completed']=4; //$regie_completed
				endif;
			endif;
		endif;

		if ($data['cod']=="null"): // missing verification if $_GET['date'] is valid date
			CheckJsonParams($data,$iv,$secretKey, array('date','site','section'));
			$att=$db->getquery("select record.cod_worker, worker.name, worker.photo from record left join worker on record.cod_worker=worker.cod_worker where record.cod_site='".$data['site']."' and record.cod_section='".$data['section']."' and record.date='".$data['date']."' and (record.checkin<>'00:00:00'or record.status='P' or record.status='PI') order by worker.name ASC");
		else:
			$att=$db->getquery("select record.cod_worker, worker.name, worker.photo from record left join worker on record.cod_worker=worker.cod_worker where record.cod_site='".$regie[0][3]."' and record.cod_section='".$regie[0][4]."' and record.date='".$regie[0][5]."' order by worker.name ASC");
		endif;
		if($att[0][0]<>""):
			for($i=0;$i<count($att);$i++):
				$response['attendance']['workers'][$i]['code']=$att[$i][0];
				$response['attendance']['workers'][$i]['name']=encodeString($att[$i][1]);
				$response['attendance']['workers'][$i]['photo']=$att[$i][2];	
			endfor;
		else:
			$response['error'] = true; 
			$response['message'] = $workers_no_workers_on_site;
		endif;
	else:
		$response['error'] = true; 
		$response['message'] = $invalid_request;
	endif;
elseif($data['request']=='edit'):
	CheckJsonParams($data,$iv,$secretKey, array('cod','stime','etime', 'workers','nota'));

	$regie=$db->getquery("select start, end, date from site_regie where cod_regie='".$data['cod']."'");
	if(($regie[0][1]=="" or $regie[0][1]=="00:00:00") and $regie[0][2]==date("Y-m-d", time())): // regie is not closed today
		$note= $data['nota']=="null" ? ", notas=''" : ", notas='".$data['nota']."'";
	else: // regie is closed							
		$separator=chr(13)."_______________________| ".date("Y-m-d")." |___________________________".chr(13);
		$note= ",notas=CONCAT(notas, '".$separator.$data['nota'];
		//	if start time and end time changed add to notes
		if($regie[0][0]<>$data['stime'] or $regie[0][1]<>$data['etime']):
			$note.=chr(13).chr(13)." ".$previous_time_record.": ".$regie[0][0]." - ".$regie[0][1].chr(13).chr(13);
		endif;
		$note.="')";
	endif;
	$validation= isset($data['duration']) ? ", final_duration='".$data['duration']."', reason='".($data['reason'])."'" : "";

	if($data['stime']=="null"):
		$db->setquery("update site_regie set workers='".$data['workers']."'".$note.$validation." where cod_regie='".$data['cod']."'");
	else:
		$db->setquery("update site_regie set start='".$data['stime']."', end='".$data['etime']."', workers='".$data['workers']."'".$note.$validation." where cod_regie='".$data['cod']."'");
	endif;
	$response['error'] = false; 
	$response['message'] = $regie_edit_success;
elseif($data['request']=='add'):
	CheckJsonParams($data,$iv,$secretKey, array('stime','etime','workers','date','nota', 'site', 'section'));
	$note= isset($data['nota']) ? ($data['nota']) : "";
	$validation= isset($data['duration']) ? ", final_duration='".$data['duration']."', reason='".($data['reason'])."'" : "";

	$db->setquery("insert into site_regie set start='".$data['stime']."', end='".$data['etime']."', workers='".$data['workers']."', notas='".$note."', date='".$data['date']."', cod_site='".$data['site']."', cod_section='".$data['section']."'".$validation);
	$response['error'] = false; 
	$response['message'] = $regie_add_success;
elseif($data['request']=='del'):
	CheckJsonParams($data,$iv,$secretKey, array('cod'));

	$currentRecord=$db->getquery("select start, end from site_regie where cod_regie='".$data['cod']."'");
	if(($currentRecord[0][1]=="" or $currentRecord[0][1]=="00:00:00") and ($currentRecord[0][0]=="" or $currentRecord[0][0]=="00:00:00")): // no time logging found
		$history="";
	else: // record exists						
		$history=", notas=CONCAT(notas,'".chr(13)."DELETED RECORD on ".date("Y-m-d").chr(13)."start:".$currentRecord[0][0]."; end:".$currentRecord[0][1].chr(13)."')";
	endif;

	$db->setquery("update site_regie set start='00:00:00', end='00:00:00'".$history." where cod_regie='".$data['cod']."'");
	/*
	$query=$db->getquery("select file, cod_photo from photos where db_table='site_regie' and cod_table='".$data['cod']."'");
	if ($query[0][0]<>''):
		for($i=0;$i<count($query);$i++):
			@unlink($server['root']['files']."regie/". $query[$i][0]);
			$db->setquery("delete from photos where cod_photo='".$query[$i][1]."'");
		endfor;
	endif;
	*/
	$response['error'] = false; 
	$response['message'] = $regie_del_success;
else:
	$response['error'] = true; 
	$response['message'] = $invalid_request;
endif;

?>