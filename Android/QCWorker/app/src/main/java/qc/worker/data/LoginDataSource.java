package qc.worker.data;

import java.io.IOException;
import qc.worker.data.model.LoggedInUser;

/**
 * Class that handles authentication w/ login credentials and retrieves user information.
 */
public class LoginDataSource  {

    public Result<LoggedInUser> login(String username) {
        return new Result.Error(new IOException("Nothing to Do", new IOException()));
    }
}
