package construction.site.logistics.foreman.FragmentDialogs;

import android.content.Context;
import android.nfc.FormatException;
import android.nfc.NdefMessage;
import android.nfc.Tag;
import android.nfc.tech.Ndef;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.ImageView;
import android.widget.ProgressBar;
import android.widget.TextView;

import androidx.annotation.Nullable;
import androidx.fragment.app.DialogFragment;

import java.io.IOException;

import construction.site.logistics.foreman.MainActivity;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.Listener;
import construction.site.logistics.foreman.data.state;

public class NFCReadFragment extends DialogFragment {

    public static final String TAG = NFCReadFragment.class.getSimpleName();

    public static NFCReadFragment newInstance() {

        return new NFCReadFragment();
    }
    private TextView cardContents, title;
    private ImageView logo;
    private Button closeBtn;
    private Listener mListener;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_attendance_view_card_data ,container,false);
        initViews(view);
        getDialog().setCancelable(false);
        getDialog().setCanceledOnTouchOutside(false);
        return view;
    }

    private void initViews(View view) {
        title = view.findViewById(R.id.fragment_attendance_view_card_data_title);
        cardContents = view.findViewById(R.id.fragment_attendance_view_card_data_contents);
        logo = view.findViewById(R.id.fragment_attendance_view_card_data_logo);
        closeBtn = view.findViewById(R.id.fragment_attendance_view_card_data_btnClose);
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        state.NFCState=0; // begin read
        title.setText(getActivity().getResources().getString(R.string.fragment_nfc_pass_card_title));
        cardContents.setText("");
        cardContents.setVisibility(View.GONE);
        logo.setImageResource(R.drawable.nfc_vector);
        closeBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                dismiss();
            }
        });
        closeBtn.setVisibility(View.GONE);

    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        mListener = (MainActivity)context;
        mListener.onDialogDisplayed();
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener.onDialogDismissed();
    }

    public void onNfcDetected(Ndef ndef){

        readFromNFC(ndef);
    }

    private void readFromNFC(Ndef ndef) {
        state.ReadSmartCardID="";
        state.ReadSmartCardFullMessageString="";
        try {
            ndef.connect();

            Tag tag = ndef.getTag();
            byte[] extraID = tag.getId();
            StringBuilder sb = new StringBuilder();
            for (byte b : extraID) {
                sb.append(String.format("%02X", b));
            }
            String hexdump = "";
            hexdump = sb.toString();
            long uuid = Long.parseLong(hexdump, 16);
            state.ReadSmartCardID = String.valueOf(uuid);
            Integer s=  state.smartCardMemorySize;
            NdefMessage ndefMessage = ndef.getNdefMessage();
            state.ReadSmartCardFullMessageString= new String(ndefMessage.getRecords()[0].getPayload());
            ndef.close();

        } catch (IOException | FormatException e) {
            e.printStackTrace();
        }
        // first 16 bytes are the encrypted Auth string
        if (!state.ReadSmartCardFullMessageString.equals("") && state.ReadSmartCardFullMessageString.length()>15){
            if(state.ReadSmartCardFullMessageString.substring(0,16).contains(" ")){
                cardContents.setText(getActivity().getResources().getString(R.string.nfc_message_read_auth_error));
                cardContents.setVisibility(View.VISIBLE);
                logo.setVisibility(View.GONE);
                return;
            }else{
                state.ReadSmartCardAuthenticationString=state.ReadSmartCardFullMessageString.substring(0,16);
                Integer s=state.ReadSmartCardFullMessageString.length();
                Integer ss= s-16;
                if((state.ReadSmartCardFullMessageString.length()-16) % 7==0){
                    state.ReadSmartCardDataString=state.ReadSmartCardFullMessageString.substring(16);
                    String[] entries;
                    String contents="";
                    entries = state.ReadSmartCardDataString.split("(?<=\\G.{7})");

                    for (int i = 0; i < entries.length; i++) {
                        String date = entries[i].substring(0, 3);
                        String tmp = "202" + date.charAt(0);
                        if ((int) date.charAt(1) - 48 < 10) {
                            tmp += "-0" + ((int) date.charAt(1) - 48);
                        } else {
                            tmp += "-" + ((int) date.charAt(1) - 48);
                        }
                        if ((int) date.charAt(2) - 48 < 10) {
                            tmp += "-0" + ((int) date.charAt(2) - 48);
                        } else {
                            tmp += "-" + ((int) date.charAt(2) - 48);
                        }
                        date = tmp;

                        tmp=getActivity().getResources().getString(R.string.fragment_log_attendance_checkin)+" ";
                        String stime= entries[i].substring(3, 5);
                        if( ( (int) stime.charAt(0) - 48)<10){
                            tmp+="0"+ ((int) stime.charAt(0) - 48);
                        }else{
                            tmp+=Integer.toString((int) stime.charAt(0) - 48);
                        }
                        if( ( (int) stime.charAt(1) - 48)<10){
                            tmp+=":0"+ ((int) stime.charAt(1) - 48);
                        }else{
                            tmp+=":"+ ((int) stime.charAt(1) - 48);
                        }
                        stime=tmp;

                        tmp=getActivity().getResources().getString(R.string.fragment_log_attendance_checkout)+" ";
                        String etime= entries[i].substring(5, 7);
                        if( etime.charAt(0) - 48 <10){
                            tmp+="0"+ ((int) etime.charAt(0) - 48);
                        }else{
                            tmp+=Integer.toString((int) etime.charAt(0) - 48);
                        }
                        if( etime.charAt(1) - 48 <10){
                            tmp+=":0"+ ((int) etime.charAt(1) - 48);
                        }else{
                            tmp+=":"+ ((int) etime.charAt(1) - 48);
                        }
                        etime=tmp;
                        contents+=date+"       "+stime+"       "+etime+System.getProperty("line.separator");
                    }
                    cardContents.setText(contents);
                    cardContents.setVisibility(View.VISIBLE);
                    logo.setVisibility(View.GONE);
                    title.setText(getActivity().getResources().getString(R.string.fragment_log_attendance_view_card_data_title));
                    closeBtn.setVisibility(View.VISIBLE);
                    return;
                }else{ // corrupted data
                    cardContents.setText(getActivity().getResources().getString(R.string.nfc_message_read_auth_error));
                    cardContents.setVisibility(View.VISIBLE);
                    logo.setVisibility(View.GONE);
                    return;
                }
            }
        }else{ //empty card
            cardContents.setText(getActivity().getResources().getString(R.string.nfcEmptyCard));
            cardContents.setVisibility(View.VISIBLE);
            logo.setVisibility(View.GONE);
            return;
        }

    }



}
