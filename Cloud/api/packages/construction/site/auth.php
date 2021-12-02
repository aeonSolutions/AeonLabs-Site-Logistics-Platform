<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;

/*
	$response['auth']['level'] ='-1' -> autentication failure
	$response['auth']['level'] ='0' -> admin 
	$response['auth']['level'] ='1' -> pessoal escritorio
	$response['auth']['level'] ='2'-> encarregado / encarregado geral
	*/


$response['error'] = true; 
$response['auth']['name'] ='-1'; 	 
$response['auth']['section'] ='-1'; 	 
$response['auth']['site'] ='-1';
$response['auth']['sitename'] ='-1';
$response['auth']['latitude'] ="-1";
$response['auth']['longitude'] ="-1";
$response['auth']['authority'] ="-1";

$date=date("Y-m-d", time());
$tablet_id= isset($data['id'])? $data['id'] : "";
$sw_version= isset($data['version'])? $data['version'] : "";

$tablets=$db->getquery("select cod_tablet, active from tablets where tablet_id='".$tablet_id."'");
if($tablets[0][0]==''): // not registered on database
	$response['error'] = true; 
	$response['message'] = $auth_mobile_device_not_found;

elseif($tablets[0][1]=='0'): // tablet is disabled 
	$response['error'] = true; 
	$response['message'] = $auth_mobile_device_is_disabled;
else:
	$enc=$db->getquery("select site_chef_equipe.cod_worker, site_chef_equipe.cod_site, site_chef_equipe.cod_section from site_chef_equipe left join worker on site_chef_equipe.cod_worker=worker.cod_worker where worker.cod_nfc='".$data['sn']."' and site_chef_equipe.date='".$date."'");
	
	$encGeral=$db->getquery("select worker.cod_worker, worker.name from worker left join worker_categories on worker.cod_category=worker_categories.cod_category where worker.cod_nfc='".$data['sn']."' and worker_categories.reference='gfrm'");

	if($enc[0][0]<>'' or $encGeral[0][0]<>""): // encarregado found on DB

		$exploded= $encGeral[0][0]<>"" ? $encGeral[0][1] : explode(" ",$enc[0][3]);
		if(isset($exploded[1])):
			$name=$exploded[0]." ".$exploded[count($exploded)-1];
		else:
			$name=$exploded[0];
		endif;

		// check if is at any site
		$lat=$data['lat'];
		$lon=$data['lon'];

		$sites=$db->getquery("select site.section.cod_site, site.name, site.section.latitude, site.section.longitude, site.section.authentication_radius, site_section.cod_section from site.section left join site on site.section.cod_site=site.cod_site");
		$pos=-1;
		for($i=0; $i<count($sites); $i++):
			if(distance($lat,$lon,$sites[$i][2],$sites[$i][3])<($sites[$i][4]/1000)):
				$pos=$i; // is at a site
			endif;
		endfor;

		$posi=-1;
		if($pos>-1 and $enc[0][0]<>""): // only needed for encarregado
			//check if above selected site is authorized on database
			for($i=0; $i<count($enc); $i++):
				if($sites[$pos][0]==$enc[$i][1]):
					$posi=$i;
				endif;
			endfor;
		endif;

		if($pos==-1): //not at a site
			$response['message'] = $auth_not_on_a_site.' '.encodeString($name);
		elseif($posi==-1 and $pos>-1 and $enc[0][0]<>""): //on site but without auth
			$response['message'] = $auth_not_auth_on_this_site.' '.encodeString($name);
		elseif($pos>-1 and $encGeral[0][0]<>""): // found site , encarregado geral credential
			$records=$db->getquery("select cod_record from record where not (checkin='00:00:00' and checkout='00:00:00' and (status='EP' or status='MO')) and cod_site='".$sites[$pos][0]."' and date='".date('Y-m-d', time())."'");
			if (!($records[0][0]<>'')):
				$response['auth']['attendance']="true";
			endif;
			$response['error'] = false; 
			$response['message'] = $auth_welcome_to.' '.encodeString($sites[$pos][1]).', '.encodeString($name);

			$response['auth']['name'] =encodeString($name); 	 
			$response['auth']['section'] =$sites[$pos][5];
			$response['auth']['sitename'] =encodeString($sites[$pos][1]);
			$response['auth']['site'] =$sites[$pos][0];
			$response['auth']['latitude'] =$sites[$pos][2];
			$response['auth']['longitude'] =$sites[$pos][3];
			$response['auth']['authority'] =$sites[$pos][4]/1000;
/*
			$sections=$db->getquery("select cod_section, description from site_section where cod_site='".$sites[$pos][0]."'");
			if($sections[0][0]<>'' and count($sections)>1):
				for($i=0; $i<count($query); $i++):
					$response['auth']['sections'][$i]['code']=$sections[$i][0];
					$response['auth']['sections'][$i]['description']=$sections[$i][1];
				endfor;
			elseif($sections[0][0]<>''):
				$response['auth']['section'] =$sections[0][0]; 	 
			endif;
*/
			$db->setquery("update tablets set cod_worker='".$encGeral[$posi][0]."', sw_version='".$sw_version."', cod_site='".$sites[$pos][0]."', cod_section='".$response['auth']['section']."', date='".date("Y-m-d H:i:s")."' where cod_tablet='".$tablets[0][0]."'");
		elseif($posi>-1 and $sites[$pos][5]==$enc[$posi][2]): // found site,  encarregado credential
			$records=$db->getquery("select cod_record from record where not (checkin='00:00:00' and checkout='00:00:00' and (status='EP' or status='MO')) and cod_site='".$sites[$pos][0]."' and cod_section='".$enc[$posi][2]."' and date='".date('Y-m-d', time())."'");

			if (!($records[0][0]<>'')):
				$response['auth']['attendance']="true";
			endif;
			$response['error'] = false; 
			$response['message'] = $auth_welcome_to.' '.encodeString($sites[$pos][1]).', '.encodeString($name);

			$response['auth']['name'] = encodeString($name); 	 
			$response['auth']['sitename'] = encodeString($sites[$pos][1]);
			$response['auth']['section'] = $enc[$posi][2]; 	 
			$response['auth']['site'] = $sites[$pos][0];
			$response['auth']['latitude'] = $sites[$pos][2];
			$response['auth']['longitude'] = $sites[$pos][3];
			$response['auth']['authority'] = $sites[$pos][4]/1000;

			$db->setquery("update tablets set cod_worker='".$enc[$posi][0]."', sw_version='".$sw_version."', cod_site='".$sites[$pos][0]."', cod_section='".$enc[$posi][2]."', date='".date("Y-m-d H:i:s")."' where cod_tablet='".$tablets[0][0]."'");
		else:
			$response['error'] = true; 
			$response['message'] = encodeString($name).' '.$auth_no_credential;
		endif;
	elseif(!isset($enc[0][1])):
		$response['message'] = encodeString($name).' >>>> '.$auth_missing_team;					
	else:
		$response['message'] = $auth_card_not_found;
	endif;
endif;
?>