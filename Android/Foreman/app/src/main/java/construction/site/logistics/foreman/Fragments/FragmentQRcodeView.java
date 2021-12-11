package construction.site.logistics.foreman.Fragments;

        import android.content.Intent;
        import android.graphics.Bitmap;
        import android.net.Uri;
        import android.os.Bundle;
        import android.view.LayoutInflater;
        import android.view.View;
        import android.view.ViewGroup;
        import android.widget.Button;
        import android.widget.ImageView;
        import android.widget.TextView;

        import androidx.annotation.Nullable;
        import androidx.fragment.app.Fragment;

        import com.google.zxing.BarcodeFormat;
        import com.google.zxing.MultiFormatWriter;
        import com.google.zxing.WriterException;
        import com.google.zxing.common.BitMatrix;

        import java.text.SimpleDateFormat;
        import java.util.Calendar;
        import java.util.Date;

        import construction.site.logistics.foreman.BuildConfig;
        import construction.site.logistics.foreman.MainActivity;
        import construction.site.logistics.foreman.R;
        import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
        import construction.site.logistics.foreman.abstraction.Functions;
        import construction.site.logistics.foreman.data.state;


public class FragmentQRcodeView extends Fragment {

    private ImageView backBtn;
    private ImageView qrCodeImg;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActivity().setTitle(getResources().getString(R.string.fragment_qrcode_title));
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }
    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        backBtn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                int count = getActivity().getSupportFragmentManager().getBackStackEntryCount();
                if (count > 1) {
                    getActivity().getSupportFragmentManager().popBackStack();
                }
            }
        });

        Date c = Calendar.getInstance().getTime();
        SimpleDateFormat df = new SimpleDateFormat("yyyy-MM-dd");

        try {
            Bitmap bitmap = Functions.QRCodeEncodeAsBitmap(state.site+"-"+state.section+"-"+df.format(c));
            qrCodeImg.setImageBitmap(bitmap);
        } catch (WriterException e) {
            e.printStackTrace();
        }
    }




    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_qr_code, container, false);
        backBtn = v.findViewById(R.id.fragment_qr_code_back_btn);
        qrCodeImg =v.findViewById(R.id.fragment_qr_code_image);
        return v;
    }

}