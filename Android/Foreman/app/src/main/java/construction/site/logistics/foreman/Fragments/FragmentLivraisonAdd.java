package construction.site.logistics.foreman.Fragments;

import android.app.AlertDialog;
import android.content.ActivityNotFoundException;
import android.content.ClipData;
import android.content.DialogInterface;
import android.content.Intent;
import android.content.pm.PackageManager;
import android.content.pm.ResolveInfo;
import android.graphics.Bitmap;
import android.net.Uri;
import android.os.Build;
import android.os.Bundle;
import android.os.Environment;
import android.provider.MediaStore;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.ImageView;
import android.widget.Spinner;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.Nullable;
import androidx.core.content.FileProvider;
import androidx.fragment.app.Fragment;

import com.bumptech.glide.Glide;
import com.bumptech.glide.load.DataSource;
import com.bumptech.glide.load.engine.DiskCacheStrategy;
import com.bumptech.glide.load.engine.GlideException;
import com.bumptech.glide.request.RequestListener;
import com.bumptech.glide.request.target.Target;
import com.github.chrisbanes.photoview.PhotoView;

import java.io.File;
import java.io.IOException;
import java.net.URI;
import java.util.ArrayList;
import java.util.List;

import construction.site.logistics.foreman.BuildConfig;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.data.state;


public class FragmentLivraisonAdd extends Fragment {

    private Button del, add, send;
    private PhotoView photo;
    private String Photopath;

