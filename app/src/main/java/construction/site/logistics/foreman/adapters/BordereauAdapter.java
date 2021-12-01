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


public class BordereauAdapter extends RecyclerView.Adapter<BordereauAdapter.MyViewHolder> {

    private LayoutInflater inflater;
    public ArrayList<LoadedRecord> recordArrayList;
    private int selectedPos = RecyclerView.NO_POSITION;
    private boolean IsSelected = false;

    public BordereauAdapter(Context ctx, ArrayList<LoadedRecord> _recordArrayList){
        inflater = LayoutInflater.from(ctx);
        this.recordArrayList = _recordArrayList;
    }

    @Override
    public BordereauAdapter.MyViewHolder onCreateViewHolder(ViewGroup parent, int viewType) {

        View view = inflater.inflate(R.layout.adapter_bordereau, parent, false);
        MyViewHolder holder = new MyViewHolder(view);
        return holder;
    }


    @Override
    public void onBindViewHolder(final BordereauAdapter.MyViewHolder holder, int position) {
        final LoadedRecord model = recordArrayList.get(position);

        String string = model.getRecord1();
        string=string.replace("[newline]", System.getProperty("line.separator"));
        holder.task.setText(string);
        string="";
        if(!model.getRecord7().equals("")){
            string=" ("+model.getRecord7()+")";
        }
        holder.code.setText(model.getRecord2()+string);

        holder.units.setText(model.getRecord3());
        holder.total.setText(model.getRecord4());
        holder.feito.setText(model.getRecord6());
        holder.falta.setText(model.getRecord5());

        holder.itemView.setSelected(selectedPos == position);

        holder.cardView.setBackgroundColor(model.isSelected() ? Color.GREEN : Color.WHITE);

        if(model.getRecord8().equals("0")) {
            holder.cardView.setBackgroundColor(Color.LTGRAY);
        }else if(model.getRecord8().equals("2")){
                holder.cardView.setBackgroundColor(Color.YELLOW);
        }else {
            holder.cardView.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View v) {
                    notifyItemChanged(selectedPos);
                    selectedPos = holder.getLayoutPosition();
                    notifyItemChanged(selectedPos);
                    if ((!IsSelected && model.isSelected() == false) || (IsSelected && model.isSelected())) {
                        model.setSelected(!model.isSelected());
                        holder.cardView.setBackgroundColor(model.isSelected() ? Color.GREEN : Color.WHITE);
                        IsSelected = !IsSelected;
                    }
                }
            });
        }
    }

    @Override
    public int getItemCount() {
        return recordArrayList.size();
    }

    class MyViewHolder extends RecyclerView.ViewHolder{
        TextView task, code, units, total, feito, falta;
        View view;
        CardView cardView;

        public MyViewHolder(View itemView) {
            super(itemView);
            view=itemView;
            cardView = itemView.findViewById(R.id.bordereau_adapter_card_view);
            code = itemView.findViewById(R.id.bordereau_adapter_code);
            task = itemView.findViewById(R.id.bordereau_adapter_name);
            units = itemView.findViewById(R.id.bordereau_adapter_units);
            total = itemView.findViewById(R.id.bordereau_adapter_qtd_total);
            feito = itemView.findViewById(R.id.bordereau_adapter_qtd_feito);
            falta = itemView.findViewById(R.id.bordereau_adapter_qtd_falta);
        }
    }
}

