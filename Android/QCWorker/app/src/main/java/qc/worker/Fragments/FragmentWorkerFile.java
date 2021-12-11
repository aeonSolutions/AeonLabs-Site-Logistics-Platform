package qc.worker.Fragments;

        import android.app.Activity;
        import android.content.Context;
        import android.os.AsyncTask;
        import android.os.Bundle;
        import android.view.LayoutInflater;
        import android.view.View;
        import android.view.ViewGroup;
        import android.widget.Button;
        import android.widget.CheckBox;
        import android.widget.CompoundButton;
        import android.widget.EditText;
        import android.widget.ImageView;
        import android.widget.TextView;
        import android.widget.Toast;

        import androidx.annotation.Nullable;
        import androidx.fragment.app.Fragment;

        import com.bumptech.glide.load.engine.DiskCacheStrategy;
        import com.bumptech.glide.request.RequestOptions;
        import com.squareup.picasso.MemoryPolicy;
        import com.squareup.picasso.NetworkPolicy;
        import com.squareup.picasso.Picasso;

        import org.json.JSONException;
        import org.json.JSONObject;

        import java.net.URL;

        import qc.worker.Network.HttpRequestHandler;
        import qc.worker.Network.SendRequest;
        import qc.worker.R;
        import qc.worker.abstraction.CustomExceptionHandler;
        import qc.worker.abstraction.Functions;
        import qc.worker.abstraction.GlideApp;
        import qc.worker.data.LoadedRecord;
        import qc.worker.data.state;

