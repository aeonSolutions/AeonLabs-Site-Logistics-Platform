package construction.site.logistics.foreman.Fragments;

        import android.annotation.SuppressLint;
        import android.app.Activity;
        import android.app.AlertDialog;
        import android.content.DialogInterface;
        import android.content.Intent;
        import android.os.AsyncTask;
        import android.os.Bundle;
        import android.os.Handler;
        import android.os.Looper;
        import android.view.LayoutInflater;
        import android.view.View;
        import android.view.ViewGroup;
        import android.widget.ArrayAdapter;
        import android.widget.BaseAdapter;
        import android.widget.CheckBox;
        import android.widget.EditText;
        import android.widget.GridView;
        import android.widget.ImageView;
        import android.widget.Spinner;
        import android.widget.TextView;
        import android.widget.Toast;

        import androidx.annotation.Nullable;
        import androidx.fragment.app.Fragment;
        import androidx.fragment.app.FragmentManager;
        import androidx.fragment.app.FragmentTransaction;

        import com.bumptech.glide.Glide;
        import com.bumptech.glide.load.engine.DiskCacheStrategy;

        import org.json.JSONArray;
        import org.json.JSONException;
        import org.json.JSONObject;

        import java.io.File;
        import java.text.ParseException;
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
        import construction.site.logistics.foreman.data.LoadConfig;
        import construction.site.logistics.foreman.data.database.EntityFields;
        import construction.site.logistics.foreman.data.database.EntityFiles;
        import construction.site.logistics.foreman.data.database.EntityQueue;
        import construction.site.logistics.foreman.data.state;


public class FragmentLivraisonEdit extends Fragment {

    public String text = "";

    private ImageView calendar;
    private EditText notas, qtd, refdoc, outro;
    private Spinner material, units;
    private TextView dateTxt;
    private ImageView save_btn, btnAddPhoto;
    private GridView SysPhotos;

    private ArrayList<String> materialList = new ArrayList<>();
    private ArrayList<String> unitsList = new ArrayList<>();

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

        state.setCurrentNavItem(R.id.nav_livraison_add);

        materialList.clear();
        materialList.add("Acier");
        materialList.add("Béton");
        materialList.add("Bloc béton 9");
        materialList.add("Bloc béton 14");
        materialList.add("Bloc béton 19");
        materialList.add("Bois de Coffrage");
        materialList.add("Murs / Pre Murs");
        materialList.add("Pré Dalles");
        materialList.add("Silico Calcaire");
        materialList.add("Seuils");
        materialList.add("Stepoc");
        materialList.add("Treillis");
        materialList.add("Ytong");
        materialList.add("Hourdis");
        materialList.add("Outro");