    private ImageView test;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }


    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        add.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if(Functions.checkPermissionForReadExtertalStorage(getActivity())){
                    Long tsLong = System.currentTimeMillis()/1000;

                    File storageDir = Environment.getExternalStoragePublicDirectory(Environment.DIRECTORY_PICTURES);
                    Photopath = storageDir.getAbsolutePath() + "/qc_"+tsLong.toString()+".jpg";

                    File file= new File (Photopath);

                    file.setWritable(true);
                    if (file.exists()) {
                        file.delete();
                    }
                    else {
                        file.getParentFile().mkdirs();
                    }
                    Intent i=new Intent(MediaStore.ACTION_IMAGE_CAPTURE);
                    Uri outputUri= FileProvider.getUriForFile(getActivity(), BuildConfig.APPLICATION_ID, file);
                    i.putExtra(MediaStore.EXTRA_OUTPUT, outputUri);
                    if (Build.VERSION.SDK_INT>=Build.VERSION_CODES.LOLLIPOP) {
                        i.addFlags(Intent.FLAG_GRANT_WRITE_URI_PERMISSION);
                    }
                    else if (Build.VERSION.SDK_INT>=Build.VERSION_CODES.JELLY_BEAN) {
                        ClipData clip= ClipData.newUri(getActivity().getContentResolver(), "QC photo", outputUri);
                        i.setClipData(clip);
                        i.addFlags(Intent.FLAG_GRANT_WRITE_URI_PERMISSION);
                    }
                    else {
                        List<ResolveInfo> resInfoList= getActivity().getPackageManager().queryIntentActivities(i, PackageManager.MATCH_DEFAULT_ONLY);

                        for (ResolveInfo resolveInfo : resInfoList) {
                            String packageName = resolveInfo.activityInfo.packageName;
                            getActivity().grantUriPermission(packageName, outputUri, Intent.FLAG_GRANT_WRITE_URI_PERMISSION);
                        }
                    }
                    try {
                        state.setCurrentNavItem(R.id.nav_livraison_add);
                        startActivityForResult(i, 1008);
                    }
                    catch (ActivityNotFoundException e) {
                        Toast.makeText(getActivity(), R.string.error_no_camera, Toast.LENGTH_LONG).show();
                    }
                }else{
                    Toast.makeText(getActivity(), "No permission read storage", Toast.LENGTH_SHORT).show();
                }
            }
        });

        del.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {

            }
        });

        send.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if (state.isDemonstrationEnabled){
                    return;
                }
                AddLivraison();
            }
        });
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_livraison_add, container, false);
        add = v.findViewById(R.id.livraison_add_btn_add);
        del = v.findViewById(R.id.livraison_add_btn_del);
        send = v.findViewById(R.id.livraison_add_btn_send);
        photo = v.findViewById(R.id.livraison_add_photo );
        test = v.findViewById(R.id.imageTest );
        return v;
    }

    @Override
    public void onResume() {
        super.onResume();
        getActivity().setTitle(getResources().getString(R.string.fragment_livraison_add_title));

    }

    @Override
    public void onActivityResult(int requestCode, int resultCode, @Nullable Intent data) {
        if (requestCode == 1008 && resultCode == getActivity().RESULT_OK) {
            File imgFile = new  File(Photopath);
            if(imgFile.exists()) {
                try {
                    Bitmap mImageBitmap = MediaStore.Images.Media.getBitmap(getActivity().getContentResolver(), Uri.fromFile(new File(Photopath)));
                    test.setImageBitmap(mImageBitmap);
                } catch (IOException e) {
                    e.printStackTrace();
                }


                try {
                    Intent mediaScanIntent = new Intent(Intent.ACTION_MEDIA_SCANNER_SCAN_FILE);
                    Uri contentUri = Uri.fromFile(imgFile);
                    mediaScanIntent.setData(contentUri);
                    getActivity().sendBroadcast(mediaScanIntent);
                    //imgFile.delete();
                    try{
                        Thread.sleep(2000);
                    }catch(Exception e){

                    }
                    state.setPhotos2Upload(Photopath);
                    try {
                        Glide.with(getActivity())
                                .asBitmap()
                                .placeholder(R.drawable.loading)
                                .error(R.drawable.loading_error_image)
                                .load(contentUri)
                                .override(1080, 600)
                                .listener(requestListener)
                                .skipMemoryCache(true)  //No memory cache
                                .diskCacheStrategy(DiskCacheStrategy.NONE)
                                //No disk cache
                                .into(photo);
                    } catch(Exception e){
                        Functions.SaveCrash(e, getActivity());
                        photo.setImageResource(R.drawable.no_camera);
                        Toast.makeText(getActivity(), getActivity().getResources().getString(R.string.fragment_view_photo_not_found), Toast.LENGTH_SHORT).show();
                    }
                } catch (Exception e) {
                    Functions.SaveCrash(e, getActivity());
                    Toast.makeText(getActivity(), getActivity().getResources().getString(R.string.fragment_occurrences_add_error_photo), Toast.LENGTH_LONG).show();
                    return;
                }
            } else {
                Toast.makeText(getActivity(), getActivity().getResources().getString(R.string.fragment_view_photo_not_found), Toast.LENGTH_SHORT).show();
            }
        }
        super.onActivityResult(requestCode, resultCode, data);
    }

    private RequestListener<Bitmap> requestListener = new RequestListener<Bitmap>() {
        @Override
        public boolean onLoadFailed(@Nullable GlideException e, Object model, Target<Bitmap> target, boolean isFirstResource) {
            // todo log exception to central service or something like that
            Toast.makeText(getActivity(), e.getMessage(), Toast.LENGTH_SHORT).show();

            // important to return false so the error placeholder can be placed
            return false;
        }

        @Override
        public boolean onResourceReady(Bitmap resource, Object model, Target<Bitmap> target, DataSource dataSource, boolean isFirstResource) {
            // everything worked out, so probably nothing to do
            return false;
        }
    };

    public void AddLivraison(){
        LayoutInflater linf = LayoutInflater.from(getActivity());
        final View inflator = linf.inflate(R.layout.fragment_livraison_add_dialog, null);
        AlertDialog.Builder alert = new AlertDialog.Builder(getActivity());

        alert.setTitle(getResources().getString(R.string.fragment_bordereau_view_new_task));
        alert.setMessage(getResources().getString(R.string.fragment_bordereau_view_new_task_msg));
        alert.setView(inflator);

        final EditText refdoc = inflator.findViewById(R.id.livraison_dialog_refdoc);
        final EditText notas = inflator.findViewById(R.id.livraison_dialog_notes);

        alert.setPositiveButton(getResources().getString(R.string.button_send), new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int whichButton) {
                if(!refdoc.getText().toString().equals("")){
                        // Send data

                }else{
                    Toast.makeText(getActivity(), getResources().getString(R.string.fragment_bordereau_view_missing_name), Toast.LENGTH_SHORT).show();
                }
                dialog.cancel();
            }
        });

        alert.setNegativeButton(getResources().getString(R.string.alertbox_cancel), new DialogInterface.OnClickListener() {
            public void onClick(DialogInterface dialog, int whichButton) {
                dialog.cancel();
            }
        });

        alert.show();

    }
}