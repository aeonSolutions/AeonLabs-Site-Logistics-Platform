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


public class FragmentMaterialsDIY extends Fragment {

    private RecyclerView listMaterialsDIY;
    private ImageView calendar, photo_btn, weatherIcon, save_btn;
    private LinearLayout weather;
    private TextView weatherTxt;
    private EditText designation, stock_qty, stock_request_qty;

    public String text = "";
    ArrayList<LoadedRecord> hardwareArrayList;
    private String response="";
    private HardwareAdapter hardwareAdapter;
    private GridView SysPhotos;

    private CheckBox checkBoxRequestMore;

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
                state.setGarbage(designation.getText().toString(),1);
                state.setGarbage("hardwareAdd",2);
                state.setGarbage(stock_request_qty.getText().toString(),3);
                state.setGarbage(stock_qty.getText().toString(),5);
                if(checkBoxRequestMore.isChecked()) {
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
                state.setGarbage(designation.getText().toString(),1);
                state.setGarbage("hardwareAdd",2);
                state.setGarbage(stock_request_qty.getText().toString(),3);
                state.setGarbage(stock_qty.getText().toString(),5);

                if(checkBoxRequestMore.isChecked()) {
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
                state.setGarbage(designation.getText().toString(),1);
                state.setGarbage("hardwareAdd",2);
                state.setGarbage(stock_request_qty.getText().toString(),3);
                state.setGarbage(stock_qty.getText().toString(),5);
                if(checkBoxRequestMore.isChecked()) {
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

                if (state.isDemonstrationEnabled){
                    return;
                }
                SendData();
            }
        });

