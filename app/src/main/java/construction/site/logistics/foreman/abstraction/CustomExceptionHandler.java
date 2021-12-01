package construction.site.logistics.foreman.abstraction;

import java.lang.Thread.UncaughtExceptionHandler;
import android.app.Activity;

public class CustomExceptionHandler implements UncaughtExceptionHandler {

    private UncaughtExceptionHandler defaultUEH;

    Activity activity;

    public CustomExceptionHandler(Activity activity) {
        this.defaultUEH = Thread.getDefaultUncaughtExceptionHandler();
        this.activity = activity;
    }

    public void uncaughtException(Thread t, Throwable e) {

        Functions.SaveCrash(e, this.activity);
        defaultUEH.uncaughtException(t, e);
    }
}