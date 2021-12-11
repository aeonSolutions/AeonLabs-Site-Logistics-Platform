<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array(); 
if($data["type"]=="unknown"):
	$query=$db->getquery("select cod_user, cod_nfc from users where email='".$data['email']."'");
else:
	$query=$db->getquery("select users.cod_user, users.cod_nfc from users left join users_type on users.cod_type=users_type.cod_type where users.email='".$data['email']."' and users_type.sigla='".$data['type']."'");
endif;

if($query[0][0]<>''): // results found
	//send email
	require_once $server['root']['path'].'system/mail/swift_required.php';
	require_once $server['root']['path'].'system/settings.php';

	// Create the email and send the message
	$email_subject = $enterpriseName." - ".$forgotIdSendEmail_email_subject;
	$email_body = $forgotIdSendEmail_email_message.": ".$query[0][1];
	$message = "";

	$transport = Swift_SmtpTransport::newInstance($mailServer_address, $mailServer_port, $mailServerType)
	->setUsername($mailServerUsername)
	->setPassword($mailServePassword)
	;
	$mailer = Swift_Mailer::newInstance($transport);

	// Criar o cabeçalho, assim como a mensagem
	$message = Swift_Message::newInstance($email_subject)
	->setFrom(array($mailServerDefaultEmail => $enterpriseName))
	->setTo(array($data['email']))
	->setBody($email_body)
	;
	// Efectuar o envio
	$result = $mailer->send($message);
	if($result==0): //error sending
		$response['error'] = True; 
		$response['message'] = $forgotIdSendEmail_not_sent;
	else:
		$response['error'] = False; 
		$response['message'] = $forgotIdSendEmail_sent;
	endif;
else:
	$response['error'] = true; 
	$response['message'] = $checkCredentials_user_not_found;
endif;
?>