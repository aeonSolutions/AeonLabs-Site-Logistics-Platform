<?php


function safe_json_encode($value, $options = 0, $depth = 512, $utfErrorFlag = false) {
    $encoded = (json_encode($value, $options, $depth));
    switch (json_last_error()) {
        case JSON_ERROR_NONE:
            return $encoded;
        case JSON_ERROR_DEPTH:
           	$response['en'] = 'JsonEnc:Maximum stack depth exceeded';
            return json_encode($response);
        case JSON_ERROR_STATE_MISMATCH:
           	$response['en'] = 'JsonEnc:Underflow or the modes mismatch';
            return json_encode($response);
        case JSON_ERROR_CTRL_CHAR:
            $response['en'] = 'JsonEnc:Unexpected control character found';
            return json_encode($response);
        case JSON_ERROR_SYNTAX:
            $response['en'] = 'JsonEnc:Syntax error, malformed JSON';
            return json_encode($response);
        case JSON_ERROR_UTF8:
            $clean = utf8ize($value);
            if ($utfErrorFlag) {
                $response['en'] = 'JsonEnc:UTF8 encoding error';
	            return json_encode($response);
            }
            return safe_json_encode($clean, $options, $depth, true);
        default:
            $response['en'] = 'JsonEnc:Unknown error';
            return json_encode($response);
    }
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
		 }else{
			 $_GET[$param]=addslashes($_GET[$param]);
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

function translate($en, $fr, $nl){
	if(isset($_GET['lang'])):
		if($_GET['lang']=='en'):
			setlocale(LC_ALL, 'en_EN');
			return $en;
		elseif($_GET['lang']=='nl'):
			setlocale(LC_ALL, 'nl_NL');
			return $nl;
		else:
			setlocale(LC_ALL, 'fr_FR');
			return $fr;
		endif;
	elseif(isset($_SESSION['lang'])):
		if($_SESSION['lang']=='en'):
			setlocale(LC_ALL, 'en_EN');
			return $en;
		elseif($_SESSION['lang']=='nl'):
			setlocale(LC_ALL, 'nl_NL');
			return $nl;
		else:
			setlocale(LC_ALL, 'fr_FR');
			return $fr;
		endif;
	else:
		setlocale(LC_ALL, 'fr_FR');
		return $fr;
	endif;
};

function add_months($months, DateTime $dateObject) 
    {
        $next = new DateTime($dateObject->format('Y-m-d'));
        $next->modify('last day of +'.$months.' month');

        if($dateObject->format('d') > $next->format('d')) {
            return $dateObject->diff($next);
        } else {
            return new DateInterval('P'.$months.'M');
        }
    }

function endCycle($d1, $months)
    {
        $date = new DateTime($d1);

        // call second function to add the months
        $newDate = $date->add(add_months($months, $date));

        // goes back 1 day from date, remove if you want same day of month
        $newDate->sub(new DateInterval('P1D')); 

        //formats final date to Y-m-d form
        $dateReturned = $newDate->format('Y-m-d'); 

        return $dateReturned;
    }


require("database.class.php");
$db = new database_class;
$db->host='localhost';
$db->user='shared_csaml_usr'; // root
$db->password='dragon@1522'; // 
$db->name='shared_csaml';

date_default_timezone_set('Europe/Brussels');

?>
