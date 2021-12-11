<?php
function CheckApplicationId($db, $data, $iv, $secretKey, $userType="office"){
	return true;
	
	if($userType=="office"):
		$query=$db->getquery("select cod_pc from devices_pc where pc_id='".$data['pid']."'");
	else:
		$query=$db->getquery("select cod_tablet, active from tablets where tablet_id='".$data['tid']."'");
	endif;

	if(($query[0][0]<>'' and $userType=="office")or($query[0][0]<>'' && $query[0][1]<>'' && $userType<>"office")): // results found
		return true;
	else:
		$server['root']['path']=substr(__FILE__,0,strpos(__FILE__,"csaml"))."csaml/"; // file system path
			//load language
		$language= isset($data["language"]) ? $data["language"] : "en";
		if(is_file($server['root']['path']."api/office/translations/".$language.".php")):
			require($server['root']['path']."api/office/translations/".$language.".php");
		elseif(is_file($server['root']['path']."api/office/translations/".$DefaultLanguage.".php")):
			require($server['root']['path']."api/office/translations/".$DefaultLanguage.".php");
		else:
			require_once($server['root']['path']."api/office/translations/en.php");
		endif;

	 	$response = array(); 
	 	$response['error'] = true; 
	 	$response['message'] = $device_pc_not_found;
	
		//displaying the response in json structure 
		$response=safe_json_encode($response,0,512,false);

		$encrypted = new AesCipher;
		$encrypted->encrypt($secretKey, $response,$iv);

		if($encrypted ->hasError()): // TRUE if operation failed, FALSE otherwise
	 	 	$response = array(); 
			$response['error'] = true; 
	 		$exploded=explode(":",$encrypted->getErrorMessage());
			if(isset($exploded[1])):
				$name=$exploded[count($exploded)-1];
			else:
				$name=$encrypted->getErrorMessage();
			endif;
			$response['message'] = $errorEncryptOnServer.': ['.$name."]";

			echo safe_json_encode($response,0,512,false);

			// Set HTTP response status code to: 500 - Internal Server Error
			//http_response_code(500);
		else:
			@header("Content-type: application/octet-stream\r\n");
			@header("Authorization: ".generateRandomString(32)." \r\n");
			@header("Content-length: " . strlen($encrypted->getResult()) . "\r\n");
			@header("Connection: close\r\n\r\n");

			echo $encrypted->getResult();
		endif;	 	 
	 	//stopping further execution
	 	die();
	endif;
	
}

function CheckCredentials($db, $data, $iv, $secretKey, $userType="office"){	
	if($userType=="office"):
		$query=$db->getquery("select cod_user, name from users where cod_nfc='".$data['id']."'");
	else:
		$query=$db->getquery("select cod_worker, cod_category, name from worker where cod_nfc='".$data['sn']."'");	
	endif;
	
	$currentTime=strtotime(date('H:i:s', time()));	
	if(($query[0][0]<>'' and $userType=="office") or ($userType<>"office" and $query[0][0]<>'' and !(strtotime("21:00:00")<$currentTime and strtotime("05:00:00")>$currentTime))): // results found
		return true;
	else:
		if ($userType<>"office" and (strtotime("21:00:00")<$currentTime and strtotime("05:00:00")>$currentTime)):
	 		$response = array(); 
	 		$response['error'] = true; 
	 		$response['message'] = "out of Work day hours";
		else:
		 	$response = array(); 
	 		$response['error'] = true; 
	 		$response['message'] = "worker not found";
		endif;
		$server['root']['path']=substr(__FILE__,0,strpos(__FILE__,"csaml"))."csaml/"; // file system path
			//load language
		$language= isset($data["language"]) ? $data["language"] : "en";
		if(is_file($server['root']['path']."api/office/translations/".$language.".php")):
			require($server['root']['path']."api/office/translations/".$language.".php");
		elseif(is_file($server['root']['path']."api/office/translations/".$DefaultLanguage.".php")):
			require($server['root']['path']."api/office/translations/".$DefaultLanguage.".php");
		else:
			require_once($server['root']['path']."api/office/translations/en.php");
		endif;

		//displaying the response in json structure 
		$response=safe_json_encode($response,0,512,false);

		$encrypted = new AesCipher;
		$encrypted->encrypt($secretKey, $response,$iv);

		if($encrypted ->hasError()): // TRUE if operation failed, FALSE otherwise
	 	 	$response = array(); 
			$response['error'] = true; 
	 		$exploded=explode(":",$encrypted->getErrorMessage());
			if(isset($exploded[1])):
				$name=$exploded[count($exploded)-1];
			else:
				$name=$encrypted->getErrorMessage();
			endif;
			$response['message'] = $errorEncryptOnServer.': ['.$name."]";

			echo safe_json_encode($response,0,512,false);

			// Set HTTP response status code to: 500 - Internal Server Error
			//http_response_code(500);
		else:
			@header("Content-type: application/octet-stream\r\n");
			@header("Authorization: ".generateRandomString(32)." \r\n");
			@header("Content-length: " . strlen($encrypted->getResult()) . "\r\n");
			@header("Connection: close\r\n\r\n");

			echo $encrypted->getResult();
		endif;	 
	
	 	//stopping further execution
	 	die();
	endif;
	
}

