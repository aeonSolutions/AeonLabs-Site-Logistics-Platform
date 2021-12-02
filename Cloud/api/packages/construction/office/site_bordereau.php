<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data['request']=='load'):
	CheckJsonParams($data,$iv,$secretKey,array('p','site','sd','ed','section'));

	$section= $data['section']=="all" ? " order by bordereau.avenant asc, bordereau.previous_task asc" : " and bordereau.cod_section='".$data['section']."' order by bordereau.cod_section, bordereau.avenant asc, bordereau.previous_task asc";
	$query=$db->getquery("select bordereau.cod_task, bordereau.contractor_ref, bordereau.descricao, bordereau.pu, bordereau.qtd, bordereau.units, bordereau.enabled, bordereau.avenant, bordereau.cod_section, site_section.description, bordereau.translations, bordereau.previous_task from bordereau left join site_section on bordereau.cod_section=site_section.cod_section where bordereau.cod_site='".$data['site']."'".$section);

	$site_section = is_numeric($data['section']) ? " and cod_section='".$data['section']."'" : " ";
	$qtd_prev_query=$db->getquery("select qtd, cod_task from site_qtd_jour where cod_site='".$data['site']."' and date < '".$data['sd']."'".$site_section." order by date ASC");

	if($query[0][0]<>''):
		$params=explode(",",$data['p']);
		/* 
		pos 0 = detalhe: 1- diario, 2-semanal, 3-mensal
		pos 1 = montante por realizar
		pos 2 = montante realizado
		pos 3 = qtd por realizar
		pos 4 = qtd realizada
		pos 5 = horas
		pos 6 = rup
		*/
		$section=0;
		$counter=0;
		$crane=-1;
		$unscheduled=-1;
		$prevSection=$query[0][8];
		$response['data'][$section]['name']=$query[0][9];
		$response['data'][$section]['code']=$query[0][8];

		$sectionsArrayPos[0]=$query[0][8];
		//add activity tasks, qtds and prices
		for($i=0;$i<count($query);$i++):
			if($prevSection<>$query[$i][8]):
				$sectionsArrayPos[count($sectionsArrayPos)]=$query[$i][8];
				$section++;
				$counter=0;
				$prevSection=$query[$i][8];
				$response['data'][$section]['name']=$query[$i][9];
				$response['data'][$section]['code']=$query[$i][8];
			endif;
			$response['data'][$section]['bordereau'][$counter]['task']=$query[$i][0];
			$response['data'][$section]['bordereau'][$counter]['ref']=$query[$i][1];
			$response['data'][$section]['bordereau'][$counter]['prevtask']=$query[$i][11];

			if(mb_detect_encoding($query[$i][10], "UTF-8", true)===false):
				$JsonStr=utf8_encode($query[$i][10]);  // beware: utf8_encode is for latin1 charset
			else:
				$JsonStr=$query[$i][10];
			endif;

			if(isJson($JsonStr)):
				$language= isset($data["language"]) ? $data["language"] : "en";
				$translations = json_decode($JsonStr, true);
				if(isset($translations[$language])):
					$response['data'][$section]['bordereau'][$counter]['description']=($translations[$language]);
				else:
					$response['data'][$section]['bordereau'][$counter]['description']=($query[$i][2]);
				endif;
			else:
				$response['data'][$section]['bordereau'][$counter]['description']=($query[$i][2]);
			endif;
			
			$response['data'][$section]['bordereau'][$counter]['original']=($query[$i][2]);
			$response['data'][$section]['bordereau'][$counter]['translations']=$query[$i][10];
			$response['data'][$section]['bordereau'][$counter]['pu']=$query[$i][3];
			$response['data'][$section]['bordereau'][$counter]['qtd']=$query[$i][4];
			$response['data'][$section]['bordereau'][$counter]['units']=$query[$i][5];
			$response['data'][$section]['bordereau'][$counter]['enabled']=$query[$i][6];
			$response['data'][$section]['bordereau'][$counter]['avenant']=$query[$i][7];
			$response['data'][$section]['bordereau'][$counter]['previous']=0;
			
			if($qtd_prev_query[0][0]<>""):
				for($j=0;$j<count($qtd_prev_query);$j++):
					if($qtd_prev_query[$j][1]==$query[$i][0]):
						$response['data'][$section]['bordereau'][$counter]['previous']= strval(floatval($response['data'][$section]['bordereau'][$counter]['previous'])+  floatval($qtd_prev_query[$j][0]));
					endif;
				endfor;
			endif;

			$counter++;
		endfor;

		//add quantities recorded by workers
		$qtd_query=$db->getquery("select date, workers, qtd, cod_task, cod_section from site_qtd_jour where cod_site='".$data['site']."' and (date between '".$data['sd']."' and '".$data['ed']."') ".$site_section." order by date ASC");

		if($qtd_query[0][0]<>""):
			$response['data'][$section]['works'][0]['qtdone']="0";
			$section=array_search($qtd_query[0][4], $sectionsArrayPos);					
			$prevSection=$qtd_query[0][4];
			for($j=0;$j<count($qtd_query);$j++):
				if($prevSection<>$query[$i][4]):
					$section=array_search($qtd_query[$i][4], $sectionsArrayPos);
					$k=0;
					$prevSection=$query[$i][4];
				else:
					for($l=0;$l<count($response['data'][$section]['works']);$l++):
						if($response['data'][$section]['works'][$l]['date']==$qtd_query[$j][0] and $response['data'][$section]['works'][$l]['task']==$qtd_query[$j][3]):
							$k=$l;
						elseif($j==0):
							$k=0;
						else:	
							$k=count($response['data'][$section]['works']);
						endif;
					endfor;
				endif;

				//BUG NA SECTION on works - no section array is needed
				if($params[0]==1):// diario
					$response['data'][$section]['works'][$k]['date']=$qtd_query[$j][0];
					$response['data'][$section]['works'][$k]['task']=$qtd_query[$j][3];
					if($params[4]==1 or $params[3]==1 or $params[1]==1 or $params[2]==1): //qtd realizada
						$response['data'][$section]['works'][$k]['qtdone']=strval($response['data'][$section]['works'][$k]['qtdone']+$qtd_query[$j][2]);
					endif;
					if($params[5]==1 or $params[6]==1):
						$workers=explode(",",$qtd_query[$j][1]);
						$hours=0;
						for($l=0;$l<count($workers);$l++):
							$record=$db->getquery("select cod_record, checkin, checkout, status, absense from record where cod_worker='".$workers[$l]."' and cod_site='".$data['site']."' ".$site_section." and date='".$qtd_query[$j][0]."'");
							if($record[0][0]<>''):
								if($record[0][3]=='P'):
									$hours=$hours+10;
								elseif($record[0][3]=='PI'):
									$hours=$hours+10-$record[0][4];
								elseif($record[0][1]<>''):// checkin
									if($record[0][2]<>'')://checout
										$endTime = new DateTime($record[0][2]);
									else:
										$endTime = new DateTime();
									endif;
									$startTime = new DateTime($record[0][1]);
								$duration = $startTime->diff($endTime); //$duration is a DateInterval object	
									$hours=$hours+$duration->h;
								endif;
							else: //should not happen: worker qtd without record	
							endif;
						endfor;
						$response['data'][$section]['works'][$k]['hours']=strval($response['data'][$section]['works'][$k]['hours']+$hours);
					endif;
				endif;
			endfor;
		endif;

		//add decimal time craneman
		$gruista=$db->getquery("select cod_category from categories where reference='crn'");
		//previous decimal time craneman
		$record=$db->getquery("select record.cod_record, record.status, record.category_works_duration, record.date, record.cod_section from record left join worker on record.cod_worker=worker.cod_worker where worker.cod_category='".$gruista[0][0]."' and record.category_works_duration<>'00:00:00' and cod_site='".$data['site']."' ".$site_section." and date<'".$data['sd']."' and (record.status='P' or record.status='PI')");
		if($record[0][0]<>''):
			$startTime =strtotime("2000-01-01 00:00:00");
			$section=0;
			$prevSection=$record[0][4];
			$section=array_search($record[0][4], $sectionsArrayPos);					
			for($j=0;$j<count($record);$j++):
				if($prevSection<>$record[$i][4]):
					$posi=isset($response['data'][$section]['previousbyhour'][0]) ? count($response['data'][$section]['previousbyhour']) : 0;
					$response['data'][$section]['previousbyhour'][$posi]['task']= "C";
					if ($startTime==strtotime("2000-01-01 00:00:00")):
						$response['data'][$section]['previousbyhour'][$posi]['qtdone']="0";
					else:
						$startTimeBase = new DateTime("2000-01-01 00:00:00");
						$endTime = new DateTime(date("Y-m-d H:i:s",$startTime));
						$duration = $startTimeBase->diff($endTime); //$duration is a DateInterval object
						$response['data'][$section]['previousbyhour'][$posi]['qtdone']=strval(round($duration->format('%H')+$duration->format('%I')/60,2));
					endif;

					$section=array_search($record[$i][4], $sectionsArrayPos);
					$prevSection=$record[$i][4];
					$startTime =  strtotime("2000-01-01 00:00:00");
				endif;
				//full day
				$record[$j][2]= ($record[$j][2]=="00:00:01") ? "10:00:00" : $record[$j][2];

				$startTime+=strtotime("2000-01-01 ".$record[$j][2]);
			endfor;
			$posi=isset($response['data'][$section]['previousbyhour'][0]) ? count($response['data'][$section]['previousbyhour']) : 0;
			$startTimeBase = new DateTime("2000-01-01 00:00:00");
			$endTime = new DateTime(date("Y-m-d H:i:s",$startTime));
			$duration = $startTimeBase->diff($endTime); //$duration is a DateInterval object
			$response['data'][$section]['previousbyhour'][$posi]['task']= "C";
			$response['data'][$section]['previousbyhour'][$posi]['qtdone']=strval(round($duration->format('%H')+$duration->format('%I')/60,2));
		endif;

		//current decimal time craneman
		$record=$db->getquery("select record.cod_record, record.status, record.category_works_duration, record.date, record.cod_section from record left join worker on record.cod_worker=worker.cod_worker where worker.cod_category='".$gruista[0][0]."' and record.category_works_duration<>'00:00:00' and cod_site='".$data['site']."' ".$site_section." and (date between '".$data['sd']."' and '".$data['ed']."') and (record.status='P' or record.status='PI')");
		$section=0;
		if($record[0][0]<>''):
			$prevSection=$record[0][4];
			$section=array_search($record[0][4], $sectionsArrayPos);					
			for($j=0;$j<count($record);$j++):
				if($prevSection<>$record[$i][4]):
					$section=array_search($record[$i][4], $sectionsArrayPos);
					$prevSection=$record[$i][4];
				endif;
				//full day
				$record[$j][2]= ($record[$j][2]=="00:00:01") ? "10:00:00" : $record[$j][2];

				$startTime = strtotime("2000-01-01 ".$record[$j][2]);
				$posi=isset($response['data'][$section]['works'][0]) ? count($response['data'][$section]['works']) : 0;
				$response['data'][$section]['works'][$posi]['date']= $record[$j][3];
				$response['data'][$section]['works'][$posi]['task']="C";
				$response['data'][$section]['works'][$posi]['rup']="0.0";
				$response['data'][$section]['works'][$posi]['hours']="0.0";
				if ($startTime==strtotime("2000-01-01 00:00:00")):
					$response['data'][$section]['works'][$posi]['qtdone']="0";
				else:
					$startTimeBase = new DateTime("2000-01-01 00:00:00");
					$endTime = new DateTime(date("Y-m-d H:i:s",$startTime));
					$duration = $startTimeBase->diff($endTime); //$duration is a DateInterval object
					$response['data'][$section]['works'][$posi]['qtdone']=strval(round($duration->format('%H')+$duration->format('%I')/60,2));
				endif;
			endfor;
		endif;

		$machinist=$db->getquery("select cod_category from categories where reference='crn'");
		//previous decimal time machinist
		$record=$db->getquery("select record.cod_record, record.status, record.category_works_duration, record.date, record.cod_section from record left join worker on record.cod_worker=worker.cod_worker where worker.cod_category<>'".$gruista[0][0]."' and record.category_works_duration<>'00:00:00' and cod_site='".$data['site']."' ".$site_section." and date<'".$data['sd']."' and (record.status='P' or record.status='PI')");
		if($record[0][0]<>''):
			$startTime =strtotime("2000-01-01 00:00:00");
			$section=0;
			$prevSection=$record[0][4];
			$section=array_search($record[0][4], $sectionsArrayPos);					
			for($j=0;$j<count($record);$j++):
				if($prevSection<>$record[$i][4]):
					$posi=isset($response['data'][$section]['previousbyhour'][0]) ? count($response['data'][$section]['previousbyhour']) : 0;
					$response['data'][$section]['previousbyhour'][$posi]['task']= "M";
					if ($startTime==strtotime("2000-01-01 00:00:00")):
						$response['data'][$section]['previousbyhour'][$posi]['qtdone']="0";
					else:
						$startTimeBase = new DateTime("2000-01-01 00:00:00");
						$endTime = new DateTime(date("Y-m-d H:i:s",$startTime));
						$duration = $startTimeBase->diff($endTime); //$duration is a DateInterval object
						$response['data'][$section]['previousbyhour'][$posi]['qtdone']=strval(round($duration->format('%H')+$duration->format('%I')/60,2));
					endif;

					$section=array_search($record[$i][4], $sectionsArrayPos);
					$prevSection=$record[$i][4];
					$startTime =  strtotime("2000-01-01 00:00:00");
				endif;
				//full day
				$record[$j][2]= ($record[$j][2]=="00:00:01") ? "10:00:00" : $record[$j][2];

				$startTime+=strtotime("2000-01-01 ".$record[$j][2]);
			endfor;
			$posi=isset($response['data'][$section]['previousbyhour'][0]) ? count($response['data'][$section]['previousbyhour']) : 0;
			$startTimeBase = new DateTime("2000-01-01 00:00:00");
			$endTime = new DateTime(date("Y-m-d H:i:s",$startTime));
			$duration = $startTimeBase->diff($endTime); //$duration is a DateInterval object
			$response['data'][$section]['previousbyhour'][$posi]['task']= "M";
			$response['data'][$section]['previousbyhour'][$posi]['qtdone']=strval(round($duration->format('%H')+$duration->format('%I')/60,2));
		endif;

		//add decimal time machinist
		$record=$db->getquery("select record.cod_record, record.status, record.category_works_duration, record.date, record.cod_section from record left join worker on record.cod_worker=worker.cod_worker where worker.cod_category<>'".$gruista[0][0]."' and record.category_works_duration<>'00:00:00' and cod_site='".$data['site']."' ".$site_section." and (date between '".$data['sd']."' and '".$data['ed']."') and (record.status='P' or record.status='PI')");
		$section=0;
		if($record[0][0]<>''):
			$prevSection=$record[0][4];
			$section=array_search($record[0][4], $sectionsArrayPos);					
			for($j=0;$j<count($record);$j++):
				if($prevSection<>$record[$i][4]):
					$section=array_search($record[$i][4], $sectionsArrayPos);
					$prevSection=$record[$i][4];
				endif;
				//full day
				$record[$j][2]= ($record[$j][2]=="00:00:01") ? "10:00:00" : $record[$j][2];
				$startTime = strtotime("2000-01-01 ".$record[$j][2]);
				$posi=isset($response['data'][$section]['works'][0]) ? count($response['data'][$section]['works']) : 0;
				$response['data'][$section]['works'][$posi]['date']= $record[$j][3];
				$response['data'][$section]['works'][$posi]['task']="M";
				$response['data'][$section]['works'][$posi]['rup']="0.0";
				$response['data'][$section]['works'][$posi]['hours']="0.0";
				if ($startTime==strtotime("2000-01-01 00:00:00")):
					$response['data'][$section]['works'][$posi]['qtdone']="0";
				else:
					$startTimeBase = new DateTime("2000-01-01 00:00:00");
					$endTime = new DateTime(date("Y-m-d H:i:s",$startTime));
					$duration = $startTimeBase->diff($endTime); //$duration is a DateInterval object
					$response['data'][$section]['works'][$posi]['qtdone']=strval(round($duration->format('%H')+$duration->format('%I')/60,2));
				endif;
			endfor;
		endif;

		$site_section= $data['section']=="all" ? "" : " and cod_section='".$data['section']."'";
		// previous decimal time regies 
		$regie=$db->getquery("select time_format(start, '%H:%i:00'), workers, time_format(end, '%H:%i:00'), date, cod_section from site_regie where cod_site='".$data['site']."' and date<'".$data['sd']."' ".$site_section);
		$totalRegiePrevious=0.0;
		$section=0;
		if($regie[0][0]<>''): // results found
			$prevSection=$qtd_query[0][4];
			$section=array_search($qtd_query[0][4], $sectionsArrayPos);					
			for($i = 0; $i < count($regie); $i++): 	
				$exploded=explode(",",$regie[$i][1]);
				$str=" and (";
				$counter=0;
				foreach( $exploded as $worker):
					$str.= $counter==0 ? " cod_worker='".$worker."'" : " or cod_worker='".$worker."'";
					$counter++;
				endforeach;
				$str= $str==" and (" ? "" : $str.")";

				if(($regie[$i][2]<>"" and $regie[$i][2]<>"00:00:00") and ($regie[$i][0]<>"" and $regie[$i][0]<>"00:00:00")):  // regie closed
					$end=substr($regie[$i][3],0,5); //09:38
				elseif(($regie[$i][2]=="" or $regie[$i][2]=="00:00:00") and ($regie[$i][0]<>"" and $regie[$i][0]<>"00:00:00")): // end time not logged
					$record=$db->getquery("select cod_worker, checkout from record where cod_site='".$data['site']."' ".$site_section." and date='".$regie[$i][3]."'".$str." order by checkout desc");

					if ($record[0][1]<>"" and $record[0][1]<>"00:00:00"):
						$regie[$i][2]=$record[0][1];
					elseif(($record[0][1]=="" or $record[0][1]=="00:00:00") and $regie[$i][3] <> date("Y-m-d")): //no checkout and not today
						$regie[$i][2]="17:30:00";
					else: // no checkout and still today
						$regie[$i][2]=date("H:i:00", time());
					endif;

				endif;
				$tstend=$regie[$i][2];

				$startTime = new DateTime($regie[$i][0]);
				$hour=substr($regie[$i][2],0,2);
				$hourStart=substr($regie[$i][0],0,2);
				$min=substr($regie[$i][2],3,5);
				$end_time=$regie[$i][2];
				if($hour>13 and $hourStart<13): // remover 30 min do almoÃƒÂ§o
					$time = strtotime(date($regie[$i][3]." ".$regie[$i][2]));
					$time = $time - (30 * 60);
					$end_time= date("H:i:00", $time);
				endif;

				$endTime = new DateTime($end_time);
				$duration = $startTime->diff($endTime); //$duration is a DateInterval object	

				if($hour>=17 and $min>=30): // calc horas extraordinarias
					$startTime = new DateTime("17:30:00");
					$endTime = new DateTime($end_time);
					$extra = $startTime->diff($endTime); //$duration is a DateInterval object
					$extra=" (".$extra->format("%Hh%I").")";
				else:
					$extra="";
				endif;
				if($prevSection<>$regie[$i][4]):
					$section=array_search($regie[$i][4], $sectionsArrayPos);
					$prevSection=$query[$i][4];

					$posi=isset($response['data'][$section]['previousbyhour'][0]) ? count($response['data'][$section]['previousbyhour']) : 0;
					$response['data'][$section]['previousbyhour'][$posi]['task']= "R";
					$response['data'][$section]['previousbyhour'][$posi]['qtdone']=$totalRegiePrevious;		

					$totalRegiePrevious=0.0;
				else:
					$totalRegiePrevious+=strval(round(($duration->format("%H")+round($duration->format("%I")/60,2))*$counter,2));
				endif;
			endfor;
		endif;
		$posi=isset($response['data'][$section]['previousbyhour'][0]) ? count($response['data'][$section]['previousbyhour']) : 0;
		$response['data'][$section]['previousbyhour'][$posi]['task']= "R";
		$response['data'][$section]['previousbyhour'][$posi]['qtdone']=strval($totalRegiePrevious);

		// add decimal time regies 
		$regie=$db->getquery("select time_format(start, '%H:%i:00'), workers, time_format(end, '%H:%i:00'), date, cod_section from site_regie where cod_site='".$data['site']."' and (date between '".$data['sd']."' and '".$data['ed']."') ".$site_section);

		$section=0;
		if($regie[0][0]<>''): // results found
			$prevSection=$qtd_query[0][4];
			$section=array_search($qtd_query[0][4], $sectionsArrayPos);					
			for($i = 0; $i < count($regie); $i++): 	
				if($prevSection<>$query[$i][4]):
					$section=array_search($qtd_query[$i][4], $sectionsArrayPos);
					$prevSection=$query[$i][4];
				endif;

				$exploded=explode(",",$regie[$i][1]);
				$str=" and (";
				$counter=0;
				foreach( $exploded as $worker):
					$str.= $counter==0 ? " cod_worker='".$worker."'" : " or cod_worker='".$worker."'";
					$counter++;
				endforeach;
				$str= $str==" and (" ? "" : $str.")";

				if(($regie[$i][2]<>"" and $regie[$i][2]<>"00:00:00") and ($regie[$i][0]<>"" and $regie[$i][0]<>"00:00:00")):  // regie closed
					$end=substr($regie[$i][3],0,5); //09:38
				elseif(($regie[$i][2]=="" or $regie[$i][2]=="00:00:00") and ($regie[$i][0]<>"" and $regie[$i][0]<>"00:00:00")): // end time not logged
					$record=$db->getquery("select cod_worker, checkout from record where cod_site='".$data['site']."' ".$site_section." and date='".$regie[$i][3]."'".$str." order by checkout desc");

					if ($record[0][1]<>"" and $record[0][1]<>"00:00:00"):
						$regie[$i][2]=$record[0][1];
					elseif(($record[0][1]=="" or $record[0][1]=="00:00:00") and $regie[$i][3] <> date("Y-m-d")): //no checkout and not today
						$regie[$i][2]="17:30:00";
					else: // no checkout and still today
						$regie[$i][2]=date("H:i:00", time());
					endif;

				endif;
				$tstend=$regie[$i][2];

				$startTime = new DateTime($regie[$i][0]);
				$hour=substr($regie[$i][2],0,2);
				$hourStart=substr($regie[$i][0],0,2);
				$min=substr($regie[$i][2],3,5);
				$end_time=$regie[$i][2];
				if($hour>13 and $hourStart<13): // remover 30 min do almoÃƒÂ§o
					$time = strtotime(date($regie[$i][3]." ".$regie[$i][2]));
					$time = $time - (30 * 60);
					$end_time= date("H:i:00", $time);
				endif;

				$endTime = new DateTime($end_time);
				$duration = $startTime->diff($endTime); //$duration is a DateInterval object	

				if($hour>=17 and $min>=30): // calc horas extraordinarias
					$startTime = new DateTime("17:30:00");
					$endTime = new DateTime($end_time);
					$extra = $startTime->diff($endTime); //$duration is a DateInterval object
					$extra=" (".$extra->format("%Hh%I").")";
				else:
					$extra="";
				endif;
				$posi=isset($response['data'][$section]['works'][0]) ? count($response['data'][$section]['works']) : 0;
				$response['data'][$section]['works'][$posi]['date']=$regie[$i][3];
				$response['data'][$section]['works'][$posi]['task']="R";
				$response['data'][$section]['works'][$posi]['rup']="0.0";
				$response['data'][$section]['works'][$posi]['hours']="0.0";
				$response['data'][$section]['works'][$posi]['qtdone']=strval(round(($duration->format("%H")+round($duration->format("%I")/60,2))*$counter,2));
			endfor;
		endif;

		$response['error'] = false; 
		$response['message'] = $checkCredentials_welcome;
	else:
		$response['error'] = true; 
		$response['message'] = $map_not_found;
	endif;
else:
	$response['error'] = true; 
	$response['message'] = $invalid_request;
endif;

?>