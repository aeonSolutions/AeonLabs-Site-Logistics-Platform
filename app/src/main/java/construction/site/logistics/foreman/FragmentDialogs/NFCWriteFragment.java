package construction.site.logistics.foreman.FragmentDialogs;

import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.nfc.FormatException;
import android.nfc.NdefMessage;
import android.nfc.NdefRecord;
import android.nfc.NfcAdapter;
import android.nfc.Tag;
import android.nfc.TagLostException;
import android.nfc.tech.Ndef;
import android.nfc.tech.NdefFormatable;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.drawerlayout.widget.DrawerLayout;
import androidx.fragment.app.DialogFragment;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;
import java.nio.charset.Charset;
import java.nio.charset.StandardCharsets;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

import construction.site.logistics.foreman.Encryption.Encryption;
import construction.site.logistics.foreman.Fragments.FragmentLogAttendance;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.abstraction.Listener;
import construction.site.logistics.foreman.MainActivity;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.state;

import static construction.site.logistics.foreman.Fragments.FragmentLogAttendance.LoadAttendanceRecord;

public class NFCWriteFragment extends DialogFragment {
    
    public static final String TAG = NFCWriteFragment.class.getSimpleName();



    public static NFCWriteFragment newInstance() { // This section create Main role .
        NFCWriteFragment  dialog = new NFCWriteFragment ();
        dialog.setCancelable(false); // Add this
        return dialog;
    }

    private class NFCdata{
        public String ReadSmartCardAuthenticationString="";
        public String ReadSmartCardDataString="";
        public String ReadSmartCardFullMessageString="";
        public String ReadSmartCardID="";
    }

    private class attendanceData{
        public String checkin="";
        public String checkout="";
        public String CardDataToWrite="";
        public String name="";
    }

