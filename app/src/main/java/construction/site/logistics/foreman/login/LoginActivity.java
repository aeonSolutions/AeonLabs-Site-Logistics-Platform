package construction.site.logistics.foreman.login;

import android.Manifest;
import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.DownloadManager;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.content.res.Configuration;
import android.net.ConnectivityManager;
import android.net.NetworkInfo;
import android.net.Uri;
import android.nfc.NfcAdapter;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.os.CountDownTimer;
import android.os.Environment;
import android.os.StrictMode;
import android.provider.Settings;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.KeyEvent;
import android.view.View;
import android.view.inputmethod.EditorInfo;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.StringRes;
import androidx.annotation.Nullable;
import androidx.appcompat.app.AppCompatActivity;
import androidx.core.app.ActivityCompat;
import androidx.core.content.ContextCompat;
import androidx.core.content.FileProvider;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProviders;


import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.InputStream;
import java.lang.reflect.Method;
import java.net.URL;
import java.util.ArrayList;
import java.util.List;
import java.util.Locale;
import java.util.Observable;

import construction.site.logistics.foreman.BuildConfig;
import construction.site.logistics.foreman.FragmentDialogs.FragmentViewQrCode;
import construction.site.logistics.foreman.Fragments.FragmentGallery;
import construction.site.logistics.foreman.Network.NetworkStateReceiver;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.GeoLocation;
import construction.site.logistics.foreman.abstraction.LocaleManager;
import construction.site.logistics.foreman.MainActivity;
import construction.site.logistics.foreman.Network.HttpRequestHandler;

import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.abstraction.Weather;
import construction.site.logistics.foreman.abstraction.nfc;
import construction.site.logistics.foreman.data.LoadConfig;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.state;


public class LoginActivity extends AppCompatActivity {

    private LoginViewModel loginViewModel;

    private TextView networkMsg, card_txt, tablet_id;
    private ImageView card_img, view_qr_code;
    private ProgressBar loadingProgressBar;