        designation.setOnFocusChangeListener(new View.OnFocusChangeListener() {
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
        View v= inflater.inflate(R.layout.fragment_materials_diy, container, false);
        weather = v.findViewById(R.id.fragment_materials_diy_add_weather);
        photo_btn = v.findViewById(R.id.fragment_materials_diy_add_photo_btn);
        calendar = v.findViewById(R.id.fragment_materials_diy_add_calendar);
        save_btn = v.findViewById(R.id.fragment_materials_diy_add_note_btn);
        designation = v.findViewById(R.id.fragment_materials_diy_add_notas);
        weatherIcon = v.findViewById(R.id.fragment_materials_diy_add_weather_icon);
        weatherTxt = v.findViewById(R.id.fragment_materials_diy_add_weather_txt);
        listMaterialsDIY = v.findViewById(R.id.fragment_materials_diy_add_list);
        SysPhotos = v.findViewById(R.id.fragment_materials_diy_add_galleryGrid);
        checkBoxRequestMore= v.findViewById(R.id.fragment_materials_diy_checkbox_request);
        stock_qty= v.findViewById(R.id.fragment_materials_diy_stock_qty);
        stock_request_qty= v.findViewById(R.id.fragment_materials_diy_stock_order_qty);
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();

        if (getActivity().equals(null)){
            return;
        }
        Functions.checkLocation(getActivity());
        checkBoxRequestMore.setChecked(false);
        stock_request_qty.setEnabled(false);
        
        if(!state.getGarbage()[2].equals("hardwareAdd")) {
            state.clearPhotos2Upload("");
            state.clearGarbage();
            state.gallerySelection.clear();

        }else{
            designation.setText(state.getGarbage()[1]);
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
            getActivity().setTitle(getResources().getString(R.string.fragment_materials_diy_title) + ", "+sdf.format(date));

        } catch (Exception e) {
            Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
        }
    }

    private void enableButtons(Boolean state){
        photo_btn.setEnabled(state);
        calendar.setEnabled(state);
        save_btn.setEnabled(state);
        designation.setEnabled(state);
        weatherIcon.setEnabled(state);
        listMaterialsDIY.setEnabled(state);
        SysPhotos.setEnabled(state);
        checkBoxRequestMore.setEnabled(state);
        stock_qty.setEnabled(state);
        stock_request_qty.setEnabled(state);
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
        if (designation.getText().toString().equals("")) {
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.fragment_materials_diy_missing_designation), getActivity());
            designation.requestFocus();
        }else if(stock_qty.getText().toString().equals("")){
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.fragment_materials_diy_missing_stock_qty), getActivity());
            stock_qty.requestFocus();
        }else if(stock_request_qty.getText().toString().equals("") && checkBoxRequestMore.isChecked()){
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.fragment_materials_diy_missing_stock_qty), getActivity());
            stock_request_qty.requestFocus();
        } else {
            enableButtons(false);

            EntityQueue queue= new EntityQueue();
            queue.setMsgType("alertbox");
            queue.setMsgSuccess(getActivity().getResources().getString(R.string.fragment_materials_diy_submit_ok));
            queue.setMsgError("resquest");
            queue.setUrl(state.HostUrl + "api/index.php");
            queue.setTitle( getResources().getString(R.string.fragment_materials_diy_title));
            queue.setDescription( getResources().getString(R.string.fragment_materials_diy_description));

            ArrayList<EntityFields> fields = new ArrayList<>();
            EntityFields field = new EntityFields();
            field.setRequestVar("task");
            field.setValue("21");
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
            field.setValue(designation.getText().toString());
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("stock");
            field.setValue(stock_qty.getText().toString());
            fields.add(field);

            if(checkBoxRequestMore.isChecked()) {
                field = new EntityFields();
                field.setRequestVar("request");
                field.setValue("1");
                fields.add(field);
                field = new EntityFields();
                field.setRequestVar("requestqty");
                field.setValue(stock_request_qty.getText().toString());
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
                file.setTitle(getResources().getString(R.string.fragment_materials_diy_title));
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
                designation.setText("");
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
                designation.setText(state.getGarbage()[1]);
                stock_request_qty.setText(state.getGarbage()[3]);
                stock_qty.setText(state.getGarbage()[5]);
                if(!state.getGarbage()[4].equals("")) {
                    checkBoxRequestMore.setChecked(true);
                }else{
                    checkBoxRequestMore.setChecked(false);
                }
            }else{
                designation.setText("");
                stock_qty.setText("");
                stock_request_qty.setText("");
                checkBoxRequestMore.setChecked(false);
            }
            state.clearGarbage();
        }else if (Functions.isSuccess(response) && idv < (hardwareArrayList.size() - 1)) {
            designation.setText(hardwareArrayList.get(idv).getRecord1());
            stock_request_qty.setText(hardwareArrayList.get(idv).getRecord6());
            stock_qty.setText(hardwareArrayList.get(idv).getRecord2());

            if(hardwareArrayList.get(idv).getRecord3().equals("1")) {
                checkBoxRequestMore.setChecked(true);
            }else{
                checkBoxRequestMore.setChecked(false);
            }

            state.setGarbage(hardwareArrayList.get(idv).getRecord3(),1);
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
                designation.setText(state.getGarbage()[1]);
                if(state.getGarbage()[4].equals("1")) {
                    checkBoxRequestMore.setChecked(true);
                }else{
                    checkBoxRequestMore.setChecked(false);
                }
                state.clearGarbage();
            }
        }
        //ToDO
        // check if checkboxes are selected the same as before
        // check if fields are the same or if it has been changed
        if(state.getGarbage()[2].equals("hardwareAdd") && !state.getGarbage()[1].equals(designation.getText().toString()) && !state.getGarbage()[1].equals("")) {
            AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
            builder.setMessage( getActivity().getResources().getString(R.string.alertbox_resume_previous_text))
                    .setCancelable(false)
                    .setTitle(getActivity().getResources().getString(R.string.alertbox_title_question))
                    .setPositiveButton(getActivity().getResources().getString(R.string.alertbox_continue),
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    designation.setText(state.getGarbage()[1]);
                                    if(state.getGarbage()[4].equals("1")) {
                                        checkBoxRequestMore.setChecked(true);
                                    }else{
                                        checkBoxRequestMore.setChecked(false);
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
        queue.setTitle( getResources().getString(R.string.fragment_materials_diy_title));
        queue.setDescription( getResources().getString(R.string.fragment_materials_diy_description));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("21");
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
            designation.setText(state.getGarbage()[1]);
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
        listMaterialsDIY.setAdapter(hardwareAdapter);
        listMaterialsDIY.setLayoutManager(new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL, false));
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
                                                queue.setTitle( getResources().getString(R.string.fragment_materials_diy_title));
                                                queue.setDescription( getResources().getString(R.string.fragment_materials_diy_description));

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
                    record.setRecord2(dataobj.getString("stock"));
                    record.setRecord3(dataobj.getString("request"));
                    record.setRecord4(dataobj.getString("delivery"));
                    record.setRecord5(dataobj.getString("code"));
                    record.setRecord6(dataobj.getString("requestqty"));

                    recordArrayList.add(record);
                }
            }

        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice),getActivity().getResources().getString(R.string.error_ivalid_data),getActivity());
        }

        record = new LoadedRecord();
        record.setRecord5("-1");
        record.setRecord1(getActivity().getResources().getString(R.string.fragment_materials_diy_checkbox_order_one));
        record.setRecord2("");
        record.setRecord3("");
        record.setRecord4("");
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

            View view = inflater.inflate(R.layout.adapter_materials_diy, parent, false);
            holder = new MyViewHolder(view);

            return holder;
        }

        @Override
        public void onBindViewHolder(final HardwareAdapter.MyViewHolder holder, int position) {
            final LoadedRecord model = recordList.get(position);

            holder.text1.setText(recordList.get(position).getRecord1().replace("[newline]", System.getProperty("line.separator")));
            
            if(recordList.get(position).getRecord2() !=null){
                holder.text2.setText(recordList.get(position).getRecord2().replace("[newline]", System.getProperty("line.separator")));
            }else{
                holder.text2.setText("");
            }

            if (recordList.get(position).getRecord3() !=null){
                if(recordList.get(position).getRecord3().equals("1")) {
                    if (recordList.get(position).getRecord4().equals("")) {
                        holder.text3.setText(getActivity().getResources().getString(R.string.fragment_materials_diy_checkbox_order_one));
                    } else { // delivery date exists
                        holder.text3.setText(recordList.get(position).getRecord4());
                    }
                }else if(recordList.get(position).getRecord3().equals("2")){
                    holder.text3.setText(getActivity().getResources().getString(R.string.fragment_materials_diy_checkbox_delivered_one));
                }else  {
                    holder.text3.setText("- -");
                }
            }else{
                holder.text3.setText("- -");
            }

            holder.itemView.setSelected(selectedPos == position);
            holder.cardView.setBackgroundColor(model.isSelected() ? Color.GREEN : Color.WHITE);

            if(model.isSelected()){
                state.setGarbage(model.getRecord5(),0);
                state.clearPhotos2Upload("");
                LoadHardwareEntry(selectedPos, activity);

                if(recordList.get(position).getRecord5().equals("-1")){ // new record
                    checkBoxRequestMore.setChecked(false);
                    checkBoxRequestMore.setEnabled(false);
                }else{
                    checkBoxRequestMore.setEnabled(true);
                }
                designation.setEnabled(true);
                save_btn.setEnabled(true);
                photo_btn.setEnabled(true);
                save_btn.setImageResource(R.drawable.save);
                photo_btn.setImageResource(R.drawable.add_photo);
            }else if (!IsSelected){
                designation.setText("");
                state.setGarbage("",0);
                state.setGarbage("",1);
                checkBoxRequestMore.setEnabled(false);
                designation.setEnabled(false);
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
                    if( !state.getGarbage()[1].equals(designation.getText().toString()) && !state.getGarbage()[1].equals("") && (IsSelected && recordList.get(selectedPos).isSelected())) {
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
                                                designation.setText("");
                                                checkBoxRequestMore.setChecked(false);
                                                state.setGarbage("",0);
                                                state.setGarbage("",1);
                                                state.setGarbage("",2);
                                                state.setGarbage("",3);
                                                checkBoxRequestMore.setEnabled(true);
                                                designation.setEnabled(true);
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
                            checkBoxRequestMore.setEnabled(true);
                            designation.setEnabled(true);
                            save_btn.setEnabled(true);
                            photo_btn.setEnabled(true);
                            save_btn.setImageResource(R.drawable.save);
                            photo_btn.setImageResource(R.drawable.add_photo);
                        }else if (!IsSelected){
                            designation.setText("");
                            state.setGarbage("",0);
                            state.setGarbage("",1);
                            checkBoxRequestMore.setEnabled(false);
                            designation.setEnabled(false);
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

            TextView text2, text1, text3;
            CardView cardView;
            View view;

            public MyViewHolder(View itemView) {
                super(itemView);
                view=itemView;
                cardView = itemView.findViewById(R.id.adapter_materials_diy_card_view);
                text1 = itemView.findViewById(R.id.adapter_materials_diy_designation);
                text2 = itemView.findViewById(R.id.adapter_materials_diy_stock);
                text3 = itemView.findViewById(R.id.adapter_materials_diy_requested);
                
            }
        }
    }
}

