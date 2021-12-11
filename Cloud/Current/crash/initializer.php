<?php
function encodeString($str){
	$res=iconv(mb_detect_encoding($str), "UTF-8", $str);
	if (false === $res):
		return utf8_encode($str);
	else:
		return $res;
	endif;
}

function encodeString16($str){
	
	$converted = iconv(mb_detect_encoding($str), 'ISO-8859-1', $str);
	if (false === $converted ):
		return utf8_encode($str);
	else:
		return $converted;
	endif;
}

function safe_json_encode($value, $options = 0, $depth = 512, $utfErrorFlag = false) {
	$response['error'] = true; 
    
    $encoded = utf8_encode(json_encode($value, $options, $depth));
    switch (json_last_error()) {
        case JSON_ERROR_NONE:
            return $encoded;
        case JSON_ERROR_DEPTH:
           	$response['message'] = 'JsonEnc:Maximum stack depth exceeded';
            return json_encode($response);
        case JSON_ERROR_STATE_MISMATCH:
           	$response['message'] = 'JsonEnc:Underflow or the modes mismatch';
            return json_encode($response);
        case JSON_ERROR_CTRL_CHAR:
            $response['message'] = 'JsonEnc:Unexpected control character found';
            return json_encode($response);
        case JSON_ERROR_SYNTAX:
            $response['message'] = 'JsonEnc:Syntax error, malformed JSON';
            return json_encode($response);
        case JSON_ERROR_UTF8:
            $clean = utf8ize($value);
            if ($utfErrorFlag) {
                $response['message'] = 'JsonEnc:UTF8 encoding error';
	            return json_encode($response);
            }
            return safe_json_encode($clean, $options, $depth, true);
        default:
            $response['message'] = 'JsonEnc:Unknown error';
            return json_encode($response);

    }
}

function utf8ize($mixed) {
    if (is_array($mixed)) {
        foreach ($mixed as $key => $value) {
            $mixed[$key] = utf8ize($value);
        }
    } else if (is_string ($mixed)) {
        return utf8_encode($mixed);
    }
    return $mixed;
}

 //function validating all the paramters are available
 //we will pass the required parameters to this function 
 function CheckPost($params){
	 //assuming all parameters are available 
	 $available = true; 
	 $missingparams = ""; 
	 
	 foreach($params as $param){
		 if(!isset($_POST[$param]) || strlen($_POST[$param])<=0){
		 	$available = false; 
		 	$missingparams = $missingparams . ", " . $param; 
		 }
 	}
 
	 //if parameters are missing 
	 if(!$available){
	 	$response = array(); 
	 	$response['error'] = true; 
	 	$response['message'] = 'Parametro [' . substr($missingparams, 1, strlen($missingparams)) . '] esta em falta';
	 
	 	//displaying error
	 	echo json_encode($response);
	 
	 	//stopping further execution
	 	die();
	 }
 }

 function CheckGet($params){
	 //assuming all parameters are available 
	 $available = true; 
	 $missingparams = ""; 
	 
	 foreach($params as $param){
		 if(!isset($_GET[$param]) || strlen($_GET[$param])<=0){
		 	$available = false; 
		 	$missingparams = $missingparams . ", " . $param; 
		 }
 	}
 
	 //if parameters are missing 
	 if(!$available){
	 	$response = array(); 
	 	$response['error'] = true; 
	 	$response['message'] = 'Parametro ' . substr($missingparams, 1, strlen($missingparams)) . ' esta em falta';
	 
	 	//displaying error
	 	echo json_encode($response);
	 
	 	//stopping further execution
	 	die();
	 }
 }

function CheckFile(){
 	$response['error'] = true; 
	if(isset($_FILES['file'])):
		if($_FILES['file']['error']===UPLOAD_ERR_OK):
		 	$response['error'] = false; 
			return true;
		elseif($_FILES['file']['error']===UPLOAD_ERR_INI_SIZE):
		  	$response['message'] = 'The uploaded file exceeds the upload_max_filesize directive in php.ini';
		elseif($_FILES['file']['error']===UPLOAD_ERR_FORM_SIZE):
		  	$response['message'] = 'The uploaded file exceeds the MAX_FILE_SIZE directive that was specified in the HTML form';
		elseif($_FILES['file']['error']===UPLOAD_ERR_PARTIAL):
		  	$response['message'] = 'Ficheiro nao foi totalmente transferido';
		elseif($_FILES['file']['error']===UPLOAD_ERR_NO_FILE):
		  	$response['message'] = 'Ficheiro nao encontrado no upload';				
		endif;
	else:
	  	$response['message'] = 'Ficheiro nao encontrado';				
	endif;
	echo json_encode($response);
	die();
}


function  distance($lat1, $lon1, $lat2, $lon2) {
    $earthRadiusKm = 6371;

    $dLat = deg2rad(floatval($lat2)-floatval($lat1));
    $dLon = deg2rad(floatval($lon2)-floatval($lon1));

    $lat1 = deg2rad(floatval($lat1));
    $lat2 = deg2rad(floatval($lat2));

    $a = sin($dLat/2) * sin($dLat/2) + sin($dLon/2) * sin($dLon/2) * cos($lat1) * cos($lat2);
    $c = 2 * atan2(sqrt($a), sqrt(1-$a));
    
    return $earthRadiusKm * $c;
}

function generateRandomString($length = 10) {
    $characters = '0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ';
    $charactersLength = strlen($characters);
    $randomString = '';
    for ($i = 0; $i < $length; $i++) {
        $randomString .= $characters[rand(0, $charactersLength - 1)];
    }
    return $randomString;
}


require("database.class.php");
$db = new database_class;
$db->host='localhost';
$db->user='shared_csaml_usr'; // root
$db->password='dragon@4108'; // 
$db->name='shared_csaml';

date_default_timezone_set('Europe/Brussels');

?>
