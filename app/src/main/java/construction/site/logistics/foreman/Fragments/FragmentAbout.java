package construction.site.logistics.foreman.Fragments;

import android.content.Intent;
import android.net.Uri;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import construction.site.logistics.foreman.BuildConfig;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.data.state;


public class FragmentAbout extends Fragment {

TextView version;
ImageView email;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActivity().setTitle(getResources().getString(R.string.fragment_about_title));
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }


    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        version.setText(getResources().getString(R.string.fragment_about_version) +" "+ BuildConfig.VERSION_CODE +" "+getResources().getString(R.string.fragment_about_serial)+" "+ state.serial);
        email.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                Intent intent = new Intent(Intent.ACTION_SENDTO, Uri.fromParts(
                        "mailto","mtpsilva@icloud.com", null));
                intent.putExtra(Intent.EXTRA_SUBJECT, getResources().getString(R.string.fragment_about_email_subject));
                intent.putExtra(Intent.EXTRA_TEXT, getResources().getString(R.string.fragment_about_email_message));
                startActivity(Intent.createChooser(intent, getResources().getString(R.string.fragment_about_email_choose)));
            }
        });
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_about, container, false);
        version = v.findViewById(R.id.about_version);
        email =v.findViewById(R.id.about_email);
        return v;
    }

}