    private TextView mTvMessage, title;
    private ProgressBar mProgress;
    private Listener mListener;
    private ImageView logo;
    private NFCdata nfcData;
    private Button closeBtn;
    private attendanceData attendanceRecord;
    private String ErrorMessage="";
    private Boolean tagIsWritable=false;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View view = inflater.inflate(R.layout.fragment_attendance_nfc_write,container,false);
        initViews(view);
        getDialog().setCancelable(false);
        getDialog().setCanceledOnTouchOutside(false);
        return view;
    }

    private void initViews(View view) {
        title = view.findViewById(R.id.fragment_nfc_write_title);
        mTvMessage = view.findViewById(R.id.fragment_nfc_write_message);
        mProgress = view.findViewById(R.id.fragment_nfc_write_progress);
        logo = view.findViewById(R.id.fragment_nfc_write_logo);
        closeBtn = view.findViewById(R.id.fragment_nfc_write_closeBtn);
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        state.NFCState=0; // begin read
        title.setText(getActivity().getResources().getString(R.string.fragment_nfc_pass_card_title));
        mTvMessage.setText("");
        mProgress.setProgress(0);
        mProgress.setVisibility(View.VISIBLE);
        logo.setImageResource(R.drawable.nfc_vector);
        closeBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                state.NFCState=-1; // nothing to do
                dismiss();
            }
        });
        closeBtn.setVisibility(View.GONE);
        state.clearNFCdata();
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        mListener = (MainActivity) context;
        mListener.onDialogDisplayed();
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener.onDialogDismissed();
        state.NFCState=-1; // nothing to do
    }

    public void onNfcDetected(Ndef ndef){

        mProgress.setVisibility(View.VISIBLE);

        if (state.NFCState.equals(0)){
            logo.setImageResource(R.drawable.nfc_vector);
            title.setText(getActivity().getResources().getString(R.string.fragment_nfc_pass_card_title));
            mProgress.setProgress(0);
            title.setText(getActivity().getResources().getString(R.string.fragment_nfc_pass_card_title));
            mTvMessage.setText("");
            Boolean result=false;

            //read card
            Boolean readResult = readFromNFC(ndef);
            if (!readResult && state.ReadSmartCardID.equals("")){ // error readin card
                logo.setImageResource(R.drawable.nfc_vector);
                title.setText(getActivity().getResources().getString(R.string.fragment_nfc_pass_card_title));
                mProgress.setProgress(0);
                mTvMessage.setText(getActivity().getResources().getString(R.string.nfc_message_read_error)+". "+getActivity().getResources().getString(R.string.nfc_message_try_again));
                mTvMessage.setVisibility(View.VISIBLE);
                closeBtn.setVisibility(View.VISIBLE);
                return;
            } else if(readResult && !state.ReadSmartCardID.equals("")) { // card has auth string and a valid ID
                ErrorMessage="";
                Integer result_i =getMessageKeys();
                if (result_i.equals(0)){
                    logo.setImageResource(R.drawable.nfc_vector);
                    title.setText(getActivity().getResources().getString(R.string.fragment_nfc_pass_card_title));
                    mProgress.setProgress(0);
                    mTvMessage.setText(getActivity().getResources().getString(R.string.nfc_message_read_auth_error));
                    closeBtn.setVisibility(View.VISIBLE);
                    return;
                }else if(result_i.equals(2)){// create new card auth
                    mTvMessage.setText(getActivity().getResources().getString(R.string.nfc_message_initialize_new_card));
                    title.setText(getActivity().getResources().getString(R.string.commServer_connect_msg));
                    mProgress.setProgress(25);
                    logo.setImageResource(R.drawable.cloud_servers);
                    result= requestNewCardAuthCode(); // returns value on state.ReadSmartCardAuthenticationString
                    if(!result){
                        logo.setImageResource(R.drawable.nfc_vector);
                        title.setText(getActivity().getResources().getString(R.string.fragment_nfc_pass_card_title));
                        mProgress.setProgress(0);
                        mTvMessage.setText(getActivity().getResources().getString(R.string.nfc_message_read_error)+". "+getActivity().getResources().getString(R.string.nfc_message_try_again));
                        closeBtn.setVisibility(View.VISIBLE);
                        return;
                    }
                }
            }
            title.setText(getActivity().getResources().getString(R.string.commServer_connect_msg));
            mTvMessage.setText(getActivity().getResources().getString(R.string.commServer_connect_title_msg));
            mProgress.setProgress(25);
            logo.setImageResource(R.drawable.cloud_servers);

            result=false;
            ErrorMessage="";
            if (state.getCurrentNavItem() == R.id.nav_attendance_log_extra || state.getCurrentNavItem() == R.id.nav_attendance_log_end_day) {
                result=sendAtttendanceRequest();
            } else if (state.CurrentNavItem == R.id.nav_regie_add) {

            } else if (state.CurrentNavItem == R.id.nav_regie_end) {

            } else if (state.CurrentNavItem == R.id.nav_occurrences_add) {

            }

            if (!result){ // error from server
                AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
                builder.setMessage(ErrorMessage+". "+getActivity().getResources().getString(R.string.alertbox_question_retry))
                        .setCancelable(false)
                        .setTitle(getActivity().getResources().getString(R.string.alertbox_title_question))
                        .setPositiveButton(getActivity().getResources().getString(R.string.alertbox_yes),
                                new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialog, int id) {
                                        dialog.cancel();
                                        state.NFCState=0; // begin read
                                        title.setText(getActivity().getResources().getString(R.string.fragment_nfc_pass_card_title));
                                        mTvMessage.setText("");
                                        mProgress.setProgress(0);
                                        logo.setImageResource(R.drawable.nfc_vector);
                                        return;
                                    }
                                })
                        .setNegativeButton(getActivity().getResources().getString(R.string.alertbox_cancel),
                                new DialogInterface.OnClickListener() {
                                    public void onClick(DialogInterface dialog, int id) {
                                        state.NFCState=-1; // begin read
                                        dialog.cancel();
                                        dismiss();
                                        return;
                                    }
                                });

                        AlertDialog alert = builder.create();
                alert.show();
            }else if(tagIsWritable){
                nfcData= new NFCdata();
                nfcData.ReadSmartCardAuthenticationString=state.ReadSmartCardAuthenticationString;
                nfcData.ReadSmartCardDataString = state.ReadSmartCardDataString;
                nfcData.ReadSmartCardFullMessageString =state.ReadSmartCardFullMessageString;
                nfcData.ReadSmartCardID=state.ReadSmartCardID;

                title.setText(attendanceRecord.name+System.getProperty("line.separator")+getActivity().getResources().getString(R.string.fragment_nfc_pass_card_again_title));
                String txt= new StringBuilder(state.ReadSmartCardID).reverse().toString();
                txt=txt.replaceAll("(.{3})", "$1 ");
                txt=new StringBuilder(txt).reverse().toString();
                mTvMessage.setText(txt);
                mProgress.setProgress(50);
                logo.setImageResource(R.drawable.nfc_vector);
                state.NFCState=2; // ready to write data on SmartCard
            }else{
                mTvMessage.setText(attendanceRecord.name+System.getProperty("line.separator")+getActivity().getResources().getString(R.string.fragment_log_attendance_checkin)+" "+attendanceRecord.checkin+"       "+getActivity().getResources().getString(R.string.fragment_log_attendance_checkout)+" "+attendanceRecord.checkout+System.getProperty("line.separator")+getActivity().getResources().getString(R.string.nfc_message_card_not_writeable));
                closeBtn.setVisibility(View.VISIBLE);
                mProgress.setVisibility(View.GONE);
                state.NFCState=-1;
                return;
            }
        }else if (state.NFCState.equals(2)){//  write data on SmartCard
            mProgress.setProgress(75);
            //save data

            Boolean readResult = readFromNFC(ndef);

            if(nfcData.ReadSmartCardID.equals(state.ReadSmartCardID) && readResult && !nfcData.ReadSmartCardID.equals("") && !state.ReadSmartCardID.equals("")){
                Boolean prepareDataresult=false;
                if (state.CurrentNavItem == R.id.nav_attendance_log_extra || state.CurrentNavItem == R.id.nav_attendance_log_end_day) {
                     prepareDataresult= saveNewNfcDataAttendance();
                } else if (state.CurrentNavItem == R.id.nav_regie_add) {
                     prepareDataresult=loadNewNfcDataRegie("start");
                } else if (state.CurrentNavItem == R.id.nav_regie_end) {
                     prepareDataresult=loadNewNfcDataRegie("end");
                } else if (state.CurrentNavItem == R.id.nav_occurrences_add) {
                     prepareDataresult=loadNewNfcDataOccurrence();
                }
                //append AUTH string at begining
                attendanceRecord.CardDataToWrite=nfcData.ReadSmartCardAuthenticationString+attendanceRecord.CardDataToWrite;

                if(prepareDataresult){
                    Boolean writeResult =writeTag(ndef,attendanceRecord.CardDataToWrite);
                    if (!writeResult){
                        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
                        builder.setMessage(ErrorMessage+". "+getActivity().getResources().getString(R.string.alertbox_question_retry))
                                .setCancelable(false)
                                .setTitle(getActivity().getResources().getString(R.string.alertbox_title_question))
                                .setPositiveButton(getActivity().getResources().getString(R.string.alertbox_yes),
                                        new DialogInterface.OnClickListener() {
                                            public void onClick(DialogInterface dialog, int id) {
                                                dialog.cancel();
                                                state.NFCState=2; // begin read
                                                title.setText(getActivity().getResources().getString(R.string.fragment_nfc_pass_card_title));
                                                mTvMessage.setText("");
                                                mProgress.setProgress(0);
                                                logo.setImageResource(R.drawable.nfc_vector);
                                                return;
                                            }
                                        })
                                .setNegativeButton(getActivity().getResources().getString(R.string.alertbox_cancel),
                                        new DialogInterface.OnClickListener() {
                                            public void onClick(DialogInterface dialog, int id) {
                                                state.NFCState=-1; // begin read
                                                dialog.cancel();
                                                dismiss();
                                                return;
                                            }
                                        });

                        AlertDialog alert = builder.create();
                        alert.show();

                        return;
                    }else{
                        mTvMessage.setText(getActivity().getResources().getString(R.string.fragment_log_attendance_checkin)+" "+attendanceRecord.checkin+"       "+getActivity().getResources().getString(R.string.fragment_log_attendance_checkout)+" "+attendanceRecord.checkout);
                        closeBtn.setVisibility(View.VISIBLE);
                        mProgress.setVisibility(View.GONE);
                        state.NFCState=-1;
                        return;

                    }
                }else{
                    mTvMessage.setText(getActivity().getResources().getString(R.string.nfc_message_write_error));
                    closeBtn.setVisibility(View.VISIBLE);
                    mProgress.setVisibility(View.GONE);
                    return;
                }
            } else{
                mTvMessage.setText(getActivity().getResources().getString(R.string.nfc_message_write_error));
                closeBtn.setVisibility(View.VISIBLE);
                mProgress.setVisibility(View.GONE);
                return;
            }
        }
    }

    private Boolean readFromNFC(Ndef ndef) {
        state.ReadSmartCardFullMessageString="";
        if (ndef == null) {
            return false;
        }
        try {
            ndef.connect();

            Tag tag = ndef.getTag();
            byte[] extraID = tag.getId();
            tagIsWritable = ndef.isWritable();
            StringBuilder sb = new StringBuilder();
            for (byte b : extraID) {
                sb.append(String.format("%02X", b));
            }
            String hexdump = "";
            hexdump = sb.toString();
            long uuid = Long.parseLong(hexdump, 16);
            state.ReadSmartCardID = String.valueOf(uuid);
            state.smartCardMemorySize=ndef.getMaxSize();
            Integer s=  state.smartCardMemorySize;
            NdefMessage ndefMessage = ndef.getNdefMessage();
            state.ReadSmartCardFullMessageString= new String(ndefMessage.getRecords()[0].getPayload());
            ndef.close();

        } catch (Exception e) {
            e.printStackTrace();
            return false;
        }
        return true;

    }

    public boolean writeTag( Ndef ndef, String data) {
        // Record to launch Play Store if app is not installed
        NdefRecord appRecord = NdefRecord.createApplicationRecord(getActivity().getPackageName());

        // Record with actual data we care about
        NdefRecord relayRecord = new NdefRecord(NdefRecord.TNF_MIME_MEDIA,
                ("application/" + getActivity().getPackageName())
                        .getBytes(StandardCharsets.UTF_8),
                null, data.getBytes());

        // Complete NDEF message with both records
        NdefMessage message = new NdefMessage(new NdefRecord[] {relayRecord, appRecord});

        // If the tag is already formatted, just write the message to it
        if(ndef != null) {
            try {
                ndef.connect();
                // Make sure the tag is writable
                if(!ndef.isWritable()) {
                    ErrorMessage= getString(R.string.nfcReadOnlyError);
                    ndef.close();
                    return false;
                }
                // Check if there's enough space on the tag for the message
                int size = message.toByteArray().length;
                if(ndef.getMaxSize() < size) {
                    ErrorMessage=  getString(R.string.nfcBadSpaceError);
                    ndef.close();
                    return false;
                }
                // Write the data to the tag
                ndef.writeNdefMessage(message);
                ndef.close();
                return true;
            } catch (TagLostException tle) {
                ErrorMessage= getString(R.string.nfcTagLostError);
            } catch (IOException ioe) {
                ErrorMessage= getString( R.string.nfcFormattingError);
            } catch (FormatException fe) {
                ErrorMessage= getString( R.string.nfcFormattingError);
            } catch(Exception e) {
                ErrorMessage= getString( R.string.nfcUnknownError);
            }
        }
        return false;
    }

    private Integer getMessageKeys(){
        // first 16 bytes are the encrypted Auth string
        if (!state.ReadSmartCardFullMessageString.equals("") && state.ReadSmartCardFullMessageString.length()>15){
            if(state.ReadSmartCardFullMessageString.substring(0,16).contains(" ")){
                return 2; // create new card;
            }else{
                state.ReadSmartCardAuthenticationString=state.ReadSmartCardFullMessageString.substring(0,16);
                Integer s=state.ReadSmartCardFullMessageString.length();
                Integer ss= s-16;
                if((state.ReadSmartCardFullMessageString.length()-16) % 7==0){
                    state.ReadSmartCardDataString=state.ReadSmartCardFullMessageString.substring(16);
                        return 1;// OK
                }else{
                    return 0;// Data corrupted contact Office
                }
            }
        }else{
            return 2; // create new card;
        }
    }
    private Boolean requestNewCardAuthCode(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getActivity().getResources().getString(R.string.nfc_message_tag_detected));
        queue.setDescription( getActivity().getResources().getString(R.string.nfc_message_tag_detected));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("19");
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("sn");
        field.setValue(state.UUID);
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("worker");
        field.setValue(state.ReadSmartCardID);
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("language");
        field.setValue(state.getCurrentLanguage());
        fields.add(field);

        SendData sendData = new SendData(getActivity(), getActivity());
        sendData.addQueue(queue);
        sendData.addFields(fields);
        sendData.setEncryption(true, "AES128");
        sendData.setWaitForCode(true);
        sendData.setloadMainPage(false);
        sendData.setEnableQueue(true);
        sendData.send();
        String authKey=sendData.getResponse();
        if(authKey.length()==16){
            state.ReadSmartCardAuthenticationString=authKey;
            return true;
        }else{
            state.ReadSmartCardAuthenticationString="";
            return false;
        }
    }

    private Boolean saveNewNfcDataAttendance(){
        /**
         * worker card data structure
         * date(ymmdd), time(hhmm), time(hhmm)
         */
        Date todayDate = Calendar.getInstance().getTime();
        SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd");
        String todayDateStr = df.format(todayDate);
        Boolean recordAdded = false;
        String[] entriesTmp;
        String checkin="";
        String checkout="";
        List<String> entries= new ArrayList <String>();

        if(isTime(attendanceRecord.checkin)){
            checkin=attendanceRecord.checkin;
        }else{
            checkin="00:00";
        }
        if(isTime(attendanceRecord.checkout)){
            checkout=attendanceRecord.checkout;
        }else{
            checkout="00:00";
        }

        if(nfcData.ReadSmartCardDataString.length()>=7 && nfcData.ReadSmartCardDataString.length() % 7 == 0) {
            //check space and delete oldest entry
            if (nfcData.ReadSmartCardDataString.length() + 16 + 7 > state.smartCardMemorySize) { //delete oldest record POSSIBLE BUG ON MEMORY SIZE DIFFENTE CARDS
                entriesTmp = nfcData.ReadSmartCardDataString.split("(?<=\\G.{7})");
                String[] tmpArr = new String[entriesTmp.length - 1];
                for (int i = 1; i < entriesTmp.length; i++) {
                    entries.add(entriesTmp[i]);
                }

            }

            //check if it already has a today entry
            for (int i = 0; i < entries.size(); i++) {
                String date = entries.get(i).substring(0, 3);
                String tmp = "202" + date.charAt(0);
                if ((int) date.charAt(1) - 48 < 10) {
                    tmp += "-0" + ((int) date.charAt(1) - 48);
                } else {
                    tmp += "-" + ((int) date.charAt(1) - 48);
                }
                if ((int) date.charAt(2) - 48 < 10) {
                    tmp += "-0" + ((int) date.charAt(2) - 48);
                } else {
                    tmp += "-" + ((int) date.charAt(2) - 48);
                }
                date = tmp;
                if (date.equals(todayDateStr)) {
                    entries.set(i,compress("date", todayDateStr) + compress("time", checkin) + compress("time", checkout));
                    recordAdded = true;
                    break;
                }
            }
            if (!recordAdded) {
                entries.add(compress("date", todayDateStr) + compress("time", checkin) + compress("time", checkout));
            }
            for (int i = 0; i < entries.size(); i++) {
                attendanceRecord.CardDataToWrite+=entries.get(i);
            }
            return true;
        }else if(state.ReadSmartCardDataString.equals("")){
            attendanceRecord.CardDataToWrite =compress("date", todayDateStr) + compress("time", checkin) + compress("time", checkout);
            attendanceRecord.CardDataToWrite=attendanceRecord.CardDataToWrite;
            return true;
        }else if((nfcData.ReadSmartCardDataString.length()>=7 && !(nfcData.ReadSmartCardDataString.length() % 7 == 0)) || nfcData.ReadSmartCardDataString.length()<7) { // invalid data lenght found
            attendanceRecord.CardDataToWrite="";
            return false;
        }else{
            attendanceRecord.CardDataToWrite="";
            return false;
        }

    }

    private Boolean loadNewNfcDataRegie(String type){
        return false;

    }
    private Boolean loadNewNfcDataOccurrence(){

        return false;
    }

    private Boolean isTime(String string){
        Pattern p = Pattern.compile(".*([01]?[0-9]|2[0-3]):[0-5][0-9].*");
        Matcher m = p.matcher(string);
        return m.matches();
    }

    private String compress(String type, String record){
        String output="";
        if(type.equals("date")){ // format yyyy-mm-dd
            String year= String.valueOf(record.charAt(3));
            String month= String.valueOf(Character.toChars(48+Integer.parseInt(record.substring(5,7))));
            String day=String.valueOf(Character.toChars(48+Integer.parseInt(record.substring(8,10))));
            output=year +month+day;
            return output;
        }
        if(type.equals("time")){ // format hh:mm
            Integer idx =record.indexOf(":");
            Integer idx2 = record.indexOf(":", idx+1);
            if(idx2.equals(-1)){
                idx2=record.length();
            }
            String hours=String.valueOf(Character.toChars(48+Integer.parseInt(record.substring(0,idx))));
            String minutes=String.valueOf(Character.toChars(48+Integer.parseInt(record.substring(idx+1,idx2))));
            output=hours+minutes;
            return output;
        }
        return "";
    }

    private boolean sendAtttendanceRequest(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getActivity().getResources().getString(R.string.fragment_log_attendance_title));
        queue.setDescription( getActivity().getResources().getString(R.string.fragment_log_attendance_description));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("1");
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

        field = new EntityFields();
        field.setRequestVar("worker");
        field.setValue(state.ReadSmartCardID);
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("ssid");
        field.setValue(state.ReadSmartCardAuthenticationString);
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("language");
        field.setValue(state.getCurrentLanguage());
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("logtype");
        field.setValue(state.getGarbage()[9]);
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("logformat");
        field.setValue("NFC card");
        fields.add(field);

        SendData sendData = new SendData(getActivity(), getActivity());
        sendData.addQueue(queue);
        sendData.addFields(fields);
        sendData.setEncryption(true, "AES128");
        sendData.setWaitForCode(true);
        sendData.setloadMainPage(false);
        sendData.setEnableQueue(true);
        sendData.send();
        attendanceRecord= new attendanceData();
        attendanceRecord.checkin="";
        attendanceRecord.checkout="";
        try {
            JSONObject jsonObject = new JSONObject(sendData.getResponse());
            if (jsonObject.getString("error").equals("false")) {
                try {
                    JSONObject responseJson = jsonObject.getJSONObject("data");
                    attendanceRecord.checkin=responseJson.getString("checkin");
                    attendanceRecord.checkout=responseJson.getString("checkout");
                    attendanceRecord.name=responseJson.getString("name");

                    if(state.getGarbage()[1].equals("attendance") && state.UUID.equals(state.ReadSmartCardID) ){
                        MainActivity.drawer.setDrawerLockMode(DrawerLayout.LOCK_MODE_UNLOCKED);
                        state.setGarbage("",1);
                    }
                } catch (Exception e) {
                    Functions.SaveCrash(e, getActivity());
                    ErrorMessage=getActivity().getResources().getString(R.string.error_ivalid_url);
                    return false;
                } finally {
                    LoadAttendanceRecord();
                    return true;
                }
            }else{
                ErrorMessage=Functions.getErrorCode(getActivity(),sendData.getResponse());
                return false;
            }
        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
            ErrorMessage=getActivity().getString(R.string.error_ivalid_data);
            return false;
        }
    }
}

