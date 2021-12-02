package construction.site.logistics.foreman;

import android.annotation.SuppressLint;

import android.app.PendingIntent;
import android.content.BroadcastReceiver;
import android.content.Context;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.ActivityInfo;
import android.content.pm.PackageManager;

import android.content.res.Configuration;
import android.net.ConnectivityManager;
import android.net.Uri;
import android.nfc.NfcAdapter;
import android.nfc.Tag;
import android.nfc.tech.Ndef;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;


import androidx.annotation.Nullable;
import androidx.core.view.GravityCompat;
import androidx.appcompat.app.ActionBarDrawerToggle;

import android.os.Parcelable;
import android.view.Gravity;
import android.view.MenuItem;

import com.akexorcist.screenorientationhelper.ScreenOrientationHelper;

import com.bumptech.glide.Glide;
import com.bumptech.glide.load.engine.DiskCacheStrategy;

import com.bumptech.glide.request.RequestOptions;
import com.google.android.material.navigation.NavigationView;

import androidx.drawerlayout.widget.DrawerLayout;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.lifecycle.LifecycleObserver;

import android.view.Menu;
import android.view.View;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.io.FileInputStream;
import java.net.URL;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Observable;
import java.util.Observer;

import construction.site.logistics.foreman.FragmentDialogs.NFCReadFragment;
import construction.site.logistics.foreman.FragmentDialogs.NFCWriteFragment;
import construction.site.logistics.foreman.Fragments.FragmentAbout;
import construction.site.logistics.foreman.Fragments.FragmentBordereauView;
import construction.site.logistics.foreman.Fragments.FragmentCalendar;
import construction.site.logistics.foreman.Fragments.FragmentContacts;
import construction.site.logistics.foreman.Fragments.FragmentGallery;
import construction.site.logistics.foreman.Fragments.FragmentHardware;
import construction.site.logistics.foreman.Fragments.FragmentJournal;

import construction.site.logistics.foreman.Fragments.FragmentLivraisonEdit;
import construction.site.logistics.foreman.Fragments.FragmentLivraisonView;
import construction.site.logistics.foreman.Fragments.FragmentLogAttendance;
import construction.site.logistics.foreman.Fragments.FragmentMaterialsDIY;
import construction.site.logistics.foreman.Fragments.FragmentOccurencesAdd;
import construction.site.logistics.foreman.Fragments.FragmentOccurencesView;
import construction.site.logistics.foreman.Fragments.FragmentPrivacy;
import construction.site.logistics.foreman.Fragments.FragmentProjectView;
import construction.site.logistics.foreman.Fragments.FragmentQuantityView;
import construction.site.logistics.foreman.Fragments.FragmentRegieEnd;
import construction.site.logistics.foreman.Fragments.FragmentRegieStart;
import construction.site.logistics.foreman.Fragments.FragmentSync;
import construction.site.logistics.foreman.Fragments.FragmentTerms;
import construction.site.logistics.foreman.Fragments.FragmentWeather;

import construction.site.logistics.foreman.Network.NetworkStateReceiver;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.abstraction.AppLifecycleTracker;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.abstraction.Listener;
import construction.site.logistics.foreman.abstraction.LocaleManager;
import construction.site.logistics.foreman.abstraction.LogoutTimer;
import construction.site.logistics.foreman.abstraction.nfc;
import construction.site.logistics.foreman.data.LoadConfig;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.database.LocalDatabase;
import construction.site.logistics.foreman.data.state;
import construction.site.logistics.foreman.login.LoginActivity;

