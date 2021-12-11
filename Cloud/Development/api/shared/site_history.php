<?php
function AddHistoryRecord($db, $site, $section, $codTable, $DbTable, $username, $where, $eventType, $message){
//possible envent types:
//	normal
//	error
//	warning
//	delay
// possible where / Apps
//	office
//	foreman
//	workers
//	client

		$db->setquery("insert into site_history set cod_site='".$site."', cod_section='".$section."', cod_table='".$codTable."', db_table='".$DbTable."',  username='".$username."',  app='".$where."', type_event='".$eventType."',  message='".$message."', date='".date("Y-m-d")."'");
}

function getUserName($db, $data, $userType){
	if($userType=="office"):
		$query=$db->getquery("select name from users where cod_nfc='".$data['id']."'");
	else:
		$query=$db->getquery("select name from worker where cod_nfc='".$data['sn']."'");	
	endif;
	$exploded=explode(" ",$query[0][0]);
	if(isset($exploded[1])):
		$name=$exploded[0]." ".$exploded[count($exploded)-1];
	else:
		$name=$exploded[0];
	endif;
	return $name;
}
?>
