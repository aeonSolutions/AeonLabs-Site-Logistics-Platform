package construction.site.logistics.foreman.Fragments;

import android.annotation.SuppressLint;

import android.os.AsyncTask;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;


import com.applandeo.materialcalendarview.EventDay;
import com.applandeo.materialcalendarview.listeners.OnDayClickListener;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.List;

import construction.site.logistics.foreman.Network.HttpRequestHandler;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.DrawableUtils;
import construction.site.logistics.foreman.abstraction.Functions;

import construction.site.logistics.foreman.abstraction.GalleryMethods;
import construction.site.logistics.foreman.data.LoadConfig;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.state;

public class FragmentCalendar extends Fragment {

    private com.applandeo.materialcalendarview.CalendarView materialCalendar;
    private String SelectedDate="";
    private ImageView save_btn;
    private String lang="en";

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }


    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        getActivity().setTitle(getResources().getString(R.string.fragment_calendar_title)+": "+state.date);

        materialCalendar.setOnDayClickListener(new OnDayClickListener() {
            @Override
            public void onDayClick(EventDay eventDay) {
                Calendar calendar = eventDay.getCalendar();
                Date date = calendar.getTime();
                SimpleDateFormat format1 = new SimpleDateFormat("yyyy-MM-dd");
                String inActiveDate = format1.format(date);
                if(!inActiveDate.equals("")){
                    try {
                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                        Date date2=sdf.parse(state.date);
                        if(lang.equals("pt")){
                            sdf = new SimpleDateFormat("dd 'de' MMMM 'de' yyyy");

                        }else if(lang.equals("fr")){
                            sdf = new SimpleDateFormat("dd MMMM yyyy");
                        }else{
                            sdf = new SimpleDateFormat("MMMM dd',' yyyy");
                        }
                        getActivity().setTitle(getResources().getString(R.string.fragment_calendar_title) + ", "+sdf.format(date2));

                    } catch (Exception e) {
                        Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
                    }

                    Toast.makeText(getActivity(), getResources().getString(R.string.fragment_calendar_selected_date) + ": " + inActiveDate, Toast.LENGTH_LONG).show();
                    SelectedDate = inActiveDate;
                    state.date=SelectedDate;
                }
            }
        });
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_calendar, container, false);
        materialCalendar = v.findViewById(R.id.fragment_calendar_calendarView);
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();
        Functions.checkLocation(getActivity());

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
            getActivity().setTitle(getResources().getString(R.string.fragment_calendar_title) + ", "+sdf.format(date));

        } catch (Exception e) {
            Toast.makeText(getActivity(), e.toString(), Toast.LENGTH_SHORT).show();
        }


        materialCalendar.requestLayout();
        if(state.getGarbage()[0].equals("RegieCalendar")){
            LoadRecord();
        }
        if(state.getGarbage()[0].equals("journalCalendar")){
            LoadRecord();
        }

    }

    @SuppressLint("StaticFieldLeak")
    private void LoadRecord(){
        String response="";
        if(!state.getGarbage()[0].equals("")) {
            EntityQueue queue= new EntityQueue();
            queue.setMsgType("none");
            queue.setMsgSuccess("request");
            queue.setMsgError("request");
            queue.setUrl(state.HostUrl + "api/index.php");
            queue.setTitle( getResources().getString(R.string.fragment_occurrences_add_title));
            queue.setDescription( getResources().getString(R.string.fragment_occurrences_add_description));

            ArrayList<EntityFields> fields = new ArrayList<>();
            EntityFields field = new EntityFields();
            field.setRequestVar("task");
            field.setValue("16");
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
            if(state.getGarbage()[0].equals("RegieCalendar")){
                field.setValue("regie");
            }
            if(state.getGarbage()[0].equals("journalCalendar")){
                field.setValue("journal");
            }
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
        }
        if (Functions.isSuccess(response)) {
            try {
                JSONObject jsonObject = new JSONObject(response);
                JSONArray dataArray = jsonObject.getJSONArray("data");

                int test=dataArray.length();

                List<EventDay> events = new ArrayList<>();

                for (int i = 0; i < test; i++) {
                    JSONObject dataobj = dataArray.getJSONObject(i);

                    try {
                        SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd");
                        Date date=sdf.parse(dataobj.getString("date"));
                        Calendar calendar = Calendar.getInstance();
                        calendar.setTime(date);
                        if(state.getGarbage()[0].equals("RegieCalendar")){
                            events.add(new EventDay(calendar, DrawableUtils.getCircleDrawableWithText(getActivity(), "R")));
                        }
                        if(state.getGarbage()[0].equals("journalCalendar")){
                            events.add(new EventDay(calendar, DrawableUtils.getCircleDrawableWithText(getActivity(), "J")));
                        }
                    } catch (ParseException e) {
                        Functions.SaveCrash(e, getActivity());
                    }
                }
                materialCalendar.setEvents(events);
            } catch (JSONException e) {
                Functions.SaveCrash(e, getActivity());
                Functions.alertbox(getActivity().getResources().getString(R.string.alertbox_title_notice),getActivity().getResources().getString(R.string.commServer_connect_msg),getActivity());
            }
        }else {
            Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
            return;
        }
    }
}