import static android.content.pm.PackageManager.GET_META_DATA;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener, LifecycleObserver, ScreenOrientationHelper.ScreenOrientationChangeListener, LogoutTimer.LogOutListener, Listener {


    private ScreenOrientationHelper helper = new ScreenOrientationHelper(this);
    private TextView name, mobile, site;
    private ImageView photo;
    private View header;
    private boolean intentGoing=false;
    private BroadcastReceiver mNetworkReceiver;
    private boolean loadingActivity=true;
    public static DrawerLayout drawer;
    public static Toolbar toolbar;
    private NFCWriteFragment mNfcWriteFragment;
    private NFCReadFragment mNfcReadFragment;
    private NfcAdapter mNfcAdapter;
    static public boolean isDialogDisplayed = false;
    static public boolean isWrite = false;
    public final static String ReadSmartCardID = "ReadSmartCardID";

    @Override
    protected void onStart() {
            super.onStart();
            helper.onStart();
            LogoutTimer.startLogoutTimer(this, this);
    }

    @Override
    protected void onSaveInstanceState(Bundle outState) {
            helper.onSaveInstanceState(outState);
            super.onSaveInstanceState(outState);
    }

    @Override
    protected void onRestoreInstanceState(Bundle savedInstanceState) {
            helper.onRestoreInstanceState(savedInstanceState);
            super.onRestoreInstanceState(savedInstanceState);

    }

    @Override
    public void onScreenOrientationChanged(int orientation) {
            ResumeLoadedFragment();
        }

    @Override
    protected void onCreate(@Nullable  Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        loadingActivity=true;
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(this));

        helper.onCreate(savedInstanceState);
        helper.setScreenOrientationChangeListener(this);

        AppLifecycleTracker handler = new AppLifecycleTracker();
        getApplication().registerActivityLifecycleCallbacks(handler);
        registerComponentCallbacks(handler);

        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }
        state.activity=this;

        setContentView(R.layout.activity_main);
        toolbar = findViewById(R.id.toolbar);
        toolbar.setNavigationIcon(R.drawable.menu_icon);
        setSupportActionBar(toolbar);

        drawer = findViewById(R.id.drawer_layout);
        NavigationView navigationView = findViewById(R.id.nav_view);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.addDrawerListener(toggle);
        toggle.syncState();
        navigationView.setNavigationItemSelectedListener(this);

        resetTitles();

        header = navigationView.getHeaderView(0);
        name= header.findViewById(R.id.drawer_worker_name);
        site= header.findViewById(R.id.drawer_worker_site);
        mobile= header.findViewById(R.id.drawer_worker_contact);
        photo= header.findViewById(R.id.drawer_worker_photo);
        if (state.isSmartCardEnabled){
            mNfcAdapter = NfcAdapter.getDefaultAdapter(this);
        }
        mNetworkReceiver = new NetworkStateReceiver();

        //initialize global vars
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
        state.date=sdf.format(new Date());
        loadingActivity=false;
        //throw new RuntimeException("This is a crash");

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
    public void onDialogDisplayed() {

        isDialogDisplayed = true;
    }

    @Override
    public void onDialogDismissed() {

        isDialogDisplayed = false;
        isWrite = false;
    }

    @Override
    public void onDestroy() {
        unregisterNetworkChanges();
        LocalDatabase.destroyInstance();
        super.onDestroy();
    }

    @Override
    public void onUserInteraction() {
        super.onUserInteraction();
        state.userIsInteracting = true;
        LogoutTimer.startLogoutTimer(this, this);
    }

    /*
     * Performing idle time logout
     */

    @Override
    public void doLogout() {
        state.clearSettings();
        runOnUiThread(new Runnable() {
            public void run() {
                Toast.makeText(getApplication(), R.string.error_session_expired , Toast.LENGTH_SHORT).show();
            }
        });
        LogoutTimer.stopLogoutTimer();
        Intent intent = new Intent(getApplicationContext(), LoginActivity.class);
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        startActivity(intent);
        finish();
    }

    @Override
    protected void onNewIntent(Intent intent) {
        super.onNewIntent(intent);
        String action = intent.getAction();
        if (NfcAdapter.ACTION_NDEF_DISCOVERED.equals(action) || NfcAdapter.ACTION_TECH_DISCOVERED.equals(action) || NfcAdapter.ACTION_TAG_DISCOVERED.equals(action) ) {
            intentGoing = true;
            Tag tag = intent.getParcelableExtra(NfcAdapter.EXTRA_TAG);
            if (tag != null) {
                //Toast.makeText(this, getString(R.string.nfc_message_tag_detected), Toast.LENGTH_SHORT).show();
                Ndef ndef = Ndef.get(tag);
                nfc.ReadNFC(intent);
                if(!nfc.getCardCode().equals("")) {
                    state.ReadSmartCardID = nfc.getCardCode();
                }else{
                    state.ReadSmartCardID = "";
                    state.ReadSmartCardAuthenticationString = "";
                    state.ReadSmartCardDataString = "";
                    state.ReadSmartCardFullMessageString = "";
                    state.NFCState = -1;
                }


                if (isDialogDisplayed) {
                    if (isWrite) {
                        mNfcWriteFragment = (NFCWriteFragment) this.getSupportFragmentManager().findFragmentByTag(NFCWriteFragment.TAG);
                        mNfcWriteFragment.onNfcDetected(ndef);
                    } else {
                        mNfcReadFragment = (NFCReadFragment) this.getSupportFragmentManager().findFragmentByTag(NFCReadFragment.TAG);
                        mNfcReadFragment.onNfcDetected(ndef);
                    }
                } else {
                    if (state.CurrentNavItem == R.id.nav_regie_add) {
                        intent = new Intent(this, FragmentRegieStart.class);
                        intent.putExtra(ReadSmartCardID, state.ReadSmartCardID);
                        Fragment fragment = (FragmentRegieStart) getSupportFragmentManager().findFragmentById(R.id.content_frame);
                        fragment.onActivityResult(1002,RESULT_OK, intent);
                    } else if (state.CurrentNavItem == R.id.nav_regie_end) {
                        intent = new Intent(this, FragmentRegieEnd.class);
                        intent.putExtra(ReadSmartCardID, state.ReadSmartCardID);
                        Fragment fragment = (FragmentRegieEnd) getSupportFragmentManager().findFragmentById(R.id.content_frame);
                        fragment.onActivityResult(1003,RESULT_OK, intent);
                    } else if (state.CurrentNavItem == R.id.nav_occurrences_add) {
                        intent = new Intent(this, FragmentOccurencesAdd.class);
                        intent.putExtra(ReadSmartCardID, state.ReadSmartCardID);
                        Fragment fragment = (FragmentOccurencesAdd) getSupportFragmentManager().findFragmentById(R.id.content_frame);
                        fragment.onActivityResult(1004,RESULT_OK, intent);
                    }
                }
            }
        }
    }

    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        // Do something here.
        // But don't forget to call this method
        super.onConfigurationChanged(newConfig);
    }

    @Override
    protected void attachBaseContext(Context base) {
        super.attachBaseContext(LocaleManager.setLocale(base));
    }

    protected void resetTitles() {
        try {
            ActivityInfo info = getPackageManager().getActivityInfo(getComponentName(), GET_META_DATA);
            if (info.labelRes != 0) {
                setTitle(info.labelRes);
            }
        } catch (PackageManager.NameNotFoundException e) {
            Functions.SaveCrash(e, this);
        }
    }

    @Override
    public void onBackPressed() {
        DrawerLayout drawer = findViewById(R.id.drawer_layout);
        if (drawer.isDrawerOpen(GravityCompat.START)) {
            drawer.closeDrawer(GravityCompat.START);
        }
        int count = getSupportFragmentManager().getBackStackEntryCount();
        if (count > 1) {
            state.clearNFCdata();
            getSupportFragmentManager().popBackStack();
        }
    }

    @Override
    public boolean onCreateOptionsMenu(Menu menu) {
        // Inflate the menu; this adds items to the action bar if it is present.
        getMenuInflater().inflate(R.menu.main, menu);
        return true;
    }

    @Override
    public boolean onOptionsItemSelected(MenuItem item) {
        // Handle action bar item clicks here. The action bar will
        // automatically handle clicks on the Home/Up button, so long
        // as you specify a parent activity in AndroidManifest.xml.
        int id = item.getItemId();

        //noinspection SimplifiableIfStatement
        if (id == R.id.action_lang_en) {
            for (Fragment fragment : getSupportFragmentManager().getFragments()) {
                if (fragment != null) {
                    getSupportFragmentManager().beginTransaction().remove(fragment).commit();
                }
            }
            LoadConfig LoadConfig = new LoadConfig();
            construction.site.logistics.foreman.data.LoadConfig.saveConfig("en", getApplicationContext());
            state.setCurrentLanguage("en");
            LocaleManager.setNewLocale(this, LocaleManager.LANGUAGE_KEY_ENGLISH);
            recreate();
        }else if(id== R.id.action_lang_fr){
            for (Fragment fragment : getSupportFragmentManager().getFragments()) {
                if (fragment != null) {
                    getSupportFragmentManager().beginTransaction().remove(fragment).commit();
                }
            }
            state.setCurrentLanguage("fr");
            LoadConfig.saveConfig("fr", getApplicationContext());
            LocaleManager.setNewLocale(this, LocaleManager.LANGUAGE_KEY_FRENCH);
            recreate();
        }else if(id== R.id.action_lang_pt){
            for (Fragment fragment : getSupportFragmentManager().getFragments()) {
                if (fragment != null) {
                    getSupportFragmentManager().beginTransaction().remove(fragment).commit();
                }
            }
            LoadConfig.saveConfig("pt", getApplicationContext());
            state.setCurrentLanguage("pt");
            LocaleManager.setNewLocale(this, LocaleManager.LANGUAGE_KEY_PORTUGUESE);
            recreate();
        }

        return super.onOptionsItemSelected(item);
    }

    private void displaySelectedFragment(Fragment fragment) {
        FragmentManager fragmentManager = getSupportFragmentManager();
        fragmentManager.beginTransaction()
                .replace(R.id.content_frame, fragment)
                .addToBackStack(null)
                .commit();
        fragmentManager.executePendingTransactions();
    }

    public void ResumeLoadedFragment() {
        state.ReadSmartCardID="";
        Functions.checkLocation(this);

        if(state.getGarbage()[1].equals("attendance") && state.getGarbage()[0].equals("login") && false ) { //remove false
            state.setGarbage("SOD", 9);
            state.setCurrentNavItem(R.id.nav_attendance_log_extra);
            displaySelectedFragment(new FragmentLogAttendance());
        }else if(state.getTookPhoto()){
            state.setTookPhoto(false);
            displaySelectedFragment(new FragmentGallery());
        }else if (state.CurrentNavItem == R.id.nav_home || state.CurrentNavItem ==-1) {
            displaySelectedFragment(new FragmentJournal());
        } else if (state.CurrentNavItem == R.id.nav_attendance_log_end_day) {
            state.setGarbage("EOD", 9);
            displaySelectedFragment(new FragmentLogAttendance());
        } else if (state.CurrentNavItem == R.id.nav_attendance_log_extra) {
            state.setGarbage("EXTRA", 9);
            displaySelectedFragment(new FragmentLogAttendance());
        } else if (state.CurrentNavItem == R.id.nav_regie_planned) {
            //TODO
            //displaySelectedFragment(new FragmentSync());
        } else if (state.CurrentNavItem == R.id.nav_regie_add) {
            displaySelectedFragment(new FragmentRegieStart());
        } else if (state.CurrentNavItem == R.id.nav_regie_end) {
            displaySelectedFragment(new FragmentRegieEnd());
        } else if (state.CurrentNavItem == R.id.nav_utils_calendar) {
            displaySelectedFragment(new FragmentCalendar());
        } else if (state.CurrentNavItem == R.id.nav_utils_weather) {
            displaySelectedFragment(new FragmentWeather());
        } else if (state.CurrentNavItem == R.id.nav_occurrences_add) {
            displaySelectedFragment(new FragmentOccurencesAdd());
        } else if (state.CurrentNavItem == R.id.nav_occurrences_view) {
            displaySelectedFragment(new FragmentOccurencesView());
        } else if (state.CurrentNavItem == R.id.nav_utils_gallery) {
            displaySelectedFragment(new FragmentGallery());
        } else if (state.CurrentNavItem == R.id.nav_livraison_planned) {
            //TODO
            //displaySelectedFragment(new FragmentSync());
        } else if (state.CurrentNavItem == R.id.nav_livraison_add) {
            displaySelectedFragment(new FragmentLivraisonEdit());
        } else if (state.CurrentNavItem == R.id.nav_livraison_view) {
            displaySelectedFragment(new FragmentLivraisonView());
        } else if (state.CurrentNavItem == R.id.nav_contactos) {
            displaySelectedFragment(new FragmentContacts());
        } else if (state.CurrentNavItem == R.id.nav_bordereau) {
            displaySelectedFragment(new FragmentBordereauView());
        } else if (state.CurrentNavItem == R.id.nav_qtd) {
            displaySelectedFragment(new FragmentQuantityView());
        } else if (state.CurrentNavItem == R.id.nav_project) {
            displaySelectedFragment(new FragmentProjectView());
        } else if (state.CurrentNavItem == R.id.nav_utils_sync) {
            displaySelectedFragment(new FragmentSync());

        } else if (state.CurrentNavItem == R.id.nav_hardware) {
            displaySelectedFragment(new FragmentHardware());
        } else if (state.CurrentNavItem == R.id.nav_consumables) {
            displaySelectedFragment(new FragmentMaterialsDIY());
        } else if (state.CurrentNavItem == R.id.nav_about) {
            displaySelectedFragment(new FragmentAbout());
        } else if (state.CurrentNavItem == R.id.nav_privacy) {
            displaySelectedFragment(new FragmentPrivacy());
        } else if (state.CurrentNavItem == R.id.nav_terms) {
            displaySelectedFragment(new FragmentTerms());
        } else if (state.CurrentNavItem == R.id.nav_logout) {
            state.clearSettings();
            state.CurrentNavItem=-1;
            Intent intent = new Intent(getApplicationContext(), LoginActivity.class);
            startActivity(intent);
        } else if (state.CurrentNavItem == R.id.nav_share) {
            state.CurrentNavItem = R.id.nav_home;
            state.saveSettings();
            Intent sharingIntent = new Intent(android.content.Intent.ACTION_SEND);
            sharingIntent.setType("text/plain");
            sharingIntent.putExtra(android.content.Intent.EXTRA_SUBJECT, getResources().getString(R.string.share_title));
            sharingIntent.putExtra(android.content.Intent.EXTRA_TEXT, getResources().getString(R.string.share_message));
            startActivity(Intent.createChooser(sharingIntent, getResources().getString(R.string.share_via)));
        } else if (state.CurrentNavItem == R.id.nav_visit_us) {
            state.CurrentNavItem = R.id.nav_home;
            state.saveSettings();
            Intent urlIntent = new Intent(Intent.ACTION_VIEW, Uri.parse(state.CompanyURL));
            startActivity(urlIntent);
        }
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {

        // Handle navigation view item clicks here.
        state.setCurrentNavItem(item.getItemId());
        state.clearGarbage();
        ResumeLoadedFragment();
        DrawerLayout drawer = findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }


    @Override
    protected void onPause() {
        unregisterNetworkChanges();
        super.onPause();
        if(mNfcAdapter!= null)
            mNfcAdapter.disableForegroundDispatch(this);
    }



    @Override
    protected void onResume(){
        super.onResume();

        IntentFilter tagDetected = new IntentFilter(NfcAdapter.ACTION_TAG_DISCOVERED);
        IntentFilter ndefDetected = new IntentFilter(NfcAdapter.ACTION_NDEF_DISCOVERED);
        IntentFilter techDetected = new IntentFilter(NfcAdapter.ACTION_TECH_DISCOVERED);
        IntentFilter[] nfcIntentFilter = new IntentFilter[]{techDetected,tagDetected,ndefDetected};

        PendingIntent pendingIntent = PendingIntent.getActivity(
                this, 0, new Intent(this, getClass()).addFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP), 0);

            if (mNfcAdapter != null)
                mNfcAdapter.enableForegroundDispatch(this, pendingIntent, nfcIntentFilter, null);

        registerNetworkBroadcast();
        state.loadSettings();

        String filename = getApplicationContext().getFilesDir() + "/config.xml";
        File file = new File(filename);

        if(file.exists()) {
            //read configuration file
            LoadConfig LoadConfig = new LoadConfig();
            LoadConfig.filename = filename;
            state.setCurrentLanguage(LoadConfig.GetConfigString("language"));
        }

        state.UUID="123456785";

        Functions.checkLocation(this);
        if(state.UUID.equals("")) {
            state.clearSettings();
            Toast.makeText(this, R.string.error_session_expired, Toast.LENGTH_SHORT).show();
            Intent intent = new Intent(getApplicationContext(), LoginActivity.class);
            startActivity(intent);

        }else if(!intentGoing && !loadingActivity) {
            ResumeLoadedFragment();

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
            field.setValue("14");
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("sn");
            field.setValue(state.UUID);
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("site");
            field.setValue(state.site);
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("section");
            field.setValue(state.section);
            fields.add(field);

            if(state.getGarbage()[0].equals("login")){
                field = new EntityFields();
                field.setRequestVar("messagebox");
                field.setValue("0");
                fields.add(field);
                if(!state.getGarbage()[1].equals("attendance")){
                    state.setGarbage("",0);
                }
            }
            field = new EntityFields();
            field.setRequestVar("language");
            field.setValue(state.getCurrentLanguage());
            fields.add(field);

            SendData sendData = new SendData(this, this);
            SendDataResultObserver sendDataResultObserver = new SendDataResultObserver(sendData.DelayedResult);
            sendData.DelayedResult.addObserver(sendDataResultObserver);
            sendData.addQueue(queue);
            sendData.addFields(fields);
            sendData.setEncryption(true, "AES128");
            sendData.setWaitForCode(false);
            sendData.setloadMainPage(false);
            sendData.setEnableQueue(false);
            sendData.send();
            //String response= sendData.getResponse();

            SendCrashReport();
        } else if (intentGoing){
            intentGoing=false;
        }



    }

    public class SendDataResultObserver implements Observer
    {
        private SendData.ObservableValue ov = null;
        public SendDataResultObserver(SendData.ObservableValue ov) {
            this.ov = ov;
        }
        public void update(Observable obs, Object obj) {
            if (obs == ov) {
                updateOfflineData(ov.getValue());
            }
        }
    }

    private void updateOfflineData(String response){
        try {
            JSONObject jsonObject = new JSONObject(response);
            if (jsonObject.getString("error").equals("false")) {
                try {
                    state.foremanName=jsonObject.getString("name");
                    name.setText(jsonObject.getString("name"));
                    mobile.setText(jsonObject.getString("mobile"));
                    site.setText(state.sitename);
                    //encode the URL
                    URL url = new URL(state.HostUrl);
                    // URI uri = new URI(url.getProtocol(), url.getUserInfo(), url.getHost(), url.getPort(), url.getPath(), url.getQuery(), url.getRef());
                    //String str= url.getProtocol()+"://"+url.getHost()+"/works/photos/"+jsonObject.getString("photo");

                    String str= state.HostUrl + "photos/" +jsonObject.getString("photo");

                    Glide.with(photo.getContext())
                            .asBitmap()
                            .placeholder(R.drawable.loading)
                            .error(R.drawable.loading_error_image)
                            .load(str)
                            .override(1080, 600)
                            .centerCrop()
                            .skipMemoryCache(true)  //No memory cache
                            .diskCacheStrategy(DiskCacheStrategy.NONE)   //No disk cache
                            .apply(RequestOptions.circleCropTransform())
                            .thumbnail(0.5f)
                            .into(photo);


                } catch (Exception e) {
                    Functions.SaveCrash(e, MainActivity.this);
                    Toast.makeText(this, getResources().getString(R.string.error_ivalid_url), Toast.LENGTH_LONG).show();
                }
            }else{
                Toast.makeText(this, Functions.getErrorCode(this,response), Toast.LENGTH_LONG).show();
            }
        } catch (JSONException e) {
            Functions.SaveCrash(e, MainActivity.this);
            Toast.makeText(this, getResources().getString(R.string.error_ivalid_data), Toast.LENGTH_LONG).show();
        }
    }

    @SuppressLint("StaticFieldLeak")
    private void SendCrashReport(){
        new AsyncTask<Void, Void, String>(){
            protected String doInBackground(Void[] params) {
                String filename = getApplicationContext().getFilesDir() + "/crash.log";
                File file = new File(filename);
                if(file.exists()) {
                    int length = (int) file.length();
                    byte[] bytes = new byte[length];
                    try {
                        FileInputStream in = new FileInputStream(file);
                        in.read(bytes);
                        in.close();
                    } catch(Exception ex) {
                        Functions.SaveCrash(ex, MainActivity.this);
                    }
                    String contents = new String(bytes);

                    EntityQueue queue= new EntityQueue();
                    queue.setMsgType("silent");
                    queue.setMsgSuccess("response");
                    queue.setMsgError("response");
                    queue.setUrl(state.HostUrl + "api/index.php");
                    queue.setTitle( "Crash Reports");
                    queue.setDescription( "Crash Reports");

                    ArrayList<EntityFields> fields = new ArrayList<>();
                    EntityFields field = new EntityFields();
                    field.setRequestVar("task");
                    field.setValue("17");
                    fields.add(field);

                    field = new EntityFields();
                    field.setRequestVar("sn");
                    field.setValue(state.UUID);
                    fields.add(field);

                    field = new EntityFields();
                    field.setRequestVar("report");
                    field.setValue(contents);
                    fields.add(field);

                    field = new EntityFields();
                    field.setRequestVar("language");
                    field.setValue(state.getCurrentLanguage());
                    fields.add(field);

                    SendData sendData = new SendData(MainActivity.this, MainActivity.this);
                    sendData.addQueue(queue);
                    sendData.addFields(fields);
                    sendData.setEncryption(true, "AES128");
                    sendData.setWaitForCode(true);
                    sendData.setloadMainPage(false);
                    sendData.setEnableQueue(false);
                    sendData.send();
                    String str = sendData.getResponse();
                    if (sendData.getError()){
                        return "true"; // an error occurred on sending report
                    }else{
                        return "false"; // reports sent sucessfully
                    }
                }
                return "false"; // no errors to report
            }
            protected void onPostExecute(String result) {
                if (result.equals("true")) { // error found on submit report
                    Toast.makeText(getApplicationContext(), getResources().getString(R.string.error_http_loading_response), Toast.LENGTH_LONG).show();
                }else { // no errors found check if crash log exists and delete it
                    String filename = getApplicationContext().getFilesDir() + "/crash.log";
                    File file = new File(filename);
                    if(file.exists()) {
                        file.delete();
                    }
                }
            }
        }.execute();
    }

}
