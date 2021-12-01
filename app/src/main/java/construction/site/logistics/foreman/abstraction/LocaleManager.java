package construction.site.logistics.foreman.abstraction;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;
import android.content.res.Configuration;
import android.content.res.Resources;
import android.os.Build;
import android.preference.PreferenceManager;
import android.text.TextUtils;
import android.util.DisplayMetrics;
import android.widget.Toast;

import java.util.Locale;

import construction.site.logistics.foreman.MainActivity;
import construction.site.logistics.foreman.R;

public class LocaleManager {

    public static final String LANGUAGE_KEY_ENGLISH = "en";
    public static final String LANGUAGE_KEY_FRENCH = "fr";
    public static final String LANGUAGE_KEY_PORTUGUESE = "pt";
    /**
     *  SharedPreferences Key
     */
    private static final String LANGUAGE_KEY = "language_key";

    /**
     * set current pref locale
     * @param mContext
     * @return
     */
    public static Context setLocale(Context mContext) {
        return updateResources(mContext, getLanguagePref(mContext));
    }

    /**
     * Set new Locale with context
     * @param mContext
     * @param mLocaleKey
     * @return
     */
    public static Context setNewLocale(Context mContext, String mLocaleKey) {
        if (android.os.Build.VERSION.SDK_INT > 23) {
            setLanguagePref(mContext, mLocaleKey);
            return updateResources(mContext, mLocaleKey);
        }else{
            setLocale(mContext, mLocaleKey);
            return mContext;
        }
    }

    public static void setLocale(Context context, String localeName) {
            Locale myLocale = new Locale(localeName);
            String currentLang= Locale.getDefault().getLanguage();

            Resources res = context.getResources();
            DisplayMetrics dm = res.getDisplayMetrics();
            Configuration conf = res.getConfiguration();
            conf.locale = myLocale;
            res.updateConfiguration(conf, dm);
            Intent refresh = new Intent(context, MainActivity.class);
            refresh.putExtra(currentLang, localeName);
            context.startActivity(refresh);
    }
    /**
     * Get saved Locale from SharedPreferences
     * @param mContext current context
     * @return current locale key by default return english locale
     */
    public static String getLanguagePref(Context mContext) {
        SharedPreferences mPreferences = PreferenceManager.getDefaultSharedPreferences(mContext);
        return mPreferences.getString(LANGUAGE_KEY, LANGUAGE_KEY_ENGLISH);
    }

    /**
     *  set pref key
     * @param mContext
     * @param localeKey
     */
    private static void setLanguagePref(Context mContext, String localeKey) {
        SharedPreferences mPreferences = PreferenceManager.getDefaultSharedPreferences(mContext);
        mPreferences.edit().putString(LANGUAGE_KEY, localeKey).commit();
    }

    /**
     * update resource
     * @param context
     * @param language
     * @return
     */
    private static Context updateResources(Context context, String language) {
        Locale locale = new Locale(language);
        Locale.setDefault(locale);
        Resources res = context.getResources();
        Configuration config = new Configuration(res.getConfiguration());
        if (Build.VERSION.SDK_INT >= 17) {
            config.setLocale(locale);
            context = context.createConfigurationContext(config);
        } else {
            config.locale = locale;
            res.updateConfiguration(config, res.getDisplayMetrics());
        }
        return context;
    }

    /**
     * get current locale
     * @param res
     * @return
     */
    public static Locale getLocale(Resources res) {
        Configuration config = res.getConfiguration();
        return Build.VERSION.SDK_INT >= 24 ? config.getLocales().get(0) : config.locale;
    }

    public static void updateLanguage(Context ctx, String lang)
    {
        Configuration cfg = new Configuration();
        if (!TextUtils.isEmpty(lang))
            cfg.locale = new Locale(lang);
        else
            cfg.locale = Locale.getDefault();

        ctx.getResources().updateConfiguration(cfg, null);
    }

}

