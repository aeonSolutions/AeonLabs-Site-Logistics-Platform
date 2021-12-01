package construction.site.logistics.foreman.login;


import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Handler;
import android.util.Patterns;
import android.view.LayoutInflater;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.lang.reflect.Method;
import java.text.DecimalFormat;
import java.util.ArrayList;

import construction.site.logistics.foreman.BuildConfig;
import construction.site.logistics.foreman.Network.HttpRequestHandler;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.Network.SendRequest;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.abstraction.GeoLocation;
import construction.site.logistics.foreman.data.LoginRepository;
import construction.site.logistics.foreman.data.Result;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.model.LoggedInUser;
import construction.site.logistics.foreman.data.state;


public class LoginViewModel extends ViewModel {

    public static MutableLiveData<LoginFormState> loginFormState = new MutableLiveData<>();
    private MutableLiveData<LoginResult> loginResult = new MutableLiveData<>();
    private LoginRepository loginRepository;

    LoginViewModel(LoginRepository loginRepository) {
        this.loginRepository = loginRepository;
    }

    LiveData<LoginFormState> getLoginFormState() {
        return loginFormState;
    }

    LiveData<LoginResult> getLoginResult() {
        return loginResult;
    }

    public void login(String username, Activity activity) {
        /*
        state.site = "1";
        state.section = "1";
        state.latitude = 0.0;
        state.longitude = 0.0;
        state.workerName = "worker test";
        state.sitename="construction site test";
        state.authRadius=10000.0;
        state.UUID=username;
        state.saveSettings();
        */


        GeoLocation gps= new GeoLocation();
        if(gps.getLocation(activity.getApplicationContext()) == null & !state.isDemonstrationEnabled){
            Toast.makeText(activity.getApplicationContext(), activity.getResources().getString(R.string.error_location_disabled), Toast.LENGTH_LONG).show();
            // Intent intent = new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS);
            // startActivity(intent);
        }else {
            EntityQueue queue= new EntityQueue();
            queue.setMsgType("silent");
            queue.setMsgSuccess("response");
            queue.setMsgError("response");
            queue.setUrl(state.HostUrl + "api/index.php");
            queue.setTitle("");
            queue.setDescription("");

            ArrayList<EntityFields> fields = new ArrayList<>();
            EntityFields field = new EntityFields();
            field.setRequestVar("task");
            field.setValue("0");
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("sn");
            field.setValue(username);
            fields.add(field);

            if (state.overrideSite){
                field = new EntityFields();
                field.setRequestVar("lat");
                field.setValue(Double.toString(state.overrideLatitude));
                fields.add(field);

                field = new EntityFields();
                field.setRequestVar("lon");
                field.setValue(Double.toString(state.overrideLongitude));
                fields.add(field);

            }else{
                field = new EntityFields();
                field.setRequestVar("lat");
                field.setValue(Double.toString(gps.getLatitude()));
                fields.add(field);

                field = new EntityFields();
                field.setRequestVar("lon");
                field.setValue(Double.toString(gps.getLongitude()));
                fields.add(field);            }

            field = new EntityFields();
            field.setRequestVar("id");
            field.setValue(state.serial);
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("language");
            field.setValue(state.getCurrentLanguage());
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("version");
            field.setValue(Integer.toString(BuildConfig.VERSION_CODE));
            fields.add(field);

            SendData sendData = new SendData( activity , null);
            sendData.addQueue(queue);
            sendData.addFields(fields);
            sendData.setEncryption(true, "AES128");
            sendData.setWaitForCode(true);
            sendData.setloadMainPage(false);
            sendData.setEnableQueue(false);
            sendData.send();
            String response= sendData.getResponse();

            Result result;

            try {
                JSONObject jsonObject = new JSONObject(response);
                if (jsonObject.getString("error").equals("false")) {
                    JSONObject auth = jsonObject.getJSONObject("auth");
                    state.site = auth.getString("site");
                    state.section = auth.getString("section");
                    state.latitude = Double.parseDouble(auth.getString("latitude"));
                    state.longitude = Double.parseDouble(auth.getString("longitude"));
                    state.workerName = auth.getString("name");
                    state.sitename=auth.getString("sitename");
                    state.authRadius=Double.parseDouble(auth.getString("authority"));
                    state.UUID=username;
                    if (auth.has("attendance")) {
                        if(auth.getString("attendance").equals("true")) {
                            state.setGarbage("attendance", 1);
                        }
                    }
                    state.saveSettings();

                    gps = new GeoLocation();
                    if (gps.getLocation(activity.getApplicationContext()) == null & !state.isDemonstrationEnabled) {
                        Toast.makeText(activity.getApplicationContext(), activity.getResources().getString(R.string.error_location_disabled), Toast.LENGTH_LONG).show();
                        // Intent intent = new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS);
                        // startActivity(intent);
                    } else {
                        // Check if GPS enabled
                        if (gps.canGetLocation()) {
                            double latitude =-1.0;
                            double longitude =-1.0;
                            double authRadius=-1.0;

                            if (state.overrideSite){
                                 latitude = state.overrideLatitude;
                                 longitude = state.overrideLongitude;
                                 authRadius = 5.0;
                            }else{
                                latitude = gps.getLatitude();
                                longitude = gps.getLongitude();
                                authRadius=state.authRadius;
                            }

                            if (latitude == -1 && longitude == -1) {
                                Functions.alertbox(activity.getResources().getString(R.string.error_title), activity.getResources().getString(R.string.error_unable_get_location), activity);
                            } else {
                                Double distance = gps.distance(state.latitude, state.longitude, latitude, longitude);
                                DecimalFormat df2 = new DecimalFormat("#.##");
                                Toast.makeText(activity.getApplicationContext(), activity.getResources().getString(R.string.info_distance) +" "+ df2.format(distance) + " km", Toast.LENGTH_LONG).show();
                                Functions.removeSimpleProgressDialog();
                                if (distance < authRadius ) {

                                    if(auth.has("sections")){
                                        JSONArray dataArray = auth.getJSONArray("sections");
                                        int test=dataArray.length();
                                        ArrayList<String> sectionList = new ArrayList<>();
                                        String[] code= new String[test];
                                        for (int i = 0; i < test; i++) {
                                            JSONObject dataobj = dataArray.getJSONObject(i);
                                            code[i]=dataobj.getString("code");
                                            sectionList.add(dataobj.getString("description"));
                                        }

                                        LayoutInflater linf = LayoutInflater.from(activity);
                                        final View inflator = linf.inflate(R.layout.activity_login_dialog_select_section, null);
                                        AlertDialog.Builder alert = new AlertDialog.Builder(activity);

                                        alert.setTitle(activity.getResources().getString(R.string.alertbox_title_question));
                                        alert.setMessage(activity.getResources().getString(R.string.login_select_section));
                                        alert.setView(inflator);

                                        final Spinner units = inflator.findViewById(R.id.section_dlg_spinner);

                                        ArrayAdapter<String> unitsAdapter = new ArrayAdapter<String>(activity, android.R.layout.simple_spinner_item, sectionList);
                                        unitsAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
                                        units.setAdapter(unitsAdapter);

                                        alert.setPositiveButton(activity.getResources().getString(R.string.alertbox_continue), new DialogInterface.OnClickListener() {
                                            public void onClick(DialogInterface dialog, int whichButton) {
                                                state.section=code[units.getSelectedItemPosition()];
                                                LoggedInUser User = new LoggedInUser(state.UUID, state.workerName);
                                                Result result = new Result.Success<>(User);
                                                if (result instanceof Result.Success) {
                                                    LoggedInUser data = ((Result.Success<LoggedInUser>) result).getData();
                                                    state.setGarbage("login",0);
                                                    loginResult.setValue(new LoginResult(new LoggedInUserView(data.getDisplayName())));
                                                } else {
                                                    loginResult.setValue(new LoginResult(R.string.login_failed));
                                                }
                                                dialog.cancel();
                                            }
                                        });

                                        alert.show();
                                    }else{
                                        LoggedInUser User = new LoggedInUser(state.UUID, state.workerName);
                                        result = new Result.Success<>(User);
                                        if (result instanceof Result.Success) {
                                            LoggedInUser data = ((Result.Success<LoggedInUser>) result).getData();
                                            state.setGarbage("login",0);
                                            loginResult.setValue(new LoginResult(new LoggedInUserView(data.getDisplayName())));
                                        } else {
                                            loginResult.setValue(new LoginResult(R.string.login_failed));
                                        }
                                    }

                                } else {
                                    result = new Result.Error(new IOException("Error logging in", new Exception()));
                                    Functions.showSimpleProgressDialog(activity, activity.getResources().getString(R.string.error_title), activity.getResources().getString(R.string.login_not_on_site), false);
                                    Handler handler = new Handler();
                                    handler.postDelayed(new Runnable() {
                                        public void run() {
                                            Functions.removeSimpleProgressDialog();
                                        }
                                    }, 1500);
                                }
                            }
                        } else {
                            // Can't get location.
                            // GPS or network is not enabled.
                            // Ask user to enable GPS/network in settings.
                            gps.showSettingsAlert();
                        }
                    }
                }else{
                    Toast.makeText(activity.getApplicationContext(), Functions.getErrorCode(activity, response), Toast.LENGTH_LONG).show();
                    Exception e = new Exception();
                    result = new Result.Error(new IOException(Functions.getErrorCode(activity, response), new IOException()));
                }

            } catch (Exception e) {
                Functions.SaveCrash(e, activity);
            }

        }


    }



    public void loginDataChanged(String username) {
        if (!isUserNameValid(username)) {
            loginFormState.setValue(new LoginFormState(R.string.invalid_username, null));
        } else {
            loginFormState.setValue(new LoginFormState(true));
        }
    }

    // A placeholder username validation check
    private boolean isUserNameValid(String username) {
        if (username == null) {
            return false;
        }
        return android.text.TextUtils.isDigitsOnly(username);

    }

    // A placeholder password validation check
    private boolean isPasswordValid(String password) {
        return password != null && password.trim().length() > 5;
    }
}
