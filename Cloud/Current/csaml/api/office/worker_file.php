<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();
if($data['request']=='delworker'):
			CheckJsonParams($data,$iv,$secretKey, array('cod'));
			$query=$db->getquery("select contrato_file, destacamento_file, act_file, a1_file, mutuelle_file, medico_file, gruista_file, cc_file, csaude_file from worker where cod_worker='".$data['cod']."'");
			if(is_file($server['root']['files']."contratos/".$query[0][0])):
				unlink($server['root']['files']."contratos/".$query[0][0]);
			endif;
			if(is_file($server['root']['files']."destacamento/".$query[0][1])):
				unlink($server['root']['files']."destacamento/".$query[0][1]);
			endif;
			if(is_file($server['root']['files']."act/".$query[0][2])):
				unlink($server['root']['files']."act/".$query[0][2]);
			endif;
			if(is_file($server['root']['files']."a1/".$query[0][3])):
				unlink($server['root']['files']."a1/".$query[0][3]);
			endif;
			if(is_file($server['root']['files']."mutuelle/".$query[0][4])):
				unlink($server['root']['files']."mutuelle/".$query[0][4]);
			endif;
			if(is_file($server['root']['files']."medico/".$query[0][5])):
				unlink($server['root']['files']."medico/".$query[0][5]);
			endif;
			if(is_file($server['root']['files']."gruista/".$query[0][6])):
				unlink($server['root']['files']."gruista/".$query[0][6]);
			endif;
			if(is_file($server['root']['files']."cc/".$query[0][7])):
				unlink($server['root']['files']."cc/".$query[0][7]);
			endif;
			if(is_file($server['root']['files']."csaude/".$query[0][8])):
				unlink($server['root']['files']."csaude/".$query[0][8]);
			endif;
	
			$db->setquery("delete from worker where cod_worker='".$data['cod']."'");
            $db->setquery("delete from record where cod_worker='".$data['cod']."'");
            $db->setquery("delete from teams where cod_worker='".$data['cod']."'");
            $db->setquery("delete from worker_limosa where cod_worker='".$data['cod']."'");
            $db->setquery("delete from worker_ausencia where cod_worker='".$data['cod']."'");

			$db->connect(false);
			$response['error'] = false; 
		  	$response['message'] = 'Trabalhador apagado com sucesso';
		  	
		  	
elseif($data['request']=='delworkerfile'):
			CheckJsonParams($data,$iv,$secretKey, array('cod','type'));
			$arr=explode(",",$data['type']);
			$db->connect(true);
			for($i=0;$i<count($arr);$i++):
				if($arr[$i]=="contrato"):
					$uploadDir = $server['root']['files']."contratos/";
					$key="contrato_file";
				elseif($arr[$i]=="a1"):
					$uploadDir = $server['root']['files']."a1/";
					$key="a1_file";
				elseif($arr[$i]=="act"):
					$uploadDir = $server['root']['files']."act/";
					$key="act_file";
				elseif($arr[$i]=="destacamento"):
					$uploadDir = $server['root']['files']."destacamento/";
					$key="destacamento_file";
				elseif($arr[$i]=="mutuelle"):
					$uploadDir = $server['root']['files']."mutuelle/";
					$key="mutuelle_file";
				elseif($arr[$i]=="medico"):
					$uploadDir = $server['root']['files']."medico/";
					$key="medico_file";
				elseif($arr[$i]=="gruista"):
					$uploadDir = $server['root']['files']."gruista/";
					$key="gruista_file";
				elseif($arr[$i]=="cc"):
					$uploadDir = $server['root']['files']."cc/";
					$key="cc_file";
				elseif($arr[$i]=="csaude"):
					$uploadDir = $server['root']['files']."csaude/";
					$key="csaude_file";
				endif;
				$query=$db->getquery("select ".$key." from worker where cod_worker='".$data['cod']."'");
				if($query[0][0]<>""):
					unlink($uploadDir.$query[0][0]);
				endif;
				$query=$db->setquery("update worker set ".$key."='' where cod_worker='".$data['cod']."'");

			endfor;
			$response=[];
		 	$response['error'] = false; 
		  	$response['message'] = $checkCredentials_welcome;