        ArrayAdapter<String> materialAdapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_spinner_item, materialList);
        materialAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        material.setAdapter(materialAdapter);

        unitsList.clear();
        unitsList.add("ml");
        unitsList.add("m2");
        unitsList.add("m3");
        unitsList.add("Kg");
        unitsList.add("pc");
        ArrayAdapter<String> unitsAdapter = new ArrayAdapter<String>(getActivity(), android.R.layout.simple_spinner_item, unitsList);
        unitsAdapter.setDropDownViewResource(android.R.layout.simple_spinner_dropdown_item);
        units.setAdapter(unitsAdapter);

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
                state.setGarbage(refdoc.getText().toString(),1);
                state.setGarbage(material.getSelectedItem().toString(),2);
                state.setGarbage(outro.getText().toString(),3);
                state.setGarbage(qtd.getText().toString(),4);
                state.setGarbage(units.getSelectedItem().toString(),5);
                state.setGarbage(notas.getText().toString(),6);
                state.setGarbage("livraisonAdd",7);

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
        refdoc.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    Functions.hideKeyboard(v, getActivity().getApplicationContext());
                }
            }
        });
        outro.setOnFocusChangeListener(new View.OnFocusChangeListener() {
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

        btnAddPhoto.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                state.setGarbage(refdoc.getText().toString(),1);
                state.setGarbage(material.getSelectedItem().toString(),2);
                state.setGarbage(outro.getText().toString(),3);
                state.setGarbage(qtd.getText().toString(),4);
                state.setGarbage(units.getSelectedItem().toString(),5);
                state.setGarbage(notas.getText().toString(),6);
                state.setGarbage("livraisonAdd",7);

                Fragment fragment = new FragmentGallery();
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
        View v= inflater.inflate(R.layout.fragment_livraison_edit, container, false);
        refdoc=v.findViewById(R.id.fragment_livraison_refdoc);
        material=v.findViewById(R.id.fragment_livraison_material);
        outro=v.findViewById(R.id.fragment_livraison_outro);
        qtd=v.findViewById(R.id.fragment_livraison_qtd);
        units=v.findViewById(R.id.fragment_livraison_units);
        notas=v.findViewById(R.id.fragment_livraison_notas);
        SysPhotos=v.findViewById(R.id.fragment_livraison_add_galleryGrid);
        save_btn = v.findViewById(R.id.fragment_livraison_add_save_btn);
        calendar = v.findViewById(R.id.fragment_livraison_add_calendar);
        btnAddPhoto = v.findViewById(R.id.fragment_livraison_add_btn_take_photo);
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
        if(!state.getGarbage()[7].equals("livraisonAdd")) {
            state.clearPhotos2Upload("");
        }else{
            refdoc.setText(state.getGarbage()[1]);
            outro.setText(state.getGarbage()[3]);
            qtd.setText(state.getGarbage()[4]);
            notas.setText(state.getGarbage()[6]);
            for (int i=0; i<materialList.size();i++) {
                if (materialList.get(i).equals(state.getGarbage()[2])) {
                    material.setSelection(i);
                    break;
                }
            }
            for (int i=0; i<unitsList.size();i++) {
                if (unitsList.get(i).equals(state.getGarbage()[5])) {
                    units.setSelection(i);
                    break;
                }
            }
        }

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
            getActivity().setTitle(getResources().getString(R.string.fragment_livraison_add_title) + ", "+sdf.format(date));
        } catch (Exception e) {
            Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
        }

        LoadLivraison();
    }


    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        // todo use appropriate resultCode in your case

        if (requestCode == 1004) {
            if(resultCode == getActivity().RESULT_OK){
                SendData();
                return;
            }
        }else{
            super.onActivityResult(requestCode, resultCode, data);
        }
    }

    @SuppressLint("StaticFieldLeak")
    private void LoadLivraison(){
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
                }
            }
        }

        String response="";
        if(!state.getGarbage()[0].equals("")) {
            EntityQueue queue= new EntityQueue();
            queue.setMsgType("silent");
            queue.setMsgSuccess("response");
            queue.setMsgError("response");
            queue.setUrl(state.HostUrl + "api/index.php");
            queue.setTitle( getResources().getString(R.string.fragment_livraison_add_title));
            queue.setDescription( getResources().getString(R.string.fragment_livraison_add_description));

            ArrayList<EntityFields> fields = new ArrayList<>();
            EntityFields field = new EntityFields();
            field.setRequestVar("task");
            field.setValue("6");
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
        UpdateUI runnable = new UpdateUI();
        Long tsLong = System.currentTimeMillis()/1000;

        if (Functions.isSuccess(response)) {
            try {
                JSONObject jsonObject = new JSONObject(response);
                JSONArray dataArray = jsonObject.getJSONArray("data");
                JSONObject dataobj = dataArray.getJSONObject(0);
                runnable.setData(null, notas, dataobj.getString("notas"));
                getActivity().runOnUiThread(runnable);
                runnable.setData(null, refdoc, dataobj.getString("code"));
                getActivity().runOnUiThread(runnable);
                runnable.setData(null, qtd, dataobj.getString("qtd"));
                getActivity().runOnUiThread(runnable);
                for (int i=0; i<unitsList.size();i++) {
                    if (unitsList.get(i).equals(dataobj.getString("units"))) {
                        units.setSelection(i);
                    }
                }

                material.setSelection(materialList.size()-1);
                Boolean selected=true;
                for (int i=0; i<materialList.size();i++) {
                    if (materialList.get(i).equals(dataobj.getString("material"))) {
                        material.setSelection(i);
                        selected=false;
                    }
                }
                if(selected){
                    runnable.setData(null, outro, dataobj.getString("material"));
                    getActivity().runOnUiThread(runnable);
                }

                try {
                    state.date=dataobj.getString("data");
                    SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                    Date date=sdf.parse(state.date);
                    sdf = new SimpleDateFormat("dd 'de' MMMM 'de' yyyy");
                    getActivity().setTitle(getResources().getString(R.string.fragment_livraison_add_title) + ", "+sdf.format(date));

                } catch (ParseException e) {
                    Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
                }
                if(dataobj.has("photos")){
                    JSONArray dataSubArray = dataobj.getJSONArray("photos");
                    int test=dataSubArray.length();
                    photosListCode= new ArrayList<>();
                    for (int i = 0; i < test; i++) {
                        JSONObject dataSubObj = dataSubArray.getJSONObject(i);
                        String url=state.HostFilesUrl+"files/delivery/"+dataSubObj.getString("file");
                        photosListCode.add(dataSubObj.getString("code"));
                        albumList.add(GalleryMethods.mappingInbox("site", url, tsLong.toString(), GalleryMethods.converToTime( tsLong.toString()), null));
                    }
                }
            } catch (JSONException e) {
                Functions.SaveCrash(e, getActivity());
                Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice),getActivity().getResources().getString(R.string.commServer_connect_msg),getActivity());
            }
        }else if(!response.equals("new")) {
            Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
            return;
        }


        // check if fields are the same or if it has been changed
        if(state.getGarbage()[7].equals("livraisonAdd") && (
                !state.getGarbage()[6].equals(notas.getText().toString()) ||
                        !state.getGarbage()[1].equals(refdoc.getText().toString()) ||
                        !state.getGarbage()[2].equals(material.getSelectedItem().toString()) ||
                        !state.getGarbage()[3].equals(outro.getText().toString()) ||
                        !state.getGarbage()[4].equals(qtd.getText().toString()) ||
                        !state.getGarbage()[5].equals(units.getSelectedItem().toString())
        ) ) {
            AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
            builder.setMessage( getActivity().getResources().getString(R.string.alertbox_resume_previous_text))
                    .setCancelable(false)
                    .setTitle(getActivity().getResources().getString(R.string.alertbox_title_question))
                    .setPositiveButton(getActivity().getResources().getString(R.string.alertbox_continue),
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    notas.setText(state.getGarbage()[6]);
                                    refdoc.setText(state.getGarbage()[1]);
                                    qtd.setText(state.getGarbage()[4]);
                                    for (int i=0; i<unitsList.size();i++) {
                                        if (unitsList.get(i).equals(state.getGarbage()[5])) {
                                            units.setSelection(i);
                                        }
                                    }
                                    material.setSelection(materialList.size()-1);
                                    Boolean selected=true;
                                    for (int i=0; i<materialList.size();i++) {
                                        if (materialList.get(i).equals(state.getGarbage()[2])) {
                                            material.setSelection(i);
                                            selected=false;
                                        }
                                    }
                                    if(selected){
                                        outro.setText(state.getGarbage()[3]);
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
            albumList.add(GalleryMethods.mappingInbox("site", f, tsLong.toString(), GalleryMethods.converToTime( tsLong.toString()), null));
        }

        if(state.gallerySelection.size()>0){
            AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
            builder.setMessage( getActivity().getResources().getString(R.string.alertbox_add_selected_photo_msg))
                    .setCancelable(false)
                    .setTitle(getActivity().getResources().getString(R.string.alertbox_title_result))
                    .setPositiveButton(getActivity().getResources().getString(R.string.alertbox_continue),
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    for (Iterator<String> it = state.gallerySelection.iterator(); it.hasNext(); ) {
                                        String f = it.next();
                                        photosListCode.add("new");
                                        albumList.add(GalleryMethods.mappingInbox("site", f, tsLong.toString(), GalleryMethods.converToTime( tsLong.toString()), null));
                                        state.setPhotos2Upload(f);
                                    }
                                    state.gallerySelection.clear();
                                    SysAlbumAdapter adapter = new SysAlbumAdapter(getActivity(), albumList);
                                    SysPhotos.setAdapter(adapter);
                                }
                            })
                    .setNegativeButton(getActivity().getResources().getString(R.string.alertbox_cancel),
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    state.gallerySelection.clear();
                                    SysAlbumAdapter adapter = new SysAlbumAdapter(getActivity(), albumList);
                                    SysPhotos.setAdapter(adapter);
                                    dialog.cancel();
                                }
                            });
            AlertDialog alert = builder.create();
            alert.show();
        }else{
            SysAlbumAdapter adapter = new SysAlbumAdapter(getActivity(), albumList);
            SysPhotos.setAdapter(adapter);
        }
    }


    public class SysAlbumAdapter extends BaseAdapter {
        private Activity activity;
        private ArrayList<HashMap<String, String>> data;
        private SingleAlbumViewHolder holder = null;

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
                holder = new SingleAlbumViewHolder();
                convertView = LayoutInflater.from(activity).inflate(R.layout.fragment_album_single_row, parent, false);
                holder.galleryImage = convertView.findViewById(R.id.galleryImage);
                holder.checkBox = convertView.findViewById(R.id.ImageCheckBox);
                convertView.setTag(holder);
            } else {
                holder = (SingleAlbumViewHolder) convertView.getTag();
            }

            holder.galleryImage.setId(position);
            holder.checkBox.setId(position);
            if(photosListCode.get(position).equals("new")){
                holder.checkBox.setTextAppearance(getActivity(), R.style.checkbox_gallery);
            }else{
                holder.checkBox.setTextAppearance(getActivity(), R.style.checkbox_database);
            }


            String str=data.get(position).get(GalleryMethods.KEY_PATH);

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
                    state.setGarbage(refdoc.getText().toString(),1);
                    state.setGarbage(material.getSelectedItem().toString(),2);
                    state.setGarbage(outro.getText().toString(),3);
                    state.setGarbage(qtd.getText().toString(),4);
                    state.setGarbage(units.getSelectedItem().toString(),5);
                    state.setGarbage(notas.getText().toString(),6);

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
                                                queue.setTitle( getResources().getString(R.string.fragment_livraison_add_title));
                                                queue.setDescription( getResources().getString(R.string.fragment_livraison_add_description));

                                                ArrayList<EntityFields> fields = new ArrayList<>();
                                                EntityFields field = new EntityFields();
                                                field.setRequestVar("task");
                                                field.setValue("6");
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
                                                LoadLivraison();
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

    @SuppressLint("StaticFieldLeak")
    private void SendData(){
        if (refdoc.getText().toString().equals("")) {
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.fragment_livraison_add_missing_refdoc), getActivity());
            refdoc.requestFocus();
        } else if (material.getSelectedItem().toString().equals("Outro") && outro.getText().toString().equals("")) {
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.fragment_livraison_add_missing_material), getActivity());
            outro.requestFocus();
        } else if (qtd.getText().toString().equals("")) {
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.fragment_livraison_add_missing_qtd), getActivity());
            qtd.requestFocus();
        } else {
            EntityQueue queue= new EntityQueue();
            queue.setMsgType("alertbox");
            queue.setMsgSuccess(getActivity().getResources().getString(R.string.fragment_livraison_add_submit_ok));
            queue.setMsgError("response");
            queue.setUrl(state.HostUrl + "api/index.php");
            queue.setTitle( getResources().getString(R.string.fragment_livraison_add_title));
            queue.setDescription( getResources().getString(R.string.fragment_livraison_add_description));

            ArrayList<EntityFields> fields = new ArrayList<>();
            EntityFields field = new EntityFields();
            field.setRequestVar("task");
            field.setValue("6");
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
            field.setRequestVar("date");
            field.setValue(state.date);
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("refdoc");
            field.setValue(refdoc.getText().toString());
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("qtd");
            field.setValue(qtd.getText().toString());
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("units");
            field.setValue(units.getSelectedItem().toString());
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("notas");
            field.setValue(notas.getText().toString());
            fields.add(field);

            if(material.getSelectedItem().toString().equals("Outro")){
                field = new EntityFields();
                field.setRequestVar("material");
                field.setValue(outro.getText().toString());
                fields.add(field);
            }else{
                field = new EntityFields();
                field.setRequestVar("material");
                field.setValue(material.getSelectedItem().toString());
                fields.add(field);
            }

            if (!state.getGarbage()[0].equals("")) {
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
                file.setTitle(getResources().getString(R.string.fragment_livraison_add_title));
                files.add(file);
            }

            SendData sendData = new SendData(getActivity(), getActivity());
            sendData.addQueue(queue);
            sendData.addFields(fields);
            sendData.addfFiles(files);
            sendData.setEncryption(true, "AES128");
            sendData.setWaitForCode(true);
            sendData.setloadMainPage(true);
            sendData.setEnableQueue(true);
            sendData.send();
            if(!sendData.getError()) {
                state.clearGarbage();
            }
        }
    }
}

