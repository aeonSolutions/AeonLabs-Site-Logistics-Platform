package construction.site.logistics.foreman.Fragments;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;

import construction.site.logistics.foreman.Network.HttpRequestHandler;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.data.LoadConfig;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.state;


public class FragmentQuantityAdd extends Fragment {

    public String text = "";

    private ImageView calendar;
    private EditText notas, qtd;
    private TextView dateTxt, units;
    private ImageView save_btn;

    ArrayList<HashMap<String, String>> albumList = new ArrayList<HashMap<String, String>>();


    static public List<String> photosListCode= new ArrayList<>();

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {

        if(!state.getGarbage()[0].equals("")) {
            LoadQuantity();
        }else if (!state.getGarbage()[6].equals("")) {
            units.setText(state.getGarbage()[6]);
        }


            state.LoadNewFragment=true;

        save_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (state.isDemonstrationEnabled){
                    return;
                }
                SendData();
            }
        });

        calendar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                state.setGarbage(notas.getText().toString(),1);
                Fragment fragment = new FragmentCalendar();
                FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                fragmentManager.beginTransaction()
                        .replace(R.id.content_frame, fragment)
                        .addToBackStack(null)
                        .commit();
                fragmentManager.executePendingTransactions();
            }
        });


        notas.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    Functions.hideKeyboard(v, getActivity().getApplicationContext());
                }
            }
        });

        qtd.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    Functions.hideKeyboard(v, getActivity().getApplicationContext());
                }
            }
        });

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_quantity_add, container, false);
        notas=v.findViewById(R.id.fragment_quantity_add_notas);
        qtd=v.findViewById(R.id.fragment_quantity_add_qtd);
        units=v.findViewById(R.id.fragment_quantity_add_units);
        save_btn = v.findViewById(R.id.fragment_quantity_add_save_btn);
        calendar = v.findViewById(R.id.fragment_quantity_add_calendar);

        return v;
    }

    @Override
    public void onPause() {
        super.onPause();
    }

    @Override
    public void onResume() {
        super.onResume();
        Functions.checkLocation(getActivity());

        String lang="en";
        String filename = getActivity().getFilesDir() + "/config.xml";
        File file = new File(filename);
        if(file.exists()) {
            //read configuration file
            LoadConfig LoadConfig = new LoadConfig();
            LoadConfig.filename = filename;
            lang = LoadConfig.GetConfigString("language");
        }
        try {
            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
            Date date=sdf.parse(state.date);
            if(lang.equals("pt")){
                sdf = new SimpleDateFormat("dd 'de' MMMM 'de' yyyy");

            }else if(lang.equals("fr")){
                sdf = new SimpleDateFormat("dd MMMM yyyy");
            }else{
                sdf = new SimpleDateFormat("MMMM dd',' yyyy");
            }
            getActivity().setTitle(getResources().getString(R.string.fragment_quantity_add_title) + ", "+sdf.format(date));
        } catch (Exception e) {
            Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
        }
    }


    @SuppressLint("StaticFieldLeak")
    private void LoadQuantity(){
        class UpdateUI implements Runnable {
            private String str;
            private TextView t;
            private EditText e;
            public void setData(TextView _t, EditText _e, String _str) {
                this.str = _str;
                this.t=_t;
                this.e=_e;
            }
            public void run() {
                if(t!=null){
                    t.setText(this.str);
                }
                if(e!=null){
                    e.setText(this.str);
                }            }
        }
        String response="";

        if(!state.getGarbage()[0].equals("-1")) {

            EntityQueue queue= new EntityQueue();
            queue.setMsgType("silent");
            queue.setMsgSuccess("response");
            queue.setMsgError("response");
            queue.setUrl(state.HostUrl + "api/index.php");
            queue.setTitle( getResources().getString(R.string.fragment_quantity_add_title));
            queue.setDescription( getResources().getString(R.string.fragment_quantity_add_description));

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
            field.setRequestVar("cod");
            field.setValue(state.getGarbage()[0]);
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
            response= sendData.getResponse();

            }else{
                response= "new";
            }
        albumList.clear();
        Long tsLong = System.currentTimeMillis()/1000;

        if (Functions.isSuccess(response)) {
            try {
                JSONObject jsonObject = new JSONObject(response);
                JSONObject jsonSubObject = new JSONObject(jsonObject.getString("data"));

                UpdateUI runnable = new UpdateUI();
                runnable.setData(null, notas, jsonSubObject.getString("nota"));
                getActivity().runOnUiThread(runnable);

                runnable = new UpdateUI();
                runnable.setData(units, null, jsonSubObject.getString("units"));
                getActivity().runOnUiThread(runnable);

                runnable = new UpdateUI();
                runnable.setData(null, qtd, jsonSubObject.getString("qtd"));
                getActivity().runOnUiThread(runnable);

                try {
                    state.date=jsonSubObject.getString("data");
                    SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                    Date date=sdf.parse(state.date);
                    sdf = new SimpleDateFormat("dd 'de' MMMM 'de' yyyy");

                    getActivity().setTitle(getResources().getString(R.string.fragment_quantity_add_title) + ", "+sdf.format(date));
                } catch (ParseException e) {
                    Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
                }
            } catch (JSONException e) {
                Functions.SaveCrash(e, getActivity());
            }
        }else if(response.equals("new")) {
            UpdateUI runnable = new UpdateUI();
            runnable.setData(units, null, state.getGarbage()[1]);
            getActivity().runOnUiThread(runnable);
        }else if(!response.equals("new")) {
            Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
        }
    }

    @SuppressLint("StaticFieldLeak")
    private void SendData(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("alertbox");
        queue.setMsgSuccess(getActivity().getResources().getString(R.string.fragment_quantity_add_submit_ok));
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_quantity_add_title));
        queue.setDescription( getResources().getString(R.string.fragment_quantity_add_description));

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
        field.setRequestVar("date");
        field.setValue(state.date);
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("nota");
        field.setValue(notas.getText().toString());
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("qtd");
        field.setValue(qtd.getText().toString());
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("language");
        field.setValue(state.getCurrentLanguage());
        fields.add(field);

        if (!state.getGarbage()[0].equals("")) {
            field = new EntityFields();
            field.setRequestVar("type");
            field.setValue("edit");
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("cod");
            field.setValue(state.getGarbage()[0]);
            fields.add(field);
        }else{
            field = new EntityFields();
            field.setRequestVar("type");
            field.setValue("add");
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("activity");
            field.setValue(state.getGarbage()[2]);
            fields.add(field);
            if (!state.getGarbage()[4].equals("")) {
                field = new EntityFields();
                field.setRequestVar("codcat");
                field.setValue("null");
                fields.add(field);

                field = new EntityFields();
                field.setRequestVar("users");
                field.setValue(state.getGarbage()[4]);
                fields.add(field);
            }else if (!state.getGarbage()[5].equals("")){
                field = new EntityFields();
                field.setRequestVar("users");
                field.setValue("null");
                fields.add(field);

                field = new EntityFields();
                field.setRequestVar("codcat");
                field.setValue(state.getGarbage()[5]);
                fields.add(field);
            }else{
                field = new EntityFields();
                field.setRequestVar("codcat");
                field.setValue("null");
                fields.add(field);

                field = new EntityFields();
                field.setRequestVar("users");
                field.setValue("null");
                fields.add(field);
            }
        }

        SendData sendData = new SendData(getActivity(), getActivity());
        sendData.addQueue(queue);
        sendData.addFields(fields);
        sendData.setEncryption(true, "AES128");
        sendData.setWaitForCode(true);
        sendData.setloadMainPage(true);
        sendData.setEnableQueue(true);
        sendData.send();
    }
}
