package softuni.workshop.model.binding;

import org.hibernate.validator.constraints.Length;

public class UserLogin {
    private final String username;
    private final String password;

    public UserLogin(String username, String password) {
        this.username = username;
        this.password = password;
    }

    @Length(min = 2,max = 10,message = "Username must be between 2 and 10 characters")
    public String getUsername() {
        return username;
    }

    @Length(min = 3,max = 15,message = "Password must be between 3 and 15 characters")
    public String getPassword() {
        return password;
    }
}
