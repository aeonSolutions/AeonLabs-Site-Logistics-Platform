package construction.site.logistics.foreman.Fragments;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.app.AlertDialog;
import android.content.DialogInterface;
import android.graphics.Color;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.os.Looper;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.BaseAdapter;
import android.widget.CheckBox;
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
import java.util.Set;

import construction.site.logistics.foreman.Network.HttpRequestHandler;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.Network.SendRequest;
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

public class FragmentJournalAdd extends Fragment {

    private RecyclerView listjournal;
    private ImageView calendar, photo_btn, weatherIcon, save_btn;
    private LinearLayout weather;
    private TextView date_txt, weatherTxt;
    private EditText note;

    public String text = "";
    ArrayList<LoadedRecord> JournalArrayList;
    private String response="";
    private JournalAddAdapter journalAdapter;
    private GridView SysPhotos;

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
                state.setGarbage("journalAdd",2);

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
                state.setGarbage("journalAdd",2);

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
                state.setGarbage("journalAdd",2);

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
                if (state.isDemonstrationEnabled){
                    return;
                }
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

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_journal_add, container, false);
        weather = v.findViewById(R.id.fragment_journal_add_weather);
        photo_btn = v.findViewById(R.id.fragment_journal_add_photo_btn);
        calendar = v.findViewById(R.id.fragment_journal_add_calendar);
        save_btn = v.findViewById(R.id.fragment_journal_add_note_btn);
        note = v.findViewById(R.id.fragment_journal_add_notas);
        weatherIcon = v.findViewById(R.id.fragment_journal_add_weather_icon);
        weatherTxt = v.findViewById(R.id.fragment_journal_add_weather_txt);
        listjournal = v.findViewById(R.id.fragment_journal_add_list);
        SysPhotos = v.findViewById(R.id.fragment_journal_add_galleryGrid);
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();

        if (getActivity().equals(null)){
            return;
        }
        Functions.checkLocation(getActivity());

        if(!state.getGarbage()[2].equals("journalAdd")) {
            state.clearPhotos2Upload("");
            state.clearGarbage();
            state.gallerySelection.clear();

        }else{
            note.setText(state.getGarbage()[1]);
        }

        LoadJournal(getActivity());
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
            getActivity().setTitle(getResources().getString(R.string.fragment_journal_add_title) + ", "+sdf.format(date));

        } catch (Exception e) {
            Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
        }
    }


    @SuppressLint("StaticFieldLeak")
    private void SendData(){
        if (note.getText().toString().equals("")) {
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.fragment_journal_add_missing_description), getActivity());
            note.requestFocus();
        } else {
            EntityQueue queue= new EntityQueue();
            queue.setMsgType("alertbox");
            queue.setMsgSuccess(getActivity().getResources().getString(R.string.fragment_journal_add_submit_ok));
            queue.setMsgError("resquest");
            queue.setUrl(state.HostUrl + "api/index.php");
            queue.setTitle( getResources().getString(R.string.fragment_journal_add_title));
            queue.setDescription( getResources().getString(R.string.fragment_journal_add_description));

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
            field.setRequestVar("nota");
            field.setValue(note.getText().toString());
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("type");
            field.setValue("add");
            fields.add(field);

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
                file.setTitle(getResources().getString(R.string.fragment_journal_add_title));
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
                LoadJournal(getActivity());
                albumList.clear();
                note.setText("");
            }
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

    public void LoadJournalEntry(int idv, Activity activity) {
        albumList.clear();
        Long tsLong = System.currentTimeMillis() / 1000;

        if(idv == (JournalArrayList.size() - 1)) {
            if(state.getGarbage()[2].equals("journalAdd")) {
                note.setText(state.getGarbage()[1]);
            }else{
                note.setText("");
            }
            state.setGarbage("",1);
        }else if (Functions.isSuccess(response) && idv < (JournalArrayList.size() - 1)) {
            note.setText(JournalArrayList.get(idv).getRecord3());
            state.setGarbage(JournalArrayList.get(idv).getRecord3(),1);
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
                        String url = state.HostUrl + "files/journal/" + dataSubObj.getString("file");
                        photosListCode.add(dataSubObj.getString("code"));
                        albumList.add(GalleryMethods.mappingInbox("site", url, tsLong.toString(), GalleryMethods.converToTime(tsLong.toString()), null));
                    }
                }
            } catch (JSONException e) {
                Functions.SaveCrash(e, getActivity());
                Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.error_ivalid_data), getActivity());
            }
            if(state.getGarbage()[2].equals("journalAdd")) {
                note.setText(state.getGarbage()[1]);
            }
        }

        // check if fields are the same or if it has been changed
        if(state.getGarbage()[2].equals("journalAdd") && !state.getGarbage()[1].equals(note.getText().toString()) && !state.getGarbage()[1].equals("")) {
            AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
            builder.setMessage( getActivity().getResources().getString(R.string.alertbox_resume_previous_text))
                    .setCancelable(false)
                    .setTitle(getActivity().getResources().getString(R.string.alertbox_title_question))
                    .setPositiveButton(getActivity().getResources().getString(R.string.alertbox_continue),
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    note.setText(state.getGarbage()[1]);
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
    private void LoadJournal(Activity activity){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_journal_add_title));
        queue.setDescription( getResources().getString(R.string.fragment_journal_add_description));

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
        response= sendData.getResponse();

        JournalArrayList = getInfoJournal(response);
        journalAdapter = new JournalAddAdapter(getActivity(),JournalArrayList);
        if(state.getGarbage()[2].equals("journalAdd")) {
            note.setText(state.getGarbage()[1]);
        }
        if (!state.getGarbage() [5].equals("") ){
            int selected=-1;
            for (int i=0;i<JournalArrayList.size();i++) {
                if (JournalArrayList.get(i).getRecord5().equals(state.getGarbage() [5]) ) {
                    selected=i;
                }
            }
            if(selected>-1) {
                journalAdapter.recordList.get(selected).setSelected(true);
                state.setGarbage(journalAdapter.recordList.get(selected).getRecord5(),0);

                LoadJournalEntry( selected, activity);
            }
        }else{
            state.setGarbage("-1",0);
            journalAdapter.recordList.get(journalAdapter.recordList.size()-1).setSelected(true);
        }
        listjournal.setAdapter(journalAdapter);
        listjournal.setLayoutManager(new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL, false));
        journalAdapter.notifyDataSetChanged();
        if (! Functions.isSuccess(response)) {
            Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
        }
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
                                                queue.setTitle( getResources().getString(R.string.fragment_journal_add_title));
                                                queue.setDescription( getResources().getString(R.string.fragment_journal_add_description));

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
                                                LoadJournal(activity);
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
                    record.setRecord1(dataobj.getString("name"));
                    record.setRecord5(dataobj.getString("code"));
                    record.setRecord2(dataobj.getString("hora"));
                    record.setRecord3(dataobj.getString("note"));

                    recordArrayList.add(record);
                }
            }

        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice),getActivity().getResources().getString(R.string.error_ivalid_data),getActivity());
        }

        record = new LoadedRecord();
        record.setRecord1("");
        record.setRecord5("-1");
        record.setRecord2("");
        record.setRecord3(getActivity().getResources().getString(R.string.fragment_journal_add_new_entry));
        recordArrayList.add(record);

        return recordArrayList;
    }

    public class JournalAddAdapter extends RecyclerView.Adapter<JournalAddAdapter.MyViewHolder> {

        private LayoutInflater inflater;
        public  ArrayList<LoadedRecord> recordList;
        private int selectedPos = RecyclerView.NO_POSITION;
        private boolean IsSelected = true;
        public MyViewHolder holder;
        private Activity activity;

        public JournalAddAdapter(Activity _activity, ArrayList<LoadedRecord> _recordList){
            this.activity=_activity;
            this.inflater = LayoutInflater.from(_activity);
            this.recordList = _recordList;

        }

        @Override
        public JournalAddAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

            View view = inflater.inflate(R.layout.adapter_journal, parent, false);
            holder = new MyViewHolder(view);

            return holder;
        }

        @Override
        public void onBindViewHolder(final JournalAddAdapter.MyViewHolder holder, int position) {
            final LoadedRecord model = recordList.get(position);

            holder.text1.setText(recordList.get(position).getRecord1().replace("[newline]", System.getProperty("line.separator")));
            if(recordList.get(position).getRecord2() !=null){
                holder.text2.setText(recordList.get(position).getRecord2().replace("[newline]", System.getProperty("line.separator")));
            }else{
                holder.text2.setText("");
            }
            if(recordList.get(position).getRecord3() !=null){
                holder.text3.setText(recordList.get(position).getRecord3().replace("[newline]", System.getProperty("line.separator")));
            }else{
                holder.text3.setText("");
            }

            holder.itemView.setSelected(selectedPos == position);
            holder.cardView.setBackgroundColor(model.isSelected() ? Color.GREEN : Color.WHITE);

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
                                                state.setGarbage("",0);
                                                state.setGarbage("",1);
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
                            LoadJournalEntry(selectedPos, activity);
                        }else if (!IsSelected){
                            note.setText("");
                            state.setGarbage("",0);
                            state.setGarbage("",1);
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

            TextView text2, text1, text3;
            CardView cardView;
            View view;

            public MyViewHolder(View itemView) {
                super(itemView);
                view=itemView;
                cardView = itemView.findViewById(R.id.adapter_journal_card_view);
                text2 = itemView.findViewById(R.id.adapter_journal_text2);
                text1 = itemView.findViewById(R.id.adapter_journal_text1);
                text3 = itemView.findViewById(R.id.adapter_journal_text3);
            }
        }
    }
}
