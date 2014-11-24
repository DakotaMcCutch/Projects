

import javax.servlet.ServletException;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.HttpSession;
import java.io.IOException;
import java.io.PrintWriter;

@WebServlet("/MainPage")
public class MainPage extends HttpServlet {
	private static final long serialVersionUID = 1L;

	protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		
	}
	
	protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
		
		HttpSession session = request.getSession(true);
		User user = (User) session.getAttribute("user");
		String body = "<h3>Welcome " +
				user.getFirstName() +
				", Login successful to Java Club.</h3>\n"
				+ "<br>"
				+ "<div>Your Name Is " + user.getFirstName() + " " + user.getLastName() + ""
				+ "<br><br><br>"
				+"<a href='"+response.encodeURL("Logout")+"'>Logout</a>\n";
				
				response.setContentType("text/html");
				PrintWriter out = response.getWriter();
				printHeader(out, "Welcome", "");
				out.println(body);
				printFooter(out);
	}
	private void printHeader (PrintWriter out, String title, String css)//prints HTML header
    {
        String header = "<!DOCTYPE html>\n" +
                "<html lang=\"en\">\n" +
                "<head>\n" +
                "<meta charset=\"utf-8\">\n" +
                "<title>" +
                title +
                "</title>\n" +
                css +
                "</head>\n" +
                "<body>\n";
        out.println (header);
    }


    private void printFooter (PrintWriter out)//Prints HTML footer
    {
        out.println ("\n</body>\n</html>\n");
    }
}