public class FragmentWorkerFile extends Fragment {
    private EditText name,email, mobile, mobile112, nib, address;
    private CheckBox enableEdit;
    private Button send;
    private LoadedRecord workerData;
    private ImageView worker_photo;
    private TextView nfc;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActivity().setTitle(getResources().getString(R.string.fragment_workerfile_title));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
            Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        }
    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {

        workerData= new LoadedRecord();

        name.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    Functions.hideKeyboard(v, getActivity().getApplicationContext());
                }
            }
        });
        email.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    Functions.hideKeyboard(v, getActivity().getApplicationContext());
                }
            }
        });
        mobile.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    Functions.hideKeyboard(v, getActivity().getApplicationContext());
                }
            }
        });
        mobile112.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    Functions.hideKeyboard(v, getActivity().getApplicationContext());
                }
            }
        });
        nib.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    Functions.hideKeyboard(v, getActivity().getApplicationContext());
                }
            }
        });
        address.setOnFocusChangeListener(new View.OnFocusChangeListener() {
            @Override
            public void onFocusChange(View v, boolean hasFocus) {
                if (!hasFocus) {
                    Functions.hideKeyboard(v, getActivity().getApplicationContext());
                }
            }
        });

        enableEdit.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if(((CompoundButton) view).isChecked()){
                    System.out.println("Checked");
                } else {
                    System.out.println("Un-Checked");
                }
            }
        });

        enableEdit.setOnCheckedChangeListener(new CompoundButton.OnCheckedChangeListener() {
            public void onCheckedChanged(CompoundButton buttonView, boolean isChecked) {
                email.setEnabled(isChecked);
                mobile.setEnabled(isChecked);
                mobile112.setEnabled(isChecked);
                nib.setEnabled(isChecked);
                address.setEnabled(isChecked);
            }
        });

        send.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                String send_email="", send_nib="", send_mobile="", send_mobile112="", send_address="";
                if(!email.getText().toString().equals(workerData.getRecord2())){
                    send_email=email.getText().toString();
                }
                if(!mobile.getText().toString().equals(workerData.getRecord3())){
                    send_mobile=mobile.getText().toString();
                }
                if(!mobile112.getText().toString().equals(workerData.getRecord4())){
                    send_mobile112=mobile112.getText().toString();
                }
                if(!nib.getText().toString().equals(workerData.getRecord5())){
                    send_nib=nib.getText().toString();
                }
                if(!address.getText().toString().equals(workerData.getRecord6())){
                    send_address=address.getText().toString();
                }

                if(send_address.equals("") && send_email.equals("") && send_mobile.equals("") && send_mobile112.equals("") && send_nib.equals("") ){
                    Toast.makeText( getActivity().getApplicationContext(), getResources().getString(R.string.fragment_workerfile_nothing_changes), Toast.LENGTH_SHORT).show();
                }else{
                    new SendRequest(state.HostUrl + "api/api.php?task=workerfile&uuid=" + state.UUID+"&email="+send_email+"&mobile="+send_mobile+"&mobile112="+send_mobile112+"&nib="+send_nib+"&address="+send_address, getActivity(), getActivity()).execute();
                }
            }
        });

        new MakeServerCall(state.HostUrl + "api/api.php?task=workerfile&type=get&uuid=" + state.UUID , getActivity()).execute();

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_worker_file, container, false);
        name= v.findViewById(R.id.worker_file_name);
        email= v.findViewById(R.id.worker_file_email);
        mobile= v.findViewById(R.id.worker_file_mobile);
        mobile112= v.findViewById(R.id.worker_file_mobile112);
        nib= v.findViewById(R.id.worker_file_nib);
        address= v.findViewById(R.id.worker_file_address);
        enableEdit= v.findViewById(R.id.worker_file_change_details);
        send= v.findViewById(R.id.worker_file_send);
        worker_photo= v.findViewById(R.id.worker_file_photo);
        nfc= v.findViewById(R.id.worker_file_nfc);

        return v;
    }

    public class MakeServerCall extends AsyncTask<Void, Void, String> {

        private String url="";
        private Activity activity=null;

        public MakeServerCall (String url, Activity activity){
            this.url=url;
            this.activity=activity;
        }

        @Override
        protected String doInBackground(Void... params) {
            HttpRequestHandler requestHandler = new HttpRequestHandler();
            return requestHandler.sendGetRequest(this.url, this.activity);
        }

        @Override
        protected void onPostExecute(String response) {

            try {
                JSONObject jsonObject = new JSONObject(response);
                if (jsonObject.getString("error").equals("false")) {
                    try {
                        name.setText(jsonObject.getString("name"));
                        email.setText(jsonObject.getString("email"));
                        mobile.setText(jsonObject.getString("mobile"));
                        mobile112.setText(jsonObject.getString("mobile112"));
                        nib.setText(jsonObject.getString("nib"));
                        address.setText(jsonObject.getString("address"));
                        nfc.setText(getResources().getString(R.string.fragment_workerfile_worker_number) + " "+ jsonObject.getString("nfc").replaceAll("...(?!$)", "$0 "));

                        workerData.setRecord1(jsonObject.getString("name"));
                        workerData.setRecord2(jsonObject.getString("email"));
                        workerData.setRecord3(jsonObject.getString("mobile"));
                        workerData.setRecord4(jsonObject.getString("mobile112"));
                        workerData.setRecord5(jsonObject.getString("nib"));
                        workerData.setRecord6(jsonObject.getString("address"));

                        //encode the URL
                        URL url = new URL(state.HostUrl);
                        // URI uri = new URI(url.getProtocol(), url.getUserInfo(), url.getHost(), url.getPort(), url.getPath(), url.getQuery(), url.getRef());
                        String str= url.getProtocol()+"://"+url.getHost()+"/works/photos/"+jsonObject.getString("photo");
                       // Picasso.get().load(str).networkPolicy(NetworkPolicy.NO_CACHE).memoryPolicy(MemoryPolicy.NO_CACHE).into(worker_photo);

                        GlideApp.with(worker_photo.getContext())
                                .asBitmap()
                                .load(str)
                                .override(1080, 600)
                                .centerCrop()
                                .skipMemoryCache(true)  //No memory cache
                                .diskCacheStrategy(DiskCacheStrategy.NONE)   //No disk cache
                                .apply(RequestOptions.circleCropTransform())
                                .thumbnail(0.5f)
                                .into(worker_photo);
                    } catch (Exception e) {
                        Functions.SaveCrash(e, getActivity());

                        Toast.makeText(getActivity().getApplicationContext(), getResources().getString(R.string.error_ivalid_url), Toast.LENGTH_LONG).show();
                    }
                }else{
                    nfc.setText( getResources().getString(R.string.fragment_workerfile_ivalid_user));
                    Toast.makeText(getActivity().getApplicationContext(), Functions.getErrorCode(getActivity().getApplicationContext(),response), Toast.LENGTH_LONG).show();

                }
            } catch (JSONException e) {
                Functions.SaveCrash(e, getActivity());

                Toast.makeText(getActivity().getApplicationContext(), getResources().getString(R.string.error_ivalid_data), Toast.LENGTH_LONG).show();
                nfc.setText(getResources().getString(R.string.error_title));
            }

        }
    }

}