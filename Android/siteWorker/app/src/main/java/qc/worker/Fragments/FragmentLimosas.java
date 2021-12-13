package qc.worker.Fragments;

        import android.app.Activity;
        import android.content.Context;
        import android.net.Uri;
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

        import com.github.chrisbanes.photoview.PhotoView;
        import com.squareup.picasso.MemoryPolicy;
        import com.squareup.picasso.NetworkPolicy;
        import com.squareup.picasso.Picasso;

        import org.json.JSONException;
        import org.json.JSONObject;

        import java.io.IOException;
        import java.net.URI;
        import java.net.URL;

        import qc.worker.Network.HttpRequestHandler;
        import qc.worker.R;
        import qc.worker.abstraction.CustomExceptionHandler;
        import qc.worker.abstraction.Functions;
        import qc.worker.abstraction.GeoLocation;
        import qc.worker.data.Result;
        import qc.worker.data.model.LoggedInUser;
        import qc.worker.data.state;


public class FragmentLimosas extends Fragment {

    TextView site;
    ImageView qrcode;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActivity().setTitle(getResources().getString(R.string.fragment_limosas_title));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
            Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        }
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_limosas, container, false);
        site= v.findViewById(R.id.limosa_site);
        qrcode= v.findViewById(R.id.limosa_qrcode);
        return v;
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        GeoLocation gps= new GeoLocation();
        if(gps.getLocation(getActivity().getApplicationContext()) == null){
            Toast.makeText(getActivity().getApplicationContext(), getResources().getString(R.string.error_location_disabled), Toast.LENGTH_LONG).show();
            // Intent intent = new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS);
            // startActivity(intent);
        }else {
            new MakeServerCall(state.HostUrl + "api/api.php?task=limosa&uuid=" + state.UUID + "&lat=" + gps.getLatitude() + "&lon=" + gps.getLongitude(), getActivity()).execute();
        }
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
                        site.setText(jsonObject.getString("site"));
                        //encode the URL
                        URL url = new URL(state.HostUrl);
                       // URI uri = new URI(url.getProtocol(), url.getUserInfo(), url.getHost(), url.getPort(), url.getPath(), url.getQuery(), url.getRef());
                        String str= url.getProtocol()+"://"+url.getHost()+"/works/files/limosas/qrcode/"+jsonObject.getString("qrcode");
                        Picasso.get().load(str).networkPolicy(NetworkPolicy.NO_CACHE).memoryPolicy(MemoryPolicy.NO_CACHE).into(qrcode);

                    } catch (Exception e) {
                        Functions.SaveCrash(e, getActivity());

                        Toast.makeText(getActivity().getApplicationContext(), getResources().getString(R.string.error_ivalid_url), Toast.LENGTH_LONG).show();
                    }
                }else{

                    if(jsonObject.getString("message").equals("site_not_found")){
                        site.setText( getResources().getString(R.string.fragment_limosas_nosite));
                        Toast.makeText(getActivity().getApplicationContext(), getResources().getString(R.string.fragment_limosas_nosite), Toast.LENGTH_LONG).show();

                    } else  if(jsonObject.getString("message").equals("limosa_not_found")){
                        site.setText(getResources().getString(R.string.fragment_limosas_nolimosa));
                        Toast.makeText(getActivity().getApplicationContext(), getResources().getString(R.string.fragment_limosas_nolimosa), Toast.LENGTH_LONG).show();
                    }
                }
            } catch (JSONException e) {
                Functions.SaveCrash(e, getActivity());

                Toast.makeText(getActivity().getApplicationContext(), getResources().getString(R.string.error_ivalid_data), Toast.LENGTH_LONG).show();
                site.setText(getResources().getString(R.string.error_title));
            }

        }
    }

}