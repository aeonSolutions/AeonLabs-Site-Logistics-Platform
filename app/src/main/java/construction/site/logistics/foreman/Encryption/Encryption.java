package construction.site.logistics.foreman.Encryption;

import android.app.Activity;

import androidx.annotation.Nullable;

import java.util.Optional;

import construction.site.logistics.foreman.data.state;

public class Encryption {

    private  Boolean error;
    private  String ErrMessage = "";
    private  String EncryptedMsg, DecryptedMsg;
    private  String EncryptedVector, DecryptedVector;
    private  Activity activity;
    private  String secretKey="";

    public String getErrMessage() {
        return ErrMessage;
    }

    public Boolean getError() {
        return error;
    }

    public String getEncryptedString() {
        return EncryptedMsg;
    }

    public String getDecryptedString() {
        return DecryptedMsg;
    }


    public String getEncryptedVector() {
        return EncryptedVector;
    }

    public String getDecryptedVector() {
        return DecryptedVector;
    }

    public void setSecretKey(String key){
        secretKey=key;
    }

    public Encryption(Activity _activity) {
        activity = _activity;
        secretKey="";
    }

    public boolean encryptString(String str) {
        if(state.encryptionKey.equals("")){
            ErrMessage="encryption key not found";
            return false;
        }
        if(secretKey.equals("")){
            secretKey=state.encryptionKey;
        }

        AESCipher encrypted = AESCipher.encrypt(secretKey, str);
        error = encrypted.hasError(); // TRUE if operation failed, FALSE otherwise
        EncryptedMsg = encrypted.getData(); // Encoded/Decoded result
        EncryptedVector=encrypted.getInitVector(); // Get used (random if encode) init vector
        ErrMessage=encrypted.getErrorMessage();
        return !error;
    }

    public boolean decryptString(String str) {
        if(state.encryptionKey.equals("")){
            ErrMessage="encryption key not found";
            return false;
        }
        if(secretKey.equals("")){
            secretKey=state.encryptionKey;
        }

        AESCipher decrypted = AESCipher.decrypt(secretKey, str);
        error = decrypted.hasError(); // TRUE if operation failed, FALSE otherwise
        DecryptedMsg = decrypted.getData(); // Encoded/Decoded result
        DecryptedVector= decrypted.getInitVector(); // Get used (random if encode) init vector
        ErrMessage=decrypted.getErrorMessage();
        return !error;
    }
}