    private NfcAdapter mNfcAdapter;
    private GeoLocation gps;
    private Boolean UpdateDownloaded=false;
    private BroadcastReceiver mNetworkReceiver;
    private Boolean fromIntent=false;
    private Boolean loading=true;
    private FragmentViewQrCode dialogViewQrCode;
    @Override
    public void onCreate(Bundle savedInstanceState) {
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(this));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }

        state.overrideSite=true;
        state.overrideLatitude=0.0;
        state.overrideLongitude=0.0;
        state.isDemonstrationEnabled=false;

        state.activity= this;
        loading=true;
        ConnectivityManager connectivityManager
                = (ConnectivityManager) getSystemService(Context.CONNECTIVITY_SERVICE);
        NetworkInfo activeNetworkInfo = connectivityManager.getActiveNetworkInfo();
        state.setNetworkStatus( activeNetworkInfo != null && activeNetworkInfo.isConnected());

        String filename = getApplicationContext().getFilesDir() + "/config.xml";
        File file = new File(filename);
        //boolean deleted = file.delete();

        if(file.exists()) {
            //read configuration file
            LoadConfig LoadConfig = new LoadConfig();
            LoadConfig.filename = filename;
            String lang = LoadConfig.GetConfigString("language");
            String currentLang= Locale.getDefault().getLanguage();

            if (lang.equals("en") &&  !currentLang.equals("en")) {
                state.setCurrentLanguage(currentLang);
                LocaleManager.updateLanguage(this, LocaleManager.LANGUAGE_KEY_ENGLISH);
            }else if(lang.equals("fr") &&  !currentLang.equals("fr")){
                state.setCurrentLanguage(currentLang);
                LocaleManager.updateLanguage(this, LocaleManager.LANGUAGE_KEY_FRENCH);
            }else if(lang.equals("pt") &&  !currentLang.equals("pt")){
                state.setCurrentLanguage(currentLang);
                LocaleManager.updateLanguage(this, LocaleManager.LANGUAGE_KEY_PORTUGUESE);
            }
        }
        super.onCreate(savedInstanceState);

        setContentView(R.layout.activity_login);
        if (android.os.Build.VERSION.SDK_INT > 9)
        {
            StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
            StrictMode.setThreadPolicy(policy);
        }

        //TODO : add text input in case of smartcard is not available
        if (state.isSmartCardEnabled){
             mNfcAdapter = NfcAdapter.getDefaultAdapter(this);
        }
        mNetworkReceiver = new NetworkStateReceiver();

        loginViewModel = ViewModelProviders.of(this, new LoginViewModelFactory())
                .get(LoginViewModel.class);

        EditText usernameEditText = findViewById(R.id.username);
        Button loginButton = findViewById(R.id.login);
        loadingProgressBar = findViewById(R.id.loading);
        networkMsg = findViewById(R.id.login_msg);
        card_img=findViewById(R.id.login_image_card);
        card_txt=findViewById(R.id.login_card_txt);
        tablet_id=findViewById(R.id.login_tablet_id);
        view_qr_code=findViewById(R.id.view_qr_code);

        loginViewModel.getLoginFormState().observe(this, new Observer<LoginFormState>() {
            @Override
            public void onChanged(@Nullable LoginFormState loginFormState) {
                if (loginFormState == null) {
                    return;
                }
                //loginButton.setEnabled(loginFormState.isDataValid());
                if (loginFormState.getUsernameError() != null) {
                    usernameEditText.setError(getString(loginFormState.getUsernameError()));
                }
            }
        });

        view_qr_code.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                dialogViewQrCode = (FragmentViewQrCode) getSupportFragmentManager().findFragmentByTag(FragmentViewQrCode.TAG);
                if (dialogViewQrCode == null) {
                    dialogViewQrCode = FragmentViewQrCode.newInstance();
                }
                dialogViewQrCode.show(getSupportFragmentManager(),FragmentViewQrCode.TAG);
            }
        });

        loginViewModel.getLoginResult().observe(this, new Observer<LoginResult>() {
            @Override
            public void onChanged(@Nullable LoginResult loginResult) {
                if (loginResult == null) {
                    return;
                }
                loadingProgressBar.setVisibility(View.GONE);
                if (loginResult.getError() != null) {
                    showLoginFailed(loginResult.getError());
                    return;
                }
                if (loginResult.getSuccess() != null) {
                    updateUiWithUser(loginResult.getSuccess());
                }
                setResult(Activity.RESULT_OK);

                //Complete and destroy login activity once successful
                finish();
                Intent intent = new Intent(getApplicationContext(), MainActivity.class);
                startActivity(intent);
            }
        });

        TextWatcher afterTextChangedListener = new TextWatcher() {
            @Override
            public void beforeTextChanged(CharSequence s, int start, int count, int after) {
                // ignore
            }

            @Override
            public void onTextChanged(CharSequence s, int start, int before, int count) {
                // ignore
            }

            @Override
            public void afterTextChanged(Editable s) {
                loginViewModel.loginDataChanged(usernameEditText.getText().toString());
            }
        };
        usernameEditText.setOnEditorActionListener(new TextView.OnEditorActionListener() {

            @Override
            public boolean onEditorAction(TextView v, int actionId, KeyEvent event) {
                if (actionId == EditorInfo.IME_ACTION_DONE) {
                    loginViewModel.login(usernameEditText.getText().toString(), LoginActivity.this);
                }
                return false;
            }
        });

        usernameEditText.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    Functions.hideKeyboard(v, getApplicationContext());
                }
            }
        });

        loginButton.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                loadingProgressBar.setVisibility(View.VISIBLE);
                loginViewModel.login(usernameEditText.getText().toString(), LoginActivity.this);
            }
        });

    loading=false;
    }

    private void registerNetworkBroadcast() {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            registerReceiver(mNetworkReceiver, new IntentFilter(ConnectivityManager.CONNECTIVITY_ACTION));
        }
    }

    protected void unregisterNetworkChanges() {
        try {
            unregisterReceiver(mNetworkReceiver);
        } catch (IllegalArgumentException e) {
            Functions.SaveCrash(e, this);
        }
    }

    @Override
    public void onBackPressed() {

        int count = getSupportFragmentManager().getBackStackEntryCount();
        if (count > 0) {
            getSupportFragmentManager().popBackStack();
        }
    }

    private void updateUiWithUser(LoggedInUserView model) {
        String welcome = getString(R.string.welcome) + model.getDisplayName();
        // TODO : initiate successful logged in experience
        Toast.makeText(getApplicationContext(), welcome, Toast.LENGTH_LONG).show();
    }

    private void showLoginFailed(@StringRes Integer errorString) {
        Toast.makeText(getApplicationContext(), errorString, Toast.LENGTH_SHORT).show();
    }
    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        // Do something here.
        // But don't forget to call this method
        super.onConfigurationChanged(newConfig);

    }

    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
            nfc.ReadNFC(intent);
            if(!nfc.getCardCode().equals("")){
                state.UUID=nfc.getCardCode();
                if(!state.UUID.equals("")) {
                    loginViewModel.login(state.UUID, this);
                    fromIntent = true;
                }
            }

    }

    @Override
    protected void onPause() {
        unregisterNetworkChanges();
        if (state.isSmartCardEnabled){
            Functions.stopForegroundDispatch(this, mNfcAdapter);
        }
        super.onPause();
    }

    @Override
    protected void onResume() {
        super.onResume();

        int result = ContextCompat.checkSelfPermission(getApplicationContext(), Manifest.permission.READ_EXTERNAL_STORAGE);
        if (result != PackageManager.PERMISSION_GRANTED){
            ActivityCompat.requestPermissions(this,new String[] {Manifest.permission.READ_EXTERNAL_STORAGE}, 1);
        }

        result = ContextCompat.checkSelfPermission(getApplicationContext(),Manifest.permission.READ_PHONE_STATE);
        if (result != PackageManager.PERMISSION_GRANTED){
            ActivityCompat.requestPermissions(this,new String[] {Manifest.permission.READ_PHONE_STATE}, 1);
        }

        result = ContextCompat.checkSelfPermission(getApplicationContext(),Manifest.permission.ACCESS_FINE_LOCATION);
        if (result != PackageManager.PERMISSION_GRANTED){
            ActivityCompat.requestPermissions(this,new String[] {Manifest.permission.ACCESS_FINE_LOCATION}, 1);
        }

        result = ContextCompat.checkSelfPermission(getApplicationContext(),Manifest.permission.CAMERA);
        if (result != PackageManager.PERMISSION_GRANTED){
            ActivityCompat.requestPermissions(this,new String[] {Manifest.permission.CAMERA}, 1);
        }

        if (!state.isDemonstrationEnabled) {
            gps = new GeoLocation();
            if (gps.getLocation(getApplicationContext()) == null) {
                Toast.makeText(this, getResources().getString(R.string.error_location_disabled), Toast.LENGTH_LONG).show();
                // Intent intent = new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS);
                // startActivity(intent);
            }
            if (state.isSmartCardEnabled) {
                if (mNfcAdapter == null) {
                    // Stop here, we definitely need NFC
                    card_txt.setVisibility(View.INVISIBLE);
                    card_img.setVisibility(View.INVISIBLE);
                    Toast.makeText(this, getResources().getString(R.string.error_nfc_not_supported), Toast.LENGTH_LONG).show();
                    finish();
                    return;
                }

                if (!mNfcAdapter.isEnabled()) {
                    AlertDialog.Builder builder = new AlertDialog.Builder(this);
                    builder.setMessage(getApplication().getResources().getString(R.string.error_nfc_ask))
                            .setCancelable(false)
                            .setTitle(getResources().getString(R.string.error_nfc_disabled))
                            .setPositiveButton(getApplication().getResources().getString(R.string.alertbox_continue),
                                    new DialogInterface.OnClickListener() {
                                        public void onClick(DialogInterface dialog, int id) {
                                            if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.JELLY_BEAN) {
                                                Intent intent = new Intent(Settings.ACTION_NFC_SETTINGS);
                                                startActivity(intent);
                                            } else {
                                                Intent intent = new Intent(Settings.ACTION_WIRELESS_SETTINGS);
                                                startActivity(intent);
                                            }
                                        }
                                    })
                            .setNegativeButton(getApplication().getResources().getString(R.string.alertbox_cancel),
                                    new DialogInterface.OnClickListener() {
                                        public void onClick(DialogInterface dialog, int id) {
                                            card_txt.setVisibility(View.INVISIBLE);
                                            card_img.setVisibility(View.INVISIBLE);
                                            dialog.cancel();
                                        }
                                    });
                    AlertDialog alert = builder.create();
                    alert.show();

                }
            }
        }

        registerNetworkBroadcast();
        if (state.isSmartCardEnabled){
            Functions.setupForegroundDispatch(this, mNfcAdapter);
        }
        if (!fromIntent && loading.equals(false)){
            LoginViewModel.loginFormState.setValue(new LoginFormState(false));
            state.clearSettings();
            state.serial=getSerialNumber( this);
            tablet_id.setText("ID: "+state.serial+ " "+getApplication().getResources().getString(R.string.fragment_about_version)+": "+BuildConfig.VERSION_CODE);
            CheckForUpdatedApp();
        }else{
            fromIntent=false;
        }

        Weather weather=new Weather();
        weather.load(this, false);


    }
    public static String getSerialNumber(Activity activity) {
        String serialNumber;

        try {
            Class<?> c = Class.forName("android.os.SystemProperties");
            Method get = c.getMethod("get", String.class);

            serialNumber="";
            if (Build.VERSION.SDK_INT >= 26) {
                if (activity.checkSelfPermission(android.Manifest.permission.READ_PHONE_STATE) == PackageManager.PERMISSION_GRANTED) {
                    serialNumber = Build.getSerial();
                }
            }
            if (serialNumber.equals(""))
                serialNumber = (String) get.invoke(c, "gsm.sn1");
            if (serialNumber.equals(""))
                serialNumber = (String) get.invoke(c, "ril.serialnumber");
            if (serialNumber.equals(""))
                serialNumber = (String) get.invoke(c, "ro.serialno");
            if (serialNumber.equals(""))
                serialNumber = (String) get.invoke(c, "sys.serialnumber");
            if (serialNumber.equals(""))
                serialNumber = Build.SERIAL;

            // If none of the methods above worked
            if (serialNumber.equals(""))
                serialNumber = null;
        } catch (Exception e) {
            e.printStackTrace();
            serialNumber = null;
        }

        return serialNumber;
    }

    @SuppressLint("StaticFieldLeak")
    private void CheckForUpdatedApp(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_log_attendance_title));
        queue.setDescription( getResources().getString(R.string.fragment_log_attendance_description));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("15");
        fields.add(field);

        SendData sendData = new SendData(this, this);
        UpdateDataResultObserver updateDataResultObserver = new UpdateDataResultObserver(sendData.DelayedResult);
        sendData.DelayedResult.addObserver(updateDataResultObserver);
        sendData.addQueue(queue);
        sendData.addFields(fields);
        sendData.setEncryption(true, "AES128");
        sendData.setWaitForCode(false);
        sendData.setloadMainPage(false);
        sendData.setEnableQueue(false);
        sendData.send();
        //String response= sendData.getResponse();


    }
    public class UpdateDataResultObserver implements java.util.Observer
    {
        private SendData.ObservableValue ov = null;
        public UpdateDataResultObserver(SendData.ObservableValue ov) {
            this.ov = ov;
        }
        public void update(Observable obs, Object obj) {
            if (obs == ov) {
                UpdateDataResult(ov.getValue());
            }
        }
    }

    private void UpdateDataResult(String response){
        if(Functions.isSuccess(response)){
            try {
                JSONObject jsonObject = new JSONObject(response);
                if (jsonObject.getString("error").equals("false")) {
                    int versionCode = BuildConfig.VERSION_CODE;
                    int server_version= jsonObject.getInt("version");
                    if(server_version> versionCode){
                        networkMsg.setText(R.string.update_required);
                        if (UpdateDownloaded.equals(false)){
                            DownloadUpdate();
                        }
                    }else{
                        networkMsg.setText(R.string.update_ok);
                    }
                }else{
                    networkMsg.setText(R.string.commServer_error);
                }
            } catch (JSONException e) {
                Functions.SaveCrash(e, LoginActivity.this);
            }
        }else{
            new CountDownTimer(20000, 1000) {

                public void onTick(long millisUntilFinished) {
                    networkMsg.setText(R.string.commServer_retry+" "+millisUntilFinished / 1000);
                }

                public void onFinish() {
                    networkMsg.setText(R.string.commServer_connect_msg);
                    CheckForUpdatedApp();
                }
            }.start();
        }
    }
    private void DownloadUpdateWeb(){
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setMessage(getApplication().getResources().getString(R.string.error_update_msg))
                .setCancelable(false)
                .setTitle(getResources().getString(R.string.error_update_available))
                .setPositiveButton(getApplication().getResources().getString(R.string.alertbox_continue),
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                Intent urlIntent = new Intent(Intent.ACTION_VIEW, Uri.parse(state.HostUrl + "update/qcsite.apk"));
                                startActivity(urlIntent);                              }
                        })
                .setNegativeButton(getApplication().getResources().getString(R.string.alertbox_cancel),
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                UpdateDownloaded=true;
                                dialog.cancel();
                            }
                        });
        AlertDialog alert = builder.create();
        alert.show();

    }

    private void DownloadUpdateWithSDCard(){

        if (Build.VERSION.SDK_INT >= 23) {
            if (checkSelfPermission(android.Manifest.permission.WRITE_EXTERNAL_STORAGE)
                    == PackageManager.PERMISSION_GRANTED) {
                Log.e("Permission error","You have permission");
            } else {

                Log.e("Permission error","You have asked for permission");
                ActivityCompat.requestPermissions(this, new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE}, 1);
            }
        }
        else { //you dont need to worry about these stuff below api level 23
            Log.e("Permission error","You already have the permission");
        }

        //get destination to update file and set Uri
        //TODO: First I wanted to store my update .apk file on internal storage for my app but apparently android does not allow you to open and install
        //aplication with existing package from there. So for me, alternative solution is Download directory in external storage. If there is better
        //solution, please inform us in comment



        String destination = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS) + "/qcsite.apk";
        File file= new File (destination);
        file.setWritable(true);
        final Uri uriIntent = FileProvider.getUriForFile(getApplicationContext(), BuildConfig.APPLICATION_ID, file);
        final Uri uri = Uri.parse("file://" + destination);

        //Delete update file if exists
        if (file.exists())
            //file.delete() - test this, I think sometimes it doesnt work
            file.delete();



        //get url of app on server
        String url = state.HostUrl + "update/qcsite.apk";

        //set downloadmanager
        DownloadManager.Request request = new DownloadManager.Request(Uri.parse(url));
        request.setDescription("A fazer download da ultima versao da App");
        request.setTitle("QC Site");

        //set destination
        request.setDestinationUri(uri);

        // get download service and enqueue file
        final DownloadManager manager = (DownloadManager) getSystemService(Context.DOWNLOAD_SERVICE);
        final long downloadId = manager.enqueue(request);

        //set BroadcastReceiver to install app when .apk is downloaded
        BroadcastReceiver onComplete = new BroadcastReceiver() {
            public void onReceive(Context ctxt, Intent intent) {
                Intent install = new Intent(Intent.ACTION_VIEW);

                intent.setDataAndType(uriIntent, "application/vnd.android.package-archive");
                intent.putExtra(Intent.EXTRA_STREAM, uriIntent);
                intent.setFlags(Intent.FLAG_GRANT_READ_URI_PERMISSION | Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_NEW_TASK);

                install.setDataAndType(uriIntent, manager.getMimeTypeForDownloadedFile(downloadId));
                List<ResolveInfo> resInfoList = getApplicationContext().getPackageManager().queryIntentActivities(intent, PackageManager.MATCH_DEFAULT_ONLY);
                for (ResolveInfo resolveInfo : resInfoList) {
                    String packageName = resolveInfo.activityInfo.packageName;
                    getApplicationContext().grantUriPermission(packageName, uriIntent, Intent.FLAG_GRANT_WRITE_URI_PERMISSION | Intent.FLAG_GRANT_READ_URI_PERMISSION);
                }
                startActivity(install);

                unregisterReceiver(this);
                finish();
            }
        };
        //register receiver for when .apk download is compete
        registerReceiver(onComplete, new IntentFilter(DownloadManager.ACTION_DOWNLOAD_COMPLETE));

    }

    @SuppressLint("StaticFieldLeak")
    private void DownloadUpdate(){
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setMessage(getApplication().getResources().getString(R.string.error_update_msg))
                .setCancelable(false)
                .setTitle(getResources().getString(R.string.error_update_available))
                .setPositiveButton(getApplication().getResources().getString(R.string.alertbox_continue),
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                DownloadUpdateFile();
                            }
                        })
                .setNegativeButton(getApplication().getResources().getString(R.string.alertbox_cancel),
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                UpdateDownloaded=true;
                                dialog.cancel();
                            }
                        });
        AlertDialog alert = builder.create();
        alert.show();
    }

    @SuppressLint("StaticFieldLeak")
    private void DownloadUpdateFile(){
        Functions.showSimpleProgressDialog(this, getResources().getString(R.string.commServer_connect_title_msg),getResources().getString(R.string.commServer_connect_msg),false);

        new AsyncTask<Void, Void, String>(){
            protected String doInBackground(Void[] params) {
                File file = new File(getExternalFilesDir(null),"qcsite.apk");
                if(file.exists()) {
                    file.delete();
                }
                HttpRequestHandler requestHandler = new HttpRequestHandler();
                return requestHandler.getHttpFile(state.HostUrl + "update/qcsite.apk", file.toString(), LoginActivity.this);

            }
            protected void onPostExecute(String response) {

                if (Functions.isSuccess(response)) {
                    Functions.removeSimpleProgressDialog();  //will remove progress dialog
                    String filename=getApplicationContext().getFilesDir() + "/qcsite.apk";
                    UpdateDownloaded=true;
                    open_file(filename);

                }else {
                    Toast.makeText(LoginActivity.this, Functions.getErrorCode(LoginActivity.this, response), Toast.LENGTH_SHORT).show();
                }

                Functions.removeSimpleProgressDialog();
            }
        }.execute();
    }

    public void open_file(String filename) {


// Start the standard installation window
        Intent downloadIntent;
        if(Build.VERSION.SDK_INT >= Build.VERSION_CODES.N) {
            File fileLocation = new File(getExternalFilesDir(null), "qcsite.apk");
            Uri apkUri = FileProvider.getUriForFile(this, getApplicationContext().getPackageName(), fileLocation);

            downloadIntent = new Intent(Intent.ACTION_VIEW);
            downloadIntent.addFlags(Intent.FLAG_GRANT_READ_URI_PERMISSION);
            downloadIntent.setFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            downloadIntent.setDataAndType(apkUri, "application/vnd.android.package-archive");

            List<ResolveInfo> resInfoList = getPackageManager().queryIntentActivities(downloadIntent, PackageManager.MATCH_DEFAULT_ONLY);
            for (ResolveInfo resolveInfo : resInfoList) {
                String packageName = resolveInfo.activityInfo.packageName;
                grantUriPermission(packageName, apkUri, Intent.FLAG_GRANT_WRITE_URI_PERMISSION | Intent.FLAG_GRANT_READ_URI_PERMISSION);
            }

        } else {
            File fileLocation = new File(getFilesDir(), "qcsite.apk");
            downloadIntent = new Intent(Intent.ACTION_VIEW);
            downloadIntent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            downloadIntent.setDataAndType(Uri.fromFile(fileLocation), "application/vnd.android.package-archive");
        }
        startActivity(downloadIntent);
    }
}