function CheckFile($db, $data, $iv, $secretKey){
 	$response['error'] = true; 
	if(isset($_FILES['file'])):
		if($_FILES['file']['error']===UPLOAD_ERR_OK):
		 	$response['error'] = false; 
			return true;
		elseif($_FILES['file']['error']===UPLOAD_ERR_INI_SIZE):
		  	$response['message'] = $photos_upload_max_size;
		elseif($_FILES['file']['error']===UPLOAD_ERR_FORM_SIZE):
		  	$response['message'] = $photos_upload_max_size_html_form;
		elseif($_FILES['file']['error']===UPLOAD_ERR_PARTIAL):
		  	$response['message'] = $photos_upload_partial_file;
		elseif($_FILES['file']['error']===UPLOAD_ERR_NO_FILE):
		  	$response['message'] = $photos_no_file_found_on_data_post;				
		endif;
	else:
	  	$response['message'] = $photos_upload_error;				
	endif;
	
	$server['root']['path']=substr(__FILE__,0,strpos(__FILE__,"csaml"))."csaml/"; // file system path
	//load language
	$language= isset($data["language"]) ? $data["language"] : "en";
	if(is_file($server['root']['path']."api/office/translations/".$language.".php")):
		require($server['root']['path']."api/office/translations/".$language.".php");
	elseif(is_file($server['root']['path']."api/office/translations/".$DefaultLanguage.".php")):
		require($server['root']['path']."api/office/translations/".$DefaultLanguage.".php");
	else:
		require_once($server['root']['path']."api/office/translations/en.php");
	endif;

	$response = array(); 
	$response['error'] = true; 
	$response['message'] = $device_pc_not_found;

	//displaying the response in json structure 
	$response=safe_json_encode($response,0,512,false);

	$encrypted = new AesCipher;
	$encrypted->encrypt($secretKey, $response,$iv);

	if($encrypted ->hasError()): // TRUE if operation failed, FALSE otherwise
		$response = array(); 
		$response['error'] = true; 
		$exploded=explode(":",$encrypted->getErrorMessage());
		if(isset($exploded[1])):
			$name=$exploded[count($exploded)-1];
		else:
			$name=$encrypted->getErrorMessage();
		endif;
		$response['message'] = $errorEncryptOnServer.': ['.$name."]";

		echo safe_json_encode($response,0,512,false);

		// Set HTTP response status code to: 500 - Internal Server Error
		//http_response_code(500);
	else:
		@header("Content-type: application/octet-stream\r\n");
		@header("Authorization: ".generateRandomString(32)." \r\n");
		@header("Content-length: " . strlen($encrypted->getResult()) . "\r\n");
		@header("Connection: close\r\n\r\n");

		echo $encrypted->getResult();
	endif;	 	 
	//stopping further execution
	die();
}
?>