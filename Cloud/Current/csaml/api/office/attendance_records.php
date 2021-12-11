<?php
if(!defined("COOKIE_GOES_TO_TOWN")):
	die();
endif;
$response = array();
if(isset($data['type'])):
	if($data['type']=="lock"):
		$db->setquery("update site_section set attendances_last_close='".$data['date']."' where cod_site='".$data['site']."' and cod_section='".$data['section']."'");
		$response['error'] = false; 
		$response['message'] = $attendance_edit_success;
	elseif($data['type']=="add"):
		CheckJsonParams($data,$iv,$secretKey, array('worker','status','absense'));
		$motif= isset($data['motif']) ? "and validation_reason='".$data['motif']."'":"";
		$foremanCodCategory=$db->getquery("select cod_category from worker_categories where reference='frm' or reference='gfrm'");
		$category="";
		for($i=0; $i<count($foremanCodCategory);$i++):
			$category.= ($i>0) ? "or " : "";
			$category.="cod_category='".$foremanCodCategory[$i][0]."'";
		endfor;
		
		if($data['status']=="checkout"):
			$db->setquery("update record set checkout='00:00:00' where cod_worker='".$data['worker']."'and date='".$data['date']."' and cod_site='".$data['site']."' and cod_section='".$data['section']."' ".$motif);
			$response['error'] = false; 
			$response['message'] = $attendance_edit_success;
		else:
			$step=false;
			if(isset($data['teams']) and ($data['status']=="MO" or $data['status']=="EP")):
				$worker=$db->getquery("select cod_category from record where cod_worker='".$data['worker']."' and cod_site='".$data['site']."' and cod_section='".$data['section']."' and (date between '".date("Y-m-01", strtotime($data['date']))."' and '".date("Y-m-t", strtotime($data['date']))."') and ".$category);
				if($worker[0][0]<>"" or !(strpos($data['tasks'],"T")===false)):
					if($data['status']=="MO"):
						$db->setquery("delete from site_chef_equipe where cod_worker='".$data['worker']."'and date='".$data['date']."'and cod_site='".$data['site']."'and cod_section='".$data['section']."'");
					else: //EP
						$db->setquery("insert into site_chef_equipe set cod_worker='".$data['worker']."', date='".$data['date']."', cod_site='".$data['site']."', cod_section='".$data['section']."'");
					endif;
					$step=true;
				else:
					$response['error'] = true; 
					$response['message'] = $attendance_chef_not_found;
				endif;
			else:
				$step=true;
			endif;
			if ($step):
				if($data['absense']<>"null"):
					$absense="absense='".$data['absense']."'";
				else:
					$absense="absense=NULL";
				endif;
				$record=$db->getquery("select record.checkin, record.checkout, site.name, record.status from record left join site on record.cod_site=site.cod_site where record.cod_worker='".$data['worker']."' and record.date='".$data['date']."' and record.cod_site<>'".$data['site']."' and record.status<>'PI' and record.status<>'S' and record.status<>'EP' and record.status<>'MO'");

				if( ( ($record[0][0]<>'00:00:00' and $record[0][0]<>'') or ($record[0][1]<>'00:00:00' and $record[0][1]<>'') ) and !isset($data['teams']) ):
					$response['error'] = true; 
					$response['message'] = $attendance_duplicate_record." | ".$record[0][2]." |";
				else:
					$craneman= isset($data['craneman']) ? ",category_works_duration='".$data['craneman']."'" : "";
					$motif= isset($data['motif']) ? ", validation_reason='".$data['motif']."'":"";
					$category= isset($data['category']) ? ", cod_category='".$data['category']."'":"";
					$tasks= isset($data['tasks']) ? ", tasks='".$data['tasks']."'":"";
					$bundle=$craneman.$motif.$category.$tasks;

					$record=$db->getquery("select cod_record, status, checkin from record where cod_worker='".$data['worker']."'and date='".$data['date']."' and cod_site='".$data['site']."' and cod_section='".$data['section']."'");
					
					if($record[0][0]<>""): // ja existe registo
						if(isset($data['teams'])):
							if($record[0][1]<>'' and  $record[0][1]<>'EP' and $record[0][1]<>'MO' and $record[0][1]<>'S'):
								$status="";
							else:
								$status=", status='".$data['status']."'";
							endif;
							if(($record[0][1]=='' or  $record[0][1]=='EP' or $record[0][1]=='MO') and $record[0][2]<>'' and $record[0][2]<>'00:00:00'): // with checkin and no status validation
								$checkin="";
							else:
								$checkin=", checkin='00:00:00'";
							endif;
						else:
							$settings=$db->getquery("select disable_checkin, disable_checkout from settings");
							$checkin= $settings[0][0]=="1" ? ", checkin='00:00:00'": "";
							$checkin.= $settings[0][1]=="1" ? ", checkout='00:00:00'": "";
							$status=", status='".$data['status']."'";
						endif;
						if($data['status']=='clearcheckout'):
							$db->setquery("update record set checkout='00:00:00' where cod_worker='".$data['worker']."'and date='".$data['date']."' and cod_site='".$data['site']."' and cod_section='".$data['section']."'");
						else:
							$db->setquery("update record set ".$absense.$status.$checkin.$bundle." where cod_worker='".$data['worker']."'and date='".$data['date']."' and cod_site='".$data['site']."' and cod_section='".$data['section']."'");
						endif;
						$response['error'] = false; 
						$response['message'] = $attendance_edit_success;
					else: // new record		
						$category= isset($data['category']) ? ", cod_category='".$data['category']."'" : "";
					
						$query="insert into record set ".$absense.", cod_worker='".$data['worker']."', date='".$data['date']."', cod_site='".$data['site']."', cod_section='".$data['section']."', status='".$data['status']."', checkin='00:00:00', checkout='00:00:00' ".$bundle;
						$db->setquery($query);
						$response['error'] = false; 
						$response['message'] = $attendance_add_success;
					endif;
				endif;
			endif;
		endif;
	elseif($data['type']=='del'):
		$step=false;
		CheckJsonParams($data,$iv,$secretKey, array('worker','status','absense'));

		if(isset($data['teams'])):
			$db->setquery("delete from site_chef_equipe where cod_worker='".$data['worker']."'and date='".$data['date']."'and cod_site='".$data['site']."'and cod_section='".$data['section']."'");
		endif;

		$chefs=$db->getquery("select cod_chef_equipe from site_chef_equipe where cod_site ='".$data['site']."' and cod_section='".$data['section']."' and cod_worker='".$data['worker']."' and date='".$data['date']."'");

		$motif= isset($data['motif']) ? ", validation_reason='".$data['motif']."'":"";

		$currentRecord=$db->getquery("select checkin, checkout, date from record where cod_site ='".$data['site']."' and cod_section='".$data['section']."' and cod_worker='".$data['worker']."' and date='".$data['date']."'");
		if(($currentRecord[0][1]=="" or $currentRecord[0][1]=="00:00:00") and ($currentRecord[0][0]=="" or $currentRecord[0][0]=="00:00:00")): // no time logging found
			$history="";
		else: // record exists						
			$history=", history=CONCAT(history,'".chr(13)."checkin:".$currentRecord[0][0]."; checkout:".$currentRecord[0][1].chr(13)."')";
		endif;
		$bundle=$motif.$history;

		if($chefs[0][0]<>""):
			$db->setquery("update record set checkin='00:00:00', checkout='00:00:00', status='EP', absense='00:00:00', notas='', tasks='', category_works_duration='00:00:00'".$bundle." where cod_site ='".$data['site']."' and cod_section='".$data['section']."' and cod_worker='".$data['worker']."' and date='".$data['date']."'");
			$response['message'] = "cleared record. chef status.";
		elseif($history=="" and $motif==""):
			$response['message'] = $attendance_del_success;
			$db->setquery("delete from record where cod_site ='".$data['site']."' and cod_section='".$data['section']."' and cod_worker='".$data['worker']."' and date='".$data['date']."'");
		else:
			$response['message'] ="suppressed status";
			$db->setquery("update record set checkin='00:00:00', checkout='00:00:00', status='S', tasks='' ".$bundle." where cod_site ='".$data['site']."' and cod_section='".$data['section']."' and cod_worker='".$data['worker']."' and date='".$data['date']."'");
		endif;
		$response['error'] = false; 
	endif;
endif;
?>