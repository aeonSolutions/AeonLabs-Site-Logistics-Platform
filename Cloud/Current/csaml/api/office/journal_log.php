<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

$logger_start=$db->getquery("select distinct TIME_FORMAT(checkin , '%H:%i:%s') from record where checkin<>'' and cod_site='".$data['site']."' and date='".$data['date']."' and cod_section='".$data['section']."'");
$logger_end=$db->getquery("select distinct TIME_FORMAT(checkout , '%H:%i:%s')from record where checkout<>'' and cod_site='".$data['site']."' and date='".$data['date']."' and cod_section='".$data['section']."'");
$regie=$db->getquery("select workers, notas, TIME_FORMAT(start , '%H:%i:%s'), TIME_FORMAT(end , '%H:%i:%s') from site_regie where cod_site='".$data['site']."' and date='".$data['date']."' and cod_section='".$data['section']."' order by start asc");
$qtds=$db->getquery("select TIME_FORMAT(site_qtd_jour.log_time, '%H:%i:%s'), site_qtd_jour.workers, site_qtd_jour.qtd, site_qtd_jour.notas, bordereau.descricao, bordereau.units from site_qtd_jour left join bordereau on site_qtd_jour.cod_task=bordereau.cod_task where site_qtd_jour.cod_site='".$data['site']."' and site_qtd_jour.date='".$data['date']."' and site_qtd_jour.cod_section='".$data['section']."' order by site_qtd_jour.log_time asc");
$livraison=$db->getquery("select TIME_FORMAT(log_time, '%H:%i:%s'), cod_delivery, ref_doc, material, qtd, units, notas from site_delivery where cod_site='".$data['site']."' and cod_section='".$data['section']."' and date='".$data['date']."' order by log_time asc");
$journal=$db->getquery("select TIME_FORMAT(time, '%H:%i:%s'), note, cod_worker from site_journal where cod_site='".$data['site']."' and cod_section='".$data['section']."' and date='".$data['date']."' order by time asc");
$weather=$db->getquery("select distinct from_unixtime( UNIX_TIMESTAMP(time),'%H:%i:%s' ), weather from site_weather where cod_site='".$data['site']."' and cod_section='".$data['section']."'and time between '".($data['date']." 00:00:00")."' and '".($data['date']." 23:59:59")."' order by time asc");

$pos=0;
if($logger_start[0][0]<>''):
	for($i=0;$i<count($logger_start);$i++):
		$arr[$pos]['time']=strtotime($data['date']." ".$logger_start[$i][0]);
		$arr[$pos]['position']=$i;
		$arr[$pos]['var']='logger_start';
		$pos++;
	endfor;
endif;
if($logger_end[0][0]<>''):
	for($i=0;$i<count($logger_end);$i++):
		$arr[$pos]['time']=strtotime($data['date']." ".$logger_end[$i][0]);
		$arr[$pos]['position']=$i;
		$arr[$pos]['var']='logger_end';
		$pos++;
	endfor;
endif;
if($regie[0][0]<>''):
	for($i=0;$i<count($regie);$i++):
		$arr[$pos]['time']=strtotime($data['date']." ".$regie[$i][2]);
		$arr[$pos]['position']=$i;
		$arr[$pos]['var']='regie';
		$pos++;
	endfor;
endif;
if($qtds[0][0]<>''):
	for($i=0;$i<count($qtds);$i++):
		$arr[$pos]['time']=strtotime($data['date']." ".$qtds[$i][0]);
		$arr[$pos]['position']=$i;
		$arr[$pos]['var']='qtds';
		$pos++;
	endfor;
endif;
if($livraison[0][0]<>''):
	for($i=0;$i<count($livraison);$i++):
		$arr[$pos]['time']=strtotime($data['date']." ".$livraison[$i][0]);
		$arr[$pos]['position']=$i;
		$arr[$pos]['var']='livraison';
		$pos++;
	endfor;
endif;
if($journal[0][0]<>''):
	for($i=0;$i<count($journal);$i++):
		$arr[$pos]['time']=strtotime($data['date']." ".$journal[$i][0]);
		$arr[$pos]['position']=$i;
		$arr[$pos]['var']='journal';
		$pos++;
	endfor;
