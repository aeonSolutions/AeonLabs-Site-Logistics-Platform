<?php
if(isset($_POST['origin'])):
	if($_POST['origin']=="foreman"):
		define("COOKIE_GOES_TO_THE_BEACH",true);
		//load  encryption secret key
		include("config/site.key.php");
		// load api
		include("site.php");
	elseif($_POST['origin']=="worker"):
		define("COOKIE_GOES_TO_THE_BEACH",true);
		//load  encryption secret key
		include("config/worker.key.php");
		// load api
		include("worker.php");
	elseif($_POST['origin']=="office"):
		define("COOKIE_GOES_TO_THE_BEACH",true);
		//load  encryption secret key
		include("config/office.key.php");
		// load api
		include("office.php");

	elseif($_POST['origin']=="installoffice"):
		define("COOKIE_GOES_TO_THE_BEACH",true);
		//load  encryption secret key
		include("config/install.key.php");
		// load api
		include("office.php");
	elseif($_POST['origin']=="installworker"):
		define("COOKIE_GOES_TO_THE_BEACH",true);
		//load  encryption secret key
		include("config/install.key.php");
		// load api
		include("worker.php");
	elseif($_POST['origin']=="installsite"):
		define("COOKIE_GOES_TO_THE_BEACH",true);
		//load  encryption secret key
		include("config/install.key.php");
		// load api
		include("site.php");
	else:
		$actual_link = (isset($_SERVER['HTTPS']) && $_SERVER['HTTPS'] === 'on' ? "https" : "http") . "://".$_SERVER['HTTP_HOST'];
		header($actual_link);
	endif;
else:
	$actual_link = (isset($_SERVER['HTTPS']) && $_SERVER['HTTPS'] === 'on' ? "https" : "http") . "://".$_SERVER['HTTP_HOST'];
	header($actual_link);
endif;
?>