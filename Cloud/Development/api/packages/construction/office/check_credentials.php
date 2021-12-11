<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();

if($data["type"]=="unknown"):
	$queryType[0][0]="unknown";
else:
	$queryType=$db->getquery("select cod_type from users_type where sigla='".$data["type"]."'");
endif;

if($queryType[0][0]<>'' and isset($data['idkey'])): // results found
	if(strlen($data['idkey'])>4):
		$cardAuthStr= " and users.card_auth_key='".$data['idkey']."'";
	elseif(strlen($data['idkey'])==4):
		$cardAuthStr= " and users.card_auth_key LIKE '".$data['idkey']."%'";
	else:
		$cardAuthStr="";
	endif;

	if ($queryType[0][0]=="unknown"):
		$query=$db->getquery("select users.cod_user, users.name, users_type.reference, users.photo, users.connection_types from users left join users_type on users.cod_type= users_type.cod_type where users.cod_nfc='".$data['id']."'".$cardAuthStr);
	else:
		$query=$db->getquery("select users.cod_user, users.name, users_type.reference, users.photo, users.connection_types from users left join users_type on users.cod_type=users_type.cod_type where cod_nfc='".$data['id']."' and cod_type='".$queryType[0][0]."'".$cardAuthStr);
	endif;

	if($query[0][0]<>''): // results found
		$exploded=explode(" ",$query[0][1]);
		if(isset($exploded[1])):
			$name=$exploded[0]." ".$exploded[count($exploded)-1];
		else:
			$name=$exploded[0];
		endif;
		$response['error'] = false; 
		$response['message'] = $checkCredentials_welcome." ". $name;
		$response['username'] =$name;
		$response['photo'] = $query[0][3];
		$response['type'] = $query[0][2];
		$response['conntype'] = $query[0][4];

		require($server['root']['path']."api/config/dll.php");
		if (!(strpos($response['conntype'],"site")===false)):
			$LoadDlls=$siteDlls;
		elseif(!(strpos($response['conntype'],"office")===false)):
			if($response['type']=='adm'):
				$loadDlls=$officeDlls;
			else:
				$loadDlls=$officeDlls;
			endif;
		elseif(!(strpos($response['conntype'],"contractor")===false)):
			$loadDlls=$contractorDlls;
		endif;
		for($i=0;$i<count($loadDlls);$i++):
			$response['dlls'][$i]=$loadDlls[$i];
		endfor;

		require($server['root']['path']."api/config/update.php");
		$version=file_get_contents($updateServer);
		$error=isValidJson($version);
		if($error["error"]==false):
			$version = json_decode($version, true);	
			$response['status']['version']=$version['version'];
			$response['status']['url']=$version['url'];
			$response['status']['changelog']=$version['changelog'];
			$response['status']['checksum']=$version{'checksum'};
			$response['status']['mandatory']=true;
		endif;
	else:
		$response['error'] = true; 
		$response['message'] = $checkCredentials_user_not_found;
	endif;
else: 
	$response['error'] = true; 
	$response['message'] = $checkCredentials_user_not_found;
endif;
?>