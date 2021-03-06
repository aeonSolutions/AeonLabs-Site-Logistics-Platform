<?php
//errors
$errorDecryptOnServer="Error decrypting on server";
$errorEncryptOnServer="Error ecrypting on server";
$invalid_request="Invalid request";

// check device ID
$device_pc_not_found="Your computer is not authorized in the system. Please contact the Office for more information";
$device_pc_added="Your device is authorized";

//check credentials
$checkCredentials_welcome="Welcome";
$checkCredentials_user_not_found="User not found.";

//forgot id send email
$forgotIdSendEmail_not_sent="Error sending email.";
$forgotIdSendEmail_sent="An email has just been sent with instructions on how to proceed.";
$forgotIdSendEmail_email_subject="Forgot company ID";
$forgotIdSendEmail_email_message="Your access ID is";

// send secret key
$secretKey_not_found="Error loading Public Key. Please contact the Office for more information";

//AddOns
$addons_found="Addons available";
$addons_not_found="No available addons";

//site Closure
$siteclosure_found="closed days found";
$siteclosure_not_found="no closed days found";

//unscheduled works / regie
$regie_checkout_eod="checkout EoD";
$regie_default_eod="default EoD";
$regie_ongoing="ongoing";
$regie_completed="completed";
$regie_no_records="No records found of unscheduled works";
$regie_edit_success="Record edited sucessfully";
$regie_add_success="Record added successfully";
$regie_del_success="Record deleted successfully";


//workers attendance
$workers_no_workers_on_site="no workers found on site for the selected date";
$attendance_edit_success="Record successfully edited";
$attendance_add_success="Record successfully added";
$attendance_del_success="Record successfully deleted";
$attendance_chef_not_found="Site foreman not found";
$attendance_duplicate_record="worker already have a record on another site at the same day";
$unable_to_del_records_present="worker already has an attendance record on this site";

//holidays
$holidays_alreaday_exists="Date alreaday on the system";
$holidays_alreaday_del="Date already deleted from the system";
$holidays_del="Date removed from the system";
$holidays_add="Date added to the system";

//photos
$photo_error_upload="Error on uploading photo";

//journal
$journal_error_upload="Error on uploading file";

// request files
$file_not_found="File not found";

//company client
$company_error_del="You can not delete this company. There are construction site associated with it";

//bordereau
$map_not_found="No task list map found for the selected site";

// site production measurements
$production_no_data="No production measurments found for the selection";

//photos
$photos_del_photo_not_found="photo not found on DB to delete";
$photos_photo_added="Photo was added successfully";
$photos_upload_error="Error uploading photo";
$photos_upload_max_size="'The uploaded file exceeds the upload_max_filesize directive in php.ini'";
$photos_upload_max_size_html_form="The uploaded file exceeds the MAX_FILE_SIZE directive that was specified in the HTML form";
$photos_upload_partial_file="Error: File was only partially transfered. ";
$photos_no_file_found_on_data_post="Error: File not found on POST request";
$photo_file_not_found="photo file not found";
$photo_not_found_db="photo not found on DB to delete";
$file_not_found="file not found";

// site delivery documents
$delivery_no_data="No delivery documents found for the selection";

//worker details
$worker_details_not_working_today="Selected worker is not logged into any construction site";

// site
$site_initials_duplicate="Site initials already present on database. Choose a different set of letters.";







//Attendance
$attendance_without_checkout="s/ check-out";
$attendance_worker_not_found="Ouvrier non trouv??. Contacter le bureau";

$list_workers_onsite_today_no_records_found="aucun enregistrement trouv?? pour aujourd'hui";

$list_on_journal_workers_onsite_today_no_records_found="Aucune fiche de pr??sence trouv??e pour le site s??lectionn??";
$list_on_journal_workers_onsite_today_team_not_found="??quipe non trouv??e pour ce site. Contact le chef de Chantier g??n??ral";

$journal_entry_not_found="Entr??e de journal non trouv??e";
$journal_entry_not_found_selected_day="Entr??e de journal introuvable pour le jour s??lectionn??.";

