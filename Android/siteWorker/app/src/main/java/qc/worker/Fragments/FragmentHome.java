package qc.worker.Fragments;

import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;

import androidx.annotation.Nullable;
import androidx.cardview.widget.CardView;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;

import qc.worker.R;
import qc.worker.abstraction.CustomExceptionHandler;
import qc.worker.abstraction.Functions;
import qc.worker.data.state;

public class FragmentHome extends Fragment {

    private CardView lodge, meal, absense, file, limosa;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        getActivity().setTitle(getResources().getString(R.string.fragment_home_title));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
            Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        }

    }
    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        lodge.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                displaySelectedFragment(new FragmentLodging());
                state.loadedfragment="lodging";
            }
        });

        meal.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                displaySelectedFragment(new FragmentFood());
                state.loadedfragment="alimentacao";
            }
        });

        absense.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                displaySelectedFragment(new FragmentAbsense());
                state.loadedfragment="ausencia";
            }
        });

        file.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                displaySelectedFragment(new FragmentWorkerFile());
                state.loadedfragment="ficha";
            }
        });

        limosa.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                displaySelectedFragment(new FragmentLimosas());
                state.loadedfragment="limosas";
            }
        });
    }

    private void displaySelectedFragment(Fragment fragment) {
        FragmentTransaction fragmentTransaction = getActivity().getSupportFragmentManager().beginTransaction();
        fragmentTransaction.replace(R.id.content_frame, fragment);
        fragmentTransaction.commit();
    }
    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_home, container, false);
        lodge= v.findViewById(R.id.home_lodge_card);
        meal= v.findViewById(R.id.home_meal_card);
        absense= v.findViewById(R.id.home_absense_card);
        file= v.findViewById(R.id.home_file_card);
        limosa= v.findViewById(R.id.home_limosa_card);
        return v;
    }

}