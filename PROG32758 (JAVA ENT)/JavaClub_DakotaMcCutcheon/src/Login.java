

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.io.PrintWriter;

/**
 * Created by Dakota on 7/3/2014.
 */
@WebServlet ("/Login")
public class Login extends HttpServlet {
    /**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        doGet(request,response);
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

        UserDatabase DB = new UserDatabase();

        response.setContentType("text/html");

        String userId = request.getParameter("userId");

        String password = request.getParameter("password");

        String body = "<div>\n";

        if(DB.validLogin(userId,password) != true)
        {

           body += "<form action=\"Login\" method=\"GET\">"
           		+ "<p style=\"color:white; text-shadow: 1px 1px black;\">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;You Have Entered An Invalid User ID And Password</p>" +
            "<label style=\"color:white; text-shadow: 1px 1px black;\">User ID: </label><input type=\"text\" name=\"userId\"><br>"+
            "<label style=\"color:white; text-shadow: 1px 1px black;\">Password:</label><input type=\"text\" name=\"password\"><br>"+
            "<label></label><input class=\"signup\" type=\"submit\" value=\"login\">"+
            "</form>" ;
        }
        else
        {
        	HttpSession session = request.getSession(true);
        	User arrList = DB.getUser(userId);//gets the infomation of the user that is stored in the database
        	session.setAttribute("user", arrList );//created attribute of the user thats logged in
        	session.setMaxInactiveInterval(-1);//session set to never expire unless invalidated
        response.sendRedirect(response.encodeRedirectURL("MainPage"));
        }
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
                "</title>\n"
                + "<style>" +
                ".all"
                + "{"
                + "background-image: url(img/4.jpg);"
                + " background-size:818px 950px;"
                + " background-repeat:repeat;"
        + "}" +
        "input {"+
		"	text-align: center;"+
		"}"+
		
		"label {"+
		"display: inline-block;"+
		"vertical-align: baseline;"+
		"	width: 150px;"+
		"}"+
		
		".signup {"+
			"display: inline-block;"+
			"vertical-align: baseline;"+
			"width: 155px;"+
		"}"
        + "</style>" +
                "</head>\n" +
                "<body class=\"all\">\n";
        out.println(header);
    }

    private void printFooter(PrintWriter out)
    {
        out.println("\n</body>\n</html>\n");
    }


}
