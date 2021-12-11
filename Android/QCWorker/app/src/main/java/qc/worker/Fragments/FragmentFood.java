package qc.worker.Fragments;

import android.app.Activity;
import android.app.AlertDialog;
import android.content.Context;
import android.content.DialogInterface;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.inputmethod.InputMethodManager;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.util.ArrayList;

import qc.worker.Network.HttpRequestHandler;
import qc.worker.Network.SendRequest;
import qc.worker.R;
import qc.worker.abstraction.CustomExceptionHandler;
import qc.worker.abstraction.Functions;
import qc.worker.data.LoadedRecord;
import qc.worker.data.state;

public class FragmentFood extends Fragment {

    private TextView restaurant;
    private Spinner meals;
    private Button send;
    private ArrayList<LoadedRecord> record;
    private int i;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActivity().setTitle(getResources().getString(R.string.fragment_food_title));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
            Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        }
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        new LoadFood(state.HostUrl + "api/api.php?task=food&type=get&uuid=" + state.UUID, getActivity()).execute();
        send.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                i= (int) meals.getSelectedItemId();
                if((record.get(i).getRecord1().equals("-1"))){
                    AlertDialog.Builder builder = new AlertDialog.Builder(getActivity());
                    builder.setMessage(getResources().getString(R.string.fragment_food_alertbox_no_meal))
                            .setCancelable(false)
                            .setTitle(getResources().getString(R.string.alertbox_title_question))
                            .setPositiveButton(getResources().getString(R.string.alertbox_continue),
                                    new DialogInterface.OnClickListener() {
                                        public void onClick(DialogInterface dialog, int id) {
                                            new SendRequest(state.HostUrl + "api/api.php?task=food&type=request&uuid=" + state.UUID + "&meal=" + record.get(i).getRecord1(), getActivity(), getActivity()).execute();
                                        }
                                    });
                    AlertDialog alert = builder.create();
                    alert.show();
                }else{
                    new SendRequest(state.HostUrl + "api/api.php?task=food&type=request&uuid=" + state.UUID + "&meal=" + record.get(i).getRecord1(), getActivity(), getActivity()).execute();
                }
            }
        });
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_food, container, false);
        restaurant= v.findViewById(R.id.food_restaurant_assignment);
        meals=v.findViewById(R.id.food_spinner);
        send=v.findViewById(R.id.food_button);

        return v;
    }


    public class LoadFood extends AsyncTask<Void, Void, String> {

        private String url="";
        private Activity activity=null;

        public LoadFood (String url, Activity activity){
            this.url=url;
            this.activity=activity;
        }

        @Override
        protected String doInBackground(Void... params) {
            Functions.showSimpleProgressDialog(getActivity(), getResources().getString(R.string.commServer_connect_title_msg), getResources().getString(R.string.commServer_connect_msg),false);

            HttpRequestHandler requestHandler = new HttpRequestHandler();
            return requestHandler.sendGetRequest(this.url, this.activity);
        }

        @Override
        protected void onPostExecute(String response) {

            if (Functions.isSuccess(response)) {
                record = LoadData(response);
                ArrayList<String> list = new ArrayList<String>();
                for (LoadedRecord model : record) {
                    list.add(model.getRecord2());
                }
                ArrayAdapter<String> spinnerAdapter = new ArrayAdapter<String>( getActivity().getApplicationContext(), R.layout.spinner_item, list);
                spinnerAdapter.setDropDownViewResource(R.layout.spinner_dropdown_item);
                meals.setAdapter(spinnerAdapter);
                meals.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> parentView, View selectedItemView, int position, long id) {
                        // your code here
                        if (meals.getSelectedItemId() != AdapterView.INVALID_ROW_ID) {
                        }
                    }
                    @Override
                    public void onNothingSelected(AdapterView<?> parentView) {
                        // your code here
                    }
                });
            } else {
                Toast.makeText( getActivity().getApplicationContext(), Functions.getErrorCode( getActivity().getApplicationContext(), response), Toast.LENGTH_SHORT).show();
            }
            Functions.removeSimpleProgressDialog();

        }
    }

    public ArrayList<LoadedRecord> LoadData(String response) {
        ArrayList<LoadedRecord> arrayList = new ArrayList<>();
        try {
            JSONObject jsonObject = new JSONObject(response);
            if (jsonObject.getString("error").equals("false")) {
                if(jsonObject.getString("place").equals("no_place")){
                    restaurant.setText(getResources().getString(R.string.fragment_food_no_assign));
                }else {
                    restaurant.setText(jsonObject.getString("place"));
                }

                LoadedRecord record;
                if (jsonObject.has("meals")) {
                    JSONArray dataArray = jsonObject.getJSONArray("meals");
                    int test = dataArray.length();

                    for (int i = 0; i < test; i++) {
                        record = new LoadedRecord();
                        JSONObject dataobj = dataArray.getJSONObject(i);
                        record.setRecord1(dataobj.getString("code"));
                        record.setRecord2(dataobj.getString("name"));

                        arrayList.add(record);
                    }
                }
                record = new LoadedRecord();
                record.setRecord1("-1");
                record.setRecord2(getResources().getString(R.string.fragment_food_no_eat));

                arrayList.add(record);
            }

        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
            Functions.alertbox(getResources().getString(R.string.error_title), e.toString(), getActivity().getApplicationContext());
        }

        return arrayList;
    }

}