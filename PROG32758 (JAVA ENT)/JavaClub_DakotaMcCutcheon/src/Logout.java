

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
@WebServlet ("/Logout")
public class Logout extends HttpServlet {
    /**
	 * 
	 */
	private static final long serialVersionUID = 1L;

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {

    	HttpSession session = request.getSession(true);
    	
    	session.invalidate();//invalidates the session and unbinds all attributes associated with the session
    	
    	String body = "<h3>Good Bye</h3>\n"
    			+ "<br>"
    			+ "<br>"
    			+ "<a href='index.html'>Go to Main Page</a>\n";
				
		
				response.setContentType("text/html");
				PrintWriter out = response.getWriter();
				printHeader(out, "Good Bye", "");
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
					
					"</style>"+
					                "</head>\n" +
					                "<body>\n";
        out.println(header);
    }

    private void printFooter(PrintWriter out)
    {
        out.println("\n</body>\n</html>\n");
    }

}
