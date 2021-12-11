package construction.site.logistics.foreman.Network;

import android.app.Activity;
import android.content.Context;
import android.os.AsyncTask;
import android.os.CountDownTimer;
import android.widget.Toast;

import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentActivity;
import androidx.fragment.app.FragmentTransaction;

import org.json.JSONObject;

import java.net.URLEncoder;
import java.util.ArrayList;
import java.util.List;
import java.util.Observable;

import construction.site.logistics.foreman.Encryption.Encryption;
import construction.site.logistics.foreman.Fragments.FragmentJournal;
import construction.site.logistics.foreman.MainActivity;
import construction.site.logistics.foreman.R;
import construction.site.logistics.foreman.abstraction.Functions;
import construction.site.logistics.foreman.data.database.EntityFields;
import construction.site.logistics.foreman.data.database.EntityFiles;
import construction.site.logistics.foreman.data.database.EntityQueue;
import construction.site.logistics.foreman.data.database.LocalDatabaseOperations;
import construction.site.logistics.foreman.data.state;


public class SendData  {

    private Activity activity=null;
    private FragmentActivity fragmentActivity=null;

    private EntityQueue queue=null;
    private List<EntityFields> fieldsInList=null;
    private List<EntityFiles> filesInList=null;

    private Boolean encrypt;
    private String encryptionType="";
    private Boolean waitForCode=false;
    private Boolean loadMainPage=false;
    private Boolean enableQueue=true;
    private Integer retryCount;
    private String title;

    private static Boolean error;
    private String responseMsg="";
    public ObservableValue DelayedResult;

    public SendData (Activity _activity, FragmentActivity _fragmentActivity){
        this.activity=_activity;
        this.fragmentActivity=_fragmentActivity;
        this.DelayedResult = new ObservableValue(getResponse());
        this.retryCount=0;
    }

    public void setWaitForCode(Boolean _wait){ waitForCode=_wait;}
    public void setloadMainPage(Boolean _load){ loadMainPage=_load;}
    public String getResponse(){ return responseMsg; }
    public Boolean getError(){ return error; }

    public void addQueue(EntityQueue _queue){ queue=_queue;}
    public void addFields(List<EntityFields> _fields){ fieldsInList=_fields;}
    public void addfFiles(List<EntityFiles> _files){ filesInList=_files;}

    public void setEnableQueue(Boolean _queue){ enableQueue=_queue; }
    public void setEncryption(Boolean _encrypt, String _type){
        encryptionType= _type;
        encrypt=_encrypt;
    }


    public class ObservableValue extends Observable
    {
        private String responseMsg = "";
        public ObservableValue(String _responseMsg)
        {
            this.responseMsg = _responseMsg;
        }
        public void setValue(String _responseMsg)
        {
            this.responseMsg = _responseMsg;
            setChanged();
            notifyObservers();
        }
        public String getValue()
        {
            return responseMsg;
        }
    }

