package qc.worker.Fragments;

import android.content.Context;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import java.util.ArrayList;

import qc.worker.Network.HttpRequestHandler;
import qc.worker.Network.SendRequest;
import qc.worker.R;
import qc.worker.abstraction.CustomExceptionHandler;
import qc.worker.abstraction.Functions;
import qc.worker.data.LoadedRecord;
import qc.worker.data.state;

public class FragmentSuggestion extends Fragment {

    EditText reason;
    Button send;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActivity().setTitle(getResources().getString(R.string.fragment_suggestion_title));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
            Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        }
    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        send.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(reason.getText().toString().equals("")){
                    Toast.makeText( getActivity().getApplicationContext(), getResources().getString(R.string.fragment_suggestion_invalid_reason), Toast.LENGTH_SHORT).show();
                    reason.requestFocus();
                }else{
                    new SendRequest(state.HostUrl + "api/api.php?task=suggestion&uuid=" + state.UUID+"&motif="+reason.getText(),  getActivity(), getActivity()).execute();
                }
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
        View v= inflater.inflate(R.layout.fragment_suggestion, container, false);
        reason= v.findViewById(R.id.suggestion_msg);
        send=v.findViewById(R.id.suggestion_button);
        return v;
    }


}