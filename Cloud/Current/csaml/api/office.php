<?php
if(!defined("COOKIE_GOES_TO_THE_BEACH")):
	die();
endif;
if(!isset($secretKey)):
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
require($server['root']['path']."api/office/translations/en.php");
require($server['root']['path']."system/settings.php");

define("COOKIE_GOES_TO_TOWN",true);

//DATABASE SETUP
$db = new database_class;
$db->host=$DbHost;
$db->user=$DbUser;
$db->password=$DbPassword; 
$db->name=$DbName;
$db->encryption_key=$secretKey;
$db->charset="utf8";

//LANGUAGE SETUP
date_default_timezone_set($Timezone);

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
		$response['message'] = "Error decrypt on server: ".chr(13).$name.chr(13).chr(13)." DATA:".chr(13)."]".rawurldecode($_POST['data']). "[ ".chr(13).chr(13)." IV:".chr(13)."]".$decrypted->getInitVector()."[".chr(13)."MD5:]".md5(rawurldecode($_POST['data']))."[";
	else:

		$data=$decrypted->getResult(); // Encoded/Decoded result
		$iv=$decrypted->getInitVector(); // Get used (random if encode) init vector
		$error=isValidJson($data);
		$db->encryption_iv=$iv;
		if($error["error"]==false):
			$data = json_decode($data, true);	
   			foreach($data as $key => $value):				
   				$data[$key]=CheckLetters($value);
         	endforeach;
			//load language
			$language= isset($data["language"]) ? $data["language"] : "en";
			if(is_file($server['root']['path']."api/office/translations/".$language.".php")):
				require($server['root']['path']."api/office/translations/".$language.".php");
			elseif(is_file($server['root']['path']."api/office/translations/".$DefaultLanguage.".php")):
				require($server['root']['path']."api/office/translations/".$DefaultLanguage.".php");
			else:
				require_once($server['root']['path']."api/office/translations/en.php");
			endif;
			
			if(isset($data['task'])):
				$db->connect(true);
				switch($data['task']):
					//wizard requests begin with 0
					case '101': // check ID credentials
						CheckJsonParams($data,$iv,$secretKey, array('id','type'));
						$response=[];
						require("office/check_credentials.php");
						break;

					case '1011': // wizzard forgot ID -> send email with ID
						CheckJsonParams($data,$iv,$secretKey, array('email','type'));
						$response=[];						
						require("office/forgot_id_send_email.php");						
						break;

					case '1020': // wizzard send encryption key
						//check auth
						CheckCredentials($db, $data, $iv, $secretKey);
						$response=[];						
						require("office/send_encryption_key.php");						
						break;

					case '1021': // wizzard save program UID
						//check auth
						CheckCredentials($db, $data, $iv, $secretKey);
						CheckJsonParams($data,$iv,$secretKey, array('pid'));
						$response=[];						
						require("office/save_program_uid.php");						
						break;

					// request template files 
					case '1050': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','file'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("shared/files_request_templates.php");
						break;

					// request dll files 
					case '1100': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','file'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("shared/files_request_dlls.php");
						break;

					//Login
					case '1': // check ID credentials
						CheckJsonParams($data,$iv,$secretKey, array('id','pid'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/check_credentials.php");
						break;

					
					case '2': // load addons
						CheckJsonParams($data,$iv,$secretKey, array('id','pid'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/load_addons.php");
						break;

					//Site days closed
					case '3': // load addons
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','type'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/site_days_closed.php");
						break;

					//unscheduled works / regie
					case '4': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','request'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/unscheduled_works.php");
						break;

					//attendance records
					case '5': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','site','date','section'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/attendance_records.php");
						break;

					//query requests
					case '6': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','request'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/queries.php");
						break;

					//attendace display table
					case '7': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','company','site','section','startdate','enddate'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/attendance.php");
						break;

					//attendance record day annotations
					case '8': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','site','worker','date','note','section'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/attendance_annotations.php");
						break;
					//holidays
					case '9': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','type','date'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/holidays.php");
						break;

					//workers absenses
					case '10': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','type'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/workers_absenses.php");
						break;

					//workers clothes protection equipments
					case '11': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','type'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/workers_clothes.php");
						break;

					//scheduling reception of materials at the site
					case '12': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','type'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/site_materials_reception.php");
						break;

					//mobile devices
					case '13': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','type'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/mobile_devices.php");
						break;

					//construction sites
					case '14': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','request'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/site.php");
						break;

					//construction site manager
					case '15': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','request'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/site_managers.php");
						break;

					//construction site client company
					case '16': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','request'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/site_client_company.php");
						break;

					//construction site sections
					case '17': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','request'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/site_sections.php");
						break;

					//construction site teams
					case '18': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','type'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/site_teams.php");
						break;

					//construction site bordereau
					case '19': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','request'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/site_bordereau.php");
						break;

					//App photos
					case '20': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','request'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/photos.php");
						break;

					//construction site production measurements
					case '21': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','request'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/site_production.php");
						break;

					//construction site delivery documents
					case '22': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','request'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/site_delivery.php");
						break;

					//attendance workers records for journal ++
					case '23': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','date','site','type','section'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/attendance_logger.php");
						break;

					//journal Log
					case '24': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','date','site','section'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/journal_log.php");
						break;

					// add journal entries & pdf file
					case '25': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','date','activity','ocurrence','site','section'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/journal_add.php");
						break;
//FREE SLOT number 26

					// worker locate details
					case '27': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid','cod'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/worker_details.php");
						break;

					// worker file
					case '28': 
						CheckJsonParams($data,$iv,$secretKey, array('id','pid'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/worker_file.php");
						break;

					// limosas
					case '29': 
						CheckJsonParams($data,$iv,$secretKey, array('request'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/limosas.php");
						break;

					// ausencias
					case '30': 
						CheckJsonParams($data,$iv,$secretKey, array('type'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/ausencias.php");
						break;

					// users profile
					case '31': 
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/user_profile.php");
						break;

					// bordereau edit tasks
					case '32': 
						CheckJsonParams($data,$iv,$secretKey, array('request','site','section'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/site_bordereau_edit.php");
						break;

					// get file
					case '33': 
						CheckJsonParams($data,$iv,$secretKey, array('type','cod'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/files_get.php");
						break;
					// save settings
					case '34': 
						CheckJsonParams($data,$iv,$secretKey, array('checkin','checkout','hours', 'maxdelay'));
						CheckApplicationId($db, $data, $iv, $secretKey);
						$response=[];
						require("office/server_settings.php");
						break;

					endswitch;
				$db->connect(false);
			else:
				$response['error'] = true; 
				$response['message'] = 'Invalid task request:';
			endif;
		else:
			$response['error'] = true; 
			$response['message'] = $error['message']." DATA:]".$data."[";
  			//$response['message'] = 'No valid data found';
		endif;
	endif;
else:
 	$response['error'] = true; 
  	$response['message'] = 'no data found';
endif;




function display_array($your_array){
	$tmp=array();
	foreach ($your_array as $key => $value):    
		if (is_array($value)):
			$tmp[$key]=display_array($value);
		else:
			$tmp[$key]=checkLetters($value);
		endif;
	file_put_contents("test.txt", $key."->".$value.chr(13), FILE_APPEND);
	endforeach;
	return $tmp;
}

//$response=display_array($response);

//encrypt and send request
require($server['root']['path']."api/shared/send_response_request.php");
?>