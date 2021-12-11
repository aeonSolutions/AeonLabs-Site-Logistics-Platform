package qc.worker;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.content.Intent;
import android.content.pm.ActivityInfo;
import android.content.pm.PackageManager;

import android.content.res.Configuration;
import android.graphics.drawable.Drawable;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;


import androidx.annotation.Nullable;
import androidx.core.view.GravityCompat;
import androidx.appcompat.app.ActionBarDrawerToggle;

import android.view.MenuItem;

import com.akexorcist.screenorientationhelper.ScreenOrientationHelper;
import com.bumptech.glide.Glide;
import com.bumptech.glide.load.DataSource;
import com.bumptech.glide.load.engine.DiskCacheStrategy;
import com.bumptech.glide.load.engine.GlideException;
import com.bumptech.glide.load.resource.drawable.DrawableTransitionOptions;
import com.bumptech.glide.request.RequestListener;
import com.bumptech.glide.request.RequestOptions;
import com.bumptech.glide.request.target.Target;
import com.google.android.material.navigation.NavigationView;

import androidx.drawerlayout.widget.DrawerLayout;

import androidx.appcompat.app.AppCompatActivity;
import androidx.appcompat.widget.Toolbar;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
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

import qc.worker.Fragments.FragmentAbout;
import qc.worker.Fragments.FragmentAbsense;
import qc.worker.Fragments.FragmentContacts;
import qc.worker.Fragments.FragmentFood;
import qc.worker.Fragments.FragmentHome;
import qc.worker.Fragments.FragmentLimosas;
import qc.worker.Fragments.FragmentLodging;
import qc.worker.Fragments.FragmentPerformance;
import qc.worker.Fragments.FragmentPrivacy;
import qc.worker.Fragments.FragmentSuggestion;
import qc.worker.Fragments.FragmentTerms;
import qc.worker.Fragments.FragmentWorkerFile;
import qc.worker.Network.HttpRequestHandler;
import qc.worker.abstraction.AppLifecycleTracker;
import qc.worker.abstraction.CustomExceptionHandler;
import qc.worker.abstraction.Functions;
import qc.worker.abstraction.GlideApp;
import qc.worker.abstraction.GlideCustom;
import qc.worker.abstraction.LocaleManager;
import qc.worker.data.LoadConfig;
import qc.worker.data.state;
import qc.worker.login.LoginActivity;

import static android.content.pm.PackageManager.GET_META_DATA;

