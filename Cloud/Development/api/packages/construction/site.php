<?php
if(!defined("COOKIE_GOES_TO_THE_BEACH")):
	die();
endif;
if(!isset($secretKey)):
	echo "config missing";
	die();
endif;

$server['root']['path']=substr(__FILE__,0,strpos(__FILE__,"csaml"))."csaml/"; // file system path
$server['root']['files']=substr(__FILE__,0,strpos(__FILE__,"csaml"))."works/files/"; // files path
$server['root']['photos']=substr(__FILE__,0,strpos(__FILE__,"csaml"))."works/photos/"; // photos path

require("system/json.functions.php");
require("system/language.functions.php");
require("system/location.functions.php");
require("system/authentication.functions.php");
require("system/strings.functions.php");
require("system/datetime.functions.php");

require("system/database.class.php");
require("system/AesCipher.class.php");

require("shared/site_history.php");

define("COOKIE_GOES_TO_TOWN",true);


//DATABASE SETUP
$db = new database_class;
$db->host='localhost';
$db->user='qualit11_qc'; // root
$db->password='dragon@1522'; // 
$db->name='qualit11_construction';
$db->encryption_key=$secretKey;
$db->charset="utf8";

//LANGUAGE SETUP
date_default_timezone_set('Europe/Brussels');

$iv="";

