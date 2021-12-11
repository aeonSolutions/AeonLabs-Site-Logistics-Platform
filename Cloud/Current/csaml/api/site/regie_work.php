<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

if(isset($data['type'])):
	if($data['type']=='add'):
		CheckJsonParams($data,$iv,$secretKey, array('gest','workers'));
		$response['error'] = false;
		$workersToAdd=explode(",",$data['workers']);
		$manager=$db->getquery("select cod_manager, auth_string from site_manager where cod_site='".$data['site']."' and cod_nfc='".$data['gest']."' and cod_section='".$data['section']."'");
		if($manager[0][0]<>''):
			$query2=$db->getquery("select workers from site_regie where date='".date('Y-m-d', time())."' and start<='".date('H:i:s',time())."' and end=''");
			if($query2[0][0]<>''): // open regie found
				$workerFound=false;
				for($i=0;$i<count($query2);$i++):
					foreach( $workersToAdd as $worker):
						$arr=explode(",",$query2[$i][0]);
						if(in_array($worker,$arr)):
							$workerFound=true;
							$query3=$db->getquery("select name from worker where cod_worker='".$worker."'");
							$exploded=explode(" ",$query3[0][0]);
							if(isset($exploded[1])):
								$name=$exploded[0]." ".$exploded[count($exploded)-1];
							else:
								$name=$exploded[0];
							endif;
							$response['error'] = true;
							$response['message'] =encodeString($name).' '.$regie_work_worker_already_at_regie;
						endif;	
					endforeach;
				endfor;
			endif;
			if($response['error']==false):
				$db->setquery("insert into site_regie set cod_site='".$data['site']."', cod_section='".$data['section']."', date='".date('Y-m-d', time())."', start='".date('H:i:s',time())."', workers='".$data['workers']."', start_auth_string_manager='".manager[0][1]."', record_type=concat(record_type,'-ForemanStart- ')");
				$response['error'] = false; 
				$response['message'] = (count($exploded)==0 ? "1": count($exploded)).' '.$regie_work_workers_at_regie.' '.date('H:i',time());
				
				
				//ADD history record
				AddHistoryRecord($db, $data['site'], $data['section'], $codTable,"site_regie", getUserName($db, $data, "foreman"), "Foreman", "delay", "late scheduling will cause a delay on planning. max delay expected: ".count($workersToAdd)." days of work");
			endif;
		else:
			$response['error'] = true; 
			$response['message'] =$regie_work_conducteur_not_found;
		endif;
	elseif($data['type']=='edit'):
		CheckJsonParams($data,$iv,$secretKey, array('cod','nota'));
		$db->setquery("update site_regie set notas='".encodeString16($data['nota'])."' where cod_regie='".$data['cod']."'");
		$response['error'] = false; 
		$response['message'] =$regie_work_note_saved;
	elseif($data['type']=='entries'):
		$query=$db->getquery("select date from site_regie where cod_site='".$data['site']."' and cod_section='".$data['section']."'");
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
	elseif ($data['type']=='close'):
		$response['error'] = false;
		$manager=$db->getquery("select cod_manager, auth_string from site_manager where cod_site='".$data['site']."' and cod_section='".$data['section']."' and cod_nfc='".$data['gest']."'");
		if($manager[0][0]<>''):
			$query=$db->getquery("select start from site_regie where date='".date('Y-m-d', time())."' and start like '%".str_replace("h",":",$data['hour'])."%' and cod_site='".$data['site']."' and cod_section='".$data['section']."'");
			if($query[0][0]<>''):
				if(!isset($data['notas'])):
					$notas="";
				else:
					$notas="_______________________________________".chr(13).encodeString16($data['notas']);
				endif;
				$db->setquery("update site_regie set end='".date('H:i:s',time())."', notas=concat(notas,'".$notas."'), end_auth_string_manager='".manager[0][1]."', record_type=concat(record_type,'-ForemanEnd-') where cod_site='".$data['site']."'and date='".date('Y-m-d', time())."' and start='".$query[0][0]."' and cod_section='".$data['section']."'");
				$response['error'] = false; 
				$response['message'] = $regie_work_closed_successfully.' : '.date('H:i',time());					
			else:
				$response['error'] = true; 
				$response['message'] =$regie_work_regie_not_found;
			endif;
		else:
			$response['error'] = true; 
			$response['message'] =$regie_work_conducteur_not_found;
		endif;		
	elseif($data['type']=='list'):
		if(isset($data['date'])):
			$date=$data['date'];
			$query=$db->getquery("select time_format(start, '%H:%i:%s'), workers, notas, end, cod_regie, date from site_regie where cod_site='".$data['site']."' and date='".$date."' and cod_section='".$data['section']."'");
		else: // terminar regie
			$date=date("Y-m-d");
			$query=$db->getquery("select time_format(start, '%H:%i:%s'), workers, notas, end, cod_regie, date from site_regie where cod_site='".$data['site']."' and cod_section='".$data['section']."' and date='".$date."' and (end='' or end='00:00:00')");
		endif;
		if($query[0][0]<>''): // results found
			$response['error'] = false; 
			$response['message'] ='Bem vindo';
			for($i = 0; $i < count($query); $i++):

				if($query[$i][3]<>"00:00:00"):
					$end=substr($query[$i][3],0,5); //09:38
				else: // end time not logged
					$exploded=explode(",",$query[$i][1]);
					$str=" and (";
					$counter=0;
					foreach( $exploded as $worker):
						$str.= $counter==0 ? " cod_worker='".$worker."'" : " or cod_worker='".$worker."'";
						$counter++;
					endforeach;
					$str= $str==" and (" ? "" : $str.")";

					$record=$db->getquery("select cod_worker, checkout from record where cod_site='".$data['site']."' and cod_section='".$data['section']."' and date='".$date."'".$str." order by checkout desc");

					if ($record[0][1]<>"" and $record[0][1]<>"00:00:00"):
						$query[$i][3]=$record[0][1];
						$end=" auto checkout";
					elseif(($record[0][1]=="" or $record[0][1]=="00:00:00") and $date <> date("Y-m-d")): //no checkout and not today
						$query[$i][3]="17:30:00";
						$end=$regie_work_without_record;
					else: // no checkout and still today
					$query[$i][3]=date("H:i:s", time());
					$end=" ".$regie_work_ongoing;
					endif;

				endif;
				$startTime = new DateTime($query[$i][0]);
				$hour=substr($query[$i][3],0,2);
				$hourStart=substr($query[$i][0],0,2);
				$min=substr($query[$i][3],3,5);
				$end_time=$query[$i][3];
				if($hour>13 and $hourStart<=13): // remover 30 min do almoço
					$time = strtotime(date($query[$i][5]." ".$query[$i][3]));
					$time = $time - (30 * 60);
					$end_time= date("H:i:s", $time);
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
				$response['data'][$i]['hora']=substr(str_replace(":","h",$query[$i][0]),0,5);
				$response['data'][$i]['notas']=encodeString($query[$i][2]);
				$response['data'][$i]['code']=$query[$i][4];
				$response['data'][$i]['horafim']=$end."[newline]".$regie_work_duration." ".$duration->format("%Hh%I").$extra;
				$response['data'][$i]['imgURL']="quantities.png";
				$exploded=explode(",",$query[$i][1]);
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

					$response['data'][$i]['workers'][$pos]['coduser']=$query2[0][0];
					$response['data'][$i]['workers'][$pos]['name']=encodeString($query2[0][1]);
					$response['data'][$i]['workers'][$pos]['imgURL']=$query2[0][2];
					$pos++;
				endforeach;
				$response['data'][$i]['workerlist']=encodeString($name);
			endfor;
		else:
			$response['error'] = true;
			$response['message'] =$regie_work_regie_not_found_for_selected_date;
		endif;
	else:
		$response['error'] = true;
		$response['message'] ='Invalid GET request';
	endif;
else:
	$response['error'] = true;
	$response['message'] ='Invalid GET request';
endif;
?>