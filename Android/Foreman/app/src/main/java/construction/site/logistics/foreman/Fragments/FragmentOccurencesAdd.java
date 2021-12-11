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
import android.widget.BaseAdapter;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.GridView;
import android.widget.ImageView;
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


public class FragmentOccurencesAdd extends Fragment {

    public String text = "";
    private String filename="";

    private ImageView calendar;
    private EditText notas;
    private ImageView save_btn, btnAddPhoto, btnTranslate;
    private GridView SysPhotos;

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

        state.setCurrentNavItem(R.id.nav_occurrences_add);

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
                state.setGarbage("occurencesAdd",2);

                Fragment fragment = new FragmentCalendar();
                FragmentManager fragmentManager = getActivity().getSupportFragmentManager();
                fragmentManager.beginTransaction()
                        .replace(R.id.content_frame, fragment)
                        .addToBackStack(null)
                        .commit();
                fragmentManager.executePendingTransactions();
            }
        });

        btnTranslate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                TranslateDescricao();
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

        btnAddPhoto.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                state.setGarbage(notas.getText().toString(),1);
                state.setGarbage("occurencesAdd",2);

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
        View v= inflater.inflate(R.layout.fragment_occurrences_add, container, false);
        notas=v.findViewById(R.id.fragment_occurences_add_notas);
        SysPhotos=v.findViewById(R.id.fragment_occurences_add_galleryGrid);
        save_btn = v.findViewById(R.id.fragment_occurences_add_save_btn);
        calendar = v.findViewById(R.id.fragment_occurences_add_calendar);
        btnAddPhoto = v.findViewById(R.id.fragment_occurences_add_btn_take_photo);
        btnTranslate = v.findViewById(R.id.fragment_occurences_add_btn_translate);
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

        if(!state.getGarbage()[2].equals("occurencesAdd")) {
            state.clearPhotos2Upload("");
        }else{
            notas.setText(state.getGarbage()[1]);
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
            getActivity().setTitle(getResources().getString(R.string.fragment_occurrences_add_title) + ", "+sdf.format(date));

        } catch (Exception e) {
            Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
        }

        LoadOccurence();

    }




    @Override
    public void onActivityResult(int requestCode, int resultCode, Intent data) {
        // todo use appropriate resultCode in your case

        if (requestCode == 1004) {
            if(resultCode == getActivity().RESULT_OK){
                Functions.removeSimpleProgressDialog();
                SendData();
                return;
            }
        }else{
            super.onActivityResult(requestCode, resultCode, data);
        }
    }

    @SuppressLint("StaticFieldLeak")
    private void LoadOccurence(){
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
            queue.setTitle( getResources().getString(R.string.fragment_occurrences_add_title));
            queue.setDescription( getResources().getString(R.string.fragment_occurrences_add_description));

            ArrayList<EntityFields> fields = new ArrayList<>();
            EntityFields field = new EntityFields();
            field.setRequestVar("task");
            field.setValue("7");
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

                try {
                    state.date=dataobj.getString("data");
                    SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                    Date date=sdf.parse(state.date);
                    sdf = new SimpleDateFormat("dd 'de' MMMM 'de' yyyy");
                    getActivity().setTitle(getResources().getString(R.string.fragment_occurrences_add_title) + ", "+sdf.format(date));

                } catch (ParseException e) {
                    Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
                }
                if(dataobj.has("photos")){
                    JSONArray dataSubArray = dataobj.getJSONArray("photos");
                    int test=dataSubArray.length();
                    photosListCode= new ArrayList<>();
                    for (int i = 0; i < test; i++) {
                        JSONObject dataSubObj = dataSubArray.getJSONObject(i);
                        String url=state.HostUrl+"files/ocurrences/"+dataSubObj.getString("file");
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
        if(state.getGarbage()[2].equals("occurencesAdd") && !state.getGarbage()[1].equals(notas.getText().toString())) {
            AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
            builder.setMessage( getActivity().getResources().getString(R.string.alertbox_resume_previous_text))
                    .setCancelable(false)
                    .setTitle(getActivity().getResources().getString(R.string.alertbox_title_question))
                    .setPositiveButton(getActivity().getResources().getString(R.string.alertbox_continue),
                            new DialogInterface.OnClickListener() {
                                public void onClick(DialogInterface dialog, int id) {
                                    notas.setText(state.getGarbage()[1]);
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

            HashMap<String, String> song = new HashMap<String, String>();

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
                    state.setGarbage(notas.getText().toString(),1);

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
                                                queue.setTitle( getResources().getString(R.string.fragment_occurrences_add_title));
                                                queue.setDescription( getResources().getString(R.string.fragment_occurrences_add_description));

                                                ArrayList<EntityFields> fields = new ArrayList<>();
                                                EntityFields field = new EntityFields();
                                                field.setRequestVar("task");
                                                field.setValue("7");
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
                                                LoadOccurence();
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
    private void TranslateDescricao() {
        class UpdateUI implements Runnable {
            private String str;
            public void setData(String _str) { this.str = _str; }
            public void run() {
                notas.setText(this.str);
            }
        }

        Functions.showSimpleProgressDialog(getActivity(), getResources().getString(R.string.commServer_connect_msg),getResources().getString(R.string.fragment_occurrences_do_translation),false);
        new AsyncTask<Void, Void, String>(){
            protected String doInBackground(Void[] params) {
                String str =  notas.getText().toString();
                Integer idx = str.indexOf("\n _________________________\ntraduction en français ci-dessous:\n _________________________ \n");
                if ( idx >0) {
                    str=str.substring(0,idx);
                    UpdateUI runnable = new UpdateUI();
                    runnable.setData(str);
                    getActivity().runOnUiThread(runnable);
                }
                HttpRequestHandler requestHandler = new HttpRequestHandler();
                return requestHandler.sendGetRequest("http://translate.googleapis.com/translate_a/single?client=gtx&sl=pt&tl=fr&dt=t&q=" +str, getActivity());
            }
            protected void onPostExecute(String response) {
                Functions.removeSimpleProgressDialog();  //will remove progress dialog
                try {
                    JSONArray dataArray = new JSONArray(response);
                    dataArray = new JSONArray(dataArray.get(0).toString());
                    dataArray = new JSONArray(dataArray.get(0).toString());
                    notas.setText(notas.getText().toString()+"\n _________________________\ntraduction en français ci-dessous:\n _________________________ \n"+ dataArray.get(0).toString());
                } catch (JSONException e) {
                    Functions.SaveCrash(e, getActivity());
                    Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice),getActivity().getResources().getString(R.string.error_ivalid_data),getActivity());
                }
            }
        }.execute();
    }

    @SuppressLint("StaticFieldLeak")
    private void SendData(){
        if (notas.getText().toString().equals("")) {
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.fragment_occurrences_add_missing_description), getActivity());
            notas.requestFocus();
        } else if (state.ReadSmartCardID.equals("")) {
            Functions.showSimpleProgressDialog(getActivity(), getActivity().getResources().getString(R.string.fragment_regie_start_present_card_title), getActivity().getResources().getString(R.string.fragment_regie_start_present_card_message), false);
        } else {
            EntityQueue queue= new EntityQueue();
            queue.setMsgType("alertbox");
            queue.setMsgSuccess(getActivity().getResources().getString(R.string.fragment_occurrences_add_submit_ok));
            queue.setMsgError("response");
            queue.setUrl(state.HostUrl + "api/index.php");
            queue.setTitle( getResources().getString(R.string.fragment_occurrences_add_title));
            queue.setDescription( getResources().getString(R.string.fragment_occurrences_add_description));

            ArrayList<EntityFields> fields = new ArrayList<>();
            EntityFields field = new EntityFields();
            field.setRequestVar("task");
            field.setValue("7");
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

            if (!state.getGarbage()[0].equals("")) {
                field = new EntityFields();
                field.setRequestVar("cod");
                field.setValue(state.getGarbage()[0]);
                fields.add(field);
            }

            field = new EntityFields();
            field.setRequestVar("snc");
            field.setValue(state.ReadSmartCardID);
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("notas");
            field.setValue(notas.getText().toString());
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("language");
            field.setValue(state.getCurrentLanguage());
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("date");
            field.setValue(state.date);
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
            sendData.setloadMainPage(true);
            sendData.setEnableQueue(true);
            sendData.send();
            if(!sendData.getError()) {
                state.clearGarbage();
            }
        }
    }
}
