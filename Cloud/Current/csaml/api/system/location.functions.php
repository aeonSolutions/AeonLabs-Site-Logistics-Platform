<?php
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
?>