public class MainActivity extends AppCompatActivity
        implements NavigationView.OnNavigationItemSelectedListener, LifecycleObserver, ScreenOrientationHelper.ScreenOrientationChangeListener {


    private ScreenOrientationHelper helper = new ScreenOrientationHelper(this);
    private TextView name, mobile;
    private ImageView photo;
    private View header;

    @Override
        protected void onStart() {
            super.onStart();
            helper.onStart();
        }

        @Override
        protected void onSaveInstanceState(Bundle outState) {
            super.onSaveInstanceState(outState);
            helper.onSaveInstanceState(outState);
        }

        @Override
        protected void onRestoreInstanceState(Bundle savedInstanceState) {
            super.onRestoreInstanceState(savedInstanceState);
            helper.onRestoreInstanceState(savedInstanceState);
        }

        @Override
        public void onScreenOrientationChanged(int orientation) {
            Fragment fragment = new FragmentHome();
            displaySelectedFragment(fragment);
        }


    @Override
    protected void onCreate(@Nullable  Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(this));

        helper.onCreate(savedInstanceState);
        helper.setScreenOrientationChangeListener(this);

        AppLifecycleTracker handler = new AppLifecycleTracker();
        getApplication().registerActivityLifecycleCallbacks(handler);
        registerComponentCallbacks(handler);

        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }

        setContentView(R.layout.activity_main);
        Toolbar toolbar = findViewById(R.id.toolbar);
        setSupportActionBar(toolbar);

        DrawerLayout drawer = findViewById(R.id.drawer_layout);
        NavigationView navigationView = findViewById(R.id.nav_view);
        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(
                this, drawer, toolbar, R.string.navigation_drawer_open, R.string.navigation_drawer_close);
        drawer.addDrawerListener(toggle);
        toggle.syncState();
        navigationView.setNavigationItemSelectedListener(this);
        resetTitles();

        header = navigationView.getHeaderView(0);
        name= header.findViewById(R.id.drawer_worker_name);
        mobile= header.findViewById(R.id.drawer_worker_contact);
        photo= header.findViewById(R.id.drawer_worker_photo);

        //Loading backgrounf image
        ImageView navBackground = header.findViewById(R.id.img_header_bg);

        GlideApp.with(photo.getContext())
                .asBitmap()
                .load(state.HostUrl+"images/nav_bg.png")
                .override(1080, 600)
                .centerCrop()
                .skipMemoryCache(true)  //No memory cache
                .diskCacheStrategy(DiskCacheStrategy.NONE)   //No disk cache
                .thumbnail(0.5f)
                .into(navBackground);

        //throw new RuntimeException("This is a crash");
    }




    @Override
    public void onConfigurationChanged(Configuration newConfig) {
        // Do something here.
        // But don't forget to call this method
        super.onConfigurationChanged(newConfig);

    }

    private void displaySelectedFragment(Fragment fragment) {
        FragmentTransaction fragmentTransaction = getSupportFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.content_frame, fragment);
        fragmentTransaction.commit();
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
        } else {
            super.onBackPressed();
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
            LoadConfig.saveConfig("en", getApplicationContext());
            LocaleManager.setNewLocale(this, LocaleManager.LANGUAGE_KEY_ENGLISH);
            recreate();
        }else if(id== R.id.action_lang_fr){
            for (Fragment fragment : getSupportFragmentManager().getFragments()) {
                if (fragment != null) {
                    getSupportFragmentManager().beginTransaction().remove(fragment).commit();
                }
            }
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
            LocaleManager.setNewLocale(this, LocaleManager.LANGUAGE_KEY_PORTUGUESE);
            recreate();
        }

        return super.onOptionsItemSelected(item);
    }

    @SuppressWarnings("StatementWithEmptyBody")
    @Override
    public boolean onNavigationItemSelected(MenuItem item) {
        // Handle navigation view item clicks here.
        int id = item.getItemId();
        Fragment fragment = null;

        if (id == R.id.nav_home) {
            fragment = new FragmentHome();
            displaySelectedFragment(fragment);
            state.loadedfragment="home";
        } else if (id == R.id.nav_alimentacao) {
            fragment = new FragmentFood();
            displaySelectedFragment(fragment);
            state.loadedfragment="alimentacao";
        } else if (id == R.id.nav_alojamento) {
            fragment = new FragmentLodging();
            state.loadedfragment="lodging";
            displaySelectedFragment(fragment);
        } else if (id == R.id.nav_contactos) {
            fragment = new FragmentContacts();
            displaySelectedFragment(fragment);
            state.loadedfragment="contacts";
        } else if (id == R.id.nav_ficha) {
            fragment = new FragmentWorkerFile();
            displaySelectedFragment(fragment);
            state.loadedfragment="ficha";
        } else if (id == R.id.nav_limosas) {
            fragment = new FragmentLimosas();
            displaySelectedFragment(fragment);
            state.loadedfragment="limosas";
        } else if (id == R.id.nav_ausencia) {
            fragment = new FragmentAbsense();
            displaySelectedFragment(fragment);
            state.loadedfragment="ausencia";
        } else if (id == R.id.nav_desempenho) {
            fragment = new FragmentPerformance();
            displaySelectedFragment(fragment);
            state.loadedfragment="performance";
        } else if (id == R.id.nav_sugestao) {
            fragment = new FragmentSuggestion();
            displaySelectedFragment(fragment);
            state.loadedfragment="suggestion";
        } else if (id == R.id.nav_about) {
            fragment = new FragmentAbout();
            displaySelectedFragment(fragment);
            state.loadedfragment="about";
        } else if (id == R.id.nav_privacy) {
            displaySelectedFragment(new FragmentPrivacy());
            state.loadedfragment="privacy";
        } else if (id == R.id.nav_terms) {
            displaySelectedFragment(new FragmentTerms());
            state.loadedfragment="terms";
        } else if (id == R.id.nav_logout) {
            state.UUID="";
            Intent intent = new Intent(getApplicationContext(), LoginActivity.class);
            startActivity(intent);
        } else if (id == R.id.nav_share) {
            //Display Share Via dialogue
            Intent sharingIntent = new Intent(android.content.Intent.ACTION_SEND);
            sharingIntent.setType("text/plain");
            sharingIntent.putExtra(android.content.Intent.EXTRA_SUBJECT, getResources().getString(R.string.share_title));
            sharingIntent.putExtra(android.content.Intent.EXTRA_TEXT, getResources().getString(R.string.share_message));
            startActivity(Intent.createChooser(sharingIntent, getResources().getString(R.string.share_via)));

        } else if (id == R.id.nav_visit_us) {
            //Open URL on click of Visit Us
            Intent urlIntent = new Intent(Intent.ACTION_VIEW, Uri.parse(state.CompanyURL));
            startActivity(urlIntent);
        }

        DrawerLayout drawer = findViewById(R.id.drawer_layout);
        drawer.closeDrawer(GravityCompat.START);
        return true;
    }

