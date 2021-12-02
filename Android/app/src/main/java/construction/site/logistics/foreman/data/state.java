package construction.site.logistics.foreman.data;

import android.app.Activity;
import android.content.Context;
import android.content.SharedPreferences;
import android.graphics.Bitmap;

import java.util.Arrays;
import java.util.Collections;
import java.util.HashSet;
import java.util.Set;

import static android.content.Context.MODE_PRIVATE;


public class state {
    static public String UUID="";
    static public String[] garbage={ "", "", "", "", "", "","","","","" };
    static public String site="";
    static public String sitename="";
    static public String section="";
    static public Double latitude=0.0;
    static public Double longitude=0.0;
    static public Double authRadius=0.0;
    static public String HostUrl="http://www.aeonlabs.solutions/sitelogistics.construction/shared/csaml/";
    static public String HostFilesUrl="http://www.aeonlabs.solutions/sitelogistics.construction/shared/csaml/works/";
    static public String HostWeatherUrl="http://api.openweathermap.org/data/2.5/weather?appid=7c18fcf0c019a0859fc974d45f6f9d29&units=metric";
    static public Activity activity=null;
    static public String workerName="";
    static public String foremanName="";
    static public String CompanyURL="http://www.aeonlabs.solutions/sitelogistics.construction";
    static public String date="";
    static public Boolean tookPhoto=false;
    static public Set<String> gallerySelection= new HashSet<>();
    static public int CurrentNavItem=-1;
    static public Boolean LoadNewFragment=true;
    static public boolean userIsInteracting=false;
    static public String serial="";
    static public Boolean connected=false;
    static public String encryptionKey="26kozQaKwRuNJ24t";
    static public String currentLanguage="en";
    static public Integer IdleLogoutTimeOut=10; // in minutes

    static public String ReadSmartCardAuthenticationString="";
    static public String ReadSmartCardDataString="";
    static public String ReadSmartCardFullMessageString="";
    static public String ReadSmartCardID="";
    static public Integer NFCState=-1;
    static public String smartCardEncryptionKey="5pRQVsgHK1VvqJBb";
    static public Integer smartCardMemorySize=504; // memory size in bytes
    // override site location
    static public boolean overrideSite=true;
    static public Double overrideLatitude=50.646185;
    static public Double overrideLongitude=5.609522;
    static public boolean isDemonstrationEnabled = false;
    // authentication configuration
    static public boolean isSmartCardEnabled = false;
    static public String demonstrationHostUrl="http://www.aeonlabs.solutions/sitelogistics.construction/shared/csaml/";
    static public String demonstrationHostFilesUrl="http://www.aeonlabs.solutions/sitelogistics.construction/shared/csaml/works/";


    public static void clearNFCdata(){
         ReadSmartCardAuthenticationString="";
         ReadSmartCardDataString="";
         ReadSmartCardFullMessageString="";
         ReadSmartCardID="";

    }

    public static void setCurrentLanguage(String _lang){
        currentLanguage=_lang;
        SharedPreferences settingsfile= activity.getSharedPreferences("settings",MODE_PRIVATE);
        SharedPreferences.Editor myeditor = settingsfile.edit();
        myeditor.putString("currentlanguage", _lang);
        myeditor.apply();
        myeditor.commit();
    }

    public static String getCurrentLanguage(){
        SharedPreferences settings= activity.getSharedPreferences("settings", MODE_PRIVATE);
        state.currentLanguage= settings.getString("currentlanguage", "en");
        return state.currentLanguage;
    }


    public static void setNetworkStatus(Boolean _state){
        connected=_state;
        SharedPreferences settingsfile= activity.getSharedPreferences("settings",MODE_PRIVATE);
        SharedPreferences.Editor myeditor = settingsfile.edit();
        myeditor.putBoolean("NetworkStatus", _state);
        myeditor.apply();
        myeditor.commit();
    }

    public static Boolean getNetworkStatus(){
        SharedPreferences settings= activity.getSharedPreferences("settings", MODE_PRIVATE);
        state.connected= settings.getBoolean("NetworkStatus", true);
        return state.connected;
    }

    public static void setTookPhoto(Boolean _state){
        tookPhoto=_state;
        SharedPreferences settingsfile= activity.getSharedPreferences("settings",MODE_PRIVATE);
        SharedPreferences.Editor myeditor = settingsfile.edit();
        myeditor.putBoolean("tookPhoto", _state);
        myeditor.apply();
        myeditor.commit();
    }

    public static Boolean getTookPhoto(){
        SharedPreferences settings= activity.getSharedPreferences("settings", MODE_PRIVATE);
        state.tookPhoto= settings.getBoolean("tookPhoto", false);
        return state.tookPhoto;
    }

    public static void setCurrentNavItem(int _state){
        CurrentNavItem=_state;
        SharedPreferences settingsfile= activity.getSharedPreferences("settings",MODE_PRIVATE);
        SharedPreferences.Editor myeditor = settingsfile.edit();
        myeditor.putInt("CurrentNavItem", _state);
        myeditor.apply();
        myeditor.commit();
    }

    public static int getCurrentNavItem(){
        SharedPreferences settings= activity.getSharedPreferences("settings", MODE_PRIVATE);
        state.CurrentNavItem= settings.getInt("CurrentNavItem", -1);
        return state.CurrentNavItem;
    }

