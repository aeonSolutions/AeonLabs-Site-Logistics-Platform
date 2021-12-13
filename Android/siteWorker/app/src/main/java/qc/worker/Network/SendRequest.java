package qc.worker.Network;

import android.app.Activity;
import android.content.Context;
import android.os.AsyncTask;
import android.widget.Toast;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.fragment.app.FragmentTransaction;

import qc.worker.Fragments.FragmentHome;
import qc.worker.R;
import qc.worker.abstraction.Functions;


public class SendRequest extends AsyncTask<Void, Void, String> {

    private String url="";
    private Context context=null;
    private Activity activity=null;
    private FragmentActivity fragmentActivity=null;

    public SendRequest (String url, Activity activity, FragmentActivity fragmentActivity){
        this.url=url;
        this.activity=activity;
        this.fragmentActivity=fragmentActivity;
    }
    @Override
    protected String doInBackground(Void... params) {
        Functions.showSimpleProgressDialog(this.activity, this.activity.getResources().getString(R.string.commServer_connect_title_msg), this.activity.getResources().getString(R.string.commServer_connect_msg),false);

        HttpRequestHandler requestHandler = new HttpRequestHandler();
        return requestHandler.sendGetRequest(this.url, this.activity);
    }
    @Override
    protected void onPostExecute(String response) {

        if (Functions.isSuccess(response)) {
            Toast.makeText( this.activity, this.activity.getResources().getString(R.string.commServer_submit_ok) , Toast.LENGTH_SHORT).show();
            Fragment fragment = new FragmentHome();
            FragmentTransaction fragmentTransaction =  this.fragmentActivity.getSupportFragmentManager().beginTransaction();
            fragmentTransaction.replace(R.id.content_frame, fragment);
            fragmentTransaction.commit();
        } else {
            Toast.makeText( this.activity, this.activity.getResources().getString(R.string.commServer_submit_error), Toast.LENGTH_SHORT).show();
        }
        Functions.removeSimpleProgressDialog();
    }
}