if(isset($_POST['data'])):
 	$response['error'] = true; 
  	$response['message'] = 'Invalid task request:';

	$decrypted = new AesCipher;
	$decrypted->decrypt($secretKey, rawurldecode($_POST['data']));
	if($decrypted ->hasError()): // TRUE if operation failed, FALSE otherwise
		$response['error'] = true;
		$exploded=explode(":",$decrypted->getErrorMessage());
		if(isset($exploded[1])):
			$name=$exploded[count($exploded)-1];
		else:
			$name=$decrypted->getErrorMessage();
		endif;
		$response['message'] = 'Error decrypt on server: ['.$name."]";
	else:

		$data=$decrypted->getResult(); // Encoded/Decoded result
		$iv=$decrypted->getInitVector(); // Get used (random if encode) init vector
		$error=isValidJson($data);
		$db->encryption_iv=$iv;



		if($error["error"]==false):
			$data = json_decode($data, true);
			
			//check ID credentials & Application UUID authorizations & latitude & longitude (not mandatory)

			
			
			if(isset($data['task'])):
				$db->connect(true);
				$language= isset($data["language"]) ? $data["language"] : "en";
				if(is_file($server['root']['path']."api/site/translations/".$language.".php")):
					require($server['root']['path']."api/site/translations/".$language.".php");
				else:
					require($server['root']['path']."api/site/translations/en.php");
				endif;
				switch($data['task']):
					case '0': // authentication
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('lat','lon','sn','id', 'version'));
						$response=[];
						$db->connect(true);
						require("site/auth.php");
						break;

					case '1': // log attendance
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','worker','sn','section'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/attendance.php");
						break;

					case '2': // list workers registered on site today
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/list_workers_onsite_today.php");
						break;

					case '3': // list on journal, workers registered on site today
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section', 'date','type'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/list_on_journal_workers_onsite_today.php");
						break;

					case '4': // journal entries for given date: add, edit, view
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section','type'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/journal.php");
						break;

					case '5': // bordereau entries for given date: add, edit, view
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section','type'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/bordereau.php");
						break;

					case '6': // Livraison entries for given date: add, edit, view
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section','type'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/livraisons.php");
						break;

					case '7': // Occurrences entries for given date: add, edit, view
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section','type'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/occurrences.php");
						break;

					case '8': // Project entries for given date: add, edit, view
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section','type'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/project.php");
						break;

					case '9': // Download file, photo or image
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section','type','where','cod'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/download_files.php");
						break;

					case '10': // Quantity production entries for given date: add, edit, view
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section','type','date'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/production.php");
						break;

					case '11': // Work at Regie entries for given date: add, edit, view
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section','type'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/regie_work.php");
						break;

					case '12': // Photo entries: add, edit, view
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section','type'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/photos.php");
						break;

					case '13': // log weather
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/weather.php");
						break;

					case '14': // data for offiline mode
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/offline.php");
						break;

					case '15': // check for updates
						include_once($server['root']['path']."update/versionApp.txt");
						$response['version']=$version;
						$response['error'] = false; 
						$response['message'] = 'update request';
						break;

					case '16': // calendar entries
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section','type'));
						$response=[];
						CheckCredentials($db, $data);
						require("site/calendar_entries.php");
						break;

					case '17': // crash reports
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('sn','report'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/crash_reports.php");
						break;

					case '18': // messagebox set readed message
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('code'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						$db->setquery("update site_messages set readed=readed+1 where cod_message='".$data['code']."'");
						$response['error'] = false; 
						$response['message'] = 'OK';
						break;

					case '19': // generate a new Auth String
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('worker'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
 						$response=generateRandomString(16);
						$db->setquery("update worker set card_auth_key='".$response."' where cod_nfc='".$data['worker']."'");
						break;
						
					case '20': // harware entries for given date: add, edit, view
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section','type'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/hardware.php");
						break;
						
					case '21': // materials DIY entries for given date: add, edit, view
						CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
						CheckJsonParams($data,$iv,$secretKey, array('site','sn','section','type'));
						$response=[];
						CheckCredentials($db, $data, $iv, $secretKey,"foreman");
						require("site/materials_diy.php");
						break;


				endswitch;
			else:
				$response['error'] = true; 
				$response['message'] = 'Invalid task request:';
			endif;
		else:
			$response['error'] = true; 
			$response['message'] = $error['message']." DATA:".$data;
  			$response['message'] = 'No valid data found';
		endif;
	endif;
	if(isset($data['messagebox'])):
		CheckApplicationId($db, $data, $iv, $secretKey,"foreman");
		if(is_numeric($data['messagebox'])):
			$category=$db->getquery("select categories.reference from teams left join worker on teams.cod_worker=worker.cod_worker left join categories on teams.cod_category=categories.cod_category where worker.cod_nfc='".$data['sn']."'");
			if($category[0][0]<>""):
				$messages=$db->getquery("select message, sdate, edate, recurrence, readed, cod_message from site_messages where app_load_request_id='".$data['messagebox']."' and cod_site='".$data['site']."' and cod_section='".$data['section']."' and category_reference='".$category[0][0]."'");
				if($messages[0][0]<>""):
					for($i=0;$i<count($messages);$i++):
						if($messages[$i][1]<>"" and $messages[$i][2]<>""):
							$now = new DateTime();
							$startdate = new DateTime($messages[$i][1]);
							$enddate = new DateTime($messages[$i][2]);

							if(($startdate <= $now && $now <= $enddate) and $messages[$i][3]=="0" and $messages[$i][4]=="0"):// is between dates one time read 
								$response['messagebox'][$i]['message']=$messages[$i][0];
								$response['messagebox'][$i]['code']=$messages[$i][5];
							elseif(($startdate <= $now && $now <= $enddate) and $messages[$i][3]=="1"):// is between dates repeat read between dates
								$response['messagebox'][$i]['message']=$messages[$i][0];
								$response['messagebox'][$i]['code']=$messages[$i][5];
							endif;
						else:
							$response['messagebox'][$i]['message']=$messages[$i][0];
							$response['messagebox'][$i]['code']=$messages[$i][5];
						endif;
					endfor;
				endif;
			endif;
		endif;
	endif;
	$db->connect(false);
else:
 	$response['error'] = true; 
  	$response['message'] = 'Invalid request';
endif;


//encrypt and send request
require($server['root']['path']."api/shared/send_response_request.php");
die();



// ask for a response somewhere via POST
$host = "www.example.com";
$path = "/path/to/backend";
$arr = array('caseNumber' => '456456787');
$token = "ThisIsSomeLongToken";

$ch = curl_init();
// endpoint url
curl_setopt($ch, CURLOPT_URL, $host . $path);
// set request as regular post
curl_setopt($ch, CURLOPT_POST, true);
// set data to be send
curl_setopt($ch, CURLOPT_POSTFIELDS, http_build_query($arr));
// set header
curl_setopt($ch, CURLOPT_HTTPHEADER, array('Bearer: ' . $token));
// return transfer as string
curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
$response = curl_exec($ch);
curl_close($ch);






//view ciphers
$ciphers             = openssl_get_cipher_methods();
$ciphers_and_aliases = openssl_get_cipher_methods(true);
$cipher_aliases      = array_diff($ciphers_and_aliases, $ciphers);

//ECB mode should be avoided
$ciphers = array_filter( $ciphers, function($n) { return stripos($n,"ecb")===FALSE; } );

//At least as early as Aug 2016, Openssl declared the following weak: RC2, RC4, DES, 3DES, MD5 based
$ciphers = array_filter( $ciphers, function($c) { return stripos($c,"des")===FALSE; } );
$ciphers = array_filter( $ciphers, function($c) { return stripos($c,"rc2")===FALSE; } );
$ciphers = array_filter( $ciphers, function($c) { return stripos($c,"rc4")===FALSE; } );
$ciphers = array_filter( $ciphers, function($c) { return stripos($c,"md5")===FALSE; } );
$cipher_aliases = array_filter($cipher_aliases,function($c) { return stripos($c,"des")===FALSE; } );
$cipher_aliases = array_filter($cipher_aliases,function($c) { return stripos($c,"rc2")===FALSE; } );

print_r($ciphers);
print_r($cipher_aliases);
?>