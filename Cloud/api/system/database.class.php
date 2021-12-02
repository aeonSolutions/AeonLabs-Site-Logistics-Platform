<?php

/* File revision date: 24-mai-2019 */
// Database class for SQL queries



// missing clean SQL strings to prevent SQL injections

 

class database_class{

	var $host;     // host
	var $user;     // utilizador de acesso
	var $password; // password de acesso a base de dados
	var $name;     // nome da base de dados
	var $type;
	var $globvars;
	var $link;
	var $debug;
	var $err;
	var $encryption_iv;
	var $encryption_key;
	var $charset="utf8";
	
	function connect($work){
		if($work===true):
			if ($this->link): // already connected nothing to do
				$response['error'] = false; 
				$response['message'] = __LINE__.'DB';	
			else:
				if(!@$this->link=new mysqli($this->host, $this->user, $this->password, $this->name)):
				 	$response['error'] = true; 
				 	$response['message'] = 'Unable to Connect DB server!! (DBClass '.__LINE__.') - ['.$_SERVER['SCRIPT_NAME'].'] err no.:('.mysqli_connect_error().')';
					$this->sendError($response);
					die();
				endif;
	
				if(!@mysqli_select_db($this->link,$this->name)):
				 	$response['error'] = true; 
				 	$response['message'] = 'Unable to find DB tables !! (DBClass '.__LINE__.') - ['.$_SERVER['SCRIPT_NAME'].'] err no.:('.mysqli_connect_error().')';
					$this->sendError($response);
					die();					
				endif;
				if (!@$this->link->set_charset($this->charset)):
					$response['error'] = true; 
				 	$response['message'] = 'Error loading character set !! (DBClass '.__LINE__.') - ['.$_SERVER['SCRIPT_NAME'].'] err no.:('.$this->link->error.')';
					$this->sendError($response);
					die();				
				endif;
			endif;
		elseif($work===false):
			// Check if server is alive
			if(isset($con)):
				if (mysqli_ping($con)):
					if (!mysqli_close($this->link)):
						$response['error'] = true; 
					 	$response['message'] = 'Error Clossing Conenction to DB!!! (DBClass '.__LINE__.') - ['.$_SERVER['SCRIPT_NAME'].']';
						$this->sendError($response);
						die();	
					endif;
				else:
					$response['error'] = false; 
					$response['message'] = __LINE__.'DB';
				endif;
			else: // nothing to do
				$response['error'] = false; 
				$response['message'] = __LINE__.'DB';	
			endif;
		else:
			$response['error'] = true; 
			$response['message'] = 'Wrong connection type parsed to work!!! (DBClass '.__LINE__.') - ['.$_SERVER['SCRIPT_NAME'].']';
			$this->sendError($response);
			die();	
		endif;
	}



	function GetQuery($sql){
			if (!$this->link): // already connected nothing to do
				$response['error'] = true; 
				$response['message'] = 'Server not Connected (missing DBConnect): '.$sql;
				$this->sendError($response);
				die();	
			endif;

			$result=mysqli_query($this->link, $sql);

			if($result):
				$response['error'] = false; 
				$response['message'] = __LINE__.'DB';
			else:
				if (mysqli_errno($this->link)==1146):
					$this->err=1146;
					return false;
				else:
					$response['error'] = true; 
					$response['message'] = 'Error query SQL string to DB ('.mysqli_errno($this->link).'): '.$sql;
					$this->sendError($response);
					die();	
				endif;
			endif;
			if(!isset($result->num_rows)):
					$response['error'] = true; 
					$response['message'] = 'Error GetQuery SQL string to DB ('.mysqli_errno($this->link).'): '.$sql;
					$this->sendError($response);
					die();	

			elseif($result->num_rows==0):
				$tmp[0][0]='';
				return $tmp;
			else:
				$tmp[0][0]='';
				$j=0;
				while($row = mysqli_fetch_assoc($result)):		
					$i=0;
					foreach ($row as $data):
						$tmp[$j][$i]=$data;
						$i++;
					endforeach;
					$j++;
				endwhile;
				if (mysqli_error($this->link)):
					$response['error'] = true; 
					$response['message'] = "Erro MySQL em GetQuery: ".mysqli_error($this->link);
					$this->sendError($response);
					die();	
				endif;
				if (mysqli_free_result($result)):
					$response['error'] = true; 
					$response['message'] = "Error retrieving query from DB: ".$sql;
					$this->sendError($response);
					die();	
				endif;
				return $tmp;
			endif;
	}


	function SetQuery($sql){
			$link=$this->link;
			$debug=$this->debug;
			$insert_row=$link->query($sql);
			if($insert_row):
				$tmp=__LINE__;
			else:
				$response['error'] = true; 
				$response['message'] = 'Error add SQL string to DB : ('. $link->errno .') '. $link->error;
				$this->sendError($response);
				die();	
			endif;
	}


	function prepare_query($string){
			$link=$this->connect();
			if(get_magic_quotes_gpc()):
                $string = stripslashes($string); 
             endif;
          	$string=mysql_real_escape_string($string); 
			return $string;
	}

	
	function sendError($response){
		$iv=$this->encryption_iv;
		$secretKey=$this->encryption_key;
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
		$encrypted->encrypt($this->encryption_key, $response,$this->encryption_iv);

		if($encrypted ->hasError()): // TRUE if operation failed, FALSE otherwise
	 	 	$response = array(); 
			$response['error'] = true; 
	 		$exploded=explode(":",$encrypted->getErrorMessage());
			if(isset($exploded[1])):
				$name=$exploded[count($exploded)-1];
			else:
				$name=$encrypted->getErrorMessage();
			endif;
			$response['message'] = $errorEncryptOnServer.': .['.$name."]";

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
	}

};

?>