@Override
    public void onResume(){
        super.onResume();

        if(state.UUID.equals("")){
            Intent intent = new Intent(getApplicationContext(), LoginActivity.class);
            startActivity(intent);
        }else {
            ResumeLoadedFragment();
            new MakeServerCall(state.HostUrl + "api/api.php?task=workerfile&type=get&uuid=" + state.UUID, this).execute();
            SendCrashReport();
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
                    try {
                        //encode the URL
                        URL url = new URL(state.HostUrl);
                        // URI uri = new URI(url.getProtocol(), url.getUserInfo(), url.getHost(), url.getPort(), url.getPath(), url.getQuery(), url.getRef());
                        String str = url.getProtocol() + "://" + url.getHost() + "/crash/";
                        HttpRequestHandler requestHandler = new HttpRequestHandler();
                        return requestHandler.sendGetRequest(str + "api.php?uuid=" + state.UUID+"&report="+contents , MainActivity.this);
                    } catch (Exception ex ){
                        Functions.SaveCrash(ex, MainActivity.this);

                    }
                }
                return "false";
            }
            protected void onPostExecute(String result) {
                if (!result.equals("false")) {
                    try {
                        JSONObject jsonObject = new JSONObject(result);
                        if (jsonObject.getString("error").equals("false")) {
                            String filename = getApplicationContext().getFilesDir() + "/crash.log";
                            File file = new File(filename);
                            if (file.exists()) {
                                file.delete();
                            }
                        }
                    } catch (JSONException e) {
                        Functions.SaveCrash(e, MainActivity.this);
                        Toast.makeText(getApplicationContext(), getResources().getString(R.string.error_ivalid_data), Toast.LENGTH_LONG).show();
                    }
                }
            }
        }.execute();
    }

    private void ResumeLoadedFragment(){
        Fragment fragment = null;

        if (state.loadedfragment.equals("home") || state.loadedfragment.equals("")) {
            fragment = new FragmentHome();
            displaySelectedFragment(fragment);
        } else if (state.loadedfragment.equals("alimentacao")) {
            fragment = new FragmentFood();
            displaySelectedFragment(fragment);
        } else if (state.loadedfragment.equals("lodging")) {
            fragment = new FragmentLodging();
            displaySelectedFragment(fragment);
        } else if (state.loadedfragment.equals("contacts")) {
            fragment = new FragmentContacts();
            displaySelectedFragment(fragment);
        } else if (state.loadedfragment.equals("ficha")) {
            fragment = new FragmentWorkerFile();
            displaySelectedFragment(fragment);
        } else if (state.loadedfragment.equals("limosas")) {
            fragment = new FragmentLimosas();
            displaySelectedFragment(fragment);
        } else if (state.loadedfragment.equals("ausencia")) {
            fragment = new FragmentAbsense();
            displaySelectedFragment(fragment);
        } else if (state.loadedfragment.equals("performance")) {
            fragment = new FragmentPerformance();
            displaySelectedFragment(fragment);
        } else if (state.loadedfragment.equals("suggestion")) {
            fragment = new FragmentSuggestion();
            displaySelectedFragment(fragment);
        } else if (state.loadedfragment.equals("about")) {
            fragment = new FragmentAbout();
            displaySelectedFragment(fragment);
        } else if (state.loadedfragment.equals("privacy")) {
            displaySelectedFragment(new FragmentPrivacy());
        } else if (state.loadedfragment.equals("terms")) {
            displaySelectedFragment(new FragmentTerms());
        }
    }

    public class MakeServerCall extends AsyncTask<Void, Void, String> {

        private String url="";
        private Activity activity=null;

        public MakeServerCall (String url, Activity activity){
            this.url=url;
            this.activity=activity;
        }

        @Override
        protected String doInBackground(Void... params) {
            Functions.showSimpleProgressDialog(this.activity, this.activity.getResources().getString(R.string.commServer_connect_title_msg), this.activity.getResources().getString(R.string.commServer_connect_msg),false);

            HttpRequestHandler requestHandler = new HttpRequestHandler();
            return requestHandler.sendGetRequest(this.url, this.activity);
        }

        @Override
        protected void onPostExecute(String response) {

            try {
                JSONObject jsonObject = new JSONObject(response);
                if (jsonObject.getString("error").equals("false")) {
                    try {
                        name.setText(jsonObject.getString("name"));
                        mobile.setText(jsonObject.getString("mobile"));

                        //encode the URL
                        URL url = new URL(state.HostUrl);
                        // URI uri = new URI(url.getProtocol(), url.getUserInfo(), url.getHost(), url.getPort(), url.getPath(), url.getQuery(), url.getRef());
                        String str= url.getProtocol()+"://"+url.getHost()+"/works/photos/"+jsonObject.getString("photo");

                        GlideApp.with(photo.getContext())
                                .asBitmap()
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
                        Toast.makeText(getApplicationContext(), getResources().getString(R.string.error_ivalid_url), Toast.LENGTH_LONG).show();
                    }
                }else{

                    Toast.makeText(getApplicationContext(), Functions.getErrorCode(getApplicationContext(),response), Toast.LENGTH_LONG).show();
                }
            } catch (JSONException e) {
                Functions.SaveCrash(e, MainActivity.this);

                Toast.makeText(getApplicationContext(), getResources().getString(R.string.error_ivalid_data), Toast.LENGTH_LONG).show();
            }
            Functions.removeSimpleProgressDialog();

        }
    }

}
