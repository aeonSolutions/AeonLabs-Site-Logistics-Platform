package qc.worker.Fragments;

        import android.app.Activity;
        import android.content.Context;
        import android.os.AsyncTask;
        import android.os.Bundle;
        import android.view.LayoutInflater;
        import android.view.View;
        import android.view.ViewGroup;
        import android.view.inputmethod.InputMethodManager;
        import android.widget.AdapterView;
        import android.widget.ArrayAdapter;
        import android.widget.Button;
        import android.widget.EditText;
        import android.widget.Spinner;
        import android.widget.TextView;
        import android.widget.Toast;

        import androidx.annotation.Nullable;
        import androidx.fragment.app.Fragment;
        import androidx.fragment.app.FragmentTransaction;

        import com.squareup.picasso.MemoryPolicy;
        import com.squareup.picasso.NetworkPolicy;
        import com.squareup.picasso.Picasso;

        import org.json.JSONArray;
        import org.json.JSONException;
        import org.json.JSONObject;

        import java.net.URL;
        import java.util.ArrayList;

        import qc.worker.Network.HttpRequestHandler;
        import qc.worker.Network.SendRequest;
        import qc.worker.R;
        import qc.worker.abstraction.CustomExceptionHandler;
        import qc.worker.abstraction.Functions;
        import qc.worker.data.LoadedRecord;
        import qc.worker.data.state;

public class FragmentLodging extends Fragment {

    EditText reason;
    Spinner lodge;
    TextView lodged;
    Button send;
    ArrayList<LoadedRecord> record;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActivity().setTitle(getResources().getString(R.string.fragment_lodging_title));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
            Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        }

    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        new LoadLodging(state.HostUrl + "api/api.php?task=lodging&type=get&uuid=" + state.UUID, getActivity()).execute();
        send.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                int i = (int) lodge.getSelectedItemId();
                InputMethodManager in = (InputMethodManager) getActivity().getSystemService(Context.INPUT_METHOD_SERVICE);
                in.hideSoftInputFromWindow(reason.getApplicationWindowToken(),InputMethodManager.HIDE_NOT_ALWAYS);
                if(record.get(i).getRecord2().equals(lodged.getText())){
                    Toast.makeText( getActivity().getApplicationContext(), getResources().getString(R.string.fragment_lodging_invalid_selection), Toast.LENGTH_SHORT).show();
                    lodge.requestFocus();
                }else if(reason.getText().toString().equals("")){
                    Toast.makeText( getActivity().getApplicationContext(), getResources().getString(R.string.fragment_lodging_invalid_reason), Toast.LENGTH_SHORT).show();
                    reason.requestFocus();
                }else{
                    new SendRequest(state.HostUrl + "api/api.php?task=lodging&type=request&uuid=" + state.UUID+"&lodge="+record.get(i).getRecord1()+"&motif="+reason.getText(), getActivity(), getActivity()).execute();
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
        View v= inflater.inflate(R.layout.fragment_lodging, container, false);
        reason= v.findViewById(R.id.lodging_reason);
        lodge= v.findViewById(R.id.lodging_spinner);
        lodged=v.findViewById(R.id.lodging_lodged);
        send=v.findViewById(R.id.lodging_button);
        return v;
    }

    public class LoadLodging extends AsyncTask<Void, Void, String> {

        private String url="";
        private Activity activity=null;

        public LoadLodging (String url, Activity activity){
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
                lodge.setAdapter(spinnerAdapter);
                lodge.setOnItemSelectedListener(new AdapterView.OnItemSelectedListener() {
                    @Override
                    public void onItemSelected(AdapterView<?> parentView, View selectedItemView, int position, long id) {
                        // your code here
                        if (lodge.getSelectedItemId() != AdapterView.INVALID_ROW_ID) {
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
                if(jsonObject.getString("current").equals("no_lodge")){
                    lodged.setText(getResources().getString(R.string.fragment_lodging_no_assign));
                }else {
                    lodged.setText(jsonObject.getString("current"));
                }
                JSONArray dataArray = jsonObject.getJSONArray("lodges");
                int test=dataArray.length();
                for (int i = 0; i < test; i++) {
                    LoadedRecord record = new LoadedRecord();
                    JSONObject dataobj = dataArray.getJSONObject(i);
                    record.setRecord1(dataobj.getString("code"));
                    if(dataobj.getString("code").equals("-1")){
                        record.setRecord2( getResources().getString(R.string.fragment_lodging_no_places));
                    }else{
                        record.setRecord2(dataobj.getString("name"));
                    }
                    arrayList.add(record);
                }
            }

        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
            Functions.alertbox(getResources().getString(R.string.error_title), e.toString(), getActivity().getApplicationContext());
        }

        return arrayList;
    }


}