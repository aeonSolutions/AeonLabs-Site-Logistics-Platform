<?php
function isWeekend($date) {
    return (date('N', strtotime($date)) >= 6);
}


function add_months($months, DateTime $dateObject) {
	$next = new DateTime($dateObject->format('Y-m-d'));
	$next->modify('last day of +'.$months.' month');

	if($dateObject->format('d') > $next->format('d')) {
		return $dateObject->diff($next);
	} else {
		return new DateInterval('P'.$months.'M');
	}
}

function endCycle($d1, $months){
	$date = new DateTime($d1);

	// call second function to add the months
	$newDate = $date->add(add_months($months, $date));

	// goes back 1 day from date, remove if you want same day of month
	$newDate->sub(new DateInterval('P1D')); 

	//formats final date to Y-m-d form
	$dateReturned = $newDate->format('Y-m-d'); 

	return $dateReturned;
}
?>