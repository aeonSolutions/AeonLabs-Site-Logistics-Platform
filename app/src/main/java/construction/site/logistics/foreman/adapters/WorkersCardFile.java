package construction.site.logistics.foreman.adapters;


import android.app.Activity;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;
import com.bumptech.glide.load.engine.DiskCacheStrategy;

import java.util.ArrayList;

import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.data.LoadedRecord;


public class WorkersCardFile extends RecyclerView.Adapter<WorkersCardFile.MyViewHolder> {

    private LayoutInflater inflater;
    public static ArrayList<LoadedRecord> recordList;
    private int selectedPos = RecyclerView.NO_POSITION;
    private Boolean clicable=false;
    private Activity activity;

    public WorkersCardFile(Activity _activity, ArrayList<LoadedRecord> _recordList, Boolean _clicable){

        inflater = LayoutInflater.from(_activity);
        recordList = _recordList;
        this.clicable=_clicable;
        this.activity=_activity;
    }

    @Override
    public WorkersCardFile.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        View view = inflater.inflate(R.layout.adapter_workers_card_file, parent, false);
        MyViewHolder holder = new MyViewHolder(view);

        return holder;
    }

    @Override
    public void onBindViewHolder(final WorkersCardFile.MyViewHolder holder, int position) {
        final LoadedRecord model = recordList.get(position);

        Glide.with(activity)
                .asBitmap()
                .placeholder(R.drawable.loading)
                .error(R.drawable.loading_error_image)
                .load(recordList.get(position).getRecord4())
                .centerCrop()
                .skipMemoryCache(true)  //No memory cache
                .diskCacheStrategy(DiskCacheStrategy.NONE)   //No disk cache
                .thumbnail(0.5f)
                .into(holder.photo);

        holder.text1.setText(recordList.get(position).getRecord1().replace("[newline]", System.getProperty("line.separator")));
        if(recordList.get(position).getRecord2() !=null){
            holder.text2.setText(recordList.get(position).getRecord2().replace("[newline]", System.getProperty("line.separator")));
        }else{
            holder.text2.setText("");
        }
        if(recordList.get(position).getRecord3() !=null){
            holder.text3.setText(recordList.get(position).getRecord3().replace("[newline]", System.getProperty("line.separator")));
        }else{
            holder.text3.setText("");
        }

        holder.itemView.setSelected(selectedPos == position);
        holder.cardView.setBackgroundColor(model.isSelected() ? Color.GREEN : Color.WHITE);
        if (this.clicable) {
            holder.cardView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    notifyItemChanged(selectedPos);
                    selectedPos = holder.getLayoutPosition();
                    notifyItemChanged(selectedPos);

                    model.setSelected(!model.isSelected());
                    holder.cardView.setBackgroundColor(model.isSelected() ? Color.GREEN : Color.WHITE);
                }
            });
        }
    }

    @Override
    public int getItemCount() {
        return recordList.size();
    }

    class MyViewHolder extends RecyclerView.ViewHolder{

        TextView text2, text1, text3;
        ImageView photo;
        CardView cardView;
        View view;

        public MyViewHolder(View itemView) {
            super(itemView);
            view=itemView;
            cardView = itemView.findViewById(R.id.adapter_sync_card_file);
            text2 = itemView.findViewById(R.id.adapter_workers_card_file_text2);
            text1 = itemView.findViewById(R.id.adapter_workers_card_file_text1);
            text3 = itemView.findViewById(R.id.adapter_workers_card_file_text3);
            photo = itemView.findViewById(R.id.adapter_sync_send);
        }

    }
}