elseif( $data['type']=='addworker'):
			CheckJsonParams($data,$iv,$secretKey, array('email','catpro','entreprise','datainicio','datanasc','calcas','casaco','pe','altura','peso','nib','saude','morada','filhos','filhosenc','niss','nif','ccvalid','cc','nac','idade','c112','nfc','nfckey','mobile','nome','ecivil','class','loc','refeicao','acusto','salario','natura','concelho','ativo','adate','mealplace','lodge'));

			$response['error'] = false; 
			$notes= isset($data['notes']) ? $data['notes'] : "";
			$room= isset($data['room']) ? $data['room'] : "";
			$data['datanasc']= $data['datanasc']=='' ? 'DEFAULT' : "'".$data['datanasc']."'";
			$data['ccvalid']= $data['ccvalid']=='' ? 'DEFAULT' : "'".$data['ccvalid']."'";
			$data['datainicio']= $data['datainicio']=='' ? 'DEFAULT' : "'".$data['datainicio']."'";
			$data['contratoinicio']= $data['contratoinicio']=='' ? 'DEFAULT' : "'".$data['contratoinicio']."'";
			$data['contratofim']= $data['contratofim']=='' ? 'DEFAULT' : "'".$data['contratofim']."'";
			$data['destacamentoinicio']= $data['destacamentoinicio']=='' ? 'DEFAULT' : "'".$data['destacamentoinicio']."'";
			$data['destacamentofim']= $data['destacamentofim']=='' ? 'DEFAULT' : "'".$data['destacamentofim']."'";
			$data['actinicio']= $data['actinicio']=='' ? 'DEFAULT' : "'".$data['actinicio']."'";
			$data['actfim']= $data['actfim']=='' ? 'DEFAULT' : "'".$data['actfim']."'";
			$data['a1inicio']= $data['a1inicio']=='' ? 'DEFAULT' : "'".$data['a1inicio']."'";
			$data['a1fim']= $data['a1fim']=='' ? 'DEFAULT' : "'".$data['a1fim']."'";
			$data['mutuelle']= $data['mutuelle']=='' ? 'DEFAULT' : "'".$data['mutuelle']."'";
			$data['medico']= $data['medico']=='' ? 'DEFAULT' : "'".$data['medico']."'";
			$data['csdate']= $data['csdate']=='' ? 'DEFAULT' : "'".$data['csdate']."'";
			$data['adate']= $data['adate']=='' ? 'DEFAULT' : "'".$data['adate']."'";

			if(isset($data['cod'])): // edit worker
				$db->setquery("update worker set cod_category='".$data['catpro']."', cod_entreprise='".$data['entreprise']."', cod_nfc='".$data['nfc']."', name='".$data['nome']."', contact='".$data['mobile']."', contact112='".$data['c112']."', data_nascimento=".$data['datanasc'].", idade='".$data['idade']."', estado_civil='".$data['ecivil']."', nacionalidade='".$data['nac']."', cc='".$data['cc']."', cc_validade=".$data['ccvalid'].", nif='".$data['nif']."', niss='".$data['niss']."', filhos='".$data['filhos']."', filhos_encargo='".$data['filhosenc']."', email='".$data['email']."', data_inicio_trabalho=".$data['datainicio'].", morada='".$db->link->real_escape_string($data['morada'])."', prob_saude='".$data['saude']."', nib='".$data['nib']."', peso='".$data['peso']."', altura='".$data['altura']."', calcas='".$data['calcas']."', pe='".$data['pe']."', casaco='".$data['casaco']."', contrato_inicio=".$data['contratoinicio'].", contrato_fim=".$data['contratofim'].", destacamento_inicio=".$data['destacamentoinicio'].", destacamento_fim=".$data['destacamentofim'].", act_inicio=".$data['actinicio'].", act_fim=".$data['actfim'].", a1_inicio=".$data['a1inicio'].", a1_fim=".$data['a1fim'].", mutuelle_inicio=".$data['mutuelle'].", medico_inicio=".$data['medico'].", salario='".$data['salario']."', refeicao='".$data['refeicao']."', ajudascusto='".$data['acusto']."', localizacao='".$data['loc']."', classificacao='".$data['class']."', naturalidade='".$data['natura']."', concelho='".$data['concelho']."', activo='".$data['ativo']."', activo_date=".$data['adate'].", csaude_validade=".$data['csdate'].", cod_meal_place='".$data['mealplace']."', cod_lodging='".$data['lodge']."', notes='".$notes."', room='".$room."', card_auth_key='".$data['nfckey']."' where cod_worker='".$data['cod']."'");
			  	$response['message'] = 'Ficha trabalhador actualizada com sucesso';
			  	$response['code'] = $data['cod'];
			else:
				$db->setquery("insert into worker set cod_category='".$data['catpro']."', cod_entreprise='".$data['entreprise']."', cod_nfc='".$data['nfc']."', name='".$data['nome']."', contact='".$data['mobile']."', contact112='".$data['c112']."', data_nascimento=".$data['datanasc'].", idade='".$data['idade']."', estado_civil='".$data['ecivil']."', nacionalidade='".$data['nac']."', cc='".$data['cc']."', cc_validade=".$data['ccvalid'].", nif='".$data['nif']."', niss='".$data['niss']."', filhos='".$data['filhos']."', filhos_encargo='".$data['filhosenc']."', email='".$data['email']."', data_inicio_trabalho=".$data['datainicio'].", morada='".$data['morada']."', prob_saude='".$data['saude']."', nib='".$data['nib']."', peso='".$data['peso']."', altura='".$data['altura']."', calcas='".$data['calcas']."', pe='".$data['pe']."', casaco='".$data['casaco']."', contrato_inicio=".$data['contratoinicio'].", contrato_fim=".$data['contratofim'].", destacamento_inicio=".$data['destacamentoinicio'].", destacamento_fim=".$data['destacamentofim'].", act_inicio=".$data['actinicio'].", act_fim=".$data['actfim'].", a1_inicio=".$data['a1inicio'].", a1_fim=".$data['a1fim'].", mutuelle_inicio=".$data['mutuelle'].", medico_inicio=".$data['medico'].", salario='".$data['salario']."', refeicao='".$data['refeicao']."', ajudascusto='".$data['acusto']."', localizacao='".$data['loc']."', classificacao='".$data['class']."', naturalidade='".$data['natura']."', concelho='".$data['concelho']."', activo='".$data['ativo']."', activo_date=".$data['adate'].", csaude_validade=".$data['csdate'].", cod_meal_place='".$data['mealplace']."', cod_lodging='".$data['lodge']."', notes='".$notes."', room='".$room."', card_auth_key='".$data['nfckey']."'");
				$query=$db->getquery("select cod_worker from worker where name='".$data['nome']."'");
			  	$response['message'] = $attendance_add_success;
			  	$response['code'] = $query[0][0];
			endif;

