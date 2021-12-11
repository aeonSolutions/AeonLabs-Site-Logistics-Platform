package qc.worker.login;

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
import android.net.Uri;
import android.nfc.NfcAdapter;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
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
import androidx.lifecycle.Observer;
import androidx.lifecycle.ViewModelProviders;

import com.squareup.picasso.RequestHandler;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.io.FileInputStream;
import java.net.URL;
import java.util.List;
import java.util.Locale;

import qc.worker.BuildConfig;
import qc.worker.abstraction.CustomExceptionHandler;
import qc.worker.abstraction.GeoLocation;
import qc.worker.abstraction.LocaleManager;
import qc.worker.MainActivity;
import qc.worker.Network.HttpRequestHandler;
import qc.worker.R;
import qc.worker.abstraction.Functions;
import qc.worker.abstraction.nfc;
import qc.worker.data.LoadConfig;
import qc.worker.data.state;


public class LoginActivity extends AppCompatActivity {

    private LoginViewModel loginViewModel;

    private TextView networkMsg, card_txt;
    private ImageView card_img;
    private ProgressBar loadingProgressBar;

    private NfcAdapter mNfcAdapter;
    private GeoLocation gps;
    private Boolean UpdateDownloaded=false;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(this));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }

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
                LocaleManager.updateLanguage(this, LocaleManager.LANGUAGE_KEY_ENGLISH);
            }else if(lang.equals("fr") &&  !currentLang.equals("fr")){
                LocaleManager.updateLanguage(this, LocaleManager.LANGUAGE_KEY_FRENCH);
            }else if(lang.equals("pt") &&  !currentLang.equals("pt")){
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

        mNfcAdapter = NfcAdapter.getDefaultAdapter(this);

        loginViewModel = ViewModelProviders.of(this, new LoginViewModelFactory())
                .get(LoginViewModel.class);

        final EditText usernameEditText = findViewById(R.id.username);
        final Button loginButton = findViewById(R.id.login);
        loadingProgressBar = findViewById(R.id.loading);
        networkMsg = findViewById(R.id.login_msg);
        card_img=findViewById(R.id.login_image_card);
        card_txt=findViewById(R.id.login_card_txt);

        loginViewModel.getLoginFormState().observe(this, new Observer<LoginFormState>() {
            @Override
            public void onChanged(@Nullable LoginFormState loginFormState) {
                if (loginFormState == null) {
                    return;
                }
                loginButton.setEnabled(loginFormState.isDataValid());
                if (loginFormState.getUsernameError() != null) {
                    usernameEditText.setError(getString(loginFormState.getUsernameError()));
                }

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
            nfc.ReadNFC(intent);
            if(!nfc.getCardCode().equals("")){
                state.UUID=nfc.getCardCode();
                loginViewModel.login(state.UUID, this);
            }

    }

    @Override
    protected void onPause() {
        Functions.stopForegroundDispatch(this, mNfcAdapter);
        super.onPause();
    }

    @Override
    protected void onResume() {
        super.onResume();

        int result = ContextCompat.checkSelfPermission(getApplicationContext(), Manifest.permission.READ_EXTERNAL_STORAGE);
        if (result != PackageManager.PERMISSION_GRANTED){
            ActivityCompat.requestPermissions(this,new String[] {Manifest.permission.READ_EXTERNAL_STORAGE}, 1);
        }

        result = ContextCompat.checkSelfPermission(getApplicationContext(),Manifest.permission.ACCESS_FINE_LOCATION);
        if (result != PackageManager.PERMISSION_GRANTED){
            ActivityCompat.requestPermissions(this,new String[] {Manifest.permission.ACCESS_FINE_LOCATION}, 1);
        }

        gps = new GeoLocation();
        if(gps.getLocation(getApplicationContext()) == null){
            Toast.makeText(this, getResources().getString(R.string.error_location_disabled) , Toast.LENGTH_LONG).show();
            // Intent intent = new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS);
            // startActivity(intent);
        }

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
                                    }                                }
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
        CheckForUpdatedApp();
        Functions.setupForegroundDispatch(this, mNfcAdapter);

    }

    @SuppressLint("StaticFieldLeak")
    private void CheckForUpdatedApp(){

        Functions.showSimpleProgressDialog(this, getResources().getString(R.string.commServer_connect_title_msg),getResources().getString(R.string.commServer_connect_msg),false);

        new AsyncTask<Void, Void, String>(){
            protected String doInBackground(Void[] params) {
                HttpRequestHandler requestHandler = new HttpRequestHandler();
                return requestHandler.sendGetRequest(state.HostUrl + "api/api.php?task=update", LoginActivity.this);
            }
            protected void onPostExecute(String result) {
                Functions.removeSimpleProgressDialog();
                try {
                    JSONObject jsonObject = new JSONObject(result);
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
            }
        }.execute();
    }

    private void DownloadUpdate(){
        AlertDialog.Builder builder = new AlertDialog.Builder(this);
        builder.setMessage(getApplication().getResources().getString(R.string.error_update_msg))
                .setCancelable(false)
                .setTitle(getResources().getString(R.string.error_update_available))
                .setPositiveButton(getApplication().getResources().getString(R.string.alertbox_continue),
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                Intent urlIntent = new Intent(Intent.ACTION_VIEW, Uri.parse(state.HostUrl + "update/qcworker.apk"));
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



        String destination = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_DOWNLOADS) + "/qcworker.apk";
        File file= new File (destination);
        file.setWritable(true);
        final Uri uriIntent = FileProvider.getUriForFile(getApplicationContext(), BuildConfig.APPLICATION_ID, file);
        final Uri uri = Uri.parse("file://" + destination);

        //Delete update file if exists
        if (file.exists())
            //file.delete() - test this, I think sometimes it doesnt work
            file.delete();



        //get url of app on server
        String url = state.HostUrl + "update/qcworker.apk";

        //set downloadmanager
        DownloadManager.Request request = new DownloadManager.Request(Uri.parse(url));
        request.setDescription("A fazer download da ultima versao da App");
        request.setTitle("QC worker");

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
    private void DownloadUpdate2(){

        Functions.showSimpleProgressDialog(this, getResources().getString(R.string.commServer_connect_title_msg),getResources().getString(R.string.commServer_connect_msg),false);

        new AsyncTask<Void, Void, String>(){
            protected String doInBackground(Void[] params) {
                String filename=getApplicationContext().getFilesDir() + "/qcworker.apk";
                File file = new File(filename);
                if(file.exists()) {
                    file.delete();
                }
                HttpRequestHandler requestHandler = new HttpRequestHandler();
                return requestHandler.getHttpFile(state.HostUrl + "update/qcworker.apk", filename, LoginActivity.this);

            }
            protected void onPostExecute(String response) {

                if (Functions.isSuccess(response)) {
                    Functions.removeSimpleProgressDialog();  //will remove progress dialog
                    String filename=getApplicationContext().getFilesDir() + "/qcworker.apk";
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

        Intent intent = new Intent(Intent.ACTION_VIEW);
        String mimeType = "application/vnd.android.package-archive";
        File file= new File (filename);
        file.setWritable(true);

        Uri uri = FileProvider.getUriForFile(getApplicationContext(), BuildConfig.APPLICATION_ID, file);
        //Uri uri = Uri.parse("content://gestao.de.obra.provider/" + filename);
        intent.setDataAndType(uri, mimeType);
        intent.putExtra(Intent.EXTRA_STREAM, uri);
        intent.setFlags(Intent.FLAG_GRANT_READ_URI_PERMISSION | Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_NEW_TASK);

        List<ResolveInfo> resInfoList = getApplicationContext().getPackageManager().queryIntentActivities(intent, PackageManager.MATCH_DEFAULT_ONLY);
        for (ResolveInfo resolveInfo : resInfoList) {
            String packageName = resolveInfo.activityInfo.packageName;
            getApplicationContext().grantUriPermission(packageName, uri, Intent.FLAG_GRANT_WRITE_URI_PERMISSION | Intent.FLAG_GRANT_READ_URI_PERMISSION);
        }
        startActivity(intent);

    }
}
