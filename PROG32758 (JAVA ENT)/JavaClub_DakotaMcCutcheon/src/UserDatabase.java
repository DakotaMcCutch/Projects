

import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 * Created by Dakota on 6/16/2014.
 */
public class UserDatabase {
    private static final String DB_URL = "jdbc:mysql://localhost:3306/dev";//Database URL
    private static final String DB_USER = "root";//Database Username
    private static final String DB_PASS = "1234";//Database Password

    private JdbcHelper jdbc = null;

    public UserDatabase()//constructor for UserDatabase
    {
        jdbc = new JdbcHelper();
    }

    public int addUser (User user)// adds user to the User database
    {
        jdbc.connect(DB_URL,DB_USER,DB_PASS);
        String sql = "INSERT INTO User (id, password, firstName, lastName, email) VALUES (?, ?, ?, ?, ?)";

        ArrayList<Object> params = new ArrayList<Object>();
        params.add(user.getId());// setting of the userId to the Parrams list to be sent to the jdbc
        params.add(user.getPassword());// setting of the Password to the Parrams list to be sent to the jdbc
        params.add(user.getFirstName());// setting of the First name to the Parrams list to be sent to the jdbc
        params.add(user.getLastName());// setting of the Last Name to the Parrams list to be sent to the jdbc
        params.add(user.getEmail());// setting of the Email to the Parrams list to be sent to the jdbc

        int result = jdbc.update(sql, params);

        jdbc.disconnect();
        return result;
    }

    public ArrayList<User> getUsers()// gets a list of all users from the database, this is not to be confused with the getUser Method Below
    {
        jdbc.connect(DB_URL,DB_USER,DB_PASS);

        String sql = "SELECT * FROM User";

        ArrayList<User> users = new ArrayList<User>();

        try
        {
            ResultSet result = jdbc.query(sql, null);

            while (result.next())
            {
                User user = new User(result.getString(1),result.getString(2),result.getString(3),result.getString(4),result.getString(5));
                users.add(user);
            }
        }
        catch(SQLException e)
        {
            System.err.println(e.getSQLState() + ": " + e.getMessage());
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }

        jdbc.disconnect();
        return users;
    }
    public boolean validLogin(String user, String password)// Validates that the user name and password are in the database and are correct
    {
    	 boolean bValid = false;
    	jdbc.connect(DB_URL,DB_USER,DB_PASS);

        String sql = "SELECT * FROM User WHERE id=? && password=?";
        
        ArrayList<Object> params = new ArrayList<Object>();
        params.add(user);
        params.add(password);
        try
        {
            ResultSet result = jdbc.query(sql, params);

            if (result.next())//if there is a next means there is a match
            {
            	bValid=true;
            }
        }
        catch(SQLException e)
        {
            System.err.println(e.getSQLState() + ": " + e.getMessage());
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }
        jdbc.disconnect();
        return bValid;
    	
    }
    public boolean validUser(String user)//Used In The Signup Servlet To Check The Database For Existing User
    {
    	boolean bValid = true;

    	ArrayList <User> arrList = getUsers();

    	for (int i=0; i < arrList.size();++i)
    	{
    		User dbUser = arrList.get(i);
    	        if (user.equals(dbUser.getId()) !=true)//compares the user name from the Registration page to a user in the database
    	        {
    	        	bValid=false;
    	        }
    	}
    	return bValid;
    	
    }
    public User getUser(String user)// Retreives The Users Data Located In The User Database 
    {
    	jdbc.connect(DB_URL,DB_USER,DB_PASS);

        String sql = "SELECT * FROM User WHERE id=\'"+user+"\'";
        User dbUser = null;
        try
        {
            ResultSet result = jdbc.query(sql, null);

            while (result.next())
            {
                dbUser = new User(result.getString(1),result.getString(2),result.getString(3),result.getString(4),result.getString(5));
            }
        }
        catch(SQLException e)
        {
            System.err.println(e.getSQLState() + ": " + e.getMessage());
        }
        catch(Exception e)
        {
            e.printStackTrace();
        }
        
		return dbUser;
    	
    }

    public static String getDbUrl() {
        return DB_URL;
    }

    public static String getDbUser() {
        return DB_USER;
    }

    public static String getDbPass() {
        return DB_PASS;
    }

    public JdbcHelper getJdbc() {
        return jdbc;
    }

    public void setJdbc(JdbcHelper jdbc) {
        this.jdbc = jdbc;
    }
}

