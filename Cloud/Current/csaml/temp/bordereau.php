<?php

//settings
$cod_site="1";
$cod_section="1";

error_reporting(E_ALL);
ini_set('display_errors', 1);
require("initializer.php");
require("language.functions.php");

$db->connect(true);
setlocale(LC_ALL, 'fr_FR');
$server['root']['path']=substr(__FILE__,0,strpos(__FILE__,"csaml"))."csaml/temp/"; // file system path

if(is_file($server['root']['path']."bordereau.csv")):
	$lines = file($server['root']['path']."bordereau.csv", FILE_IGNORE_NEW_LINES);
else:
	echo "file not found";
endif;

echo "Lines:".chr(13).count($lines).chr(13);
$headers=explode(";",$lines[0]);

echo "HEADERS:";
echo $lines[0].chr(13).chr(13);

for($i=1;$i<count($lines);$i++):
	
	$arr=array();
	$arr=explode(";",$lines[$i]);
	$queryStr="";
	$translations = array();
	
	//echo "_____________________START RECORD_______________________".chr(13)."LINE:".$lines[$i].chr(13)."ARRAY:".print_r($arr).chr(13);
	
	for($j=0;$j<count($headers);$j++):
		if ($headers[$j]=="reference"):
			$queryStr.=$queryStr=="" ? "" : substr($queryStr, -1)=="," ? "" : ", ";
			$queryStr.="contractor_ref='".CheckLetters(($arr[$j]))."'";
		endif;
		if ($headers[$j]=="description"):
			$queryStr.=$queryStr=="" ? "" : substr($queryStr, -1)=="," ? "" : ", ";
			$queryStr.="descricao='".addslashes(str_replace(chr(13)," ", CheckLetters($arr[$j])))."'";
		endif;
		if ($headers[$j]=="quantity"):			
			$arr[$j]= (is_numeric($arr[$j]) or $arr[$j]=="") ? $arr[$j] : "ERROR";
			$queryStr.=$queryStr=="" ? "" : substr($queryStr, -1)=="," ? "" : ", ";
			$queryStr.="qtd='".CheckLetters(($arr[$j]))."'";
		endif;
		if ($headers[$j]=="units"):
			$queryStr.=$queryStr=="" ? "" : substr($queryStr, -1)=="," ? "" : ", ";
			$queryStr.="units='".CheckLetters(($arr[$j]))."'";
		endif;
		if ($headers[$j]=="price"):
			$queryStr.=$queryStr=="" ? "" : substr($queryStr, -1)=="," ? "" : ", ";
			$queryStr.="pu='".CheckLetters(($arr[$j]))."'";
		endif;
		if ($headers[$j]=="enabled"):
			$queryStr.=$queryStr=="" ? "" : substr($queryStr, -1)=="," ? "" : ", ";
			$queryStr.="enabled='".CheckLetters(($arr[$j]))."'";
		endif;
		if ($headers[$j]=="pt"):
			$translations['pt']=addslashes(str_replace(chr(13)," ", CheckLetters($arr[$j])));
		endif;
		if ($headers[$j]=="en"):
			$translations['en']=addslashes(str_replace(chr(13)," ", CheckLetters($arr[$j])));
		endif;
		if ($headers[$j]=="fr"):
			$translations['fr']=addslashes(str_replace(chr(13)," ", CheckLetters($arr[$j])));
		endif;
		if ($headers[$j]=="nl"):
			$translations['nl']=addslashes(str_replace(chr(13)," ", CheckLetters($arr[$j])));
		endif;
	endfor;

	if(!empty($translations)):
		$tmp="{";
		$pos=0;
		foreach ($translations as $key => $value):
			if($pos>0):
				$tmp.=",";
			endif;
			$tmp.='"'.$key.'":"'.$value.'"';
			$pos++;
		endforeach;
		$tmp.='}';

		$queryStr.=$queryStr=="" ? "" : substr($queryStr, -1)=="," ? "" : ", ";
		$queryStr.="translations='".$tmp."'";
	endif;

	$query="insert into bordereau set cod_site='".$cod_site."', cod_section='".$cod_section."'".$queryStr;

	//for testing query string only
	echo $query.chr(13);
	$db->setquery($query);
endfor;
$db->connect(false);
echo "Adicionados ".count($lines)." registos à DB. OK";

?>