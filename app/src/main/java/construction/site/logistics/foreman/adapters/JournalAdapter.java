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
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.fragment.app.FragmentManager;
import androidx.recyclerview.widget.RecyclerView;



import java.util.ArrayList;

import construction.site.logistics.foreman.Fragments.FragmentJournalAdd;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.data.LoadedRecord;
import construction.site.logistics.foreman.data.state;


public class JournalAdapter extends RecyclerView.Adapter<JournalAdapter.MyViewHolder> {

    private LayoutInflater inflater;
    public static ArrayList<LoadedRecord> recordList;
    private int selectedPos = RecyclerView.NO_POSITION;
    private FragmentActivity activity;

    public JournalAdapter(FragmentActivity _activity, ArrayList<LoadedRecord> _recordList){

        inflater = LayoutInflater.from(_activity);
        recordList = _recordList;
        this.activity=_activity;
    }

    @Override
    public JournalAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        View view = inflater.inflate(R.layout.adapter_journal, parent, false);
        MyViewHolder holder = new MyViewHolder(view);

        return holder;
    }

    @Override
    public void onBindViewHolder(final JournalAdapter.MyViewHolder holder, int position) {
        final LoadedRecord model = recordList.get(position);

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
        holder.cardView.setBackgroundColor(model.isSelected() ? Color.CYAN : Color.WHITE);
        holder.cardView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

                state.setGarbage(model.getRecord5(),5);
                state.setGarbage("journalAdd",2);
                Fragment fragment = new FragmentJournalAdd();
                FragmentManager fragmentManager = activity.getSupportFragmentManager();
                fragmentManager.beginTransaction()
                        .replace(R.id.content_frame, fragment)
                        .addToBackStack(null)
                        .commit();
                fragmentManager.executePendingTransactions();
            }
        });

    }

    @Override
    public int getItemCount() {
        return recordList.size();
    }

    class MyViewHolder extends RecyclerView.ViewHolder{

        TextView text2, text1, text3;
        CardView cardView;
        View view;

        public MyViewHolder(View itemView) {
            super(itemView);
            view=itemView;
            cardView = itemView.findViewById(R.id.adapter_journal_card_view);
            text2 = itemView.findViewById(R.id.adapter_journal_text2);
            text1 = itemView.findViewById(R.id.adapter_journal_text1);
            text3 = itemView.findViewById(R.id.adapter_journal_text3);
        }

    }
}

