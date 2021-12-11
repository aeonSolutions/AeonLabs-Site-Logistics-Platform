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

	function connect($work){
		if($work===true):
			if ($this->link): // already connected nothing to do
				$response['error'] = false; 
				$response['message'] = __LINE__.'DB';	
			else:
				@$this->link=new mysqli($this->host, $this->user, $this->password, $this->name)
				or 
				  die('<font style="font-family:Georgia, Times, serif; font-size:10px; color:#FF0000">Unable to Connect DB server!! (DBClass '.__LINE__.') - [<strong>'.$_SERVER['SCRIPT_NAME'].'</strong>]</font>');
				if(!@mysqli_select_db($this->link,$this->name)):
				 	$response['error'] = true; 
				 	$response['message'] = 'Unable to find DB tables !! (DBClass '.__LINE__.') - ['.$_SERVER['SCRIPT_NAME'].'] err no.:('.mysqli_connect_error().')';
					echo json_encode($response);
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
						echo json_encode($response);
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
			echo json_encode($response);
			die();	
		endif;
	}



	function GetQuery($sql){
			if (!$this->link): // already connected nothing to do
				$response['error'] = true; 
				$response['message'] = 'Server not Connected (missing DBConnect): '.$sql;
				echo json_encode($response);
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
					echo json_encode($response);
					die();	
				endif;
			endif;
			if(!isset($result->num_rows)):
					$response['error'] = true; 
					$response['message'] = 'Error GetQuery SQL string to DB ('.mysqli_errno($this->link).'): '.$sql;
					echo json_encode($response);
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
					echo json_encode($response);
					die();	
				endif;
				if (mysqli_free_result($result)):
					$response['error'] = true; 
					$response['message'] = "Error retrieving query from DB: ".$sql;
					echo json_encode($response);
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
				echo json_encode($response);
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

	

};

?>