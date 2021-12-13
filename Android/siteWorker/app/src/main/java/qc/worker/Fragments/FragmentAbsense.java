package qc.worker.Fragments;

import android.content.Context;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.CheckBox;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;


import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.Calendar;
import java.util.Date;
import java.util.GregorianCalendar;

import qc.worker.Network.HttpRequestHandler;
import qc.worker.Network.SendRequest;
import qc.worker.R;
import qc.worker.abstraction.CustomExceptionHandler;
import qc.worker.abstraction.Functions;
import qc.worker.data.state;
import android.widget.DatePicker;

public class FragmentAbsense extends Fragment {
    Button send;
    EditText reason;
    CheckBox start_date, end_date;
    SimpleDateFormat simpleDateFormat;
    DatePicker datepicker_start, datepicker_end;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActivity().setTitle(getResources().getString(R.string.fragment_absense_title));
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }
    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        simpleDateFormat = new SimpleDateFormat("yyyy-MM-dd");
        send.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                SimpleDateFormat format = new SimpleDateFormat("yyyy-MM-dd");
                Date sdate=null;
                Date edate=null;

                try {
                    sdate = format.parse("1970-01-01");
                    edate = format.parse("1970-01-01");
                } catch (ParseException e) {
                    e.printStackTrace();
                }
                try {
                    sdate = format.parse(start_date.getText().toString());
                    edate = format.parse(end_date.getText().toString());
                } catch (ParseException e) {
                    Functions.SaveCrash(e, getActivity());
                }
                if(sdate.getTime()< System.currentTimeMillis()){
                    Toast.makeText( getActivity().getApplicationContext(), getResources().getString(R.string.fragment_absense_invalid_start_date), Toast.LENGTH_SHORT).show();
                }else if(sdate.getTime()> edate.getTime()){
                    Toast.makeText( getActivity().getApplicationContext(), getResources().getString(R.string.fragment_absense_invalid_end_date), Toast.LENGTH_SHORT).show();
                }else if(reason.getText().toString().equals("")){
                    Toast.makeText( getActivity().getApplicationContext(), getResources().getString(R.string.fragment_absense_invalid_reason), Toast.LENGTH_SHORT).show();
                    reason.requestFocus();
                }else{
                    new SendRequest(state.HostUrl + "api/api.php?task=absense&uuid=" + state.UUID+"&motif="+reason.getText()+"&sdate="+start_date.getText().toString()+"&edate="+end_date.getText().toString(),  getActivity(), getActivity()).execute();
                }
            }
        });

        Calendar calendar = Calendar.getInstance();
        int year = calendar.get(Calendar.YEAR);
        int month = calendar.get(Calendar.MONTH);
        int day = calendar.get(Calendar.DAY_OF_MONTH);

        datepicker_start.init(year, month, day, new DatePicker.OnDateChangedListener() {
            @Override
            public void onDateChanged(DatePicker datePicker, int i, int i1, int i2) {
                Calendar calendar = new GregorianCalendar(i, i1, i2);
                start_date.setChecked(true);
                start_date.setText(simpleDateFormat.format(calendar.getTime()));
            }
        });

        datepicker_end.init(year, month, day, new DatePicker.OnDateChangedListener() {
            @Override
            public void onDateChanged(DatePicker datePicker, int i, int i1, int i2) {
                Calendar calendar = new GregorianCalendar(i, i1, i2);
                end_date.setChecked(true);
                end_date.setText(simpleDateFormat.format(calendar.getTime()));
            }
        });

        reason.setOnFocusChangeListener(new View.OnFocusChangeListener() {
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
        View v= inflater.inflate(R.layout.fragment_absense, container, false);
        send=v.findViewById(R.id.absense_button);
        reason=v.findViewById(R.id.absense_reason);
        start_date=v.findViewById(R.id.absense_start_date);
        end_date=v.findViewById(R.id.absense_end_date);
        datepicker_start = (DatePicker) v.findViewById(R.id.date_picker_start);
        datepicker_end = (DatePicker) v.findViewById(R.id.date_picker_end);

        return v;
    }


}