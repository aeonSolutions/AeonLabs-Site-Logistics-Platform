package construction.site.logistics.foreman.Fragments;

import android.annotation.SuppressLint;
import android.app.Activity;

import android.graphics.Color;
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
import androidx.cardview.widget.CardView;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;

import construction.site.logistics.foreman.Network.HttpRequestHandler;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.Functions;

import construction.site.logistics.foreman.data.LoadConfig;
import construction.site.logistics.foreman.data.LoadedRecord;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.state;

public class FragmentRegieView extends Fragment {

    private RecyclerView listregie;
    private ImageView calendar, save_btn;
    private TextView date_txt;
    private EditText note;

    private String code="";

    ArrayList<LoadedRecord> recordArrayList;
    private String response="";
    private RegieViewAdapter regieViewAdapter;



    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }
    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {

        calendar.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                state.setGarbage("RegieCalendar",0);
                Fragment fragment = new FragmentCalendar();
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
        View v= inflater.inflate(R.layout.fragment_regie_view, container, false);

        calendar = v.findViewById(R.id.fragment_regie_view_calendar);
        save_btn = v.findViewById(R.id.fragment_regie_view_save_btn);
        note = v.findViewById(R.id.fragment_regie_view_notes);
        listregie = v.findViewById(R.id.fragment_regie_view_list);
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();

        Functions.checkLocation(getActivity());

        LoadRegie();

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
            getActivity().setTitle(getResources().getString(R.string.fragment_regie_view_title) + ", "+sdf.format(date));
        } catch (Exception e) {
            Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
        }
    }


    @SuppressLint("StaticFieldLeak")
    private void SendData(){
        if (regieViewAdapter==null){
            return;
        }
        code="";
        for (LoadedRecord model : regieViewAdapter.recordList) {
            if (model.isSelected()) {
                code = model.getRecord2();
            }
        }

        if(code.equals("") ){
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice),getActivity().getResources().getString(R.string.alertbox_need_select_item),getActivity());
        }else if (note.getText().toString().equals("")) {
            Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice), getActivity().getResources().getString(R.string.fragment_regie_view_missing_description), getActivity());
            note.requestFocus();
        } else {

            EntityQueue queue= new EntityQueue();
            queue.setMsgType("alertbox");
            queue.setMsgSuccess(getActivity().getResources().getString(R.string.fragment_regie_view_added));
            queue.setMsgError("response");
            queue.setUrl(state.HostUrl + "api/index.php");
            queue.setTitle( getResources().getString(R.string.fragment_regie_view_title));
            queue.setDescription( getResources().getString(R.string.fragment_regie_view_description));

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
            field.setValue("edit");
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("date");
            field.setValue(state.date);
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("cod");
            field.setValue(code);
            fields.add(field);

            field = new EntityFields();
            field.setRequestVar("nota");
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
            sendData.setloadMainPage(false);
            sendData.setEnableQueue(true);
            sendData.send();
        }
    }


    @SuppressLint("StaticFieldLeak")
    private void LoadRegie(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_log_attendance_title));
        queue.setDescription( getResources().getString(R.string.fragment_log_attendance_description));

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
            recordArrayList = getInfoJournal(response);
            regieViewAdapter = new RegieViewAdapter(getActivity(),recordArrayList);
            listregie.setAdapter(regieViewAdapter);
            listregie.setLayoutManager(new LinearLayoutManager(getActivity().getApplicationContext(), RecyclerView.VERTICAL, false));
        }else {
            Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
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
                    record.setRecord1( getActivity().getResources().getString(R.string.fragment_regie_view_hour_start)+" "+dataobj.getString("hora")+"  "+getActivity().getResources().getString(R.string.fragment_regie_view_hour_end)+" "+dataobj.getString("horafim"));
                    record.setRecord2(dataobj.getString("code"));
                    record.setRecord3(dataobj.getString("workerlist"));
                    record.setRecord4(dataobj.getString("notas"));

                    recordArrayList.add(record);
                }
            }
        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
            Toast.makeText(getActivity(), getActivity().getResources().getString(R.string.error_ivalid_data), Toast.LENGTH_SHORT).show();
        }

        return recordArrayList;
    }

    public class RegieViewAdapter extends RecyclerView.Adapter<RegieViewAdapter.MyViewHolder> {

        private LayoutInflater inflater;
        public  ArrayList<LoadedRecord> recordList =null;
        private int selectedPos = RecyclerView.NO_POSITION;
        private boolean IsSelected = false;
        public MyViewHolder holder;

        public RegieViewAdapter(Activity _activity, ArrayList<LoadedRecord> _recordList){

            inflater = LayoutInflater.from(_activity);
            this.recordList = _recordList;

        }

        @Override
        public RegieViewAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

            View view = inflater.inflate(R.layout.adapter_regie_view, parent, false);
            holder = new MyViewHolder(view);

            return holder;
        }

        @Override
        public void onBindViewHolder(final RegieViewAdapter.MyViewHolder holder, int position) {
            final LoadedRecord model = recordList.get(position);

            holder.title.setText(model.getRecord1().replace("[newline]", System.getProperty("line.separator")));
            if(model.getRecord3() !=null){
                holder.text2.setText(model.getRecord3().replace("[newline]", System.getProperty("line.separator")));
            }else{
                holder.text2.setText("");
            }
            if(model.getRecord4() !=null){
                holder.text1.setText(model.getRecord4().replace("[newline]", System.getProperty("line.separator")));
            }else{
                holder.text1.setText("");
            }

            holder.itemView.setSelected(selectedPos == position);
            holder.cardView.setBackgroundColor(model.isSelected() ? Color.GREEN : Color.WHITE);

            holder.cardView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    notifyItemChanged(selectedPos);
                    selectedPos = holder.getLayoutPosition();
                    notifyItemChanged(selectedPos);

                    if ((!IsSelected && model.isSelected()==false) || (IsSelected && model.isSelected())){
                        model.setSelected(!model.isSelected());
                        holder.cardView.setBackgroundColor(model.isSelected() ? Color.GREEN : Color.WHITE);
                        IsSelected=!IsSelected;
                    }
                    if(model.isSelected()){
                        state.setGarbage(model.getRecord2(),0);
                        note.setText(model.getRecord4());
                    }
                }
            });
        }

        @Override
        public int getItemCount() {
            return recordList.size();
        }

        class MyViewHolder extends RecyclerView.ViewHolder{

            TextView text2, text1, title;
            CardView cardView;
            View view;

            public MyViewHolder(View itemView) {
                super(itemView);
                view=itemView;
                cardView = itemView.findViewById(R.id.adapter_regie_view_card);
                text2 = itemView.findViewById(R.id.adapter_regie_view_text2);
                text1 = itemView.findViewById(R.id.adapter_regie_view_text1);
                title = itemView.findViewById(R.id.adapter_regie_view_title);
            }
        }
    }
}

