package construction.site.logistics.foreman.Fragments;

import android.annotation.SuppressLint;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.TextView;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;

import com.bumptech.glide.Glide;
import com.bumptech.glide.load.engine.DiskCacheStrategy;


import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.CustomExceptionHandler;
import construction.site.logistics.foreman.abstraction.Weather;
import construction.site.logistics.foreman.data.state;
import construction.site.logistics.foreman.data.stateWeather;

public class FragmentWeather extends Fragment {
    ImageView icon;
    TextView city,description,temp,pressure,humidity, windSpeed,windDirection,sunrise,sunset,condition;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        Thread.setDefaultUncaughtExceptionHandler(new CustomExceptionHandler(getActivity()));
        if(!(Thread.getDefaultUncaughtExceptionHandler() instanceof CustomExceptionHandler)) {
        }
    }

    @Override
    public void onViewCreated(View view, @Nullable Bundle savedInstanceState) {
        getActivity().setTitle(getResources().getString(R.string.fragment_weather_title));
    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
        View v= inflater.inflate(R.layout.fragment_weather, container, false);
         icon= v.findViewById(R.id.fragment_weather_icon);
         city=v.findViewById(R.id.fragment_weather_city);
         description=v.findViewById(R.id.fragment_weather_description);
         temp=v.findViewById(R.id.fragment_weather_temperature);
         pressure=v.findViewById(R.id.fragment_weather_pressure);
         humidity=v.findViewById(R.id.fragment_weather_humidity);
         windSpeed=v.findViewById(R.id.fragment_weather_windSpeed);
         windDirection=v.findViewById(R.id.fragment_weather_windDirection);
         sunrise=v.findViewById(R.id.fragment_weather_sunrise);
         sunset=v.findViewById(R.id.fragment_weather_sunset);
         condition=v.findViewById(R.id.fragment_weather_condition);
        return v;
    }

    @SuppressLint("SetTextI18n")
    @Override
    public void onResume() {
        super.onResume();
        Weather weather=new Weather();
        weather.load(getActivity(), true);
        if(!stateWeather.id.equals("")){
            Glide.with(getActivity())
                    .asBitmap()
                    .placeholder(R.drawable.loading)
                    .error(R.drawable.loading_error_image)
                    .load("http://openweathermap.org/img/w/"+ stateWeather.icon +".png")
                    .override(1080, 600)
                    .centerCrop()
                    .skipMemoryCache(true)  //No memory cache
                    .diskCacheStrategy(DiskCacheStrategy.NONE)   //No disk cache
                    .thumbnail(0.5f)
                    .into(icon);

            city.setText(stateWeather.cityName);
            description.setText(stateWeather.description);
            temp.setText(getResources().getString(R.string.fragment_weather_temp)+" "+ stateWeather.temperature+"°C "+stateWeather.tempMinMax);
            pressure.setText(getResources().getString(R.string.fragment_weather_pressure)+" "+ stateWeather.pressure +"mb");
            humidity.setText(getResources().getString(R.string.fragment_weather_humidity)+" "+ stateWeather.humidity +" %");
            windSpeed.setText(getResources().getString(R.string.fragment_weather_wind)+" "+ stateWeather.windSpeed +" km/h");
            windDirection.setText(getResources().getString(R.string.fragment_weather_wind_direction)+" "+ stateWeather.windDirection+"°");
            sunrise.setText(getResources().getString(R.string.fragment_weather_sunrise)+" "+ stateWeather.sunRise);
            sunset.setText(getResources().getString(R.string.fragment_weather_sunset)+" "+ stateWeather.sunSet);
            condition.setText(weather.translate(stateWeather.condition));
        }else{
            city.setText(getResources().getString(R.string.fragment_weather_city));
            description.setText("");
            temp.setText(getResources().getString(R.string.fragment_weather_temp));
            pressure.setText(getResources().getString(R.string.fragment_weather_pressure));
            humidity.setText(getResources().getString(R.string.fragment_weather_humidity));
            windSpeed.setText("0 km/h");
            windDirection.setText(getResources().getString(R.string.fragment_weather_wind_direction));
            sunrise.setText(getResources().getString(R.string.fragment_weather_sunrise));
            sunset.setText(getResources().getString(R.string.fragment_weather_sunset));
            condition.setText("");
        }
    }
}
