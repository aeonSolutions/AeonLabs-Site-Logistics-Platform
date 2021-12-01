package construction.site.logistics.foreman.data;

import java.io.IOException;
import construction.site.logistics.foreman.data.model.LoggedInUser;

/**
 * Class that handles authentication w/ login credentials and retrieves user information.
 */
public class LoginDataSource  {

    public Result<LoggedInUser> login(String username) {
        return new Result.Error(new IOException("Nothing to Do", new IOException()));
    }
}
