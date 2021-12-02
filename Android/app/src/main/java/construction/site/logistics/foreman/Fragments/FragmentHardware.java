package construction.site.logistics.foreman.Fragments;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.graphics.Color;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.CheckBox;
import android.widget.CompoundButton;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.cardview.widget.CardView;
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
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.Iterator;
import java.util.List;
import java.util.Observable;
import java.util.Observer;
import java.util.Set;

import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.abstraction.GalleryMethods;
import construction.site.logistics.foreman.abstraction.Weather;
import construction.site.logistics.foreman.data.LoadConfig;
import construction.site.logistics.foreman.data.LoadedRecord;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityFiles;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.state;
import construction.site.logistics.foreman.data.stateWeather;


public class FragmentHardware extends Fragment {

    private RecyclerView listHardware;
    private ImageView calendar, photo_btn, weatherIcon, save_btn;
    private LinearLayout weather;
    private TextView weatherTxt;
    private EditText note;

    public String text = "";
    ArrayList<LoadedRecord> hardwareArrayList;
    private String response="";
    private HardwareAdapter hardwareAdapter;
    private GridView SysPhotos;

    private CheckBox checkBoxWorking, checkBoxBroken, checkBoxStolen, checkBoxOrderNew;

    private ArrayList<HashMap<String, String>> albumList = new ArrayList<HashMap<String, String>>();
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

        weather.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                state.setGarbage(note.getText().toString(),1);
                state.setGarbage("hardwareAdd",2);

                if(checkBoxWorking.isChecked()){
                    state.setGarbage("1",3);
                }else if(checkBoxBroken.isChecked()){
                    state.setGarbage("0",3);
                }else if(checkBoxStolen.isChecked()){
                    state.setGarbage("-1",3);
                }else{ // nothing selected
                    state.setGarbage("-2",3);
                }

                if(checkBoxOrderNew.isChecked()) {
                    state.setGarbage("1", 4);
                }else{
                    state.setGarbage("0", 4);
                }

                Fragment fragment = new FragmentWeather();
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
                state.setGarbage(note.getText().toString(),1);
                state.setGarbage("hardwareAdd",2);
                if(checkBoxWorking.isChecked()){
                    state.setGarbage("1",3);
                }else if(checkBoxBroken.isChecked()){
                    state.setGarbage("0",3);
                }else if(checkBoxStolen.isChecked()){
                    state.setGarbage("-1",3);
                }else{ // nothing selected
                    state.setGarbage("-2",3);
                }

