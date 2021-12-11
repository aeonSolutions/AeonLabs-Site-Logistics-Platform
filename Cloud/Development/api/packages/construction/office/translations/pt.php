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
$attendance_without_checkout="s/ checkout";
$attendance_worker_not_found="Trabalhador não encontrado. Contacte o esxcritório";

$list_workers_onsite_today_no_records_found="Registos nao encontrados para o dia seleccionado";

$list_on_journal_workers_onsite_today_no_records_found="Nao existe registo de trabalhadores nesta obra para a data seleccionada";
$list_on_journal_workers_onsite_today_team_not_found="Nao tem equipa definida nesta obra";

$journal_entry_not_found="Apontamento nao encontrado";
$journal_entry_not_found_selected_day="Nao tem notas apontadas para o dia seleccionado";

$bordereau_missing="Nao tem Mapa de tarefas definido nesta obra";
$bordereau_avenant_registed="Tarefa extra registada com sucesso";
$bordereau_add_avenant_tag="Adicionar uma tarefa extra ao mapa de tarefas";
$bordereau_add_avenant_title="Tarefas adicionais";

$livraison_missing="Nao tem notas de entrega nesta obra";

$occurrences_missing="Nao tem ocorrências registadas nesta obra";
$occurrences_missing_site_manager="Conducteur nao encontrado";

$project_missing="Nao tem planos de projecto registados nesta obra";

$production_success_add_qtd="Quantidade adicionada com sucesso";
$production_qtd_not_found="Quantidade nao encontrada";
$production_list_qtd_not_found="Não tem quantidades inseridas até à data este mês";

$regie_work_worker_already_at_regie="Já se encontra a trabalhar em regie";
$regie_work_workers_at_regie="trabalhadores alocados à  Regie. Hora de inicio:";
$regie_work_conducteur_not_found="Conducteur nao encontrado.";
$regie_work_note_saved="Apontamento Regie gravado com sucesso";
$regie_work_regie_list_not_found="Nao foram encontradas marcações a Regie";
$regie_work_regie_not_found="Marcação à regie não encontrada.";
$regie_work_duration="Duração";
$regie_work_regie_not_found_for_selected_date="Nao existem marcacoes à regie para o dia seleccionado";
$regie_work_ongoing="a decorrer";
$regie_work_without_record="s/ reg.";

$photos_del_photo_not_found="Foto a apagar nao encontrada na DB";
$photos_photo_added="Foto adicionada.";
$photos_upload_error="Erro no upload da foto";
$photos_upload_max_size="'The uploaded file exceeds the upload_max_filesize directive in php.ini'";
$photos_upload_max_size_html_form="The uploaded file exceeds the MAX_FILE_SIZE directive that was specified in the HTML form";
$photos_upload_partial_file="Ficheiro nao foi totalmente transferido";
$photos_no_file_found_on_data_post="Ficheiro nao encontrado no upload";
$photo_file_not_found="Ficheiro de foto nao encontrado no sistema";
$photo_not_found_db="Foto a apagar nao encontrada na DB";

$weather_error_log_info="Erro ao registar a inf. do tempo";
$weather_sucess_log_info="Informaçäo do tempo registado com sucesso";

$auth_not_on_a_site="Nao se encontra numa obra";
$auth_not_auth_on_this_site="Nao tem autorização nesta obra. Contacte o Encarregado Geral";
$auth_welcome_to="Bem vindo a";
$auth_no_credential="Nao tem credencial para esta obra";
$auth_unk_user="Utilizador nao encontrado no sistema";
$auth_missing_team="Nao tem equipa atribuida. Contacte o Encarregado Geral";
$auth_card_not_found="O cartao nao se encontra registado no sistema";
$auth_mobile_device_not_found="O seu equipamento necessita de autorizacao para continuar. Contacte o escritório para mais info.";
$auth_mobile_device_is_disabled="O seu equipamento está desactivado. Contacte o escritório para mais info.";

//bordereau
$bordereau_has_production_records="Não foi possivel eliminar a tarefa. Existem registos de produção para a tarefa selecionada."
?>