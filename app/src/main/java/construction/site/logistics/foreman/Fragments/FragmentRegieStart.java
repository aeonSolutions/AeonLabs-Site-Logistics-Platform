package construction.site.logistics.foreman.Fragments;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.nfc.NfcAdapter;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

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

public class FragmentRegieStart extends Fragment {

    private NfcAdapter mNfcAdapter;
    private RecyclerView list;
    private ImageView save_btn;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActivity().setTitle(getResources().getString(R.string.fragment_regie_start_title));
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }
    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        mNfcAdapter = NfcAdapter.getDefaultAdapter(getActivity());

        save_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (state.isDemonstrationEnabled){
                    return;
                }

                ProcessRequest();
            }
        });
        state.ReadSmartCardID="";
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_regie_start, container, false);
        list = v.findViewById(R.id.fragment_regie_start_list);
        save_btn = v.findViewById(R.id.fragment_regie_start_save_btn);

        return v;
    }

    @Override
    public void onResume() {
        super.onResume();
        Functions.checkLocation(getActivity());

        if(state.UUID.equals("")){
            Intent intent = new Intent(getActivity(), LoginActivity.class);
            getActivity().startActivity(intent);
        }else{
            LoadAttendanceRecord();
        }

    }

    @Override
    public void onPause() {
        super.onPause();
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        //super.onActivityResult(requestCode, resultCode, data);

        if (requestCode == 1002) {
            if(resultCode == MainActivity.RESULT_OK){
                Functions.removeSimpleProgressDialog();
                ProcessRequest();
            }
        }
    }

    @SuppressLint("StaticFieldLeak")
    public void ProcessRequest(){
        Boolean selected=false;
        for (LoadedRecord model : WorkersCardFile.recordList) {
            if (model.isSelected()) {
                selected=true;
            }
        }
        if(!selected){
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice),getActivity().getResources().getString(R.string.fragment_regie_start_select_worker),getActivity());
        }else if(state.ReadSmartCardID.equals("")){
            Functions.showSimpleProgressDialog(getActivity(), getActivity().getResources().getString(R.string.fragment_regie_start_present_card_title), getActivity().getResources().getString(R.string.fragment_regie_start_present_card_message), false);
        }else {
            String text="";
            int pos=0;

            for (LoadedRecord model : WorkersCardFile.recordList) {
                if (model.isSelected()) {
                    if (pos==0) {
                        text = model.getRecord5();
                        pos = 1;
                    } else {
                        text += "," + model.getRecord5();
                    }
                }
            }

            EntityQueue queue= new EntityQueue();
            queue.setMsgType("alertbox");
            queue.setMsgSuccess("response");
            queue.setMsgError("response");
            queue.setUrl(state.HostUrl + "api/index.php");
            queue.setTitle( getResources().getString(R.string.fragment_regie_start_title));
            queue.setDescription( getResources().getString(R.string.fragment_regie_start_description));

            ArrayList<EntityFields> fields = new ArrayList<>();
            EntityFields field = new EntityFields();
            field.setRequestVar("task");
            field.setValue("11");
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
            field.setRequestVar("type");
            field.setValue("add");
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("gest");
            field.setValue(state.ReadSmartCardID);
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("workers");
            field.setValue(text);
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
            sendData.setloadMainPage(true);
            sendData.setEnableQueue(true);
            sendData.send();
            state.ReadSmartCardID="";
        }
    }

    @SuppressLint("StaticFieldLeak")
    private void LoadAttendanceRecord(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_regie_start_title));
        queue.setDescription( getResources().getString(R.string.fragment_regie_start_description));

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

        SendData sendData = new SendData(getActivity(), getActivity());
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
            WorkersCardFile workersCardFileAdapter = new WorkersCardFile(getActivity(), recordList, true);
            list.setAdapter(workersCardFileAdapter);
            list.setLayoutManager(new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL, false));
        }else {
            Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
        }
    }



    public ArrayList<LoadedRecord> getInfo(String response) {
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
                    record.setRecord2("");
                    record.setRecord3("");
                    if(dataobj.getString("imgURL").equals("")){
                        record.setRecord4(state.HostUrl+"photos/person.png");
                    }else{
                        record.setRecord4(state.HostUrl+"photos/"+dataobj.getString("imgURL"));
                    }
                    record.setRecord5(dataobj.getString("coduser"));

                    recordList.add(record);
                }
            }

        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
        }
        return recordList;
    }

}
