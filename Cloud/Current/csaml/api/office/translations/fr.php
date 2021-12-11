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
$attendance_worker_not_found="Ouvrier non trouvé. Contacter le bureau";

$list_workers_onsite_today_no_records_found="aucun enregistrement trouvé pour aujourd'hui";

$list_on_journal_workers_onsite_today_no_records_found="Aucune fiche de présence trouvée pour le site sélectionné";
$list_on_journal_workers_onsite_today_team_not_found="Équipe non trouvée pour ce site. Contact le chef de Chantier général";

$journal_entry_not_found="Entrée de journal non trouvée";
$journal_entry_not_found_selected_day="Entrée de journal introuvable pour le jour sélectionné.";

$bordereau_missing="Aucune activité de plan de travail trouvée pour ce site";
$bordereau_avenant_registed="Activité supplémentaire enregistrée avec succès";
$bordereau_add_avenant_tag="Ajouter une tâche supplémentaire";
$bordereau_add_avenant_title="Tâches supplémentaires";

$livraison_missing="Bons de livraison non trouvées pour ce site";

$occurrences_missing="Aucune occurrence trouvée pour ce site";
$occurrences_missing_site_manager="Gestionnaire de site non trouvé";

$project_missing="Aucun fichier de projet trouvé pour ce site";

$production_success_add_qtd="Exécution quotidienne de la production ajoutée avec succès";
$production_qtd_not_found="Exécution quotidienne de la production non trouvée";
$production_list_qtd_not_found="Aucune exécution de production quotidienne trouvée pour ce mois";

$regie_work_worker_already_at_regie="Ouvrier travaille déjà à la régie";
$regie_work_workers_at_regie="ouvrier(s) affectés à la régie. Heure de début:";
$regie_work_conducteur_not_found="Gestionnaire de site non trouvé";
$regie_work_note_saved="Note d'entrée de la régie enregistrée avec succès";
$regie_work_regie_list_not_found="Il n'y a aucun ouvrier affecté à la régie pour le moment";
$regie_work_regie_not_found="Enregistrement de la régie introuvable";
$regie_work_duration="Durée";
$regie_work_regie_not_found_for_selected_date="Aucun enregistrement de régie trouvé pour le jour sélectionné";
$regie_work_ongoing="en cours";
$regie_work_without_record="s/ reg.";

$photos_del_photo_not_found="photo introuvable sur la DB à supprimer";
$photos_photo_added="La photo a été ajoutée avec succès";
$photos_upload_error="Erreur lors du téléchargement de la photo";
$photos_upload_max_size="'Le fichier téléchargé dépasse la directive upload_max_filesize dans php.ini'";
$photos_upload_max_size_html_form="Le fichier téléchargé dépasse la directive MAX_FILE_SIZE spécifiée dans le formulaire HTML.";
$photos_upload_partial_file="Erreur: le fichier n'a été que partiellement transféré.";
$photos_no_file_found_on_data_post="Erreur: fichier non trouvé sur la demande POST";
$photo_file_not_found="fichier photo non trouvé";
$photo_not_found_db="photo introuvable sur la DB à supprimer";

$weather_error_log_info="erreur d'enregistrement info météo";
$weather_sucess_log_info="infos météo enregistrées avec succès";

$auth_not_on_a_site="Vous n'êtes pas actuellement sur un chantier de construction";
$auth_not_auth_on_this_site="Vous n'avez pas la permission pour ce chantier.  Contact le chef de Chantier général";
$auth_welcome_to="Bienvenue à ";
$auth_no_credential=" n'a aucun identifiant valide pour ce site";
$auth_unk_user="Utilisateur inconnu trouvé";
$auth_missing_team="Vous n'avez pas d'équipe assignée. Contact le chef de Chantier généra";
$auth_card_not_found="Votre carte n'est pas enregistrée sur le système";
$auth_mobile_device_not_found="Votre appareil a besoin d'une autorisation pour continuer. Contactez le bureau pour plus d'informations";
$auth_mobile_device_is_disabled="Votre appareil a besoin d'une autorisation pour continuer. Contactez le bureau pour plus d'informations";
$auth_mobile_device_is_disabled="Votre équipement est désactivé. Contactez le bureau pour plus d'informations";

//bordereau
$bordereau_has_production_records="Impossible de supprimer l'enregistrement. La tâche a des enregistrements de production."
	
?>