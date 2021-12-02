package construction.site.logistics.foreman.adapters;

import android.content.Context;
import android.graphics.Color;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;

import androidx.cardview.widget.CardView;
import androidx.recyclerview.widget.RecyclerView;

import java.util.ArrayList;

import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.data.LoadedRecord;


public class OcurrencesAdapter extends RecyclerView.Adapter<OcurrencesAdapter.MyViewHolder> {

    private LayoutInflater inflater;
    public static ArrayList<LoadedRecord> recordArrayList;
    private int selectedPos = RecyclerView.NO_POSITION;
    private boolean IsSelected = false;

    public OcurrencesAdapter(Context ctx, ArrayList<LoadedRecord> _recordArrayList){
        inflater = LayoutInflater.from(ctx);
        recordArrayList = _recordArrayList;
    }

    @Override
    public OcurrencesAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        View view = inflater.inflate(R.layout.adapter_occurences, parent, false);
        MyViewHolder holder = new MyViewHolder(view);
        return holder;
    }


    @Override
    public void onBindViewHolder(final OcurrencesAdapter.MyViewHolder holder, int position) {
        final LoadedRecord model = recordArrayList.get(position);

        String string = model.getRecord1();
        string=string.replace("[newline]", System.getProperty("line.separator"));
        holder.description.setText(string);
        holder.code.setText(model.getRecord2());
        holder.data.setText(model.getRecord3());
        holder.itemView.setSelected(selectedPos == position);

        holder.cardView.setBackgroundColor(model.isSelected() ? Color.GREEN : Color.WHITE);
        holder.cardView.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                notifyItemChanged(selectedPos);
                selectedPos = holder.getLayoutPosition();
                notifyItemChanged(selectedPos);
                if ((!IsSelected && model.isSelected()==false) || (IsSelected && model.isSelected())){
                    model.setSelected(!model.isSelected());
                    holder.cardView.setBackgroundColor(model.isSelected() ? Color.GREEN : Color.WHITE);
                    IsSelected=!IsSelected;
                }
            }
        });
    }

    @Override
    public int getItemCount() {
        return recordArrayList.size();
    }

    class MyViewHolder extends RecyclerView.ViewHolder{
        TextView description, code, data;
        View view;
        CardView cardView;

        public MyViewHolder(View itemView) {
            super(itemView);
            view=itemView;
            cardView = itemView.findViewById(R.id.adapter_ccurences_card_view);
            description = itemView.findViewById(R.id.adapter_ccurences_description);
            data = itemView.findViewById(R.id.adapter_ccurences_data);
            code = itemView.findViewById(R.id.adapter_ccurences_code);
        }
    }
}
