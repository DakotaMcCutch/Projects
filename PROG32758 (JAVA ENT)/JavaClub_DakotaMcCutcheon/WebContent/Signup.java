

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.io.PrintWriter;

/**
 * Created by Dakota on 7/3/2014.
 */

@WebServlet ("/Signup")
public class Signup extends HttpServlet {
    /**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
    	doGet(request, response);
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        UserDatabase userDatabase = new UserDatabase();
        String id = request.getParameter ("userId");
        String password = request.getParameter("password");
        String repassword = request.getParameter("repassword");
        String firstName = request.getParameter("firstName");
        String lastName = request.getParameter("lastName");
        String email = request.getParameter("email");
        User user = new User(id, password, firstName, lastName, email);

       
        
        

        String body = "<div>\n";
        if (id == null || id.isEmpty())//validates that the userId field isn't empty or null, reprints the registration page if null or empty
        {
        	body += "<h1>Java Club Registration form</h1>"+
        			"<p style=\"color:#FF3300;\">User name can not be null</p>"+
        			"<form action=\"Signup\" method=\"GET\">"+
        				"<div class=\"text\">"+
        					"<label>Choose User ID:</label><input type=\"text\" name=\"userId\" ><br>"+
        					"<label>Choose Your Password:</label><input type=\"text\"><br>"+
        					"<label>Re-enter password:</label><input type=\"text\" name=\"repassword\" ><br>"+
        					"<label>Enter Your First Name:</label><input type=\"text\" name=\"firstName\" ><br>"+
        					"<label>Enter Your Last Name:</label><input type=\"text\" name=\"lastName\" ><br> "+
        					"<label>Enter Your Email Address:</label><input type=\"text\" name=\"email\"  ><br>"+
        					"<label></label><input class=\"Signup\" type=\"submit\" value=\"Signup\">"+
        				"</div>"+
        			"</form>";
        }
        else if (password == null || password.isEmpty())//validates that the Password field isn't empty or null, reprints the registration page if null or empty
        {
        	body += "<h1>Java Club Registration form</h1>"+
        			"<p style=\"color:#FF3300;\">password can not be null</p>"+
        			"<form action=\"Signup\" method=\"GET\">"+
        				"<div class=\"text\">"+
        					"<label>Choose User ID:</label><input type=\"text\" name=\"userId\" ><br>"+
        					"<label>Choose Your Password:</label><input type=\"text\" name=\"password\" ><br>"+
        					"<label>Re-enter password:</label><input type=\"text\" name=\"repassword\" ><br>"+
        					"<label>Enter Your First Name:</label><input type=\"text\" name=\"firstName\" ><br>"+
        					"<label>Enter Your Last Name:</label><input type=\"text\" name=\"lastName\" ><br> "+
        					"<label>Enter Your Email Address:</label><input type=\"text\" name=\"email\" ><br>"+
        					"<label></label><input class=\"Signup\" type=\"submit\" value=\"Signup\">"+
        				"</div>"+
        			"</form>";
        }
        else if (firstName == null || firstName.isEmpty())//validates that the firstName field isn't empty or null, reprints the registration page if null or empty
        {
        	body += "<h1>Java Club Registration form</h1>"+
        			"<p style=\"color:#FF3300;\">First name can not be null</p>"+
        			"<form action=\"Signup\" method=\"GET\">"+
        				"<div class=\"text\">"+
        					"<label>Choose User ID:</label><input type=\"text\" name=\"userId\" ><br>"+
        					"<label>Choose Your Password:</label><input type=\"text\" name=\"password\" ><br>"+
        					"<label>Re-enter password:</label><input type=\"text\" name=\"repassword\" ><br>"+
        					"<label>Enter Your First Name:</label><input type=\"text\" name=\"firstName\" ><br>"+
        					"<label>Enter Your Last Name:</label><input type=\"text\" name=\"lastName\" ><br> "+
        					"<label>Enter Your Email Address:</label><input type=\"text\" name=\"email\"  ><br>"+
        					"<label></label><input class=\"Signup\" type=\"submit\" value=\"Signup\">"+
        				"</div>"+
        			"</form>";
        }
        else if (lastName == null || lastName.isEmpty())//validates that the lastName field isn't empty or null, reprints the registration page if null or empty
        {
        	body += "<h1>Java Club Registration form</h1>"+
        			"<p style=\"color:#FF3300;\">Last Name Can not be null</p>"+
        			"<form action=\"Signup\" method=\"GET\">"+
        				"<div class=\"text\">"+
        					"<label>Choose User ID:</label><input type=\"text\" name=\"userId\" ><br>"+
        					"<label>Choose Your Password:</label><input type=\"text\" name=\"password\" ><br>"+
        					"<label>Re-enter password:</label><input type=\"text\" name=\"repassword\" ><br>"+
        					"<label>Enter Your First Name:</label><input type=\"text\" name=\"firstName\" ><br>"+
        					"<label>Enter Your Last Name:</label><input type=\"text\" name=\"lastName\" ><br> "+
        					"<label>Enter Your Email Address:</label><input type=\"text\" name=\"email\"  ><br>"+
        					"<label></label><input class=\"Signup\" type=\"submit\" value=\"Signup\">"+
        				"</div>"+
        			"</form>";
        }
        else if (email == null ||email.isEmpty())//validates that the email field isn't empty or null, reprints the registration page if null or empty
        {
        	body += "<h1>Java Club Registration form</h1>"+
        			"<p style=\"color:#FF3300;\">email can not be null</p>"+
        			"<form action=\"Signup\" method=\"GET\">"+
        				"<div class=\"text\">"+
        					"<label>Choose User ID:</label><input type=\"text\" name=\"userId\" ><br>"+
        					"<label>Choose Your Password:</label><input type=\"text\" name=\"password\" ><br>"+
        					"<label>Re-enter password:</label><input type=\"text\" name=\"repassword\" ><br>"+
        					"<label>Enter Your First Name:</label><input type=\"text\" name=\"firstName\"><br>"+
        					"<label>Enter Your Last Name:</label><input type=\"text\" name=\"lastName\"><br> "+
        					"<label>Enter Your Email Address:</label><input type=\"text\" name=\"email\"  ><br>"+
        					"<label></label><input class=\"Signup\" type=\"submit\" value=\"Signup\">"+
        				"</div>"+
        			"</form>";
        }
        else if(userDatabase.validUser(id) == true)//validates that the userName inputed doesn't already exist in the database
        {

           body += "<h1>Java Club Registration form</h1>"+
	"<p style=\"color:#FF3300;\">That UserNames Already Taken</p>"+
	"<form action=\"Signup\" method=\"GET\">"+
		"<div class=\"text\">"+
			"<label>Choose User ID:</label><input type=\"text\" name=\"userId\"><br>"+
			"<label>Choose Your Password:</label><input type=\"text\" name=\"password\" ><br>"+
			"<label>Re-enter password:</label><input type=\"text\" name=\"repassword\" ><br>"+
			"<label>Enter Your First Name:</label><input type=\"text\" name=\"firstName\"><br>"+
			"<label>Enter Your Last Name:</label><input type=\"text\" name=\"lastName\" ><br> "+
			"<label>Enter Your Email Address:</label><input type=\"text\" name=\"email\" ><br>"+
			"<label></label><input class=\"Signup\" type=\"submit\" value=\"Signup\">"+
		"</div>"+
	"</form>";
        }
        else if (password.equals(repassword) !=true)//validates that the password entered in the password field matches the password in the re-entry field
        {
        	body += "<h1>Java Club Registration form</h1>"+
        			"<p style=\"color:#FF3300;\">Passwords Must Match</p>"+
        			"<form action=\"Signup\" method=\"GET\">"+
        				"<div class=\"text\">"+
        					"<label>Choose User ID:</label><input type=\"text\" name=\"userId\" ><br>"+
        					"<label>Choose Your Password:</label><input type=\"text\" name=\"password\" ><br>"+
        					"<label>Re-enter password:</label><input type=\"text\" name=\"repassword\" ><br>"+
        					"<label>Enter Your First Name:</label><input type=\"text\" name=\"firstName\" ><br>"+
        					"<label>Enter Your Last Name:</label><input type=\"text\" name=\"lastName\" ><br> "+
        					"<label>Enter Your Email Address:</label><input type=\"text\" name=\"email\"  ><br>"+
        					"<label></label><input class=\"Signup\" type=\"submit\" value=\"Signup\">"+
        				"</div>"+
        			"</form>";
        }
        else //if all validation is complete and no errors the user is add to the data base
        {
        int result = userDatabase.addUser(user);
	        if (result > 0) //checks to the int returned from the addUser() method if the user was successfully added to the database
	        {
	            body += "Sign up successful, Thank you for joining JavaClub <br>"
	            		+ "<a href='index.html'>Go to Main Page</a>\n";
	        }
	        else // runs if addUser() fails to add user to database
	        {
	        	body += "<h1>Java Club Registration form</h1>"+
	        			"<p style=\"color:#FF3300;\">That UserNames Already Taken</p>"+
	        			"<form action=\"Signup\" method=\"GET\">"+
	        				"<div class=\"text\">"+
	        					"<label>Choose User ID:</label><input type=\"text\" name=\"userId\"><br>"+
	        					"<label>Choose Your Password:</label><input type=\"text\" name=\"password\" ><br>"+
	        					"<label>Re-enter password:</label><input type=\"text\" name=\"repassword\" ><br>"+
	        					"<label>Enter Your First Name:</label><input type=\"text\" name=\"firstName\"><br>"+
	        					"<label>Enter Your Last Name:</label><input type=\"text\" name=\"lastName\" ><br> "+
	        					"<label>Enter Your Email Address:</label><input type=\"text\" name=\"email\" ><br>"+
	        					"<label></label><input class=\"Signup\" type=\"submit\" value=\"Signup\">"+
	        				"</div>"+
	        			"</form>";
	        }
        }
        response.setContentType("text/html");
        PrintWriter out = response.getWriter();

        printHeader (out, "", " ");
        out.println(body);
        printFooter(out);
        
        
    }
    private void printHeader(PrintWriter out, String title, String css)
    {
        String header = "<!DOCTYPE html>\n" +
                "<html lang=\"en\">\n" +
                "<head>\n" +
                "<meta charset=\"utf-8\">\n" +
                "<title>" +
                title +
                "</title>\n" +
                "<style>"+
					"input {"+
					"	text-align: center;"+
					"}"
					+ ".all"
					+"{"
					+"	background-image: url(img/6.jpg);"
					+ "   background-repeat: repeat;"
					 + "  color:black; "
					  + " text-shadow: 1px 1px white;"
					  +  " background-size:818px 950px;"
					+"}"
					+ ".text"+
						"{"+
						"	background-image: url(img/7.jpg);"+
						"    background-repeat: no-repeat;"+
						"     background-size:818px 950px;"+
						"}"+
						  "h1"+
							"{"+
							" border-bottom: Black solid;"
							+"box-shadow: 1px 1px white;"+
							"}"+
					
					".text label {"+
					"display: inline-block;"+
					"vertical-align: baseline;"+
					"	width: 150px;"+
					"}"+
					
					".signup {"+
						"display: inline-block;"+
						"vertical-align: baseline;"+
						"width: 155px;"+
					"}"+
					"</style>"+
					                "</head>\n" +
					                "<body class=\"all\"><div class=\"text\">\n";
        out.println(header);
    }

    private void printFooter(PrintWriter out)
    {
        out.println("\n</div></body>\n</html>\n");
    }

}
