package construction.site.logistics.foreman.Fragments;

import android.annotation.SuppressLint;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.net.Uri;
import android.os.AsyncTask;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.core.content.FileProvider;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import com.google.android.material.floatingactionbutton.FloatingActionButton;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.util.ArrayList;
import java.util.List;

import construction.site.logistics.foreman.BuildConfig;
import construction.site.logistics.foreman.Network.HttpRequestHandler;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.abstraction.GalleryMethods;
import construction.site.logistics.foreman.adapters.OcurrencesAdapter;
import construction.site.logistics.foreman.data.LoadedRecord;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.state;

public class FragmentProjectView extends Fragment {
    private RecyclerView list;
    private ArrayList<LoadedRecord> recordArrayList;
    private OcurrencesAdapter ocurrencesAdapter;
    private ImageView continue_btn;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        getActivity().setTitle(getResources().getString(R.string.fragment_project_view_title));

        continue_btn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
 

                Boolean selected=false;
                for (LoadedRecord model : OcurrencesAdapter.recordArrayList) {
                    if (model.isSelected()) {
                        selected=true;
                        state.setGarbage(model.getRecord4(),0);
                    }
                }
                if(!selected){
                    Functions.alertbox(getResources().getString(R.string.alertbox_title_notice),getResources().getString(R.string.fragment_list_select_one),getActivity());
                }else {

                    //load file and open acrobat reader
                    DownloadFile();
                }
            }
        });
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_occurences_view, container, false);
        list = v.findViewById(R.id.fragment_occurences_view_list);
        continue_btn = v.findViewById(R.id.fragment_ccurences_view_save_btn);
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();
        Functions.checkLocation(getActivity());

        state.setGarbage("",0);
        LoadProjectPlans();

    }

    private String GetFileExtension(String filename){
        return filename.substring(filename.indexOf(".")+1);
    }

    @SuppressLint("StaticFieldLeak")
    private void DownloadFile(){

        Functions.showSimpleProgressDialog(getActivity(), getActivity().getResources().getString(R.string.commServer_connect_title_msg), getActivity().getResources().getString(R.string.commServer_connect_msg),false);

        new AsyncTask<Void, Void, String>(){
            protected String doInBackground(Void[] params) {
                String filename=getActivity().getApplicationContext().getFilesDir() + "/project."+ GetFileExtension(state.getGarbage()[0]);
                File file = new File(filename);
                if(file.exists()) {
                    file.delete();
                }
                HttpRequestHandler requestHandler = new HttpRequestHandler();
                return requestHandler.getHttpFile(state.HostFilesUrl + "files/project/" + state.getGarbage()[0], filename, getActivity());

            }
            protected void onPostExecute(String response) {

                if (Functions.isSuccess(response)) {
                    Functions.removeSimpleProgressDialog();  //will remove progress dialog
                    String filename=getActivity().getApplicationContext().getFilesDir() + "/project."+ GetFileExtension(state.getGarbage()[0]);
                    open_file(filename);

                }else {
                    Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
                }

                Functions.removeSimpleProgressDialog();
            }
        }.execute();
    }

    public void open_file(String filename) {

        Intent intent = new Intent(Intent.ACTION_VIEW);
        String mimeType = GetFileExtension(state.getGarbage()[0]).equals("pdf") ? "application/pdf" : "application/acad";
        File file= new File (filename);
        file.setWritable(true);

        Uri uri = FileProvider.getUriForFile(getActivity(), BuildConfig.APPLICATION_ID, file);
        //Uri uri = Uri.parse("content://gestao.de.obra.provider/" + filename);
        intent.setDataAndType(uri, mimeType);
        intent.putExtra(Intent.EXTRA_STREAM, uri);
        intent.setFlags(Intent.FLAG_GRANT_READ_URI_PERMISSION | Intent.FLAG_ACTIVITY_CLEAR_TOP | Intent.FLAG_ACTIVITY_NEW_TASK);

        List<ResolveInfo> resInfoList = getActivity().getPackageManager().queryIntentActivities(intent, PackageManager.MATCH_DEFAULT_ONLY);
        for (ResolveInfo resolveInfo : resInfoList) {
            String packageName = resolveInfo.activityInfo.packageName;
            getActivity().grantUriPermission(packageName, uri, Intent.FLAG_GRANT_WRITE_URI_PERMISSION | Intent.FLAG_GRANT_READ_URI_PERMISSION);
        }
        startActivity(intent);

    }

    @SuppressLint("StaticFieldLeak")
    private void LoadProjectPlans(){
        EntityQueue queue= new EntityQueue();
        queue.setMsgType("silent");
        queue.setMsgSuccess("response");
        queue.setMsgError("response");
        queue.setUrl(state.HostUrl + "api/index.php");
        queue.setTitle( getResources().getString(R.string.fragment_project_view_title));
        queue.setDescription( getResources().getString(R.string.fragment_project_view_description));

        ArrayList<EntityFields> fields = new ArrayList<>();
        EntityFields field = new EntityFields();
        field.setRequestVar("task");
        field.setValue("8");
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
            ocurrencesAdapter = new OcurrencesAdapter(getActivity(),getInfo(response));
            list.setAdapter(ocurrencesAdapter);
            list.setLayoutManager(new LinearLayoutManager(getActivity(), RecyclerView.VERTICAL, false));
        }else {
            Toast.makeText(getActivity(), Functions.getErrorCode(getActivity(),response), Toast.LENGTH_SHORT).show();
        }
    }

    public ArrayList<LoadedRecord> getInfo(String response) {
        ArrayList<LoadedRecord> recordArrayList = new ArrayList<>();
        try {
            JSONObject jsonObject = new JSONObject(response);
            if (jsonObject.getString("error").equals("false")) {
                JSONArray dataArray = jsonObject.getJSONArray("data");
                int test=dataArray.length();
                for (int i = 0; i < test; i++) {
                    LoadedRecord record = new LoadedRecord();
                    JSONObject dataobj = dataArray.getJSONObject(i);
                    record.setRecord1(dataobj.getString("description"));
                    record.setRecord2(dataobj.getString("code"));
                    record.setRecord3(dataobj.getString("data"));
                    record.setRecord4(dataobj.getString("file"));
                    recordArrayList.add(record);
                }
            }
        } catch (JSONException e) {
            Functions.SaveCrash(e, getActivity());
        }

        return recordArrayList;
    }
}
