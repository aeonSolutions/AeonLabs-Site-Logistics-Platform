package qc.worker.login;


import android.app.Activity;
import android.content.Context;
import android.os.AsyncTask;
import android.util.Patterns;

import androidx.lifecycle.LiveData;
import androidx.lifecycle.MutableLiveData;
import androidx.lifecycle.ViewModel;

import org.json.JSONException;
import org.json.JSONObject;

import java.io.IOException;

import qc.worker.Network.HttpRequestHandler;
import qc.worker.R;
import qc.worker.abstraction.Functions;
import qc.worker.data.LoginRepository;
import qc.worker.data.Result;
import qc.worker.data.model.LoggedInUser;
import qc.worker.data.state;


public class LoginViewModel extends ViewModel {

    private MutableLiveData<LoginFormState> loginFormState = new MutableLiveData<>();
    private MutableLiveData<LoginResult> loginResult = new MutableLiveData<>();
    private LoginRepository loginRepository;

    LoginViewModel(LoginRepository loginRepository) {
        this.loginRepository = loginRepository;
    }

    LiveData<LoginFormState> getLoginFormState() {
        return loginFormState;
    }

    LiveData<LoginResult> getLoginResult() {
        return loginResult;
    }

    public void login(String username, Activity activity) {
        new MakeServerCall(state.HostUrl + "api/index.php?task=auth&uuid=" + username, activity).execute();
    }

    public class MakeServerCall extends AsyncTask<Void, Void, String> {

        private String url="";
        private Activity activity=null;

        public MakeServerCall (String url, Activity activity){
            this.url=url;
            this.activity=activity;
        }

        @Override
        protected String doInBackground(Void... params) {
            HttpRequestHandler requestHandler = new HttpRequestHandler();
            return requestHandler.sendGetRequest(this.url, this.activity);
        }

        @Override
        protected void onPostExecute(String response) {

            Result<LoggedInUser> result = loginRepository.login(response);

            try {
                JSONObject jsonObject = new JSONObject(response);
                if (jsonObject.getString("error").equals("false")) {
                    try {
                        state.workerName=jsonObject.getString("name");
                        state.UUID=jsonObject.getString("uuid");
                        LoggedInUser User = new LoggedInUser(state.UUID,state.workerName);
                        result = new Result.Success<>(User);
                    } catch (Exception e) {
                        Functions.SaveCrash(e, this.activity);

                        result = new Result.Error(new IOException("Error logging in", e));
                    }
                }else{
                    Exception e= new Exception();
                    result = new Result.Error(new IOException(Functions.getErrorCode(this.activity,response ),  new IOException()));

                }
            } catch (JSONException e) {
                Functions.SaveCrash(e, this.activity);
            }

            if (result instanceof Result.Success) {
                LoggedInUser data = ((Result.Success<LoggedInUser>) result).getData();
                loginResult.setValue(new LoginResult(new LoggedInUserView(data.getDisplayName())));
            } else {
                loginResult.setValue(new LoginResult(R.string.login_failed));
            }
        }
    }

    public void loginDataChanged(String username) {
        if (!isUserNameValid(username)) {
            loginFormState.setValue(new LoginFormState(R.string.invalid_username, null));
        } else {
            loginFormState.setValue(new LoginFormState(true));
        }
    }

    // A placeholder username validation check
    private boolean isUserNameValid(String username) {
        if (username == null) {
            return false;
        }
        return android.text.TextUtils.isDigitsOnly(username);

    }

    // A placeholder password validation check
    private boolean isPasswordValid(String password) {
        return password != null && password.trim().length() > 5;
    }
}
