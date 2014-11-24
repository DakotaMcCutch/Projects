
/**
 * Created by Dakota on 6/16/2014.
 */
public class User {
    private String id;
    private String password;
    private String firstName;
    private String lastName;
    private String email;

    public User()
    {

    }
    public User (String id, String password, String firstName, String lastName, String email)//constructor for the user
    {
        this.id=id;
        this.password=password;
        this.firstName=firstName;
        this.lastName=lastName;
        this.email=email;

    }

    public String getId() {
        return id;
    }

    public void setId(String id) {
        this.id = id;
    }

    public String getPassword() {
        return password;
    }

    public void setPassword(String password) {
        this.password = password;
    }

    public String getFirstName() {
        return firstName;
    }

    public void setFirstName(String firstName) {
        this.firstName = firstName;
    }

    public String getLastName() {
        return lastName;
    }

    public void setLastName(String lastName) {
        this.lastName = lastName;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }
}
