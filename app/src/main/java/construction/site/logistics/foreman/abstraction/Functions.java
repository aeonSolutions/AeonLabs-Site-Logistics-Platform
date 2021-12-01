package construction.site.logistics.foreman.abstraction;

import android.Manifest;
import android.app.Activity;
import android.app.AlertDialog;
import android.app.PendingIntent;
import android.app.ProgressDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.IntentFilter;
import android.content.pm.PackageManager;
import android.graphics.Bitmap;
import android.graphics.BitmapFactory;
import android.nfc.NfcAdapter;
import android.nfc.Tag;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Handler;
import android.os.Looper;
import android.view.View;
import android.view.inputmethod.InputMethodManager;
import android.widget.ProgressBar;
import android.widget.Toast;

import androidx.core.app.ActivityCompat;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.fragment.app.FragmentTransaction;

import com.google.zxing.BarcodeFormat;
import com.google.zxing.MultiFormatWriter;
import com.google.zxing.WriterException;
import com.google.zxing.common.BitMatrix;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.text.DecimalFormat;
import java.util.ArrayList;

import construction.site.logistics.foreman.MainActivity;
import construction.site.logistics.foreman.Network.HttpRequestHandler;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.data.LoadedRecord;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.state;
import construction.site.logistics.foreman.login.LoginActivity;

import static construction.site.logistics.foreman.data.state.activity;

public class Functions {
    public static final String MIME_TEXT_PLAIN = "text/plain";
    public static ProgressDialog mProgressDialog;

    private final static int WHITE = 0xFFFFFFFF;
    private final static int BLACK = 0xFF000000;


    public static Bitmap QRCodeEncodeAsBitmap(String str) throws WriterException {
        BitMatrix result;
        try {
            result = new MultiFormatWriter().encode(str,
                    BarcodeFormat.QR_CODE, 400, 400, null);
        } catch (IllegalArgumentException iae) {
            // Unsupported format
            return null;
        }

        int w = result.getWidth();
        int h = result.getHeight();
        int[] pixels = new int[w * h];
        for (int y = 0; y < h; y++) {
            int offset = y * w;
            for (int x = 0; x < w; x++) {
                pixels[offset + x] = result.get(x, y) ? BLACK : WHITE;
            }
        }

        Bitmap bitmap = Bitmap.createBitmap(w, h, Bitmap.Config.ARGB_8888);
        bitmap.setPixels(pixels, 0, w, 0, 0, w, h);
        return bitmap;
    }

    public static void checkLocation(Activity activity){
        return;
        /*
        GeoLocation gps = new GeoLocation();
        if (gps.getLocation(activity.getApplicationContext()) == null) {
            Toast.makeText(activity.getApplicationContext(), activity.getResources().getString(R.string.error_location_disabled), Toast.LENGTH_LONG).show();
            state.clearSettings();
            Intent intent = new Intent(activity, LoginActivity.class);
            activity.startActivity(intent);
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
                    Toast.makeText(activity.getApplicationContext(), activity.getResources().getString(R.string.error_unable_get_location), Toast.LENGTH_LONG).show();
                    state.clearSettings();
                    Intent intent = new Intent(activity, LoginActivity.class);
                    activity.startActivity(intent);
                } else {
                    Double distance = gps.distance(state.latitude, state.longitude, latitude, longitude);
                    if (distance < authRadius) {



                    } else {
                        Functions.showSimpleProgressDialog(activity, activity.getResources().getString(R.string.error_title), activity.getResources().getString(R.string.login_not_on_site), false);
                        Handler handler = new Handler();
                        handler.postDelayed(new Runnable() {
                            public void run() {
                                Functions.removeSimpleProgressDialog();
                            }
                        }, 1500);
                        state.clearSettings();
                        Intent intent = new Intent(activity, LoginActivity.class);
                        activity.startActivity(intent);
                    }
                }
            } else {
                Toast.makeText(activity.getApplicationContext(), activity.getResources().getString(R.string.error_location_disabled), Toast.LENGTH_LONG).show();
                state.clearSettings();
                Intent intent = new Intent(activity, LoginActivity.class);
                activity.startActivity(intent);
            }
        }

         */
    }

    public static void ReadSmartCardID(Intent intent) {
        String action = intent.getAction();
        /*READ SERIAL NUMBER*/
        if (NfcAdapter.ACTION_NDEF_DISCOVERED.equals(action) || NfcAdapter.ACTION_TECH_DISCOVERED.equals(action) || NfcAdapter.ACTION_TAG_DISCOVERED.equals(action)) {
            Tag tagFromIntent = intent.getParcelableExtra(NfcAdapter.EXTRA_TAG);
            byte[] extraID = tagFromIntent.getId();

            StringBuilder sb = new StringBuilder();
            for (byte b : extraID) {
                sb.append(String.format("%02X", b));
            }

            String hexdump = "";
            hexdump = sb.toString();
            long uuid = Long.parseLong(hexdump, 16);

            state.ReadSmartCardID = String.valueOf(uuid);
        }
    }