    public boolean send(){
        error=false;
        if (waitForCode) {
            try{
                SendDataAsync sendDataAsync =new SendDataAsync();
                sendDataAsync.executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR).get();
                error=false;
                return true;
            }catch(Exception e){
                Functions.SaveCrash(e, activity);
                error=true;
                return false;
            }
        }else{
            SendDataAsync sendDataAsync =new SendDataAsync();
            sendDataAsync.executeOnExecutor(AsyncTask.THREAD_POOL_EXECUTOR);
            error=false;
            return true;
        }
    }

    private class SendDataAsync extends AsyncTask<Void, Void, String> {

        @Override
        protected String doInBackground(Void... params) {
            error=true;
            if (queue == null) {
                responseMsg = "{'error':true,'message':'" + activity.getResources().getString(R.string.sendData_missing_queue) + "'}";
            } else if (fieldsInList == null) {
                responseMsg = "{'error':true,'message':'" + activity.getResources().getString(R.string.sendData_missing_fields) + "'}";
            } else if (state.getNetworkStatus()) { // send immediately
                //Json format var="{'error':true,'message':'some message'}";
                String Data2Send = "{";
                String temp = "";

                JSONObject jObjectData = new JSONObject();
                List<String> FileNamesList= new ArrayList<>();
                FileNamesList.clear();
                Data2Send = "";

                EntityFields field = new EntityFields();
                field.setRequestVar("tid");
                field.setValue(state.serial);
                fieldsInList.add(field);
                try {
                    for (int i = 0; i < fieldsInList.size(); i++) {
                        jObjectData.put(fieldsInList.get(i).getRequestVar(), fieldsInList.get(i).getValue().replace("'", "\'").replace('"', '\"'));
                    }

                    if (filesInList != null) {
                        temp = "";
                        String temp2 = "";
                        for (int i = 0; i < filesInList.size(); i++) {
                            FileNamesList.add(filesInList.get(i).getFilename());
                            temp2 += filesInList.get(i).getAppendCode() ? "1" : "0";
                            temp += i == 0 ? temp2 : "," + temp2;
                        }
                        jObjectData.put("filecode", temp);
                    }
                } catch (Exception e) {
                    Functions.SaveCrash(e, activity);
                }
                Data2Send = jObjectData.toString();

                Encryption encryption = new Encryption(activity);
                encryption.setSecretKey(state.encryptionKey);
                if (encryption.encryptString(Data2Send)) {
                    HttpComm request = new HttpComm(activity);
                    request.setType("post");
                    request.setCharSet("UTF-8");
                    activity.runOnUiThread(new Runnable() {
                        public void run() {
                            Functions.showSimpleProgressDialog(activity, activity.getResources().getString(R.string.commServer_connect_title_msg), activity.getResources().getString(R.string.commServer_connect_msg),false);
                        }
                    });
                    String urlEncoded="";
                    try{
                        urlEncoded=URLEncoder.encode(encryption.getEncryptedString(), "UTF-8");
                    }catch (Exception e){
                        urlEncoded=encryption.getEncryptedString();
                    }
                    error = !request.send(queue.getUrl(), urlEncoded, FileNamesList);
                    activity.runOnUiThread(new Runnable() {
                        public void run() {
                            Functions.removeSimpleProgressDialog();
                        }
                    });

                    if(queue.getMsgError().equals("debug")) {
                        encryption.decryptString(request.getResponse());
                        responseMsg = "{'error':true,'message':'DEBUG: " + encryption.getDecryptedString() + "'}";
                    }else if(error && retryCount< 6){
                        activity.runOnUiThread(new Runnable() {
                            public void run() {
                                new CountDownTimer(20000, 1000) {
                                    public void onTick(long millisUntilFinished) {
                                        activity.setTitle(request.getMessage()+"."+R.string.commServer_retry+" "+millisUntilFinished / 1000);
                                    }
                                    public void onFinish() {
                                        activity.setTitle(title);
                                        retryCount++;
                                        send();
                                    }
                                }.start();
                            }
                        });
                        return "retrying";
                    }else if (error && enableQueue) {
                        LocalDatabaseOperations localDatabaseOperations = new LocalDatabaseOperations(activity);
                        error = LocalDatabaseOperations.addQueue(queue, fieldsInList, filesInList);
                        if (error) {
                            responseMsg = "{'error':true,'message':'" + request.getMessage() + System.getProperty("line.separator") + localDatabaseOperations.getErrMessage() + "'}";
                        } else {
                            responseMsg = "{'error':false,'message':'" + activity.getResources().getString(R.string.sendData_added_queue) + "'}";
                        }
                    } else if (error && !enableQueue) {
                        responseMsg = "{'error':true,'message':'" + request.getMessage() + "'}";
                    } else { // success sending request
                        if (encryption.decryptString(request.getResponse())) {
                            if (encryption.getEncryptedVector().equals(encryption.getDecryptedVector())) {
                                responseMsg = encryption.getDecryptedString(); // success on reteiving data from server
                            } else {
                                String ss=encryption.getEncryptedVector();
                                String sss=encryption.getDecryptedVector();
                                String s=encryption.getDecryptedString();
                                responseMsg = "{'error':true,'message':'" + activity.getResources().getString(R.string.sendData_error_ivector) + "'}";
                            }
                        } else { // error decrypting string
                            responseMsg = "{'error':true,'message':'" + activity.getResources().getString(R.string.sendData_error_decrypt_data) + "'}";
                            String response= request.getResponse();
                            String str= "Message:"+encryption.getErrMessage()+"  >>>>Encrypt:"+ encryption.getEncryptedVector()+"  >>>>Dencrypt:"+ encryption.getDecryptedVector();
                            Exception e= new Exception(str);
                            Functions.SaveCrash(e, activity);
                        }
                    }
                } else { // error encrypting string
                    responseMsg = "{'error':true,'message':'" + activity.getResources().getString(R.string.sendData_error_encrypt_data) + "'}";
                }
            }else if(!enableQueue){
                responseMsg = "{'error':true,'message':'" + activity.getResources().getString(R.string.error_no_network)  + "'}";
            } else { // send to queue
                LocalDatabaseOperations localDatabaseOperations = new LocalDatabaseOperations(activity);
                error = LocalDatabaseOperations.addQueue(queue, fieldsInList, filesInList);
                if (error) {
                    responseMsg = "{'error':true,'message':'" + localDatabaseOperations.getErrMessage() + "'}";
                } else {
                    responseMsg = "{'error':false,'message':'" + activity.getResources().getString(R.string.sendData_added_queue) + "'}";
                }
            }
            return responseMsg;
        }

        @Override
        protected void onPostExecute(String response) {
            if(response.equals("retrying")){
                return;
            }
            DelayedResult.setValue(response);

            if (queue.getMsgType().equals("toast")) {
                if (Functions.isSuccess(response)) {
                    if (queue.getMsgSuccess().equals("") || queue.getMsgSuccess().equals("response")) {
                        activity.runOnUiThread(new Runnable() {
                            public void run() {
                                Toast.makeText(activity, Functions.getErrorCode(activity, response), Toast.LENGTH_SHORT).show();
                            }
                        });
                    } else {
                        activity.runOnUiThread(new Runnable() {
                            public void run() {
                                Toast.makeText(activity, queue.getMsgSuccess(), Toast.LENGTH_SHORT).show();
                            }
                        });
                    }
                } else {
                    if (queue.getMsgError().equals("") || queue.getMsgError().equals("response")) {
                        activity.runOnUiThread(new Runnable() {
                            public void run() {
                                Toast.makeText(activity, Functions.getErrorCode(activity, response), Toast.LENGTH_SHORT).show();
                            }
                        });
                    } else {
                        activity.runOnUiThread(new Runnable() {
                            public void run() {
                                Toast.makeText(activity, queue.getMsgError(), Toast.LENGTH_SHORT).show();
                            }
                        });
                    }
                }
            } else if (queue.getMsgType().equals("alertbox")) { // alertbox
                if (Functions.isSuccess(response)) {
                    if (queue.getMsgSuccess().equals("") || queue.getMsgSuccess().equals("response")) {activity.runOnUiThread(new Runnable() {
                        public void run() {
                            Functions.alertbox(activity.getResources().getString(R.string.commServer_submit_ok), Functions.getErrorCode(activity, response), activity);
                        }
                    });

                    } else {
                        activity.runOnUiThread(new Runnable() {
                            public void run() {
                                Functions.alertbox(activity.getResources().getString(R.string.commServer_submit_ok), queue.getMsgSuccess(), activity);
                            }
                        });
                    }
                } else {
                    if (queue.getMsgError().equals("") || queue.getMsgError().equals("response") || queue.getMsgError().equals("debug")) {
                        activity.runOnUiThread(new Runnable() {
                            public void run() {
                                Functions.alertbox(activity.getResources().getString(R.string.commServer_submit_error), Functions.getErrorCode(activity, response), activity);
                            }
                        });
                    } else {
                        activity.runOnUiThread(new Runnable() {
                            public void run() {
                                Functions.alertbox(activity.getResources().getString(R.string.commServer_submit_error), queue.getMsgError(), activity);
                            }
                        });
                    }
                }
            }
            // Show messageBox messages
            if (Functions.hasMessageBox(response)) {
                Functions.getMessageBox(response);
            }

            if (loadMainPage && !error) {
                FragmentTransaction fragmentTransaction = fragmentActivity.getSupportFragmentManager().beginTransaction();
                fragmentTransaction.replace(R.id.content_frame, new FragmentJournal());
                fragmentTransaction.commit();
            }
        }
    }
}
