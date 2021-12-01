package construction.site.logistics.foreman.abstraction;

import android.annotation.SuppressLint;
import android.app.Activity;
import android.content.Context;
import android.os.AsyncTask;
import android.os.Handler;
import android.os.Looper;
import android.widget.Toast;

import org.json.JSONArray;
import org.json.JSONException;
import org.json.JSONObject;

import java.io.File;
import java.text.ParseException;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;

import construction.site.logistics.foreman.Network.HttpRequestHandler;
import construction.site.logistics.foreman.Network.SendData;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.data.LoadConfig;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.state;
import construction.site.logistics.foreman.data.stateWeather;

public class Weather {

    private Activity activity;
    private GeoLocation gps;
    public String date;

    public class GetWeatherAsyncTask extends AsyncTask<Void, Void, String> {

        private final Activity activity;
        private Double latitude=-1.0;
        private Double longitude=-1.0;
        private Boolean override;

        public GetWeatherAsyncTask(final Activity _activity, Double latitude, Double longitude, Boolean overRide) {
            this.activity = _activity;
            this.latitude=latitude;
            this.longitude=longitude;
            this.override=overRide;
        }

        protected String doInBackground(Void[] params) {
            Functions.showSimpleProgressDialog(this.activity, this.activity.getResources().getString(R.string.commServer_connect_title_msg), this.activity.getResources().getString(R.string.commServer_connect_msg),false);
            String response="";
            if(this.latitude !=-1.0 && this.longitude !=-1.0) {
                HttpRequestHandler requestHandler = new HttpRequestHandler();
                if(! this.override && stateWeather.date!=null){
                    EntityQueue queue= new EntityQueue();
                    queue.setMsgType("silent");
                    queue.setMsgSuccess("response");
                    queue.setMsgError("response");
                    queue.setUrl(state.HostUrl + "api/index.php");
                    queue.setTitle( activity.getResources().getString(R.string.fragment_log_attendance_title));
                    queue.setDescription( activity.getResources().getString(R.string.fragment_log_attendance_description));

                    ArrayList<EntityFields> fields = new ArrayList<>();
                    EntityFields field = new EntityFields();
                    field.setRequestVar("task");
                    field.setValue("13");
                    fields.add(field);

                    field = new EntityFields();
                    field.setRequestVar("sn");
                    field.setValue(state.UUID);
                    fields.add(field);

                    field = new EntityFields();
                    field.setRequestVar("site");
                    field.setValue(state.site);
                    fields.add(field);

                    field = new EntityFields();
                    field.setRequestVar("section");
                    field.setValue(state.section);
                    fields.add(field);

                     field = new EntityFields();
                    field.setRequestVar("language");
                    field.setValue(state.getCurrentLanguage());
                    fields.add(field);

                    SendData sendData = new SendData(activity, null);
                    sendData.addQueue(queue);
                    sendData.addFields(fields);
                    sendData.setEncryption(true, "AES128");
                    sendData.setWaitForCode(true);
                    sendData.setloadMainPage(false);
                    sendData.setEnableQueue(false);
                    sendData.send();
                    response= sendData.getResponse();
                }

                response = requestHandler.sendGetRequest(state.HostWeatherUrl+"&lat=" + state.latitude+"&lon="+state.longitude+"&lang="+state.getCurrentLanguage(), this.activity);
                return response;
            }else{
                response= "{'error':true,'message':'"+this.activity.getResources().getString(R.string.weather_error_location)+"'}";
                return response;
            }
        }
        protected void onPostExecute(final String response) {
            Functions.removeSimpleProgressDialog();  //will remove progress dialog
            if (Functions.isSuccessWeather(response)) {
                try {
                    JSONObject jsonObject = new JSONObject(response);

                    JSONArray dataArray = jsonObject.getJSONArray("weather");
                    JSONObject dataobj = dataArray.getJSONObject(0);
                    stateWeather.id =dataobj.getString("id");
                    stateWeather.condition =dataobj.getString("main");
                    stateWeather.description =dataobj.getString("description");
                    stateWeather.icon =dataobj.getString("icon");

                    JSONObject jsonSubObject = new JSONObject(jsonObject.getString("main"));
                    stateWeather.temperature =jsonSubObject.getString("temp");
                    stateWeather.tempMinMax="   "+this.activity.getResources().getString(R.string.weather_temp_min)+":"+jsonSubObject.getString("temp_min")+"°C"+"    "+this.activity.getResources().getString(R.string.weather_temp_max)+":"+jsonSubObject.getString("temp_max")+"°C";
                    stateWeather.pressure =jsonSubObject.getString("pressure");
                    stateWeather.humidity =jsonSubObject.getString("humidity");

                    jsonSubObject = new JSONObject(jsonObject.getString("wind"));
                    stateWeather.windSpeed =jsonSubObject.getString("speed");
                    stateWeather.windDirection =jsonSubObject.getString("deg");

                    jsonSubObject = new JSONObject(jsonObject.getString("sys"));
                    stateWeather.sunRise = ConvertTime(jsonSubObject.getString("sunrise"));
                    stateWeather.sunSet = ConvertTime(jsonSubObject.getString("sunset"));

                    stateWeather.cityName =jsonObject.optString("name");
                } catch (JSONException e) {
                    Functions.SaveCrash(e, activity);
                    Handler handler = new Handler(Looper.getMainLooper());
                    handler.post(new Runnable() {
                        public void run() {
                            Toast t = Toast.makeText(activity, activity.getResources().getString(R.string.weather_error), Toast.LENGTH_LONG);
                            t.show();
                        }
                    });
                }
            }else{
                    Handler handler = new Handler(Looper.getMainLooper());
                    handler.post(new Runnable() {
                        public void run() {
                            Toast t = Toast.makeText(activity, Functions.getErrorCode(activity, response), Toast.LENGTH_LONG);
                            t.show();
                        }
                    });
            }
        }
    }

private String ConvertTime(String time){
    //Unix seconds
    long unix_seconds = Long.parseLong(time);
    //convert seconds to milliseconds
    Date date = new Date(unix_seconds*1000L);
    // format of the date
    SimpleDateFormat jdf = new SimpleDateFormat("HH:mm");
    //jdf.setTimeZone(TimeZone.getTimeZone("GMT-4"));
    String java_date = jdf.format(date);
    return java_date;
}
    @SuppressLint("StaticFieldLeak")
    public void load(Activity _activity, Boolean override){
        this.activity=_activity;
        this.date= stateWeather.date;

        if(checkTimer() || override){
            final GetWeatherAsyncTask task = new GetWeatherAsyncTask(this.activity, state.latitude, state.longitude, override);
            task.execute();

            SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:MM:ss");
            stateWeather.date=sdf.format(new Date());
        }
    }


