package construction.site.logistics.foreman.FragmentDialogs;

        import android.app.Activity;
        import android.content.Context;
        import android.graphics.Bitmap;
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
        import android.widget.Toast;

        import androidx.annotation.Nullable;
        import androidx.fragment.app.DialogFragment;

        import com.google.zxing.WriterException;

        import java.io.IOException;
        import java.text.SimpleDateFormat;
        import java.util.Calendar;
        import java.util.Date;

        import construction.site.logistics.foreman.MainActivity;
        import construction.site.logistics.foreman.R;
        import construction.site.logistics.foreman.abstraction.Functions;
        import construction.site.logistics.foreman.abstraction.GeoLocation;
        import construction.site.logistics.foreman.abstraction.Listener;
        import construction.site.logistics.foreman.data.state;
        import construction.site.logistics.foreman.login.LoginActivity;

public class FragmentViewQrCode extends DialogFragment {

    public static final String TAG = FragmentViewQrCode.class.getSimpleName();

    public static FragmentViewQrCode newInstance() {

        return new FragmentViewQrCode();
    }
    private ImageView logo;
    private Button closeBtn;
    private Listener mListener;

    @Nullable
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {

        View view = inflater.inflate(R.layout.fragment_view_qr_code ,container,false);
        initViews(view);
        getDialog().setCancelable(false);
        getDialog().setCanceledOnTouchOutside(false);
        return view;
    }

    private void initViews(View view) {
        closeBtn = view.findViewById(R.id.fragment_view_qr_code_btnClose);
        logo = view.findViewById(R.id.fragment_view_qr_code);
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        logo.setImageResource(R.drawable.nfc_vector);
        closeBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                dismiss();
            }
        });
        closeBtn.setVisibility(View.VISIBLE);
        GeoLocation gps= new GeoLocation();
        if(gps.getLocation(getActivity().getApplicationContext()) == null){
            Toast.makeText(getActivity().getApplicationContext(), getActivity().getResources().getString(R.string.error_location_disabled), Toast.LENGTH_LONG).show();
            // Intent intent = new Intent(Settings.ACTION_LOCATION_SOURCE_SETTINGS);
            // startActivity(intent);
        }else {
            Date c = Calendar.getInstance().getTime();
            SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd");
            String str = gps.getLatitude()+"-"+gps.getLongitude()+"-"+state.serial+"-"+df.format(c);
            try {
                Bitmap bitmap = Functions.QRCodeEncodeAsBitmap(str);
                logo.setImageBitmap(bitmap);
            } catch (WriterException e) {
                e.printStackTrace();
            }
        }
    }

    @Override
    public void onAttach(Context context) {
        super.onAttach(context);
        mListener = new Listener() {
            @Override
            public void onDialogDisplayed() {

            }

            @Override
            public void onDialogDismissed() {

            }
        };
        mListener.onDialogDisplayed();
    }

    @Override
    public void onDetach() {
        super.onDetach();
        mListener.onDialogDismissed();
    }



}
