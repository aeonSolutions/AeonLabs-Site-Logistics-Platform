package qc.worker.Fragments;

import android.animation.ObjectAnimator;
import android.app.Activity;
import android.content.Context;
import android.content.res.Resources;
import android.graphics.drawable.Drawable;
import android.os.AsyncTask;
import android.os.Bundle;
import android.os.Handler;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.view.animation.DecelerateInterpolator;
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.squareup.picasso.MemoryPolicy;
import com.squareup.picasso.NetworkPolicy;
import com.squareup.picasso.Picasso;

import org.json.JSONException;
import org.json.JSONObject;

import java.net.URL;

import qc.worker.Network.HttpRequestHandler;
import qc.worker.R;
import qc.worker.abstraction.CustomExceptionHandler;
import qc.worker.abstraction.Functions;
import qc.worker.abstraction.GeoLocation;
import qc.worker.data.state;

public class FragmentPerformance extends Fragment {

    TextView value;
    ProgressBar progress;
    private int progressBarStatus = 0;
    private Handler progressBarHandler = new Handler();

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActivity().setTitle(getResources().getString(R.string.fragment_performance_title));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
            Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        }
    }


    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v = inflater.inflate(R.layout.fragment_performance, container, false);
        value= v.findViewById(R.id.performance_value);
        progress= v.findViewById(R.id.performance_progressbar);

        return v;
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
            new MakeServerCall(state.HostUrl + "api/api.php?task=performance&uuid=" + state.UUID , getActivity()).execute();
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
                        value.setText(Integer.toString(jsonObject.getInt("performance")) + "%");
                        int amount = (int) jsonObject.getInt("performance");

                        if (android.os.Build.VERSION.SDK_INT >= 11) {
                            // will update the "progress" propriety of seekbar until it reaches progress
                            ObjectAnimator animation = ObjectAnimator.ofInt(progress, "progress", amount);
                            animation.setDuration(5000); // 0.5 second
                            animation.setInterpolator(new DecelerateInterpolator());
                            animation.start();
                        } else{
                            progress.setProgress(amount); // no animation on Gingerbread or lower
                        }

                    } catch (Exception e) {
                        Functions.SaveCrash(e, getActivity());

                        Toast.makeText(getActivity().getApplicationContext(), getResources().getString(R.string.error_ivalid_url), Toast.LENGTH_LONG).show();
                        value.setText("");
                    }
                }
            } catch (JSONException e) {
                Functions.SaveCrash(e, getActivity());

                Toast.makeText(getActivity().getApplicationContext(), getResources().getString(R.string.error_ivalid_data), Toast.LENGTH_LONG).show();
                value.setText("");
            }

        }
    }
}