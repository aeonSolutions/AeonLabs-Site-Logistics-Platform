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

import java.util.ArrayList;

import construction.site.logistics.foreman.Network.HttpRequestHandler;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.Network.SendRequest;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.abstraction.GalleryMethods;
import construction.site.logistics.foreman.adapters.BordereauAdapter;
import construction.site.logistics.foreman.adapters.OcurrencesAdapter;
import construction.site.logistics.foreman.adapters.QuantityAdapter;
import construction.site.logistics.foreman.data.LoadedRecord;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.state;

public class FragmentQuantityView extends Fragment {
    private RecyclerView list;
    private ArrayList<LoadedRecord> recordArrayList;
    private QuantityAdapter quantityAdapter;
    private ImageView continue_btn;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        getActivity().setTitle(getResources().getString(R.string.fragment_quantity_view_title));

        continue_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (quantityAdapter == null){
                    Functions.alertbox(getResources().getString(R.string.alertbox_title_notice),getResources().getString(R.string.fragment_list_select_one),getActivity());
                    return;
                }
                Boolean selected=false;
                state.clearGarbage();
                for (LoadedRecord model : quantityAdapter.recordArrayList) {
                    if (model.isSelected()) {
                        selected=true;
                        state.setGarbage(model.getRecord2(),0);
                        state.setGarbage(model.getRecord6(),3);
                    }
                }
                if(!selected){
                    Functions.alertbox(getResources().getString(R.string.alertbox_title_notice),getResources().getString(R.string.fragment_list_select_one),getActivity());
                }else {
                    Fragment fragment = new FragmentQuantityAdd();
                    FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                    fragmentManager.beginTransaction()
                            .replace(R.id.content_frame, fragment)
                            .addToBackStack(null)
                            .commit();
                    fragmentManager.executePendingTransactions();
                }
            }
        });
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_quantity_view, container, false);
        list = v.findViewById(R.id.fragment_quantity_view_list);
        continue_btn = v.findViewById(R.id.fragment_quantity_view_save_btn);
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();
        Functions.checkLocation(getActivity());

        state.setGarbage("",0);
        LoadBordereau();

    }



    @SuppressLint("StaticFieldLeak")
    private void LoadBordereau(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_quantity_view_title));
        queue.setDescription( getResources().getString(R.string.fragment_quantity_view_description));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("10");
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
        field.setRequestVar("date");
        field.setValue(state.date);
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
            quantityAdapter = new QuantityAdapter(getActivity(),getInfo(response));
            list.setAdapter(quantityAdapter);
            list.setLayoutManager(new LinearLayoutManager(getActivity(), RecyclerView.VERTICAL, false));
        }else {
            Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
        }
    }

    public ArrayList<LoadedRecord> getInfo(String response) {
        ArrayList<LoadedRecord> recordArrayList = new ArrayList<>();
        LoadedRecord record = new LoadedRecord();
        try {
            JSONObject jsonObject = new JSONObject(response);
            if (jsonObject.getString("error").equals("false")) {
                JSONArray dataArray = jsonObject.getJSONArray("data");
                int test=dataArray.length();
                for (int i = 0; i < test; i++) {
                    record = new LoadedRecord();
                    JSONObject dataobj = dataArray.getJSONObject(i);
                    record.setRecord1(dataobj.getString("activity"));
                    record.setRecord2(dataobj.getString("code"));
                    record.setRecord3(dataobj.getString("qtd"));
                    record.setRecord4(dataobj.getString("workers"));
                    record.setRecord5(dataobj.getString("date"));
                    record.setRecord6(dataobj.getString("units"));

                    recordArrayList.add(record);
                }
            }
        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
        }
        return recordArrayList;
    }
}
