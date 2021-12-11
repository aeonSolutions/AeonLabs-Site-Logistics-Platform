<?php
if(!isset($response)):
	echo "missing params";
endif;

if ($iv==""):
	$iv=generateRandomString(16);
endif;

if(is_array($response)):
	//displaying the response in json structure 
	$response=(safe_json_encode($response,0,512,false));


endif;

$encrypted = new AesCipher;
$encrypted->encrypt($secretKey, $response,$iv);

if($encrypted ->hasError()): // TRUE if operation failed, FALSE otherwise
	$response['error'] = true; 
	$response['message'] = 'Error encrypt on server: ['.$encrypted->getErrorMessage()."]";
	echo safe_json_encode($response,0,512,false);

    // Set HTTP response status code to: 500 - Internal Server Error
    //http_response_code(500);
else:
	@header("Content-type: application/octet-stream\r\n");
	@header("Authorization: ".generateRandomString(32)." \r\n");
	@header("Content-length: " . strlen($encrypted->getResult()) . "\r\n");
	@header('Content-Type: text/plain; charset=utf-8');
	@header("Connection: close\r\n\r\n");

	echo $encrypted->getResult();
endif;
?>