<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

if($data['type']=='category'):
	$date= (isset($data['date'])) ? $data['date'] : date('Y-m-01', time());

	$query ="select COALESCE(NULLIF(record.cod_category,''), worker.cod_category), categories.name, worker.name from record left join worker on worker.cod_worker=record.cod_worker left join categories on COALESCE(NULLIF(record.cod_category,''), worker.cod_category)=categories.cod_category where record.date='".$date."' and record.cod_site='".$data['site']."' and record.cod_section='".$data['section']."' group by worker.name order by record.cod_site asc, record.cod_section asc, COALESCE(NULLIF(record.cod_category,''), worker.cod_category)  asc";
	if($query[0][0]<>''): // results found
		$response['error'] = false; 
		$response['message'] ='Bem vindo';
		$imgPile=array('','','stonemason.png','carpenter.png','steelworks.png');
		$pos=0;
		for($i = 0; $i < count($query); $i++):
			if($query[$i][0]=='2' or $query[$i][0]=='3' or $query[$i][0]=='4')://pedreiro, carpinteiro, ferrageiro
				$response['data'][$pos]['name']=encodeString($query[$i][1]);
				$response['data'][$pos]['CodCat']=$query[$i][0];
				$response['data'][$pos]['imgURL']=$imgPile[$query[$i][0]];
				$response['data'][$pos]['workers']="";
				
				$exploded=explode(" ",$query[$i][2]);
				if(isset($exploded[1])):
					$name=$exploded[0]." ".$exploded[count($exploded)-1];
				else:
					$name=$exploded[0];
				endif;
				if($k==0):
					$response['data'][$pos]['workers']=encodeString($name);
				else:
					$response['data'][$pos]['workers']=$response['data'][$pos]['workers'].', '.encodeString($name);
				endif;
				$pos++;
			endif;
		endfor;
		if(!isset($response['data'][0]['name'])):
			$response['error'] = true; 
			$response['message'] =$list_on_journal_workers_onsite_today_team_not_found;
		endif;
	else:
		$response['error'] = true; 
		$response['message'] =$list_on_journal_workers_onsite_today_team_not_found;
	endif;
elseif($data['type']=='worker'):
	$date= (isset($data['date'])) ? $data['date'] : date('Y-m-d', time());
	$query=$db->getquery("select worker.cod_worker, record.checkin, record.checkout, worker.name, worker.photo from record left join worker on record.cod_worker=worker.cod_worker where record.cod_site='".$data['site']."' and record.cod_section='".$data['section']."' and date='".$date."' and (record.checkin<>'00:00:00' or record.status='P') group by worker.cod_worker ");
	
	if($query[0][0]<>''):
		$response['error'] = false; 
		$response['message'] ='Bem vindo';
		for($i = 0; $i < count($query); $i++):
			$exploded=explode(" ",$query[$i][3]);
			if(isset($exploded[1])):
				$name=$exploded[0]." ".$exploded[count($exploded)-1];
			else:
				$name=$exploded[0];
			endif;
			$attendance_with_checkout;
			$attendance_without_checkout;

			$response['data'][$i]['coduser']=$query[$i][0];
			$response['data'][$i]['name']=encodeString($name);
			$response['data'][$i]['checkin']=($query[$i][1]=="" or $query[$i][1]=="00:00:00") ? $attendance_without_checkout: $attendance_with_checkout;
			$response['data'][$i]['checkout']=($query[$i][2]=="" or $query[$i][2]=="00:00:00") ? $attendance_without_checkout: $attendance_with_checkout;
			if($query[$i][4]<>''):
				$response['data'][$i]['imgURL']=$query[$i][4];
			else:
				$response['data'][$i]['imgURL']="";
			endif;
		endfor;
		$response['error'] = false; 
		$response['message'] = 'Bem vindo';
	else:
		$response['error'] = true; 
		$response['message'] = $list_workers_onsite_today_no_records_found;
	endif;			
else:
	$response['error'] = true; 
	$response['message'] ='invalid request';
endif;
?>