package construction.site.logistics.foreman.Fragments;


import android.graphics.Bitmap;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.webkit.WebView;
import android.webkit.WebViewClient;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import java.net.URL;

import construction.site.logistics.foreman.BuildConfig;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.data.state;

public class FragmentTerms extends Fragment {
    WebView web;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActivity().setTitle(getResources().getString(R.string.fragment_terms_title));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
            Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        }
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        try{
            URL url = new URL(state.HostUrl);
            String str= url.getProtocol()+"://"+url.getHost()+"/terms/terms.html";
            Functions.showSimpleProgressDialog(getActivity(), getActivity().getResources().getString(R.string.commServer_connect_title_msg), getActivity().getResources().getString(R.string.commServer_connect_msg),false);
            web.setWebViewClient(new WebViewClient() {
                @Override
                public void onPageStarted(WebView view, String url, Bitmap favicon)
                {
                    // TODO show you progress image
                    super.onPageStarted(view, url, favicon);
                    Functions.showSimpleProgressDialog(getActivity(), getActivity().getResources().getString(R.string.commServer_connect_title_msg),getActivity().getResources().getString(R.string.commServer_connect_msg),false);

                }

                @Override
                public void onPageFinished(WebView view, String url)
                {
                    // TODO hide your progress image
                    super.onPageFinished(view, url);
                    Functions.removeSimpleProgressDialog();
                }
            });
            web.loadUrl(str);
            Functions.removeSimpleProgressDialog();
        } catch (Exception e) {
            Functions.SaveCrash(e, getActivity());

            Toast.makeText(getActivity().getApplicationContext(), getResources().getString(R.string.error_ivalid_url), Toast.LENGTH_LONG).show();
        }
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_policies, container, false);
        web = v.findViewById(R.id.policies_web_render);
        return v;
    }
}