    public static void setupForegroundDispatch(final Activity activity, NfcAdapter adapter) {
        final Intent intent = new Intent(activity.getApplicationContext(), activity.getClass());
        intent.setFlags(Intent.FLAG_ACTIVITY_SINGLE_TOP);

        final PendingIntent pendingIntent = PendingIntent.getActivity(activity.getApplicationContext(), 0, intent, 0);

        IntentFilter[] filters = new IntentFilter[1];
        String[][] techList = new String[][]{};

        // Notice that this is the same filter as in our manifest.
        filters[0] = new IntentFilter();
        filters[0].addAction(NfcAdapter.ACTION_NDEF_DISCOVERED);
        filters[0].addCategory(Intent.CATEGORY_DEFAULT);
        try {
            filters[0].addDataType(MIME_TEXT_PLAIN);
        } catch (IntentFilter.MalformedMimeTypeException e) {
            throw new RuntimeException("Check your mime type.");
        }
        adapter.enableForegroundDispatch(activity, pendingIntent, null, null);
        // adapter.enableForegroundDispatch(activity, pendingIntent, filters, techList);
    }

    /*
     * @param activity The corresponding {@link BaseActivity} requesting to stop the foreground dispatch.
     * @param adapter The {@link NfcAdapter} used for the foreground dispatch.
     */
    public static void stopForegroundDispatch(final Activity activity, NfcAdapter adapter) {
        adapter.disableForegroundDispatch(activity);
    }

    public static void alertbox(String title, String mymessage, Context context) {
        AlertDialog.Builder builder = new AlertDialog.Builder(context);
        builder.setMessage(mymessage)
                .setCancelable(false)
                .setTitle(title)
                .setPositiveButton(context.getResources().getString(R.string.alertbox_continue),
                        new DialogInterface.OnClickListener() {
                            public void onClick(DialogInterface dialog, int id) {
                                dialog.cancel();
                            }
                        });
        AlertDialog alert = builder.create();
        alert.show();
    }

    public static void hideKeyboard(View view, Context context) {
        InputMethodManager inputMethodManager =(InputMethodManager) context.getSystemService(Activity.INPUT_METHOD_SERVICE);
        inputMethodManager.hideSoftInputFromWindow(view.getWindowToken(), 0);
    }

    public static void removeSimpleProgressDialog() {

        new Handler(Looper.getMainLooper()).post(new Runnable() {
            @Override
            public void run() {
                try {
                    if (mProgressDialog != null) {
                        if (mProgressDialog.isShowing()) {
                            mProgressDialog.dismiss();
                            mProgressDialog = null;
                        }
                    }
                } catch (IllegalArgumentException ie) {
                    ie.printStackTrace();

                } catch (RuntimeException re) {
                    re.printStackTrace();
                } catch (Exception e) {
                    e.printStackTrace();
                }

            }
        });

    }

