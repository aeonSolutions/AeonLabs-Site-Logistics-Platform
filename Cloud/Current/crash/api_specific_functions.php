<?php
function CheckCredentials($db){
	$query=$db->getquery("select cod_worker, cod_category, name from worker where cod_nfc='".$_GET['uuid']."'");
	if($query[0][0]<>''): // results found
		return true;
	else:
	 	$response = array(); 
	 	$response['error'] = true; 
	 	$response['message'] = "utilizador nao encontrado";
		//displaying error
	 	echo json_encode($response);
	 	//stopping further execution
	 	die();
	endif;
}

?>