                if(checkBoxOrderNew.isChecked()) {
                    state.setGarbage("1", 4);
                }else{
                    state.setGarbage("0", 4);
                }
                Fragment fragment = new FragmentCalendar();
                FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                fragmentManager.beginTransaction()
                        .replace(R.id.content_frame, fragment)
                        .addToBackStack(null)
                        .commit();
                fragmentManager.executePendingTransactions();
            }
        });

        photo_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                state.setGarbage(note.getText().toString(),1);
                state.setGarbage("hardwareAdd",2);
                if(checkBoxWorking.isChecked()){
                    state.setGarbage("1",3);
                }else if(checkBoxBroken.isChecked()){
                    state.setGarbage("0",3);
                }else if(checkBoxStolen.isChecked()){
                    state.setGarbage("-1",3);
                }else{ // nothing selected
                    state.setGarbage("-2",3);
                }

                if(checkBoxOrderNew.isChecked()) {
                    state.setGarbage("1", 4);
                }else{
                    state.setGarbage("0", 4);
                }
                Fragment fragment = new FragmentGallery();
                FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                fragmentManager.beginTransaction()
                        .replace(R.id.content_frame, fragment)
                        .addToBackStack(null)
                        .commit();
                fragmentManager.executePendingTransactions();
            }
        });

        save_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                SendData();
            }
        });

        note.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    Functions.hideKeyboard(v, getActivity().getApplicationContext());
                }
            }
        });
        checkBoxBroken.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if ( isChecked ) {
                    checkBoxStolen.setChecked(false);
                    checkBoxWorking.setChecked(false);
                }
            }
        });
        checkBoxStolen.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if ( isChecked ) {
                    checkBoxBroken.setChecked(false);
                    checkBoxWorking.setChecked(false);
                }
            }
        });
        checkBoxWorking.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if ( isChecked ) {
                    checkBoxBroken.setChecked(false);
                    checkBoxStolen.setChecked(false);
                    if(checkBoxOrderNew.isChecked()){
                        checkBoxOrderNew.setChecked(false);
                    }
                }
            }
        });
        checkBoxOrderNew.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            @Override
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                if ( isChecked && checkBoxWorking.isChecked()) {
                    checkBoxOrderNew.setChecked(false);
                }
            }
        });
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_hardware, container, false);
        weather = v.findViewById(R.id.fragment_hardware_add_weather);
        photo_btn = v.findViewById(R.id.fragment_hardware_add_photo_btn);
        calendar = v.findViewById(R.id.fragment_hardware_add_calendar);
        save_btn = v.findViewById(R.id.fragment_hardware_add_note_btn);
        note = v.findViewById(R.id.fragment_hardware_add_notas);
        weatherIcon = v.findViewById(R.id.fragment_hardware_add_weather_icon);
        weatherTxt = v.findViewById(R.id.fragment_hardware_add_weather_txt);
        listHardware = v.findViewById(R.id.fragment_hardware_add_list);
        SysPhotos = v.findViewById(R.id.fragment_hardware_add_galleryGrid);
        checkBoxWorking= v.findViewById(R.id.fragment_hardware_checkbox_working);
        checkBoxBroken= v.findViewById(R.id.fragment_hardware_checkbox_broken);
        checkBoxStolen= v.findViewById(R.id.fragment_hardware_checkbox_stolen);
        checkBoxOrderNew= v.findViewById(R.id.fragment_hardware_checkbox_order_one);
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();

        if (getActivity().equals(null)){
            return;
        }
        Functions.checkLocation(getActivity());
        checkBoxStolen.setChecked(false);
        checkBoxWorking.setChecked(false);
        checkBoxBroken.setChecked(false);
        checkBoxOrderNew.setChecked(false);

        if(!state.getGarbage()[2].equals("hardwareAdd")) {
            state.clearPhotos2Upload("");
            state.clearGarbage();
            state.gallerySelection.clear();

        }else{
            note.setText(state.getGarbage()[1]);
        }

        LoadHardware(getActivity());
        LoadWeather();
        //albumList.clear();

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
            getActivity().setTitle(getResources().getString(R.string.fragment_hardware_title) + ", "+sdf.format(date));

        } catch (Exception e) {
            Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
        }
    }

    private void enableButtons(Boolean state){
        photo_btn.setEnabled(state);
        calendar.setEnabled(state);
        save_btn.setEnabled(state);
        note.setEnabled(state);
        weatherIcon.setEnabled(state);
        listHardware.setEnabled(state);
        SysPhotos.setEnabled(state);
        checkBoxWorking.setEnabled(state);
        checkBoxBroken.setEnabled(state);
        checkBoxStolen.setEnabled(state);
        checkBoxOrderNew.setEnabled(state);

        if(state){
            save_btn.setImageResource(R.drawable.save_disabled);
            photo_btn.setImageResource(R.drawable.add_photo_disabled);
        }else{
            save_btn.setImageResource(R.drawable.save);
            photo_btn.setImageResource(R.drawable.add_photo);
        }
    }

    @SuppressLint("StaticFieldLeak")
    private void SendData(){
        if (note.getText().toString().equals("")) {
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.fragment_hardware_missing_designation), getActivity());
            note.requestFocus();
        }else if(state.getGarbage()[0].equals("-1") && !checkBoxOrderNew.isChecked()){
                Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.fragment_hardware_missing_request), getActivity());
                checkBoxOrderNew.requestFocus();
        }else if (!checkBoxWorking.isChecked() && !checkBoxStolen.isChecked() && !checkBoxBroken.isChecked()) {
                Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.fragment_hardware_missing_state_conservation), getActivity());
                checkBoxWorking.requestFocus();
        } else {
            enableButtons(false);
            EntityQueue queue= new EntityQueue();
            queue.setMsgType("alertbox");
            queue.setMsgSuccess(getActivity().getResources().getString(R.string.fragment_hardware_submit_ok));
            queue.setMsgError("resquest");
            queue.setUrl(state.HostUrl + "api/index.php");
            queue.setTitle( getResources().getString(R.string.fragment_hardware_title));
            queue.setDescription( getResources().getString(R.string.fragment_hardware_description));

            ArrayList<EntityFields> fields = new ArrayList<>();
            EntityFields field = new EntityFields();
            field.setRequestVar("task");
            field.setValue("20");
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
            field.setValue("record");
            fields.add(field);
            
            field = new EntityFields();
            field.setRequestVar("date");
            field.setValue(state.date);
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("designation");
            field.setValue(note.getText().toString());
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("state");
            if(checkBoxWorking.isChecked()){
                field.setValue("1");
            }else if(checkBoxBroken.isChecked()){
                field.setValue("0");
            }else{ // stolen or missing
                field.setValue("-1");
            }
            fields.add(field);

            if(checkBoxOrderNew.isChecked()) {
                field = new EntityFields();
                field.setRequestVar("request");
                field.setValue("1");
                fields.add(field);
            }            
            if(!state.getGarbage()[0].equals("-1")){
                field = new EntityFields();
                field.setRequestVar("cod");
                field.setValue(state.getGarbage()[0]);
                fields.add(field);
            }

            field = new EntityFields();
            field.setRequestVar("language");
            field.setValue(state.getCurrentLanguage());
            fields.add(field);

            ArrayList<EntityFiles> files = new ArrayList<>();
            EntityFiles file = null;
            Set<String> set = state.getPhotos2Upload();
            for (Iterator<String> it = set.iterator(); it.hasNext(); ) {
                file = new EntityFiles();
                file.setFilename(it.next());
                file.setAppendCode(true);
                file.setTitle(getResources().getString(R.string.fragment_hardware_title));
                files.add(file);
            }

            SendData sendData = new SendData(getActivity(), getActivity());
            sendData.addQueue(queue);
            sendData.addFields(fields);
            sendData.addfFiles(files);
            sendData.setEncryption(true, "AES128");
            sendData.setWaitForCode(true);
            sendData.setloadMainPage(false);
            sendData.setEnableQueue(true);
            sendData.send();
            if(!sendData.getError()){
                state.clearGarbage();
                LoadHardware(getActivity());
                albumList.clear();
                note.setText("");
            }
            enableButtons(true);

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

    public void LoadHardwareEntry(int idv, Activity activity) {
        albumList.clear();
        Long tsLong = System.currentTimeMillis() / 1000;

        if(idv == (hardwareArrayList.size() - 1)) {
            if(state.getGarbage()[2].equals("hardwareAdd")) {
                note.setText(state.getGarbage()[1]);
            }else{
                note.setText("");
                checkBoxOrderNew.setChecked(false);
                checkBoxStolen.setChecked(false);
                checkBoxBroken.setChecked(false);
                checkBoxWorking.setChecked(false);
            }
            state.clearGarbage();
        }else if (Functions.isSuccess(response) && idv < (hardwareArrayList.size() - 1)) {
            note.setText(hardwareArrayList.get(idv).getRecord3());
            state.setGarbage(hardwareArrayList.get(idv).getRecord3(),1);
            // 0 broken, 1 working, -1 stolen or missing
            if(hardwareArrayList.get(idv).getRecord2().equals("1")) {
                checkBoxWorking.setChecked(true);
            }else if(hardwareArrayList.get(idv).getRecord2().equals("0")){
                checkBoxBroken.setChecked(true);
            }else if(hardwareArrayList.get(idv).getRecord2().equals("-1")){
                checkBoxStolen.setChecked(true);
            }
            // 0 no request , 1 requested, 2 delivered
            if(hardwareArrayList.get(idv).getRecord4().equals("1")) {
                checkBoxOrderNew.setChecked(true);
            }else if(hardwareArrayList.get(idv).getRecord4().equals("0")){
                checkBoxOrderNew.setChecked(false);
            }else if(hardwareArrayList.get(idv).getRecord4().equals("2")){
                checkBoxStolen.setChecked(false);
            }
            try {
                JSONObject jsonObject = new JSONObject(response);
                JSONArray dataArray = jsonObject.getJSONArray("data");
                JSONObject dataobj = dataArray.getJSONObject(idv);
                if (dataobj.has("photos")) {
                    JSONArray dataSubArray = dataobj.getJSONArray("photos");
                    int test = dataSubArray.length();
                    photosListCode = new ArrayList<>();
                    for (int i = 0; i < test; i++) {
                        JSONObject dataSubObj = dataSubArray.getJSONObject(i);
                        String url = state.HostUrl + "files/hardware/" + dataSubObj.getString("file");
                        photosListCode.add(dataSubObj.getString("code"));
                        albumList.add(GalleryMethods.mappingInbox("site", url, tsLong.toString(), GalleryMethods.converToTime(tsLong.toString()), null));
                    }
                }
            } catch (JSONException e) {
                Functions.SaveCrash(e, getActivity());
                Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.error_ivalid_data), getActivity());
            }
            if(state.getGarbage()[2].equals("hardwareAdd")) {
                note.setText(state.getGarbage()[1]);
                if(state.getGarbage()[3].equals("1")){
                    checkBoxWorking.setChecked(true);
                }else if(state.getGarbage()[3].equals("0")){
                    checkBoxBroken.setChecked(true);
                }else if(state.getGarbage()[3].equals("-1")){
                    checkBoxStolen.setChecked(true);
                }else{ // nothing selected
                    checkBoxStolen.setChecked(false);
                    checkBoxWorking.setChecked(false);
                    checkBoxBroken.setChecked(false);
                }

                if(state.getGarbage()[4].equals("1")) {
                    checkBoxOrderNew.setChecked(true);
                }else{
                    checkBoxOrderNew.setChecked(false);
                }
                state.clearGarbage();
            }
        }
        //ToDO
        // check if checkboxes are selected the same as before
        // check if fields are the same or if it has been changed
        if(state.getGarbage()[2].equals("hardwareAdd") && !state.getGarbage()[1].equals(note.getText().toString()) && !state.getGarbage()[1].equals("")) {
            AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
            builder.setMessage( getActivity().getResources().getString(R.string.alertbox_resume_previous_text))
                    .setCancelable(false)
                    .setTitle(getActivity().getResources().getString(R.string.alertbox_title_question))
                    .setPositiveButton(getActivity().getResources().getString(R.string.alertbox_continue),
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    note.setText(state.getGarbage()[1]);
                                    if(state.getGarbage()[3].equals("1")){
                                        checkBoxWorking.setChecked(true);
                                    }else if(state.getGarbage()[3].equals("0")){
                                        checkBoxBroken.setChecked(true);
                                    }else if(state.getGarbage()[3].equals("-1")){
                                        checkBoxStolen.setChecked(true);
                                    }else{ // nothing selected
                                        checkBoxStolen.setChecked(false);
                                        checkBoxWorking.setChecked(false);
                                        checkBoxBroken.setChecked(false);
                                    }

                                    if(state.getGarbage()[4].equals("1")) {
                                        checkBoxOrderNew.setChecked(true);
                                    }else{
                                        checkBoxOrderNew.setChecked(false);
                                    }
                                    state.clearGarbage();

                                }
                            })
                    .setNegativeButton(getActivity().getResources().getString(R.string.alertbox_cancel),
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    state.clearGarbage();
                                    dialog.cancel();
                                }
                            });
            AlertDialog alert = builder.create();
            alert.show();
        }

        // add photos
        Set<String> set = state.getPhotos2Upload();
        for (Iterator<String> it = set.iterator(); it.hasNext(); ) {
            String f = it.next();
            photosListCode.add("new");
            albumList.add(GalleryMethods.mappingInbox("site", f, tsLong.toString(), GalleryMethods.converToTime(tsLong.toString()), null));
        }
        LoadPhotosInTransit(activity);
    }

    private void LoadPhotosInTransit(Activity activity){
        Long tsLong = System.currentTimeMillis() / 1000;
        if (state.gallerySelection.size() > 0) {
            AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
            builder.setMessage(getActivity().getResources().getString(R.string.alertbox_add_selected_photo_msg))
                    .setCancelable(false)
                    .setTitle(getActivity().getResources().getString(R.string.alertbox_title_result))
                    .setPositiveButton(getActivity().getResources().getString(R.string.alertbox_continue),
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    for (Iterator<String> it = state.gallerySelection.iterator(); it.hasNext(); ) {
                                        String f = it.next();
                                        photosListCode.add("new");
                                        albumList.add(GalleryMethods.mappingInbox("site", f, tsLong.toString(), GalleryMethods.converToTime(tsLong.toString()), null));
                                        state.setPhotos2Upload(f);
                                    }
                                    state.gallerySelection.clear();
                                    SysAlbumAdapter adapter = new SysAlbumAdapter(activity, albumList);
                                    SysPhotos.setAdapter(adapter);
                                    adapter.notifyDataSetChanged();
                                }
                            })
                    .setNegativeButton(getActivity().getResources().getString(R.string.alertbox_cancel),
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    state.gallerySelection.clear();
                                    SysAlbumAdapter adapter = new SysAlbumAdapter(activity, albumList);
                                    SysPhotos.setAdapter(adapter);
                                    adapter.notifyDataSetChanged();
                                    dialog.cancel();
                                }
                            });
            AlertDialog alert = builder.create();
            alert.show();
        } else {
            SysAlbumAdapter adapter = new SysAlbumAdapter(activity, albumList);
            SysPhotos.setAdapter(adapter);
            adapter.notifyDataSetChanged();
        }
    }

    @SuppressLint("StaticFieldLeak")
    private void LoadHardware(Activity activity){
        enableButtons(false);

        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_hardware_title));
        queue.setDescription( getResources().getString(R.string.fragment_hardware_description));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("20");
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
        LoadHardwareResultObserver loadHardwareResultObserver = new LoadHardwareResultObserver(sendData.DelayedResult);
        sendData.DelayedResult.addObserver(loadHardwareResultObserver);
        sendData.addQueue(queue);
        sendData.addFields(fields);
        sendData.setEncryption(true, "AES128");
        sendData.setWaitForCode(false);
        sendData.setloadMainPage(false);
        sendData.setEnableQueue(false);
        sendData.send();

    }

    public class LoadHardwareResultObserver implements Observer
    {
        private SendData.ObservableValue ov = null;
        public LoadHardwareResultObserver(SendData.ObservableValue ov) {
            this.ov = ov;
        }
        public void update(Observable obs, Object obj) {
            if (obs == ov) {
                updateHardwareData(ov.getValue());
            }
        }
    }
    private void updateHardwareData(String _response){
        response= _response;

        hardwareArrayList = getInfoJournal(response);
        hardwareAdapter = new HardwareAdapter(getActivity(),hardwareArrayList);
        if(state.getGarbage()[2].equals("hardwareAdd")) {
            note.setText(state.getGarbage()[1]);
        }
        if (!state.getGarbage() [5].equals("") ){
            int selected=-1;
            for (int i=0;i<hardwareArrayList.size();i++) {
                if (hardwareArrayList.get(i).getRecord5().equals(state.getGarbage() [5]) ) {
                    selected=i;
                }
            }
            if(selected>-1) {
                hardwareAdapter.recordList.get(selected).setSelected(true);
                state.setGarbage(hardwareAdapter.recordList.get(selected).getRecord5(),0);

                LoadHardwareEntry( selected, getActivity());
            }
        }else{
            state.setGarbage("-1",0);
            hardwareAdapter.recordList.get(hardwareAdapter.recordList.size()-1).setSelected(true);
        }
        listHardware.setAdapter(hardwareAdapter);
        listHardware.setLayoutManager(new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL, false));
        hardwareAdapter.notifyDataSetChanged();
        if (! Functions.isSuccess(response)) {
            Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
        }
        enableButtons(true);

    }

    public class SysAlbumAdapter extends BaseAdapter {
        private Activity activity;
        private ArrayList<HashMap<String, String>> data;
        private SysAlbumAdapter.SingleAlbumViewHolder holder = null;

        public SysAlbumAdapter(Activity a, ArrayList<HashMap<String, String>> d) {
            activity = a;
            data = d;
        }

        public int getCount() {
            return data.size();
        }

        public Object getItem(int position) {
            return position;
        }

        public long getItemId(int position) {
            return position;
        }

        public View getView(int position, View convertView, ViewGroup parent) {
            if (convertView == null) {
                holder = new SysAlbumAdapter.SingleAlbumViewHolder();
                convertView = LayoutInflater.from(activity).inflate(R.layout.fragment_album_single_row, parent, false);
                holder.galleryImage = convertView.findViewById(R.id.galleryImage);
                holder.checkBox = convertView.findViewById(R.id.ImageCheckBox);
                convertView.setTag(holder);
            } else {
                holder = (SysAlbumAdapter.SingleAlbumViewHolder) convertView.getTag();
            }

            holder.galleryImage.setId(position);
            holder.checkBox.setId(position);
            if(photosListCode.get(position).equals("new")){
                holder.checkBox.setTextAppearance(getActivity(), R.style.checkbox_gallery);
            }else{
                holder.checkBox.setTextAppearance(getActivity(), R.style.checkbox_database);
            }

            Glide.with(activity)
                    .asBitmap()
                    .load(data.get(position).get(GalleryMethods.KEY_PATH))
                    .placeholder(R.drawable.loading)
                    .error(R.drawable.loading_error_image)
                    .skipMemoryCache(true)  //No memory cache
                    .diskCacheStrategy(DiskCacheStrategy.NONE)   //No disk cache
                    .into(holder.galleryImage);

            holder.galleryImage.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    ImageView cb = (ImageView) v;
                    int idv = cb.getId();

                    Fragment fragment = new FragmentViewPhoto();
                    Bundle bundle = new Bundle();
                    bundle.putString("photoAddr", data.get(idv).get(GalleryMethods.KEY_PATH));
                    fragment.setArguments(bundle);
                    FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                    fragmentManager.beginTransaction()
                            .replace(R.id.content_frame, fragment)
                            .addToBackStack(null)
                            .commit();
                    fragmentManager.executePendingTransactions();
                }
            });

            holder.checkBox.setOnClickListener(new View.OnClickListener() {

                @Override
                public void onClick(View v) {
                    CheckBox cb = (CheckBox) v;
                    int idv = cb.getId();
                    String msg="";
                    if(photosListCode.get(idv).equals("new")) {
                        msg=getActivity().getResources().getString(R.string.alertbox_photo_del_msg);
                    }else{
                        msg=getActivity().getResources().getString(R.string.alertbox_photo_del_msg_db);
                    }

                    AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
                    builder.setMessage( msg)
                            .setCancelable(false)
                            .setTitle(getActivity().getResources().getString(R.string.alertbox_title_result))
                            .setPositiveButton(getActivity().getResources().getString(R.string.alertbox_continue),
                                    new DialogInterface.OnClickListener() {
                                        public void onClick(DialogInterface dialog, int id) {
                                            if(photosListCode.get(idv).equals("new")) {
                                                state.clearPhotos2Upload(photosListCode.get(idv));
                                                photosListCode.remove(idv);
                                                albumList.remove(idv);
                                                SysAlbumAdapter adapter = new SysAlbumAdapter(getActivity(), albumList);
                                                SysPhotos.setAdapter(adapter);
                                            }else{
                                                EntityQueue queue= new EntityQueue();
                                                queue.setMsgType("toast");
                                                queue.setMsgSuccess("response");
                                                queue.setMsgError("response");
                                                queue.setUrl(state.HostUrl + "api/index.php");
                                                queue.setTitle( getResources().getString(R.string.fragment_hardware_title));
                                                queue.setDescription( getResources().getString(R.string.fragment_hardware_description));

                                                ArrayList<EntityFields> fields = new ArrayList<>();
                                                EntityFields field = new EntityFields();
                                                field.setRequestVar("task");
                                                field.setValue("20");
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
                                                field.setValue("del");
                                                fields.add(field);


                                                field = new EntityFields();
                                                field.setRequestVar("cod");
                                                field.setValue(photosListCode.get(idv));
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
                                                LoadHardware(activity);
                                                albumList.clear();
                                            }
                                        }
                                    })
                            .setNegativeButton(getActivity().getResources().getString(R.string.alertbox_cancel),
                                    new DialogInterface.OnClickListener() {
                                        public void onClick(DialogInterface dialog, int id) {
                                            cb.setChecked(false);
                                            dialog.cancel();
                                        }
                                    });
                    AlertDialog alert = builder.create();
                    alert.show();
                }
            } );


            return convertView;
        }
        class SingleAlbumViewHolder {
            ImageView galleryImage;
            CheckBox checkBox;

        }
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
                    record.setRecord1(dataobj.getString("designation"));
                    record.setRecord2(dataobj.getString("state"));
                    record.setRecord3(dataobj.getString("worker"));
                    record.setRecord4(dataobj.getString("request"));
                    record.setRecord5(dataobj.getString("code"));
                    record.setRecord6(dataobj.getString("delivery"));

                    recordArrayList.add(record);
                }
            }

        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice),getActivity().getResources().getString(R.string.error_ivalid_data),getActivity());
        }

        record = new LoadedRecord();
        record.setRecord1(getActivity().getResources().getString(R.string.fragment_hardware_checkbox_order_one));
        record.setRecord2("");
        record.setRecord3("");
        record.setRecord4("");
        record.setRecord5("-1");
        record.setRecord6("");
        recordArrayList.add(record);

        return recordArrayList;
    }

    public class HardwareAdapter extends RecyclerView.Adapter<HardwareAdapter.MyViewHolder> {

        private LayoutInflater inflater;
        public  ArrayList<LoadedRecord> recordList;
        private int selectedPos = RecyclerView.NO_POSITION;
        private boolean IsSelected = true;
        public MyViewHolder holder;
        private Activity activity;

        public HardwareAdapter(Activity _activity, ArrayList<LoadedRecord> _recordList){
            this.activity=_activity;
            this.inflater = LayoutInflater.from(_activity);
            this.recordList = _recordList;

        }

        @Override
        public HardwareAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

            View view = inflater.inflate(R.layout.adapter_hardware, parent, false);
            holder = new MyViewHolder(view);

            return holder;
        }

        @Override
        public void onBindViewHolder(final HardwareAdapter.MyViewHolder holder, int position) {
            final LoadedRecord model = recordList.get(position);

            holder.text1.setText(recordList.get(position).getRecord1().replace("[newline]", System.getProperty("line.separator")));
            if(recordList.get(position).getRecord2() !=null){
                if(recordList.get(position).getRecord2().equals("0")) {
                    holder.text2.setText(getActivity().getResources().getString(R.string.fragment_hardware_checkbox_broken));
                }else if(recordList.get(position).getRecord2().equals("1")) {
                    holder.text2.setText(getActivity().getResources().getString(R.string.fragment_hardware_checkbox_working));
                }else if(recordList.get(position).getRecord2().equals("-1")){
                    holder.text2.setText(getActivity().getResources().getString(R.string.fragment_hardware_checkbox_stolen));
                }else{
                    holder.text2.setText("");
                }
            }else{
                holder.text2.setText("");
            }
            if(recordList.get(position).getRecord3() !=null){
                holder.text3.setText(recordList.get(position).getRecord3().replace("[newline]", System.getProperty("line.separator")));
            }else{
                holder.text3.setText("");
            }

            if (recordList.get(position).getRecord4() !=null){
                if(recordList.get(position).getRecord4().equals("1")) {
                    if (recordList.get(position).getRecord6().equals("")) {
                        holder.text4.setText(getActivity().getResources().getString(R.string.fragment_hardware_checkbox_order_one));
                    } else { // delivery date exists
                        holder.text4.setText(recordList.get(position).getRecord6());
                    }
                }else if(recordList.get(position).getRecord4().equals("2")){
                    holder.text4.setText(getActivity().getResources().getString(R.string.fragment_hardware_checkbox_delivered_one));
                }else  {
                    holder.text4.setText("- -");
                }
            }else{
                holder.text4.setText("");
            }

            holder.itemView.setSelected(selectedPos == position);
            holder.cardView.setBackgroundColor(model.isSelected() ? Color.GREEN : Color.WHITE);

            if(model.isSelected()){
                state.setGarbage(model.getRecord5(),0);
                state.clearPhotos2Upload("");
                LoadHardwareEntry(selectedPos, activity);

                if(recordList.get(position).getRecord5().equals("-1")){ // new record
                    checkBoxBroken.setEnabled(false);
                    checkBoxWorking.setEnabled(false);
                    checkBoxStolen.setEnabled(false);
                    checkBoxOrderNew.setEnabled(false);
                    checkBoxOrderNew.setChecked(true);
                }else{
                    checkBoxBroken.setEnabled(true);
                    checkBoxWorking.setEnabled(true);
                    checkBoxStolen.setEnabled(true);
                    checkBoxOrderNew.setEnabled(true);
                }
                note.setEnabled(true);
                save_btn.setEnabled(true);
                photo_btn.setEnabled(true);
                save_btn.setImageResource(R.drawable.save);
                photo_btn.setImageResource(R.drawable.add_photo);
            }else if (!IsSelected){
                note.setText("");
                state.setGarbage("",0);
                state.setGarbage("",1);
                checkBoxBroken.setEnabled(false);
                checkBoxWorking.setEnabled(false);
                checkBoxStolen.setEnabled(false);
                checkBoxOrderNew.setEnabled(false);
                note.setEnabled(false);
                save_btn.setEnabled(false);
                photo_btn.setEnabled(false);
                save_btn.setImageResource(R.drawable.save_disabled);
                photo_btn.setImageResource(R.drawable.add_photo_disabled);
            }

            holder.cardView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    notifyItemChanged(selectedPos);
                    selectedPos = holder.getLayoutPosition();
                    notifyItemChanged(selectedPos);
                    final CardView cv = (CardView) v;
                    int idv = cv.getId();

                    // check if fields are the same or if it has been changed
                    if( !state.getGarbage()[1].equals(note.getText().toString()) && !state.getGarbage()[1].equals("") && (IsSelected && recordList.get(selectedPos).isSelected())) {
                        AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
                        builder.setMessage( getActivity().getResources().getString(R.string.alertbox_discard_changes))
                                .setCancelable(false)
                                .setTitle(getActivity().getResources().getString(R.string.alertbox_title_question))
                                .setPositiveButton(getActivity().getResources().getString(R.string.alertbox_continue),
                                        new DialogInterface.OnClickListener() {
                                            public void onClick(DialogInterface dialog, int id) {
                                                state.clearGarbage();
                                                recordList.get(selectedPos).setSelected(!model.isSelected());
                                                cv.setBackgroundColor(recordList.get(selectedPos).isSelected() ? Color.GREEN : Color.WHITE);
                                                IsSelected=!IsSelected;
                                                note.setText("");
                                                checkBoxBroken.setChecked(false);
                                                checkBoxWorking.setChecked(false);
                                                checkBoxStolen.setChecked(false);
                                                checkBoxOrderNew.setChecked(false);
                                                state.setGarbage("",0);
                                                state.setGarbage("",1);
                                                state.setGarbage("",2);
                                                state.setGarbage("",3);

                                                checkBoxBroken.setEnabled(true);
                                                checkBoxWorking.setEnabled(true);
                                                checkBoxStolen.setEnabled(true);
                                                checkBoxOrderNew.setEnabled(true);
                                                note.setEnabled(true);
                                                save_btn.setEnabled(true);
                                                photo_btn.setEnabled(true);
                                                save_btn.setImageResource(R.drawable.save);
                                                photo_btn.setImageResource(R.drawable.add_photo);
                                                notifyDataSetChanged();
                                            }
                                        })
                                .setNegativeButton(getActivity().getResources().getString(R.string.alertbox_cancel),
                                        new DialogInterface.OnClickListener() {
                                            public void onClick(DialogInterface dialog, int id) {
                                                state.clearGarbage();
                                                dialog.cancel();
                                            }
                                        });
                        AlertDialog alert = builder.create();
                        alert.show();
                    }else{
                        if ((!IsSelected && model.isSelected()==false) || (IsSelected && model.isSelected())){
                            model.setSelected(!model.isSelected());
                            cv.setBackgroundColor(model.isSelected() ? Color.GREEN : Color.WHITE);
                            IsSelected=!IsSelected;
                            notifyDataSetChanged();
                        }
                        if(model.isSelected()){
                            state.setGarbage(model.getRecord5(),0);
                            state.clearPhotos2Upload("");
                            LoadHardwareEntry(selectedPos, activity);
                            checkBoxBroken.setEnabled(true);
                            checkBoxWorking.setEnabled(true);
                            checkBoxStolen.setEnabled(true);
                            checkBoxOrderNew.setEnabled(true);
                            note.setEnabled(true);
                            save_btn.setEnabled(true);
                            photo_btn.setEnabled(true);
                            save_btn.setImageResource(R.drawable.save);
                            photo_btn.setImageResource(R.drawable.add_photo);
                        }else if (!IsSelected){
                            note.setText("");
                            state.setGarbage("",0);
                            state.setGarbage("",1);
                            checkBoxBroken.setEnabled(false);
                            checkBoxWorking.setEnabled(false);
                            checkBoxStolen.setEnabled(false);
                            checkBoxOrderNew.setEnabled(false);
                            note.setEnabled(false);
                            save_btn.setEnabled(false);
                            photo_btn.setEnabled(false);
                            save_btn.setImageResource(R.drawable.save_disabled);
                            photo_btn.setImageResource(R.drawable.add_photo_disabled);
                        }
                    }
                }
            });

        }

        @Override
        public int getItemCount() {
            return recordList.size();
        }

        class MyViewHolder extends RecyclerView.ViewHolder{

            TextView text2, text1, text3, text4;
            CardView cardView;
            View view;

            public MyViewHolder(View itemView) {
                super(itemView);
                view=itemView;
                cardView = itemView.findViewById(R.id.adapter_hardware_card_view);
                text1 = itemView.findViewById(R.id.adapter_hardware_designation);
                text2 = itemView.findViewById(R.id.adapter_hardware_state);
                text3 = itemView.findViewById(R.id.adapter_hardware_worker);
                text4 = itemView.findViewById(R.id.adapter_hardware_requested);
            }
        }
    }
}
