package construction.site.logistics.foreman.Fragments;

import android.annotation.SuppressLint;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.Build;
import android.os.Bundle;
import android.provider.Settings;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.Switch;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;


import com.bumptech.glide.Glide;
import com.bumptech.glide.load.engine.DiskCacheStrategy;
import com.bumptech.glide.request.RequestOptions;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.Observable;
import java.util.Observer;

import construction.site.logistics.foreman.MainActivity;
import construction.site.logistics.foreman.Network.HttpRequestHandler;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.abstraction.Weather;
import construction.site.logistics.foreman.adapters.JournalAdapter;
import construction.site.logistics.foreman.adapters.WorkersCardFile;
import construction.site.logistics.foreman.data.LoadConfig;
import construction.site.logistics.foreman.data.LoadedRecord;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.state;
import construction.site.logistics.foreman.data.stateWeather;

public class FragmentJournal extends Fragment {

    private RecyclerView listworkers, listjournal;
    private Button qtd_btn, regie_btn,bordereau_btn;
    private ImageView calendar, save_btn, weatherIcon;
    private Switch swt, planning;
    private LinearLayout weather;
    private TextView date_txt, weatherTxt, numWorkers;
    private String lang="en";

    public String text = "";
    ArrayList<LoadedRecord> SiteWorkersArrayList;
    ArrayList<LoadedRecord> JournalArrayList;

