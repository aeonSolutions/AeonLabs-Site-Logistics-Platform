package construction.site.logistics.foreman.adapters;

import android.app.Activity;
import android.content.Context;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;
import java.util.List;

import construction.site.logistics.foreman.Fragments.FragmentSync;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.data.LoadedRecord;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityFiles;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.database.LocalDatabaseOperations;
import construction.site.logistics.foreman.data.state;


public class SyncQueueAdapter extends RecyclerView.Adapter<SyncQueueAdapter.MyViewHolder> {

    private LayoutInflater inflater;
    public List<EntityQueue> queueList;
    private int selectedPos = RecyclerView.NO_POSITION;
    private boolean IsSelected = false;
    private Activity activity;

    public SyncQueueAdapter(Activity _activity, List<EntityQueue> _queueList){
        this.activity=_activity;
        inflater = LayoutInflater.from(_activity);
        this.queueList = _queueList;

    }

    @Override
    public SyncQueueAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        View view = inflater.inflate(R.layout.adapter_occurences, parent, false);
        MyViewHolder holder = new MyViewHolder(view);
        return holder;
    }


    @Override
    public void onBindViewHolder(final SyncQueueAdapter.MyViewHolder holder, int position) {
        final EntityQueue queue = queueList.get(position);

        LocalDatabaseOperations localDatabaseOperations = new LocalDatabaseOperations(activity);
        List<EntityFields> fieldsList = LocalDatabaseOperations.getFields(queue);
        List<EntityFiles> filesList = LocalDatabaseOperations.getFiles(queue);
        String textOut="";

        textOut+=queue.getDescription() + System.getProperty("line.separator");
        holder.title.setText(queue.getTitle());
        holder.description.setText(textOut);

        holder.del.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                ImageView cb = (ImageView) v;
                int idv = cb.getId();
                LocalDatabaseOperations.delQueue(queue);
                queueList.remove(position);
                notifyItemRemoved(position);
                notifyItemRangeChanged(position,queueList.size());
            }
        } );

        holder.send.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View v) {
                ImageView cb = (ImageView) v;
                int idv = cb.getId();

                SendData sendData = new SendData(activity, null);
                sendData.addQueue(queue);
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
                    LocalDatabaseOperations.delQueue(queue);
                    queueList.remove(position);
                    notifyItemRemoved(position);
                    notifyItemRangeChanged(position,queueList.size());
                }else{
                    Functions.alertbox(activity.getResources().getString(R.string.commServer_submit_error),Functions.getErrorCode(activity,response), activity);
                }
            }
        } );


        holder.itemView.setSelected(selectedPos == position);

        holder.cardView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                notifyItemChanged(selectedPos);
                selectedPos = holder.getLayoutPosition();
                notifyItemChanged(selectedPos);
            }
        });
    }

    @Override
    public int getItemCount() {
        return queueList.size();
    }

    class MyViewHolder extends RecyclerView.ViewHolder{
        TextView description, title;
        ImageView del, send;
        View view;
        CardView cardView;

        public MyViewHolder(View itemView) {
            super(itemView);
            view=itemView;
            cardView = itemView.findViewById(R.id.adapter_sync_card_file);
            description = itemView.findViewById(R.id.adapter_sync_description);
            title = itemView.findViewById(R.id.adapter_sync_title);
            del = itemView.findViewById(R.id.adapter_sync_del);
            send = itemView.findViewById(R.id.adapter_sync_send);

        }
    }
}