    public static void showSimpleProgressDialog(final Activity activity, final String title, final String msg, final boolean isCancelable) {

        new Handler(Looper.getMainLooper()).post(new Runnable() {
            @Override
            public void run() {
                try {
                    if (mProgressDialog == null) {
                        mProgressDialog= new ProgressDialog(activity);
                        mProgressDialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);

                        mProgressDialog = ProgressDialog.show(activity, title, msg);
                        mProgressDialog.setCancelable(isCancelable);
                    }

                    if (!mProgressDialog.isShowing()) {
                        mProgressDialog.show();
                    }

                } catch (IllegalArgumentException ie) {
                    Functions.SaveCrash(ie, activity);
                } catch (RuntimeException re) {
                    Functions.SaveCrash(re, activity);
                } catch (Exception e) {
                    Functions.SaveCrash(e, activity);
                }
            }
        });

    }

    public static void SaveCrash(Throwable e, Activity activity){
        StackTraceElement[] arr = e.getStackTrace();
        String report = e.toString() + "\n\n";
        report += "--------- Stack trace ---------\n\n";
        report+= "----------"+System.nanoTime()+"----------";
        report+= "----------OS version:"+android.os.Build.VERSION.SDK_INT+"----------";

        for (int i = 0; i < arr.length; i++) {
            report += "    " + arr[i].toString() + "\n";
        }
        report += "-------------------------------\n\n";
        report += "--------- Message ---------\n\n";
        report += e.getMessage()+"\n\n";
        report += "-------------------------------\n\n";
        report += "--------- Cause ---------\n\n";
        Throwable cause = e.getCause();
        if (cause != null) {
            report += cause.toString() + "\n\n";
            arr = cause.getStackTrace();
            for (int i = 0; i < arr.length; i++) {
                report += "    " + arr[i].toString() + "\n";
            }
        }
        report += "-------------------------------\n\n";

        String filename = activity.getFilesDir() + "/crash.log";
        File file = new File(filename);

        try {
            FileOutputStream stream = new FileOutputStream(file);
            stream.write(report.getBytes());
            stream.close();
        }catch(Exception ex){
            ex.printStackTrace();
        }
    }

    public static boolean hasMessageBox(String response) {

        try {
            JSONObject jsonObject = new JSONObject(response);
            return jsonObject.has("messagebox");

        } catch (Exception e) {
            e.printStackTrace();
        }
        return false;
    }

    public static String getMessageBox(String response) {

        try {
            JSONObject jsonObject = new JSONObject(response);
            JSONArray dataArray = jsonObject.getJSONArray("messagebox");
            int test=dataArray.length();
            for (int i = 0; i < test; i++) {
                JSONObject dataobj = dataArray.getJSONObject(i);
                String message=dataobj.getString("message");
                String code=dataobj.getString("code");
                state.activity.runOnUiThread(new Runnable() {
                                           public void run() {
                                               AlertDialog.Builder alert = new AlertDialog.Builder(state.activity);
                                               alert.setTitle(state.activity.getResources().getString(R.string.message_box_title));
                                               alert.setMessage(message);
                                               alert.setPositiveButton(activity.getResources().getString(R.string.alertbox_continue), new DialogInterface.OnClickListener() {
                                                   public void onClick(DialogInterface dialog, int whichButton) {
                                                       EntityQueue queue= new EntityQueue();
                                                       queue.setMsgType("silent");
                                                       queue.setMsgSuccess("response");
                                                       queue.setMsgError("response");
                                                       queue.setUrl(state.HostUrl + "api/index.php");
                                                       queue.setTitle( state.activity.getString(R.string.message_box_title));
                                                       queue.setDescription( state.activity.getString(R.string.message_box_title));

                                                       ArrayList<EntityFields> fields = new ArrayList<>();
                                                       EntityFields field = new EntityFields();
                                                       field.setRequestVar("task");
                                                       field.setValue("18");
                                                       fields.add(field);

                                                       field = new EntityFields();
                                                       field.setRequestVar("sn");
                                                       field.setValue(state.UUID);
                                                       fields.add(field);

                                                       field = new EntityFields();
                                                       field.setRequestVar("code");
                                                       field.setValue(code);
                                                       fields.add(field);

                                                       field = new EntityFields();
                                                       field.setRequestVar("language");
                                                       field.setValue(state.getCurrentLanguage());
                                                       fields.add(field);

                                                       SendData sendData = new SendData(state.activity, null);
                                                       sendData.addQueue(queue);
                                                       sendData.addFields(fields);
                                                       sendData.setEncryption(true, "AES128");
                                                       sendData.setWaitForCode(true);
                                                       sendData.setloadMainPage(false);
                                                       sendData.setEnableQueue(false);
                                                       sendData.send();
                                                       String response= sendData.getResponse();

                                                       dialog.cancel();
                                                   }
                                               });
                                               alert.show();
                                           }
                });
            }
        } catch (Exception e) {
            e.printStackTrace();
        }
        return  state.activity.getResources().getString(R.string.error_message_box_not_found);
    }

    public static boolean isSuccess(String response) {

        try {
            JSONObject jsonObject = new JSONObject(response);
            return !jsonObject.optString("error").equals("true");

        } catch (Exception e) {
            e.printStackTrace();
        }
        return false;
    }

    public static boolean isSuccessWeather(String response) {

        try {
            JSONObject jsonObject = new JSONObject(response);

            return jsonObject.has("weather");
        } catch (Exception e) {
            e.printStackTrace();
        }
        return false;
    }

    public static String getErrorCode(Activity activity, String response) {

        try {
            JSONObject jsonObject = new JSONObject(response);
            return jsonObject.getString("message");

        } catch (Exception e) {
            Functions.SaveCrash(e, activity);
        }
        return activity.getResources().getString(R.string.error_no_data);
    }

    public static Bitmap decodeFile(File f) {
        Bitmap b = null;
        try {
            // Decode image size
            BitmapFactory.Options o = new BitmapFactory.Options();
            o.inJustDecodeBounds = true;

            FileInputStream fis = new FileInputStream(f);
            BitmapFactory.decodeStream(fis, null, o);
            fis.close();
            int IMAGE_MAX_SIZE = 1000;
            int scale = 1;
            if (o.outHeight > IMAGE_MAX_SIZE || o.outWidth > IMAGE_MAX_SIZE) {
                scale = (int) Math.pow(
                        2,
                        (int) Math.round(Math.log(IMAGE_MAX_SIZE
                                / (double) Math.max(o.outHeight, o.outWidth))
                                / Math.log(0.5)));
            }

            // Decode with inSampleSize
            BitmapFactory.Options o2 = new BitmapFactory.Options();
            o2.inSampleSize = scale;
            fis = new FileInputStream(f);
            b = BitmapFactory.decodeStream(fis, null, o2);
            fis.close();
        } catch (IOException e) {
            e.printStackTrace();
        }
        return b;
    }

    public static boolean checkPermissionForReadExtertalStorage(Activity activity) {
        if (Build.VERSION.SDK_INT >= Build.VERSION_CODES.M) {
            int result = activity.checkSelfPermission(Manifest.permission.READ_EXTERNAL_STORAGE);
            return result == PackageManager.PERMISSION_GRANTED;
        }
        try {
            ActivityCompat.requestPermissions(activity, new String[]{Manifest.permission.WRITE_EXTERNAL_STORAGE}, 2);
        } catch (Exception e) {
            Functions.SaveCrash(e, activity);
        }
        return false;
    }
}