endif;
if($weather[0][0]<>''):
	for($i=0;$i<count($weather);$i++):
		$arr[$pos]['time']=strtotime($data['date']." ".$weather[$i][0]);
		$arr[$pos]['position']=$i;
		$arr[$pos]['var']='weather';
		$pos++;
	endfor;
endif;

if(count($arr)<1):
	$response['error'] = true; 
	$response['message'] = ' não existem registos';
	echo json_encode($response);
	die();
else:
	foreach ($arr as $key => $row) {
		$time[$key] = $row['time'];
	}

	array_multisort($time, SORT_ASC, $arr);
endif;
$response['error'] = false; 
$response['message'] = 'Bem vindo';


for($i=0;$i<count($arr);$i++):
	if($arr[$i]['var']=='logger_start'):
		$response['data'][$i]['time']=date("H:i",strtotime($data['date']." ".$logger_start[$arr[$i]['position']][0]));
		$response['data'][$i]['title']='Registo de presenças';
	elseif($arr[$i]['var']=='logger_end'):
		$response['data'][$i]['time']=date("H:i",strtotime($data['date']." ".$logger_end[$arr[$i]['position']][0]));
		$response['data'][$i]['title']='Registo de presenças';
	elseif($arr[$i]['var']=='regie'):
		if($regie[$arr[$i]['position']][3]<>"00:00:00"):
			$end=substr($regie[$arr[$i]['position']][3],0,5); //09:38
		else: // end time not logged
			$exploded=explode(",",$regie[$arr[$i]['position']][0]);
			$str=" and (";
			$counter=0;
			foreach( $exploded as $worker):
				$str.= $counter==0 ? " cod_worker='".$worker."'" : " or cod_worker='".$worker."'";
				$counter++;
			endforeach;
			$str= $str==" and (" ? "" : $str.")";

			$record=$db->getquery("select cod_worker, checkout from record where cod_site='".$data['site']."' and cod_section='".$data['section']."' and date='".$data['date']."'".$str." order by checkout desc");

			if ($record[0][1]<>"" and $record[0][1]<>"00:00:00"):
				$regie[$arr[$i]['position']][3]=$record[0][1];
				$end=" auto checkout";
			elseif(($record[0][1]=="" or $record[0][1]=="00:00:00") and $data['date'] <> date("Y-m-d")): //no checkout and not today
				$regie[$arr[$i]['position']][3]="17:30:00";
				$end="s/ reg.";
			else: // no checkout and still today
			$regie[$arr[$i]['position']][3]=date("H:i:s", time());
			$end=" a decorrer";
			endif;

		endif;
		$startTime = new DateTime($regie[$arr[$i]['position']][2]);
		$hour=substr($regie[$arr[$i]['position']][3],0,2);
		$hourStart=substr($regie[$arr[$i]['position']][2],0,2);
		$min=substr($regie[$arr[$i]['position']][3],3,5);
		$end_time=$regie[$arr[$i]['position']][3];
		if($hour>13 and $hourStart<=13): // remover 30 min do almoço
			$time = strtotime(date($data['date']." ".$regie[$arr[$i]['position']][3]));
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

		$response['data'][$i]['time']=substr(str_replace(":","h",$regie[$arr[$i]['position']][2]),0,5);
		$response['data'][$i]['title']='Marcação de trabalho à Régie';
		$response['data'][$i]['text']="Fim: ".$end."     Duração ".$duration->format("%H:%I")."[newline]Horas extraordinárias:".$extra;


		$exploded=explode(",",$regie[$arr[$i]['position']][0]);
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
		endforeach;
		$response['data'][$i]['text'].="[newline][newline]Trabalhadores afetos:[newline]".encodeString($name);
		$response['data'][$i]['text'].="[newline][newline]Anotações:[newline]".$regie[$arr[$i]['position']][1];

		$response['data'][$i]['title']=encodeString($response['data'][$i]['title']);
		$response['data'][$i]['text']=encodeString($response['data'][$i]['text']);

	elseif($arr[$i]['var']=='qtds'):
		$arrw=explode(",",$qtds[$arr[$i]['position']][1]);
		$string="";
		for($k=0;$k<count($arrw);$k++):
			$string.= ($k==0) ? "cod_worker='".$arrw[$k]."'" : "or cod_worker='".$arrw[$k]."' ";
		endfor;
		$workers=$db->getquery("select name from worker where ".$string);
		$string="";
		for($k=0; $k<count($workers); $k++):
			$exploded=explode(" ",$workers[$k][0]);
			if(isset($exploded[1])):
				$name=$exploded[0]." ".$exploded[count($exploded)-1];
			else:
				$name=$exploded[0];
			endif;
			$string.= ($k==(count($workers)-1)) ? $name : $name."[newline]";
		endfor;

		$response['data'][$i]['time']=date("H:i",strtotime($data['date']." ".$qtds[$arr[$i]['position']][0]));
		$response['data'][$i]['title']='Registo de Qtd executada';					
		$response['data'][$i]['text']=$qtds[$arr[$i]['position']][2]." ".$qtds[$arr[$i]['position']][5]."[newline]";
		$response['data'][$i]['text'].=$qtds[$arr[$i]['position']][4]."[newline][newline]";
		$response['data'][$i]['text'].=$string."[newline]";
		$response['data'][$i]['text'].=$qtds[$arr[$i]['position']][3];

		$response['data'][$i]['title']=encodeString($response['data'][$i]['title']);
		$response['data'][$i]['text']=encodeString($response['data'][$i]['text']);
	elseif($arr[$i]['var']=='livraison'):
		$response['data'][$i]['time']=date("H:i",strtotime($data['date']." ".$livraison[$arr[$i]['position']][0]));
		$response['data'][$i]['code']=$livraison[$arr[$i]['position']][1];
		$response['data'][$i]['title']='Entrega de material em obra';					
		$response['data'][$i]['text']="Ref. Doc.: ".$livraison[$arr[$i]['position']][2]."[newline][newline]Material: ".$livraison[$arr[$i]['position']][3]."[newline]";
		$response['data'][$i]['text'].="Quantidade: ".$livraison[$arr[$i]['position']][4]." ".$livraison[$arr[$i]['position']][5]."[newline]";
		$response['data'][$i]['text'].="Notas:[newline]".$livraison[$arr[$i]['position']][6];

		$query2=$db->getquery("select file, cod_photo from photos where db_table='site_delivery' and cod_table='".$livraison[$arr[$i]['position']][1]."'");
		if($query2[0][0]<>''):
			for($k=0; $k<count($query2);$k++):
				$response['data'][$i]['photos'][$k]['file']=$query2[$k][0];
				$response['data'][$i]['photos'][$k]['code']=$query2[$k][1];
			endfor;
		endif;

		$response['data'][$i]['title']=encodeString($response['data'][$i]['title']);
		$response['data'][$i]['text']=encodeString($response['data'][$i]['text']);				 
	elseif($arr[$i]['var']=='journal'):
		$response['data'][$i]['time']=date("H:i", strtotime($data['date']." ".$journal[$arr[$i]['position']][0]));
		$response['data'][$i]['photo']=$journal[$arr[$i]['position']][3];
		$response['data'][$i]['title']='Entrada no Jornal';
		$response['data'][$i]['text']=$journal[$arr[$i]['position']][1];

		$response['data'][$i]['title']=encodeString($response['data'][$i]['title']);
		$response['data'][$i]['text']=encodeString($response['data'][$i]['text']);					
	elseif($arr[$i]['var']=='weather'):				
		$json=json_decode($weather[$arr[$i]['position']][1],true);

		$response['data'][$i]['time']=date("H:i", strtotime($data['date']." ".$weather[$arr[$i]['position']][0]));
		$response['data'][$i]['title']='Informação meteorologica';
		$response['data'][$i]['text']=$json['weather'][0]['description']."[newline]";
		$response['data'][$i]['text'].="Temp.: ".$json['main']['temp']."°C   Vento:".$json['wind']['speed']." km/h";
		$response['data'][$i]['icon']=$json['weather'][0]['icon'];

		$response['data'][$i]['title']=encodeString($response['data'][$i]['title']);
		$response['data'][$i]['text']=encodeString($response['data'][$i]['text']);	
	endif;

endfor;
?>