    public static void setGarbage(String _state, int pos){

        if(pos!=-1){
            state.garbage[pos]=_state;
        }
        SharedPreferences settingsfile= activity.getSharedPreferences("settings",MODE_PRIVATE);
        SharedPreferences.Editor myeditor = settingsfile.edit();
        for(int i=0;i<state.garbage.length;i++){
            myeditor.putString("garbage"+i, state.garbage[i]);
        }
        myeditor.apply();
        myeditor.commit();
    }

    public static String[] getGarbage(){
        SharedPreferences settings= activity.getSharedPreferences("settings", MODE_PRIVATE);
        for(int i=0;i<state.garbage.length;i++){
            state.garbage[i]=settings.getString("garbage"+i, "");
        }
        return state.garbage;
    }

    public static void clearGarbage(){
        SharedPreferences settingsfile= activity.getSharedPreferences("settings",MODE_PRIVATE);
        SharedPreferences.Editor myeditor = settingsfile.edit();
        for(int i=0;i<state.garbage.length;i++){
            myeditor.putString("garbage"+i, "");
        }
        myeditor.apply();
        myeditor.commit();
        state.garbage= new String[] { "", "", "", "", "", "","","","","" };
    }

    public static void setPhotos2Upload(String _state){
        SharedPreferences settings= activity.getSharedPreferences("settings",MODE_PRIVATE);
        Set<String >set = settings.getStringSet("photos2upload",new HashSet<>());
        set.add(_state);
        SharedPreferences.Editor myeditor = settings.edit();
        myeditor.putStringSet("photos2upload",set);
        myeditor.apply();
        myeditor.commit();
    }

    public static Set<String > getPhotos2Upload(){
        SharedPreferences settings= activity.getSharedPreferences("settings", MODE_PRIVATE);
        Set<String >set = settings.getStringSet("photos2upload",new HashSet<>());
        return set;
    }

    public static void clearPhotos2Upload(String str){
        SharedPreferences settings= activity.getSharedPreferences("settings",MODE_PRIVATE);
        SharedPreferences.Editor myeditor = settings.edit();
        if(str.equals("")) {
            myeditor.putStringSet("photos2upload", new HashSet<>());
        }else {
            Set<String> set = settings.getStringSet("photos2upload", new HashSet<>());
            set.remove(str);
            myeditor.putStringSet("photos2upload", set);
        }
        myeditor.apply();
        myeditor.commit();
    }

    public static void clearSettings(){
        if (activity !=null){
            SharedPreferences settingsfile= activity.getSharedPreferences("settings",MODE_PRIVATE);
            SharedPreferences.Editor myeditor = settingsfile.edit();
            myeditor.clear();
            myeditor.putString("latitude", "");
            myeditor.putString("longitude", "" );
            myeditor.putString("UUID","");
            myeditor.putString("site", "");
            myeditor.putString("sitename", "");
            myeditor.putString("section", "");
            myeditor.putBoolean("tookPhoto", false);
            myeditor.putInt("CurrentNavItem", -1);
            myeditor.apply();
            myeditor.commit();
            setGarbage("",-1);
        }

        state.UUID = "";
        state.site = "";
        state.sitename = "";
        state.section = "";
        state.tookPhoto= false;
        state.CurrentNavItem = -1;
        state.latitude= 0.0;
        state.longitude=0.0;
    }

    public static void saveSettings(){
        SharedPreferences settingsfile= activity.getSharedPreferences("settings",MODE_PRIVATE);
        SharedPreferences.Editor myeditor = settingsfile.edit();
        myeditor.clear();
        String str=String.valueOf(state.latitude);
        myeditor.putString("latitude", String.valueOf(state.latitude).equals("") ? "0.0" : String.valueOf(state.latitude) );
        myeditor.putString("longitude", String.valueOf(state.longitude).equals("") ? "0.0" : String.valueOf(state.longitude) );
        myeditor.putString("UUID", state.UUID);
        myeditor.putString("site", state.site);
        myeditor.putString("sitename", state.sitename);
        myeditor.putString("section", state.section);
        myeditor.putBoolean("tookPhoto", state.tookPhoto);
        myeditor.putInt("CurrentNavItem", state.CurrentNavItem);
        myeditor.apply();
        myeditor.commit();
        setGarbage("",-1);
    }

    public static void loadSettings(){
        SharedPreferences settings= activity.getSharedPreferences("settings", MODE_PRIVATE);
        state.UUID = settings.getString("UUID","");
        state.site = settings.getString("site","");
        state.sitename = settings.getString("sitename","");
        state.section = settings.getString("section","");
        state.tookPhoto= settings.getBoolean("tookPhoto", false);
        state.CurrentNavItem = settings.getInt("CurrentNavItem", -1);
        String latitude= settings.getString("latitude", "0.0");
        String longitude= settings.getString("longitude", "0.0");
        if(latitude.equals("")){
            state.latitude=0.0;
        }else if (latitude.matches("-?\\d+(\\.\\d+)?")){
            state.latitude= Double.parseDouble(latitude);
        }else{
            state.latitude=0.0;
        }

        if(longitude.equals("")){
            state.longitude=0.0;
        }else if (longitude.matches("-?\\d+(\\.\\d+)?")){
            state.longitude= Double.parseDouble(longitude);
        }else{
            state.longitude=0.0;
        }
        getGarbage();
    }
}