    private WorkersCardFile workersAdapter;
    private JournalAdapter journalAdapter;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }


    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {

        qtd_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Fragment fragment = new FragmentQuantityView();
                FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                fragmentManager.beginTransaction()
                        .replace(R.id.content_frame, fragment)
                        .addToBackStack(null)
                        .commit();
                fragmentManager.executePendingTransactions();
            }
        });

        regie_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Fragment fragment = new FragmentRegieView();
                FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                fragmentManager.beginTransaction()
                        .replace(R.id.content_frame, fragment)
                        .addToBackStack(null)
                        .commit();
                fragmentManager.executePendingTransactions();
            }
        });

        bordereau_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                state.setCurrentNavItem(R.id.nav_bordereau);
                Fragment fragment = new FragmentBordereauView();
                FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                fragmentManager.beginTransaction()
                        .replace(R.id.content_frame, fragment)
                        .addToBackStack(null)
                        .commit();
                fragmentManager.executePendingTransactions();
            }
        });

        calendar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                state.setGarbage("journalCalendar",0);
                Fragment fragment = new FragmentCalendar();
                FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                fragmentManager.beginTransaction()
                        .replace(R.id.content_frame, fragment)
                        .addToBackStack(null)
                        .commit();
                fragmentManager.executePendingTransactions();
            }
        });

        swt.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(swt.isChecked()){
                    LoadWorkersByCategory();
                }else{
                    LoadWorkers();
                }
            }
        });

        planning.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(planning.isChecked()){
                    planning.setText(getActivity().getResources().getString(R.string.fragment_journal_view_planning));
                    LoadJournal();
                }else{
                    planning.setText(getActivity().getResources().getString(R.string.fragment_journal_view_journal));
                    LoadPlanning();
                }
            }
        });

        save_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Boolean selected=false;
                if(swt.isChecked()){
                    for (LoadedRecord model : WorkersCardFile.recordList) {
                        if (model.isSelected()) {
                            selected=true;
                            state.setGarbage(model.getRecord5(),5);
                        }
                    }
                }else{
                    int pos=0;
                    text="";
                    for (LoadedRecord model : WorkersCardFile.recordList)
                        if (model.isSelected()) {
                            if (pos==0) {
                                text = model.getRecord5();
                                pos = 1;
                            } else {
                                text += "," + model.getRecord5();
                            }
                        }
                    if(!text.equals("")){
                        state.setGarbage(text,4);
                        selected=true;
                    }
                }

                if(!selected ){
                    Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice),getActivity().getResources().getString(R.string.fragment_journal_select_worker),getActivity());
                }else {
                    Fragment fragment = new FragmentBordereauView();
                    FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                    fragmentManager.beginTransaction()
                            .replace(R.id.content_frame, fragment)
                            .addToBackStack(null)
                            .commit();
                    fragmentManager.executePendingTransactions();
                }
            }
        });


        weather.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                Fragment fragment = new FragmentWeather();
                FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                fragmentManager.beginTransaction()
                        .replace(R.id.content_frame, fragment)
                        .addToBackStack(null)
                        .commit();
                fragmentManager.executePendingTransactions();
            }
        });
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_journal, container, false);
        weather = v.findViewById(R.id.fragment_journal_weather);
        save_btn = v.findViewById(R.id.fragment_journal_save_btn);
        calendar = v.findViewById(R.id.fragment_journal_calendar);
        bordereau_btn = v.findViewById(R.id.fragment_journal_bordereau_btn);
        regie_btn = v.findViewById(R.id.fragment_journal_regie_btn);
        qtd_btn = v.findViewById(R.id.fragment_journal_qtd_btn);
        weatherIcon = v.findViewById(R.id.fragment_journal_weather_icon);
        weatherTxt = v.findViewById(R.id.fragment_journal_weather_txt);
        numWorkers = v.findViewById(R.id.fragment_journal_num_workers);
        listworkers = v.findViewById(R.id.fragment_journal_workers_list);
        listjournal = v.findViewById(R.id.fragment_journal_list);
        swt = v.findViewById(R.id.fragment_journal_worker_selection);
        planning = v.findViewById(R.id.fragment_journal_planning_selection);

        return v;
    }

    @Override
    public void onResume() {
        super.onResume();
        Functions.checkLocation(getActivity());

        state.clearGarbage();
        //initialize global vars
        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");


        lang="en";
        String filename = getActivity().getFilesDir() + "/config.xml";
        File file = new File(filename);
        if(file.exists()) {
            //read configuration file
            LoadConfig LoadConfig = new LoadConfig();
            LoadConfig.filename = filename;
            lang = LoadConfig.GetConfigString("language");
        }

        try {

            Date today= sdf.parse(sdf.format(new Date()));
             Date sysDate= sdf.parse(state.date);
            if (!today.equals(sysDate) && ! state.date.equals("")){
                AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
                builder.setMessage(getActivity().getResources().getString(R.string.error_not_today_date))
                    .setCancelable(false)
                    .setTitle(getResources().getString(R.string.alertbox_title_notice))
                    .setPositiveButton(getActivity().getResources().getString(R.string.alertbox_keep_current_date),
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    try{
                                        LoadWorkers();
                                        LoadJournal();
                                        LoadWeather();
                                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                                        Date date=sdf.parse(state.date);
                                        if(lang.equals("pt")){
                                            sdf = new SimpleDateFormat("dd 'de' MMMM 'de' yyyy");

                                        }else if(lang.equals("fr")){
                                            sdf = new SimpleDateFormat("dd MMMM yyyy");
                                        }else{
                                            sdf = new SimpleDateFormat("MMMM dd',' yyyy");
                                        }
                                        getActivity().setTitle(getResources().getString(R.string.fragment_journal_title) + ", "+sdf.format(date));
                                    } catch (ParseException e) {
                                        Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
                                    }
                                }
                            })
                    .setNegativeButton(getActivity().getResources().getString(R.string.alertbox_change_today),
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    try{
                                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                                        state.date=sdf.format(new Date());
                                        LoadWorkers();
                                        LoadJournal();
                                        LoadWeather();
                                        sdf = new SimpleDateFormat("yyyy-MM-dd");
                                        Date date=sdf.parse(state.date);
                                        if(lang.equals("pt")){
                                            sdf = new SimpleDateFormat("dd 'de' MMMM 'de' yyyy");

                                        }else if(lang.equals("fr")){
                                            sdf = new SimpleDateFormat("dd MMMM yyyy");
                                        }else{
                                            sdf = new SimpleDateFormat("MMMM dd',' yyyy");
                                        }
                                        getActivity().setTitle(getResources().getString(R.string.fragment_journal_title) + ", "+sdf.format(date));

                                    } catch (ParseException e) {
                                        Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
                                    }
                                    dialog.cancel();
                                }
                            });
                AlertDialog alert = builder.create();
                alert.show();
            }else{
                state.date=sdf.format(new Date());
                LoadWorkers();
                LoadPlanning();
                LoadWeather();
                sdf = new SimpleDateFormat("yyyy-MM-dd");
                Date date=sdf.parse(state.date);
                if(lang.equals("pt")){
                    sdf = new SimpleDateFormat("dd 'de' MMMM 'de' yyyy");

                }else if(lang.equals("fr")){
                    sdf = new SimpleDateFormat("dd MMMM yyyy");
                }else{
                    sdf = new SimpleDateFormat("MMMM dd',' yyyy");
                }
                getActivity().setTitle(getResources().getString(R.string.fragment_journal_title) + ", "+sdf.format(date));
            }
        } catch (ParseException e) {
            Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
        }
    }

    private void LoadWeather(){
        Weather weather=new Weather();
        weather.load(getActivity(), false);
        if(!stateWeather.id.equals("")){
            Glide.with(weatherIcon.getContext())
                    .asBitmap()
                    .placeholder(R.drawable.loading)
                    .error(R.drawable.loading_error_image)
                    .load("http://openweathermap.org/img/w/"+ stateWeather.icon +".png")
                    .override(1080, 600)
                    .centerCrop()
                    .skipMemoryCache(true)  //No memory cache
                    .diskCacheStrategy(DiskCacheStrategy.NONE)   //No disk cache
                    .apply(RequestOptions.circleCropTransform())
                    .thumbnail(0.5f)
                    .into(weatherIcon);

            weatherTxt.setText(weather.translate(stateWeather.description)+System.getProperty("line.separator")+ stateWeather.temperature +"°C     "+ stateWeather.windSpeed +"km/h");
        }
    }

    public class LoadPlanningResultObserver implements Observer
    {
        private SendData.ObservableValue ov = null;
        public LoadPlanningResultObserver(SendData.ObservableValue ov) {
            this.ov = ov;
        }
        public void update(Observable obs, Object obj) {
            if (obs == ov) {
                updatePlanningData(ov.getValue());
            }
        }
    }
    //ToDo falta fazer planning for the selected date
    private void LoadPlanning(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_journal_title));
        queue.setDescription( getResources().getString(R.string.fragment_journal_description));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("");
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
        field.setRequestVar("type");
        field.setValue("list");
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("language");
        field.setValue(state.getCurrentLanguage());
        fields.add(field);

        SendData sendData = new SendData(getActivity(), getActivity());
        LoadPlanningResultObserver loadPlanningResultObserver = new LoadPlanningResultObserver(sendData.DelayedResult);
        sendData.DelayedResult.addObserver(loadPlanningResultObserver);
        sendData.addQueue(queue);
        sendData.addFields(fields);
        sendData.setEncryption(true, "AES128");
        sendData.setWaitForCode(true);
        sendData.setloadMainPage(false);
        sendData.setEnableQueue(false);
        sendData.send();
    }
    public ArrayList<LoadedRecord> getInfoPlanning(String response) {

        ArrayList<LoadedRecord> recordArrayList = new ArrayList<>();
        LoadedRecord record;

        try {
            JSONObject jsonObject = new JSONObject(response);
            if (jsonObject.getString("error").equals("false")) {

                JSONArray dataArray = jsonObject.getJSONArray("data");
                int test=dataArray.length();

                for (int i = 0; i < test; i++) {

                    record = new LoadedRecord();
                    JSONObject dataobj = dataArray.getJSONObject(i);
                    record.setRecord1(dataobj.getString("name"));
                    record.setRecord5(dataobj.getString("code"));
                    record.setRecord2(dataobj.getString("hora"));
                    record.setRecord3(dataobj.getString("note"));

                    recordArrayList.add(record);

                }
            }

        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
            Toast.makeText(getActivity(), getActivity().getResources().getString(R.string.error_ivalid_data), Toast.LENGTH_SHORT).show();
        }

        return recordArrayList;
    }


    private void updatePlanningData(String response){
        if (Functions.isSuccess(response)) {
            JournalArrayList = getInfoPlanning(response);

        }else {
            LoadedRecord record = new LoadedRecord();
            record.setRecord1("");
            record.setRecord5("-1");
            record.setRecord2("");
            record.setRecord3("");
            JournalArrayList = new ArrayList<>();
            JournalArrayList.add(record);

            Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
        }

        journalAdapter = new JournalAdapter(getActivity(),JournalArrayList);
        listjournal.setAdapter(journalAdapter);
        listjournal.setLayoutManager(new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL, false));
    }

    //  ================================================================================================================================
    public class LoadJournalResultObserver implements Observer
    {
        private SendData.ObservableValue ov = null;
        public LoadJournalResultObserver(SendData.ObservableValue ov) {
            this.ov = ov;
        }
        public void update(Observable obs, Object obj) {
            if (obs == ov) {
                updateJournalsData(ov.getValue());
            }
        }
    }

    private void LoadJournal(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_journal_title));
        queue.setDescription( getResources().getString(R.string.fragment_journal_description));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("4");
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
        field.setRequestVar("type");
        field.setValue("list");
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("language");
        field.setValue(state.getCurrentLanguage());
        fields.add(field);

        SendData sendData = new SendData(getActivity(), getActivity());
        LoadJournalResultObserver loadJournalResultObserver = new LoadJournalResultObserver(sendData.DelayedResult);
        sendData.DelayedResult.addObserver(loadJournalResultObserver);
        sendData.addQueue(queue);
        sendData.addFields(fields);
        sendData.setEncryption(true, "AES128");
        sendData.setWaitForCode(true);
        sendData.setloadMainPage(false);
        sendData.setEnableQueue(false);
        sendData.send();
        //String response= sendData.getResponse();
    }

    public ArrayList<LoadedRecord> getInfoJournal(String response) {

        ArrayList<LoadedRecord> recordArrayList = new ArrayList<>();
        LoadedRecord record;

        try {
            JSONObject jsonObject = new JSONObject(response);
            if (jsonObject.getString("error").equals("false")) {

                JSONArray dataArray = jsonObject.getJSONArray("data");
                int test=dataArray.length();

                for (int i = 0; i < test; i++) {

                    record = new LoadedRecord();
                    JSONObject dataobj = dataArray.getJSONObject(i);
                    record.setRecord1(dataobj.getString("name"));
                    record.setRecord5(dataobj.getString("code"));
                    record.setRecord2(dataobj.getString("hora"));
                    record.setRecord3(dataobj.getString("note"));

                    recordArrayList.add(record);

                }
            }

        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
            Toast.makeText(getActivity(), getActivity().getResources().getString(R.string.error_ivalid_data), Toast.LENGTH_SHORT).show();
        }

        record = new LoadedRecord();
        record.setRecord1("");
        record.setRecord5("-1");
        record.setRecord2("");
        record.setRecord3(getActivity().getResources().getString(R.string.fragment_journal_add_entry));
        recordArrayList.add(record);

        return recordArrayList;
    }


    private void updateJournalsData(String response){
        if (Functions.isSuccess(response)) {
            JournalArrayList = getInfoJournal(response);

        }else {
            LoadedRecord record = new LoadedRecord();
            record.setRecord1("");
            record.setRecord5("-1");
            record.setRecord2("");
            record.setRecord3(getActivity().getResources().getString(R.string.fragment_journal_add_entry));
            JournalArrayList = new ArrayList<>();
            JournalArrayList.add(record);

            Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
        }

        journalAdapter = new JournalAdapter(getActivity(),JournalArrayList);
        listjournal.setAdapter(journalAdapter);
        listjournal.setLayoutManager(new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL, false));
    }

    @SuppressLint("StaticFieldLeak")
    private void LoadWorkersByCategory(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_journal_title));
        queue.setDescription( getResources().getString(R.string.fragment_journal_description));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("3");
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
        field.setRequestVar("type");
        field.setValue("category");
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("language");
        field.setValue(state.getCurrentLanguage());
        fields.add(field);

        SendData sendData = new SendData(getActivity(), getActivity());
        LoadWorkersByCategoryResultObserver loadWorkersByCategoryResultObserver = new LoadWorkersByCategoryResultObserver(sendData.DelayedResult);
        sendData.DelayedResult.addObserver(loadWorkersByCategoryResultObserver);
        sendData.addQueue(queue);
        sendData.addFields(fields);
        sendData.setEncryption(true, "AES128");
        sendData.setWaitForCode(false);
        sendData.setloadMainPage(false);
        sendData.setEnableQueue(false);
        sendData.send();
       // String response= sendData.getResponse();

    }

    public class LoadWorkersByCategoryResultObserver implements Observer
    {
        private SendData.ObservableValue ov = null;
        public LoadWorkersByCategoryResultObserver(SendData.ObservableValue ov) {
            this.ov = ov;
        }
        public void update(Observable obs, Object obj) {
            if (obs == ov) {
                updateWorkersByCategorysData(ov.getValue());
            }
        }
    }
 private void updateWorkersByCategorysData(String response){
     if (Functions.isSuccess(response)) {
         SiteWorkersArrayList = getInfoCatWorkers(response);
         workersAdapter = new WorkersCardFile(getActivity(),SiteWorkersArrayList, true);
         listworkers.setAdapter(workersAdapter);
         listworkers.setLayoutManager(new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL, false));
     }else {
         Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
         swt.setChecked(false);
     }
 }

    public ArrayList<LoadedRecord> getInfoCatWorkers(String response) {
        ArrayList<LoadedRecord> recordArrayList = new ArrayList<>();
        try {
            JSONObject jsonObject = new JSONObject(response);

            if (jsonObject.getString("error").equals("false")) {

                JSONArray dataArray = jsonObject.getJSONArray("data");
                int test=dataArray.length();

                for (int i = 0; i < test; i++) {

                    LoadedRecord record = new LoadedRecord();
                    JSONObject dataobj = dataArray.getJSONObject(i);
                    record.setRecord1(dataobj.getString("name"));
                    record.setRecord5(dataobj.getString("CodCat"));
                    record.setRecord2(dataobj.getString("workers"));
                    record.setRecord4(state.HostUrl+"images/"+dataobj.getString("imgURL"));

                    recordArrayList.add(record);

                }
            }

        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
            Toast.makeText(getActivity(), getActivity().getResources().getString(R.string.error_ivalid_data), Toast.LENGTH_SHORT).show();
        }

        return recordArrayList;
    }

    public class LoadWorkersResultObserver implements Observer
    {
        private SendData.ObservableValue ov = null;
        public LoadWorkersResultObserver(SendData.ObservableValue ov) {
            this.ov = ov;
        }
        public void update(Observable obs, Object obj) {
            if (obs == ov) {
                updateWorkersData(ov.getValue());
            }
        }
    }
    @SuppressLint("StaticFieldLeak")
    private void LoadWorkers(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_journal_title));
        queue.setDescription( getResources().getString(R.string.fragment_journal_description));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("3");
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
        field.setRequestVar("type");
        field.setValue("worker");
        fields.add(field);

        field = new EntityFields();
        field.setRequestVar("language");
        field.setValue(state.getCurrentLanguage());
        fields.add(field);

        SendData sendData = new SendData(getActivity(), getActivity());
        LoadWorkersResultObserver loadWorkersResultObserver = new LoadWorkersResultObserver(sendData.DelayedResult);
        sendData.DelayedResult.addObserver(loadWorkersResultObserver);
        sendData.addQueue(queue);
        sendData.addFields(fields);
        sendData.setEncryption(true, "AES128");
        sendData.setWaitForCode(false);
        sendData.setloadMainPage(false);
        sendData.setEnableQueue(false);
        sendData.send();
        //String response= sendData.getResponse();
    }

    public ArrayList<LoadedRecord> getInfoWorkers(String response) {
        ArrayList<LoadedRecord> recordArrayList = new ArrayList<>();
        try {
            JSONObject jsonObject = new JSONObject(response);

            if (jsonObject.getString("error").equals("false")) {

                JSONArray dataArray = jsonObject.getJSONArray("data");
                int test=dataArray.length();

                for (int i = 0; i < test; i++) {

                    LoadedRecord record = new LoadedRecord();
                    JSONObject dataobj = dataArray.getJSONObject(i);
                    record.setRecord1(dataobj.getString("name"));
                    record.setRecord5(dataobj.getString("coduser"));
                    if(dataobj.getString("imgURL").equals("")){
                        record.setRecord4(state.HostUrl+"photos/person.png");
                    }else{
                        record.setRecord4(state.HostUrl+"photos/"+dataobj.getString("imgURL"));
                    }
                    recordArrayList.add(record);
                }
            }

        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
            Toast.makeText(getActivity(), getActivity().getResources().getString(R.string.error_ivalid_data), Toast.LENGTH_SHORT).show();
        }

        return recordArrayList;
    }

     private void updateWorkersData(String response){
         if (Functions.isSuccess(response)) {
             Functions.removeSimpleProgressDialog();  //will remove progress dialog
             SiteWorkersArrayList = getInfoWorkers(response);
             numWorkers.setText(SiteWorkersArrayList.size()+" "+getActivity().getResources().getString(R.string.fragment_journal_site));
         }else {
             SiteWorkersArrayList = new ArrayList<>();
             numWorkers.setText("0 "+getActivity().getResources().getString(R.string.fragment_journal_site));
             Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
         }
         workersAdapter = new WorkersCardFile(getActivity(),SiteWorkersArrayList, true);
         listworkers.setAdapter(workersAdapter);
         listworkers.setLayoutManager(new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL, false));
     }
}
