<?php

function encodeString16($str){
	
	$converted = iconv(mb_detect_encoding($str), 'ISO-8859-1', $str);
	if (false === $converted ):
		return utf8_encode($str);
	else:
		return $converted;
	endif;
}

function utf8ize($mixed) {
    if (is_array($mixed)) {
        foreach ($mixed as $key => $value) {
            $mixed[$key] = utf8ize($value);
        }
    } else if (is_string ($mixed)) {
        return utf8_encode($mixed);
    }
    return $mixed;
}


function CheckLetters($field){
	$server['root']['path']=substr(__FILE__,0,strpos(__FILE__,"csaml"))."csaml/"; // file system path
	$letters = file($server['root']['path']."api/system/utf8_char_conversion.csv", FILE_IGNORE_NEW_LINES);
	for($i=0;$i<count($letters);$i++):
		$values=explode(";", $letters[$i]);
		$find[$i]=$values[1];
		$replace[$i]=$values[0];
	endfor;
	return (str_replace($find, $replace, $field));
}

function convert_utf8( $string ) { 
    if ( strlen(utf8_decode($string)) == strlen($string) ) {   
        // $string is not UTF-8
        return iconv("ISO-8859-1", "UTF-8", $string);
    } else {
        // already UTF-8
        return $string;
    }
}
?>