    public Boolean checkTimer(){

        if(this.date==null){
            return true;
        }else{
            try{
                SimpleDateFormat sdf = new SimpleDateFormat("yyyy-MM-dd HH:MM:ss");
                Calendar cal = Calendar.getInstance(); // creates calendar
                cal.setTime(sdf.parse(this.date)); // sets calendar time/date
                cal.add(Calendar.HOUR_OF_DAY, 1); // adds one hour
                Date newDate=cal.getTime(); // returns new date object, one hour in the future
                return System.currentTimeMillis() > newDate.getTime();
            }catch (ParseException e){
                return true;
            }

        }
    }

    public String translate(String txt){
        txt= (txt.equals("thunderstorm with light rain")) ? "Trovoada e chuva ligeira" : txt;
        txt= (txt.equals("thunderstorm with rain")) ? "Trovoada e chuva" : txt;
        txt= (txt.equals("thunderstorm with heavy rain")) ? "Trovoada e chuva forte" : txt;
        txt= (txt.equals("light thunderstorm")) ? "Trovoada ligeira" : txt;
        txt= (txt.equals("thunderstorm")) ? "Trovoadas" : txt;
        txt= (txt.equals("heavy thunderstorm")) ? "Fortes trovoadas" : txt;
        txt= (txt.equals("ragged thunderstorm")) ? "Trovoadas irregulares" : txt;
        txt= (txt.equals("thunderstorm with light drizzle")) ? "Trovoada e chuviscos ligeiros" : txt;
        txt= (txt.equals("thunderstorm with drizzle")) ? "Trovoada e chuviscos" : txt;
        txt= (txt.equals("thunderstorm with heavy drizzle")) ? "Trovoada e chuviscos fortes" : txt;
        txt= (txt.equals("light intensity drizzle")) ? "Chuviscos ligeiros" : txt;
        txt= (txt.equals("drizzle")) ? "Chuviscos" : txt;
        txt= (txt.equals("heavy intensity drizzle")) ? "Chuviscos fortes" : txt;
        txt= (txt.equals("light intensity drizzle rain")) ? "Chuviscos ligeiros" : txt;
        txt= (txt.equals("drizzle rain")) ? "Chuviscos" : txt;
        txt= (txt.equals("heavy intensity drizzle rain")) ? "Chuvisco de forte intensidade" : txt;
        txt= (txt.equals("shower rain and drizzle")) ? "Periodos de chuva e chuviscos" : txt;
        txt= (txt.equals("heavy shower rain and drizzle")) ? "Periodos de chuva forte e chuviscos" : txt;
        txt= (txt.equals("shower drizzle")) ? "Periodos de chuviscos" : txt;
        txt= (txt.equals("light rain")) ? "Chuva ligeira" : txt;
        txt= (txt.equals("moderate rain")) ? "Chuva moderada" : txt;
        txt= (txt.equals("heavy intensity rain")) ? "Chuva intensa" : txt;
        txt= (txt.equals("very heavy rain")) ? "Chuva forte" : txt;
        txt= (txt.equals("extreme rain")) ? "Chuva intensa" : txt;
        txt= (txt.equals("freezing rain")) ? "Chuva congelante" : txt;
        txt= (txt.equals("light intensity shower rain")) ? "periodos de chuva" : txt;
        txt= (txt.equals("shower rain")) ? "chuva" : txt;
        txt= (txt.equals("heavy intensity shower rain")) ? "Chuva intensa" : txt;
        txt= (txt.equals("ragged shower rain")) ? "periodos de chuva forte" : txt;
        txt= (txt.equals("light snow")) ? "Neve ligeira" : txt;
        txt= (txt.equals("Snow")) ? "Neve" : txt;
        txt= (txt.equals("Heavy snow")) ? "Neve forte" : txt;
        txt= (txt.equals("Sleet")) ? "Granizo" : txt;
        txt= (txt.equals("Light shower sleet")) ? "Queda ligeira de granizo" : txt;
        txt= (txt.equals("Shower sleet")) ? "Queda de granizo" : txt;
        txt= (txt.equals("Light rain and snow")) ? "Chuva e neve ligeira" : txt;
        txt= (txt.equals("Rain and snow")) ? "Chuva e neve" : txt;
        txt= (txt.equals("Light shower snow")) ? "Ligeira queda de neve" : txt;
        txt= (txt.equals("Shower snow")) ? "Queda de neve" : txt;
        txt= (txt.equals("Heavy shower snow")) ? "Queda forte de neve" : txt;
        txt= (txt.equals("mist")) ? "névoa" : txt;
        txt= (txt.equals("sand/ dust whirls")) ? "tuerbilhões de areia/poeira" : txt;
        txt= (txt.equals("fog")) ? "nevoeiro" : txt;
        txt= (txt.equals("sand")) ? "areias" : txt;
        txt= (txt.equals("dust")) ? "poeiras" : txt;
        txt= (txt.equals("volcanic ash")) ? "cinza vulcanica" : txt;
        txt= (txt.equals("squalls")) ? "rajadas" : txt;
        txt= (txt.equals("tornado")) ? "tornado" : txt;
        txt= (txt.equals("clear sky")) ? "céu limpo" : txt;
        txt= (txt.equals("few clouds: 11-25%")) ? "poucas nuvens: 11-25%" : txt;
        txt= (txt.equals("scattered clouds: 25-50%")) ? "nuvens dispersas: 25-50%" : txt;
        txt= (txt.equals("broken clouds: 51-84%")) ? "nuvens quebradas: 51-84%" : txt;
        txt= (txt.equals("overcast clouds: 85-100%")) ? "nuvens nubladas: 85-100%" : txt;
        txt= (txt.equals("Thunderstorm")) ? "Trovoada" : txt;
        txt= (txt.equals("Drizzle")) ? "Chuvisco" : txt;
        txt= (txt.equals("Rain")) ? "Chuva" : txt;
        txt= (txt.equals("Snow")) ? "Neve" : txt;
        txt= (txt.equals("Mist")) ? "Névoa" : txt;
        txt= (txt.equals("Smoke")) ? "Fumaça" : txt;
        txt= (txt.equals("Haze")) ? "Neblina" : txt;
        txt= (txt.equals("Dust")) ? "Poeiras" : txt;
        txt= (txt.equals("Fog")) ? "Nevoeiro" : txt;
        txt= (txt.equals("Sand")) ? "Areias" : txt;
        txt= (txt.equals("Ash")) ? "Cinzas" : txt;
        txt= (txt.equals("Squall")) ? "Rajadas" : txt;
        txt= (txt.equals("Tornado")) ? "Tornado" : txt;
        txt= (txt.equals("Clear")) ? "Céu limpo" : txt;
        txt= (txt.equals("Clouds")) ? "Nuvens" : txt;

        return txt;
    }
}
