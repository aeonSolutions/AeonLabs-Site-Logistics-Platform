<?php
ini_set('display_errors', 1);
ini_set('display_startup_errors', 1);
error_reporting(E_ALL);

$server['root']['path']=substr(__FILE__,0,strpos(__FILE__,"update"))."update/"; // file system path
include_once($server['root']['path']."versionOffice.txt");
$filename="setup.exe";
$response['version']=$version;
$response['url']=utf8_encode("http://".$_SERVER['HTTP_HOST']."/shared/update/".$filename);
$response['changelog']=utf8_encode("http://".$_SERVER['HTTP_HOST']."/shared/update/changesOffice.txt");
$response['checksum']=md5_file($server['root']['path'].$filename);
$response['mandatory']=true;
$response['error'] = false; 
$response['message'] = 'update request';

//displaying the response in json structure 
echo safe_json_encode($response,0,512,false);


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

?>
