<?php

function isJson($string) {
 json_decode($string);
 return (json_last_error() == JSON_ERROR_NONE);
}

function isValidJson($string)
{
    // decode the JSON data
    $result = json_decode($string);
	$error="";
    // switch and check possible JSON errors
    switch (json_last_error()):
        case JSON_ERROR_NONE:
            $error = ''; // JSON is valid // No error has occurred
            break;
        case JSON_ERROR_DEPTH:
            $error = 'The maximum stack depth has been exceeded.';
            break;
        case JSON_ERROR_STATE_MISMATCH:
            $error = 'Invalid or malformed JSON.';
            break;
        case JSON_ERROR_CTRL_CHAR:
            $error = 'Control character error, possibly incorrectly encoded.';
            break;
        case JSON_ERROR_SYNTAX:
            $error = 'Syntax error, malformed JSON.';
            break;
        // PHP >= 5.3.3
        case JSON_ERROR_UTF8:
            $error = 'Malformed UTF-8 characters, possibly incorrectly encoded.';
            break;
        // PHP >= 5.5.0
        case JSON_ERROR_RECURSION:
            $error = 'One or more recursive references in the value to be encoded.';
            break;
        // PHP >= 5.5.0
        case JSON_ERROR_INF_OR_NAN:
            $error = 'One or more NAN or INF values in the value to be encoded.';
            break;
        case JSON_ERROR_UNSUPPORTED_TYPE:
            $error = 'A value of a type that cannot be encoded was given.';
            break;
        default:
            $error = 'Unknown JSON error occured.';
            break;
    endswitch;

    if ($error !== ''):
		$err["error"]=true;
		$err["message"]=$error;
    else:
    	// everything is OK
		$err["error"]=false;
		$err["message"]=$error;
	endif;
    return $err;
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

 function CheckJsonParams($json,$iv,$secretKey, $params){
	 //assuming all parameters are available 
	 $available = true; 
	 $missingparams = ""; 
	 $server['root']['path']=substr(__FILE__,0,strpos(__FILE__,"csaml"))."csaml/"; // file system path
	 require_once($server['root']['path']."api/system/language.functions.php");
	 foreach($params as $param ):
		 if(!isset($json[$param]) || strlen($json[$param])<=0):
		 	$available = false; 
		 	$missingparams = $missingparams . ", " . $param; 
		 else:
			 $json[$param]=encodeString($json[$param]);
		 endif;
 	endforeach;
 
	 //if parameters are missing 
	 if(!$available):
	 	$response = array(); 
	 	$response['error'] = true; 
	 	$response['message'] = 'Parametro ' . substr($missingparams, 1, strlen($missingparams)) . ' esta em falta';
 
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
				$name=$decrypted->getErrorMessage();
			endif;
			$response['message'] = 'Error decrypt on server: ['.$name."]";

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

?>