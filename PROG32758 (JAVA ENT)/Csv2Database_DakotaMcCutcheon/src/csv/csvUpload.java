/* Dakota McCutcheon #991321209 */
package csv;

import javax.servlet.RequestDispatcher;
import javax.servlet.ServletException;
import javax.servlet.annotation.MultipartConfig;
import javax.servlet.annotation.WebServlet;
import javax.servlet.http.HttpServlet;
import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;
import javax.servlet.http.Part;
import java.io.IOException;
import java.io.InputStream;
import java.util.ArrayList;

/**
 * Created by Dakota on 7/23/2014.
 */
@WebServlet("/csvUpload")
@MultipartConfig
public class csvUpload extends HttpServlet {
    protected void doPost(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        Part part = request.getPart("file");
        InputStream is = part.getInputStream() ;
        int parsedCount;
        int addedCount;

        Csv2Database db = new Csv2Database ();


        ArrayList<Person> person = db.readCsv(is);//receives an Arraylist of all records parsed
        ArrayList<Person> addedPersons = db.addPersons(person);
        parsedCount = db.getParsedPersons().size();
        addedCount = db.getAddedPersons().size();
        request.setAttribute("parsedCount", parsedCount);
        request.setAttribute("addedCount", addedCount);
        request.setAttribute("addedPersons", addedPersons);
        is.close();
        RequestDispatcher rd = getServletContext().getRequestDispatcher("/csvResult.jsp");
        rd.forward(request, response);
    }

    protected void doGet(HttpServletRequest request, HttpServletResponse response) throws ServletException, IOException {
        doPost(request,response);
    }
}
