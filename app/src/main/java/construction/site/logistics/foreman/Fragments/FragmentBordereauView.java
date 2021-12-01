package construction.site.logistics.foreman.Fragments;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.Switch;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.math.BigDecimal;
import java.math.MathContext;
import java.math.RoundingMode;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Iterator;
import java.util.Set;

import construction.site.logistics.foreman.Network.HttpRequestHandler;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.Network.SendRequest;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.abstraction.GalleryMethods;
import construction.site.logistics.foreman.adapters.BordereauAdapter;
import construction.site.logistics.foreman.adapters.OcurrencesAdapter;
import construction.site.logistics.foreman.data.LoadedRecord;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.state;

public class FragmentBordereauView extends Fragment {
    private RecyclerView list;
    private ArrayList<LoadedRecord> recordArrayList;
    private BordereauAdapter bordereauAdapter;
    private ImageView continue_btn;
    private Switch swt;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {

        swt.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                LoadBordereau();
            }
        });

        continue_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Boolean selected=false;
                state.setGarbage("",2);
                state.setGarbage("",6);

                for (LoadedRecord model : bordereauAdapter.recordArrayList) {
                    if (model.isSelected()) {
                        selected=true;
                        state.setGarbage(model.getRecord2(),2);
                        state.setGarbage(model.getRecord3(),6);
                    }
                }
                if(!selected){
                    Functions.alertbox(getResources().getString(R.string.alertbox_title_notice),getResources().getString(R.string.fragment_list_select_one),getActivity());
                }else if(state.getGarbage()[2].equals("-1")){
                    AddAvenant();
                }else if (!state.getGarbage()[4].equals("") || !state.getGarbage()[5].equals("")) {
                    Fragment fragment = new FragmentQuantityAdd();
                    FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                    fragmentManager.beginTransaction()
                            .replace(R.id.content_frame, fragment)
                            .addToBackStack(null)
                            .commit();
                    fragmentManager.executePendingTransactions();
                }else{
                    Functions.alertbox(getResources().getString(R.string.alertbox_title_notice),getResources().getString(R.string.fragment_bordereau_view_only_avenant),getActivity());
                }
            }
        });
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_bordereau_view, container, false);
        list = v.findViewById(R.id.fragment_bordereau_view_list);
        continue_btn = v.findViewById(R.id.fragment_bordereau_view_save_btn);
        swt = v.findViewById(R.id.fragment_bordereau_view_data_selector);
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();
        getActivity().setTitle(getResources().getString(R.string.fragment_bordereau_view_title));
        Functions.checkLocation(getActivity());

        state.setGarbage("",2);

        LoadBordereau();

    }


    public void AddAvenant(){
        LayoutInflater linf = LayoutInflater.from(getActivity());
        final View inflator = linf.inflate(R.layout.fragment_bordereau_dialog_add_avenant, null);
        AlertDialog.Builder alert = new AlertDialog.Builder(getActivity());

        alert.setTitle(getResources().getString(R.string.fragment_bordereau_view_new_task));
        alert.setMessage(getResources().getString(R.string.fragment_bordereau_view_new_task_msg));
        alert.setView(inflator);

        final EditText task = inflator.findViewById(R.id.task_dlg_bordereau);
        final Spinner units = inflator.findViewById(R.id.units_dlg_bordereau);

        ArrayList<String> unitsList = new ArrayList<>();
        unitsList.add("ml");
        unitsList.add("m2");
        unitsList.add("m3");
        unitsList.add("Kg");
        unitsList.add("pc");
        ArrayAdapter<String> unitsAdapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_spinner_item, unitsList);
        unitsAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        units.setAdapter(unitsAdapter);

        alert.setPositiveButton(getResources().getString(R.string.button_send), new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int whichButton) {
                dialog.cancel();
                if(!task.getText().toString().equals("")){
                    if (state.isDemonstrationEnabled){
                        return;
                    }

                    sendRequestAvenant(task.getText().toString(),units.getSelectedItem().toString());
                }else{
                    Toast.makeText(getActivity(), getResources().getString(R.string.fragment_bordereau_view_missing_name), Toast.LENGTH_SHORT).show();
                }
            }
        });

        alert.setNegativeButton(getResources().getString(R.string.alertbox_cancel), new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int whichButton) {
                dialog.cancel();
            }
        });

        alert.show();

    }

    @SuppressLint("StaticFieldLeak")
    private void sendRequestAvenant(String task, String units){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("alertbox");
        queue.setMsgSuccess(getActivity().getResources().getString(R.string.fragment_bordereau_view_add_avenant_ok));
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_bordereau_view_title));
        queue.setDescription( getResources().getString(R.string.fragment_bordereau_view_description));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("5");
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
        field.setRequestVar("activity");
        field.setValue(task);
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("units");
        field.setValue(units);
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("language");
        field.setValue(state.getCurrentLanguage());
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("type");
        field.setValue("add");
        fields.add(field);

        SendData sendData = new SendData(getActivity(), getActivity());
        sendData.addQueue(queue);
        sendData.addFields(fields);
        sendData.setEncryption(true, "AES128");
        sendData.setWaitForCode(true);
        sendData.setloadMainPage(false);
        sendData.setEnableQueue(true);
        sendData.send();
        LoadBordereau();
    }


    @SuppressLint("StaticFieldLeak")
    private void LoadBordereau(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_bordereau_view_title));
        queue.setDescription( getResources().getString(R.string.fragment_bordereau_view_description));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("5");
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
        field.setRequestVar("avenant");
        field.setValue("1");
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
            bordereauAdapter = new BordereauAdapter(getActivity(),getInfo(response));
            list.setAdapter(bordereauAdapter);
            list.setLayoutManager(new LinearLayoutManager(getActivity(), RecyclerView.VERTICAL, false));
        }else {
            Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
        }
    }

    public ArrayList<LoadedRecord> getInfo(String response) {
        ArrayList<LoadedRecord> recordArrayList = new ArrayList<>();
        try {
            JSONObject jsonObject = new JSONObject(response);
            if (jsonObject.getString("error").equals("false")) {
                JSONArray dataArray = jsonObject.getJSONArray("data");
                int test=dataArray.length();
                double falta=0.0;
                double feito=0.0;
                for (int i = 0; i < test; i++) {
                    LoadedRecord record = new LoadedRecord();
                    JSONObject dataobj = dataArray.getJSONObject(i);
                    record.setRecord1(dataobj.getString("name"));
                    record.setRecord2(dataobj.getString("code"));
                    record.setRecord3(dataobj.getString("units"));
                    record.setRecord4(dataobj.getString("qtd"));
                    record.setRecord5(dataobj.getString("qtdfalta"));
                    record.setRecord6(dataobj.getString("qtdfeito"));
                    record.setRecord7(dataobj.getString("ref"));
                    record.setRecord8(dataobj.getString("enabled"));

                    if(swt.isChecked()) {
                        try {
                            if(!record.getRecord4().equals("") && !record.getRecord5().equals("") && !record.getRecord6().equals("") ){
                                falta = Double.parseDouble(record.getRecord5()) / Double.parseDouble(record.getRecord4())*100;
                                feito = Double.parseDouble(record.getRecord6())/ Double.parseDouble(record.getRecord4())*100;
                                int roundedFalta = (int) falta;
                                int roundedFeito = (int) feito;
                                record.setRecord5(roundedFalta +"%");
                                record.setRecord6(roundedFeito +"%");
                            }
                        } catch (NumberFormatException e) {
                            // p did not contain a valid double
                        }
                    }
                    recordArrayList.add(record);
                }
            }
        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
        }

        return recordArrayList;
    }
}
