package construction.site.logistics.foreman.Fragments;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.LinearLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import java.util.List;

import construction.site.logistics.foreman.BuildConfig;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.adapters.OcurrencesAdapter;
import construction.site.logistics.foreman.adapters.SyncQueueAdapter;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityFiles;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.database.LocalDatabaseOperations;
import construction.site.logistics.foreman.data.state;


public class FragmentSync extends Fragment {

    private Button delAll, sendAll;
    private RecyclerView list;
    private Boolean error=true;
    private List<EntityQueue> queueList;
    private SyncQueueAdapter syncQueueAdapter;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }


    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        delAll.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

            }
        });
        sendAll.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                LocalDatabaseOperations localDatabaseOperations = new LocalDatabaseOperations(getActivity());
                queueList = LocalDatabaseOperations.getQueue();
                for(int i=0;i<queueList.size();i++){
                    SendData sendData = new SendData(getActivity(), null);
                    List<EntityFields> fieldsList = LocalDatabaseOperations.getFields(queueList.get(i));
                    List<EntityFiles> filesList = LocalDatabaseOperations.getFiles(queueList.get(i));

                    sendData.addQueue(queueList.get(i));
                    sendData.addFields(fieldsList);
                    if(filesList.size()>0){
                        sendData.addfFiles(filesList);
                    }
                    sendData.setEncryption(true, "AES128");
                    sendData.setWaitForCode(true);
                    sendData.setloadMainPage(false);
                    sendData.setEnableQueue(false);
                    sendData.send();
                    String response= sendData.getResponse();
                    if (Functions.isSuccess(response)) {
                        LocalDatabaseOperations.delQueue(queueList.get(i));
                    }else{
                        Functions.alertbox(getActivity().getResources().getString(R.string.commServer_submit_error),Functions.getErrorCode(getActivity(),response), getActivity());
                    }
                }
                loadQueue();
            }
        });

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_sync, container, false);
        delAll = v.findViewById(R.id.fragment_sync_del_all);
        sendAll = v.findViewById(R.id.fragment_sync_send_all);
        list = v.findViewById(R.id.fragment_sync_list);
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();
        getActivity().setTitle(getResources().getString(R.string.fragment_sync_title));
        Functions.checkLocation(getActivity());

        loadQueue();
    }

    public void loadQueue(){
        LocalDatabaseOperations localDatabaseOperations = new LocalDatabaseOperations(getActivity());
        queueList = LocalDatabaseOperations.getQueue();
        if (queueList.size()>0) {
            syncQueueAdapter = new SyncQueueAdapter(getActivity(), queueList);
            list.setAdapter(syncQueueAdapter);
            list.setLayoutManager(new LinearLayoutManager(getActivity(), RecyclerView.VERTICAL, false));
        }else {
            Toast.makeText(getActivity(), "no requests queued", Toast.LENGTH_SHORT).show();
        }
    }
}