package construction.site.logistics.foreman.Fragments;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.Gravity;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.core.view.GravityCompat;
import androidx.drawerlayout.widget.DrawerLayout;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.fragment.app.FragmentManager;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.List;

import construction.site.logistics.foreman.FragmentDialogs.NFCReadFragment;
import construction.site.logistics.foreman.FragmentDialogs.NFCWriteFragment;
import construction.site.logistics.foreman.MainActivity;
import construction.site.logistics.foreman.Network.HttpRequestHandler;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.adapters.WorkersCardFile;
import construction.site.logistics.foreman.data.LoadedRecord;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.state;
import construction.site.logistics.foreman.login.LoginActivity;

import static construction.site.logistics.foreman.MainActivity.drawer;
import static construction.site.logistics.foreman.MainActivity.isDialogDisplayed;


public class FragmentLogAttendance extends Fragment {

    static private RecyclerView list;
    private Button startRegister, viewWorkerCardRecords,startQrCode;
    private NFCWriteFragment mNfcWriteFragment;
    private NFCReadFragment mNfcReadFragment;
    static private Boolean messagesViewed=false;
    static private Activity activity;
    static private FragmentActivity fragmentActivity;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }

    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        //
        startRegister.setOnClickListener(v -> showWriteFragment());
        viewWorkerCardRecords.setOnClickListener(v -> showReadFragment());
        activity= getActivity();
        fragmentActivity=getActivity();
        startQrCode.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Fragment fragment = new FragmentQRcodeView();
                FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                fragmentManager.beginTransaction()
                        .replace(R.id.content_frame, fragment)
                        .addToBackStack(null)
                        .commit();
                fragmentManager.executePendingTransactions();
            }
        });

        MainActivity.toolbar.setNavigationOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                Integer DrawerState = drawer.getDrawerLockMode( GravityCompat.START);
                if(state.getGarbage()[1].equals("attendance") && DrawerState.equals(DrawerLayout.LOCK_MODE_LOCKED_CLOSED)){
                    Functions.alertbox(getResources().getString(R.string.fragment_log_attendance_title),getResources().getString(R.string.fragment_nfc_pass_card_title) + ", "+System.getProperty("line.separator")+ state.foremanName, getActivity());
                }else if(DrawerState.equals(DrawerLayout.LOCK_MODE_UNLOCKED)){
                    if(drawer.isDrawerOpen(GravityCompat.START)){
                        drawer.openDrawer(GravityCompat.END);

                    }else {
                        drawer.openDrawer(GravityCompat.START);
                    }
                }

            }
        });
    }

    private void showWriteFragment() {
        MainActivity.isWrite = true;
        messagesViewed=false;
        mNfcWriteFragment = (NFCWriteFragment) getActivity().getSupportFragmentManager().findFragmentByTag(NFCWriteFragment.TAG);
        if (mNfcWriteFragment == null) {
            mNfcWriteFragment = NFCWriteFragment.newInstance();
        }
        mNfcWriteFragment.show(getActivity().getSupportFragmentManager(),NFCWriteFragment.TAG);

    }

    private void showReadFragment() {
        mNfcReadFragment = (NFCReadFragment) getActivity().getSupportFragmentManager().findFragmentByTag(NFCReadFragment.TAG);
        if (mNfcReadFragment == null) {
            mNfcReadFragment = NFCReadFragment.newInstance();
        }

        mNfcReadFragment.show(getActivity().getSupportFragmentManager(),NFCReadFragment.TAG);
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_attendance_register, container, false);
        list = v.findViewById(R.id.log_attendance_worker_list);
        startRegister=v.findViewById(R.id.log_attendance_start_register );
        viewWorkerCardRecords=v.findViewById(R.id.log_attendance_view_card_records);
        startQrCode=v.findViewById(R.id.log_attendance_use_qrcode);
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();
        Functions.checkLocation(getActivity());

        if(state.UUID.equals("")){
            Intent intent = new Intent(getActivity(), LoginActivity.class);
            getActivity().startActivity(intent);
        }
        getActivity().setTitle(getResources().getString(R.string.fragment_log_attendance_title));
        LoadAttendanceRecord();

    }

    @Override
    public void onPause() {
        super.onPause();
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        super.onActivityResult(requestCode, resultCode, data);
    }

    @SuppressLint("StaticFieldLeak")
    static public void LoadAttendanceRecord(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( activity.getResources().getString(R.string.fragment_log_attendance_title));
        queue.setDescription( activity.getResources().getString(R.string.fragment_log_attendance_description));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("2");
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
        field.setRequestVar("language");
        field.setValue(state.getCurrentLanguage());
        fields.add(field);

        SendData sendData = new SendData(activity, fragmentActivity);
        sendData.addQueue(queue);
        sendData.addFields(fields);
        sendData.setEncryption(true, "AES128");
        sendData.setWaitForCode(true);
        sendData.setloadMainPage(false);
        sendData.setEnableQueue(false);
        sendData.send();
        String response= sendData.getResponse();
        if (Functions.isSuccess(response)) {
            ArrayList<LoadedRecord> recordList = getInfo(response);
            WorkersCardFile workersCardFileAdapter = new WorkersCardFile(activity, recordList, false);
            list.setAdapter(workersCardFileAdapter);
            list.setLayoutManager(new LinearLayoutManager(activity.getApplicationContext(), RecyclerView.VERTICAL, false));
        }else {
            if(state.getGarbage()[1].equals("attendance") && messagesViewed.equals(false)){
                messagesViewed=true;
                state.setGarbage("true",3);
                drawer.setDrawerLockMode(DrawerLayout.LOCK_MODE_LOCKED_CLOSED);
                Functions.alertbox(activity.getResources().getString(R.string.fragment_log_attendance_title),activity.getResources().getString(R.string.fragment_log_attendance_morning_message) + " "+ state.sitename, activity);
            }
            Toast.makeText(activity, Functions.getErrorCode(activity,response), Toast.LENGTH_SHORT).show();
        }
    }

    static public ArrayList<LoadedRecord> getInfo(String response) {
        ArrayList<LoadedRecord> recordList = new ArrayList<>();
        try {
            JSONObject jsonObject = new JSONObject(response);
            if (jsonObject.getString("error").equals("false")) {
                JSONArray dataArray = jsonObject.getJSONArray("data");
                int test=dataArray.length();
                for (int i = 0; i < test; i++) {
                    LoadedRecord record = new LoadedRecord();
                    JSONObject dataobj = dataArray.getJSONObject(i);
                    record.setRecord1(dataobj.getString("name"));
                    if(dataobj.getString("checkin").equals("")){
                        record.setRecord2(activity.getResources().getString(R.string.fragment_log_attendance_no_checkin));
                    }else{
                        record.setRecord2(activity.getResources().getString(R.string.fragment_log_attendance_checkin) +" "+dataobj.getString("checkin"));
                    }
                    if(dataobj.getString("checkout").equals("")){
                        record.setRecord3(activity.getResources().getString(R.string.fragment_log_attendance_no_checkout));
                    }else{
                        record.setRecord3(activity.getResources().getString(R.string.fragment_log_attendance_checkout) +" "+dataobj.getString("checkout"));
                    }
                    if(dataobj.getString("imgURL").equals("")){
                        record.setRecord4(state.HostUrl+"photos/person.png");
                    }else{
                        record.setRecord4(state.HostUrl+"photos/"+dataobj.getString("imgURL"));
                    }
                    recordList.add(record);
                }
            }

        } catch (JSONException e) {
            Functions.SaveCrash(e, activity);
        }
        return recordList;
    }
}

