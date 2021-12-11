package construction.site.logistics.foreman.Fragments;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.res.Resources;
import android.nfc.NfcAdapter;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Spinner;
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

public class FragmentRegieEnd extends Fragment {

    private NfcAdapter mNfcAdapter;
    private RecyclerView list;
    private ImageView save_btn;
    private EditText note;
    private Spinner spinnerHora;
    private ArrayList <String> NotesArrayList;
    private String serverData="";
    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActivity().setTitle(getResources().getString(R.string.fragment_regie_end_title));
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }


    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        mNfcAdapter = NfcAdapter.getDefaultAdapter(getActivity());
        state.ReadSmartCardID="";
        save_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (state.isDemonstrationEnabled){
                    return;
                }

                if(spinnerHora != null && spinnerHora.getSelectedItem() !=null ) {
                    String test="";
                    AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
                    builder.setMessage(getActivity().getResources().getString(R.string.fragment_regie_end_confirm_msg)+" " + spinnerHora.getSelectedItem().toString())
                            .setCancelable(false)
                            .setTitle(getActivity().getResources().getString(R.string.alertbox_title_confirm))
                            .setPositiveButton(getActivity().getResources().getString(R.string.alertbox_continue),
                                    new DialogInterface.OnClickListener() {
                                        public void onClick(DialogInterface dialog, int id) {
                                            ProcessRequest();
                                        }
                                    })
                            .setNegativeButton(getActivity().getResources().getString(R.string.alertbox_cancel),
                                    new DialogInterface.OnClickListener() {
                                        public void onClick(DialogInterface dialog, int id) {
                                            dialog.cancel();
                                        }
                                    });
                    AlertDialog alert = builder.create();
                    alert.show();
                }else{
                    Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice),getActivity().getResources().getString(R.string.fragment_regie_end_select_regie), getActivity());
                }

            }
        });
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_regie_end, container, false);
        list = v.findViewById(R.id.fragment_regie_end_list);
        save_btn = v.findViewById(R.id.fragment_regie_end_save_btn);
        note = v.findViewById(R.id.fragment_regie_end_notes);
        spinnerHora = v.findViewById(R.id.fragment_regie_end_spinner_hora);

        return v;
    }

    @Override
    public void onResume() {
        super.onResume();
        Functions.checkLocation(getActivity());

        if(state.UUID.equals("")){
            Intent intent = new Intent(getActivity(), LoginActivity.class);
            getActivity().startActivity(intent);
        }else if (getActivity()!=null){
            LoadRegieRecord();
        }
    }

    @Override
    public void onPause() {
        super.onPause();
    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        //super.onActivityResult(requestCode, resultCode, data);

        if (requestCode == 1003) {
            if(resultCode == MainActivity.RESULT_OK){
                Functions.removeSimpleProgressDialog();
                ProcessRequest();

            }
        }
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
    }

    @SuppressLint("StaticFieldLeak")
    public void ProcessRequest(){

        if(state.ReadSmartCardID.equals("")) {
            Functions.showSimpleProgressDialog(getActivity(), getActivity().getResources().getString(R.string.fragment_regie_start_present_card_title), getActivity().getResources().getString(R.string.fragment_regie_start_present_card_message), false);
        }else if(spinnerHora != null && spinnerHora.getSelectedItem() !=null ) {
            EntityQueue queue= new EntityQueue();
            queue.setMsgType("alertbox");
            queue.setMsgSuccess("response");
            queue.setMsgError("response");
            queue.setUrl(state.HostUrl + "api/index.php");
            queue.setTitle( getResources().getString(R.string.fragment_regie_end_title));
            queue.setDescription( getResources().getString(R.string.fragment_regie_end_description));

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
            field.setValue("close");
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("gest");
            field.setValue(state.ReadSmartCardID);
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("hour");
            field.setValue(spinnerHora.getSelectedItem().toString());
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("notas");
            field.setValue(note.getText().toString());
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
        } else{
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice),getActivity().getResources().getString(R.string.fragment_regie_end_select_regie), getActivity());
        }
    }

    @SuppressLint("StaticFieldLeak")
    private void LoadRegieRecord(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_regie_end_title));
        queue.setDescription( getResources().getString(R.string.fragment_regie_end_description));

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
        field.setValue("list");
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
            serverData = response;
            ArrayList <String> HoraArrayList = LoadData(response);
            ArrayAdapter<String> dataAdapterWhere = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_spinner_item, HoraArrayList);
            dataAdapterWhere.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
            spinnerHora.setAdapter(dataAdapterWhere);
            spinnerHora.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                @Override
                public void onItemSelected(AdapterView<?> parentView, View selectedItemView, int position, long id) {
                    // your code here
                    if (spinnerHora.getSelectedItemId() != AdapterView.INVALID_ROW_ID) {
                        LoadWorkersRegieList((int) spinnerHora.getSelectedItemId());
                        note.setText(NotesArrayList.get((int) spinnerHora.getSelectedItemId()));
                    }
                }

                @Override
                public void onNothingSelected(AdapterView<?> parentView) {
                    // your code here
                }

            });
            LoadWorkersRegieList(0);
        }else {
            Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
        }
    }

    public ArrayList<String> LoadData(String response) {
        ArrayList<String> recordList = new ArrayList<>();
        try {
            JSONObject jsonObject = new JSONObject(response);
            NotesArrayList= new ArrayList<String>();
            if (jsonObject.getString("error").equals("false")) {
                JSONArray dataArray = jsonObject.getJSONArray("data");
                int test=dataArray.length();
                for (int i = 0; i < test; i++) {
                    JSONObject dataobj = dataArray.getJSONObject(i);
                    recordList.add(dataobj.getString("hora"));
                    NotesArrayList.add(dataobj.getString("notas"));
                }
            }

        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
        }

        return recordList;
    }

    protected void LoadWorkersRegieList(int pos) {
        ArrayList<LoadedRecord> RecordArrayList = new ArrayList<>();
        try {
            JSONObject jsonObject = new JSONObject(serverData);
            if (jsonObject.getString("error").equals("false")) {

                JSONArray dataArray = jsonObject.getJSONArray("data");
                JSONObject dataobj = dataArray.getJSONObject(pos);
                JSONArray WorkersArray = dataobj.getJSONArray("workers");
                int test = WorkersArray.length();

                for (int i = 0; i < test; i++) {
                    LoadedRecord playersModel = new LoadedRecord();
                    dataobj = WorkersArray.getJSONObject(i);

                    playersModel.setRecord1(dataobj.getString("name"));
                    playersModel.setRecord5(dataobj.getString("coduser"));
                    if (dataobj.getString("imgURL").equals("")) {
                        playersModel.setRecord4(state.HostUrl + "photos/person.png");
                    } else {
                        playersModel.setRecord4(state.HostUrl + "photos/" + dataobj.getString("imgURL"));
                    }
                    RecordArrayList.add(playersModel);
                }
            }

        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
        }
        WorkersCardFile workersCardFileAdapter = new WorkersCardFile(getActivity(), RecordArrayList, false);
        list.setAdapter(workersCardFileAdapter);
        list.setLayoutManager(new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL, false));
    }
}