elseif($data['request']=='addworkerfile'):
			CheckFile($db, $data, $iv, $secretKey);
			CheckJsonParams($data,$iv,$secretKey, array('file','user'));
			$fileName=generateRandomString().'.pdf';
			if($data['file']=="contrato"):
				$uploadDir = $server['root']['files']."contratos/";
				$key="contrato_file";
			elseif($data['file']=="a1"):
				$uploadDir = $server['root']['files']."a1/";
				$key="a1_file";
			elseif($data['file']=="act"):
				$uploadDir = $server['root']['files']."act/";
				$key="act_file";
			elseif($data['file']=="destacamento"):
				$uploadDir = $server['root']['files']."destacamento/";
				$key="destacamento_file";
			elseif($data['file']=="mutuelle"):
				$uploadDir = $server['root']['files']."mutuelle/";
				$key="mutuelle_file";
			elseif($data['file']=="medico"):
				$uploadDir = $server['root']['files']."medico/";
				$key="medico_file";
			elseif($data['file']=="gruista"):
				$uploadDir = $server['root']['files']."gruista/";
				$key="gruista_file";
			elseif($data['file']=="cc"):
				$uploadDir = $server['root']['files']."cc/";
				$key="cc_file";
			elseif($data['file']=="csaude"):
				$uploadDir = $server['root']['files']."csaude/";
				$key="csaude_file";
			elseif($data['file']=="photo"):
				$uploadDir = $server['root']['photos'];
				$key="photo";
				$fileName=($data['file']=="photo" ? generateRandomString().'.jpg' : generateRandomString().'.pdf') ;
			endif;

			while (is_file($uploadDir. $fileName)):
				$fileName=($data['file']=="photo" ? generateRandomString().'.jpg' : generateRandomString().'.pdf') ;
			endwhile;
			
			if(move_uploaded_file($_FILES['file']['tmp_name'], $uploadDir.$fileName)):

				$response=[];
				$query=$db->getquery("select ".$key." from worker where cod_worker='".$data['user']."'");
				if($query[0][0]<>""):
					unlink($uploadDir.$query[0][0]);
				endif;
				$query=$db->setquery("update worker set ".$key."='".$fileName."' where cod_worker='".$data['user']."'");
			 	$response['error'] = false; 
			  	$response['message'] = $checkCredentials_welcome;

			else:
				$response['error'] = true; 
		  		$response['message'] = $file_not_found;
			endif;

else:
	$response['error'] = true; 
	$response['message'] = $invalid_request;

endif;


?>