$bordereau_missing="Aucune activit?? de plan de travail trouv??e pour ce site";
$bordereau_avenant_registed="Activit?? suppl??mentaire enregistr??e avec succ??s";
$bordereau_add_avenant_tag="Ajouter une t??che suppl??mentaire";
$bordereau_add_avenant_title="T??ches suppl??mentaires";

$livraison_missing="Bons de livraison non trouv??es pour ce site";

$occurrences_missing="Aucune occurrence trouv??e pour ce site";
$occurrences_missing_site_manager="Gestionnaire de site non trouv??";

$project_missing="Aucun fichier de projet trouv?? pour ce site";

$production_success_add_qtd="Ex??cution quotidienne de la production ajout??e avec succ??s";
$production_qtd_not_found="Ex??cution quotidienne de la production non trouv??e";
$production_list_qtd_not_found="Aucune ex??cution de production quotidienne trouv??e pour ce mois";

$regie_work_worker_already_at_regie="Ouvrier travaille d??j?? ?? la r??gie";
$regie_work_workers_at_regie="ouvrier(s) affect??s ?? la r??gie. Heure de d??but:";
$regie_work_conducteur_not_found="Gestionnaire de site non trouv??";
$regie_work_note_saved="Note d'entr??e de la r??gie enregistr??e avec succ??s";
$regie_work_regie_list_not_found="Il n'y a aucun ouvrier affect?? ?? la r??gie pour le moment";
$regie_work_regie_not_found="Enregistrement de la r??gie introuvable";
$regie_work_duration="Dur??e";
$regie_work_regie_not_found_for_selected_date="Aucun enregistrement de r??gie trouv?? pour le jour s??lectionn??";
$regie_work_ongoing="en cours";
$regie_work_without_record="s/ reg.";

$photos_del_photo_not_found="photo introuvable sur la DB ?? supprimer";
$photos_photo_added="La photo a ??t?? ajout??e avec succ??s";
$photos_upload_error="Erreur lors du t??l??chargement de la photo";
$photos_upload_max_size="'Le fichier t??l??charg?? d??passe la directive upload_max_filesize dans php.ini'";
$photos_upload_max_size_html_form="Le fichier t??l??charg?? d??passe la directive MAX_FILE_SIZE sp??cifi??e dans le formulaire HTML.";
$photos_upload_partial_file="Erreur: le fichier n'a ??t?? que partiellement transf??r??.";
$photos_no_file_found_on_data_post="Erreur: fichier non trouv?? sur la demande POST";
$photo_file_not_found="fichier photo non trouv??";
$photo_not_found_db="photo introuvable sur la DB ?? supprimer";

$weather_error_log_info="erreur d'enregistrement info m??t??o";
$weather_sucess_log_info="infos m??t??o enregistr??es avec succ??s";

$auth_not_on_a_site="Vous n'??tes pas actuellement sur un chantier de construction";
$auth_not_auth_on_this_site="Vous n'avez pas la permission pour ce chantier.  Contact le chef de Chantier g??n??ral";
$auth_welcome_to="Bienvenue ?? ";
$auth_no_credential=" n'a aucun identifiant valide pour ce site";
$auth_unk_user="Utilisateur inconnu trouv??";
$auth_missing_team="Vous n'avez pas d'??quipe assign??e. Contact le chef de Chantier g??n??ra";
$auth_card_not_found="Votre carte n'est pas enregistr??e sur le syst??me";
$auth_mobile_device_not_found="Votre appareil a besoin d'une autorisation pour continuer. Contactez le bureau pour plus d'informations";
$auth_mobile_device_is_disabled="Votre appareil a besoin d'une autorisation pour continuer. Contactez le bureau pour plus d'informations";
$auth_mobile_device_is_disabled="Votre ??quipement est d??sactiv??. Contactez le bureau pour plus d'informations";

//bordereau
$bordereau_has_production_records="Impossible de supprimer l'enregistrement. La t??che a des enregistrements de production."
	
?>