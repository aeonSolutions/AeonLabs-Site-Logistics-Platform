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


public class QuantityAdapter extends RecyclerView.Adapter<QuantityAdapter.MyViewHolder> {

    private LayoutInflater inflater;
    public ArrayList<LoadedRecord> recordArrayList;
    private int selectedPos = RecyclerView.NO_POSITION;
    private boolean IsSelected = false;

    public QuantityAdapter(Context ctx, ArrayList<LoadedRecord> _recordArrayList){
        inflater = LayoutInflater.from(ctx);
        this.recordArrayList = _recordArrayList;
    }

    @Override
    public QuantityAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        View view = inflater.inflate(R.layout.adapter_quantity, parent, false);
        MyViewHolder holder = new MyViewHolder(view);
        return holder;
    }


    @Override
    public void onBindViewHolder(final QuantityAdapter.MyViewHolder holder, int position) {
        final LoadedRecord model = recordArrayList.get(position);

        holder.task.setText(model.getRecord1().replace("[newline]", System.getProperty("line.separator")));
        holder.code.setText(model.getRecord2());
        holder.data.setText(model.getRecord5());
        holder.workers.setText(model.getRecord4());
        holder.qtd.setText(model.getRecord3());

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
        TextView task, code, qtd, data, workers;
        View view;
        CardView cardView;

        public MyViewHolder(View itemView) {
            super(itemView);
            view=itemView;
            cardView = itemView.findViewById(R.id.adapter_quantity_card_view);
            code = itemView.findViewById(R.id.adapter_quantity_code);
            task = itemView.findViewById(R.id.adapter_quantity_name);
            qtd = itemView.findViewById(R.id.adapter_quantity_qtd);
            workers = itemView.findViewById(R.id.adapter_quantity_workers);
            data = itemView.findViewById(R.id.adapter_quantity_date);
        }
    }
}

