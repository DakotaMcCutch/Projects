import java.io.*;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.Calendar;

/**
 * Created by Dakota on 3/27/2014.
 */
public class WorldBank {
    private BufferedReader in = null;
    private PrintWriter out = null;
    private String[] sTemp;
  private ArrayList<String>recordArr0= new ArrayList<String>();
    private ArrayList<String>recordArr1= new ArrayList<String>();
    private ArrayList<String>recordArr2= new ArrayList<String>();
    private ArrayList<String>recordArr3= new ArrayList<String>();
    private ArrayList<String>recordArr4= new ArrayList<String>();
    private ArrayList<String>recordArr5= new ArrayList<String>();
    private ArrayList<String>recordArr6= new ArrayList<String>();
    private ArrayList<String>recordArr7= new ArrayList<String>();
    private ArrayList<String>recordArr8= new ArrayList<String>();
    private ArrayList<String>recordArr9= new ArrayList<String>();
    private ArrayList<String>recordArr10= new ArrayList<String>();
    private ArrayList<String>recordArr11= new ArrayList<String>();
    private String tStamp = new SimpleDateFormat("EEE, d MMMMM YYYY HH:mm:ss").format(Calendar.getInstance().getTime());
    private int iCount;
   public void splice ()
   {
        boolean bMoreToDo;

        do {
            bMoreToDo = read();
            if (bMoreToDo) {


                recordArr0.add(sTemp[0]);
                recordArr1.add(sTemp[1]);
                recordArr2.add(sTemp[2]);
                recordArr3.add(sTemp[3]);
                recordArr4.add(sTemp[4]);
                recordArr5.add(sTemp[5]);
                recordArr6.add(sTemp[6]);
                recordArr7.add(sTemp[7]);
                recordArr8.add(sTemp[8]);
                recordArr9.add(sTemp[9]);
               recordArr10.add(sTemp[10]);
                recordArr11.add(sTemp[11]);
                iCount++;
            }

        } while (bMoreToDo);
    }
    public void open() {
        File f = new File("worldbank.csv");
        try {
            in = new BufferedReader(new FileReader(f));
        } catch (FileNotFoundException e) {
            System.out.println("File Was Not Found Error -" + e);
        }
    }

    public boolean read() {
        String line = null;
        boolean bRead = true;
        try {
            line = in.readLine();

        } catch (IOException e) {
            System.out.println("Error Occurred during reading of file Found Error -" + e);
        }
        if (line == null) {
            bRead = false;
        } else {
            line = line.replaceAll(",", "  ,");
            sTemp = line.split(",");
        }
        return bRead;
    }

    public void write() {
        File f = new File("worldbankOut.html");
        try {
            out = new PrintWriter(new BufferedWriter(new FileWriter(f)));
        } catch (IOException e) {
            System.out.println("Couldn't Write To File Found Error -" + e);
        }
        int size = recordArr0.size();

            out.println("<!DOCTYPE html>");
            out.println("<!---DAKOTA MCCUTCHEON ID#991 321 209 ---->");
            out.println("<html>");
            out.println("<head>");
            out.println("<style>");
            out.println(".title");
            out.println("{");
            out.println("    text-align: center;");
            out.println("}");
            out.println("table");
            out.println("{");
            out.println("border: 2px solid red;");
            out.println("}");
            out.println("tr, td,th");
            out.println("{");
            out.println(" border: 1px solid navy;");
            out.println(" padding: 7px;");
            out.println("}");
            out.println("tr:nth-child(-n+2)");
            out.println("{");
            out.println("background: lightblue;");
            out.println("}");
            out.println("</style>");
            out.println("<meta charset=\"utf-8\">");
            out.println("<title></title>");
            out.println("</head>");
            out.println("<body>");
            out.println("<h1 class=\"title\">Report <br>December 31,2005 <br> Compiled On: "+ tStamp + " </h1>");
            out.println("<table>");

            for (int i2 = 0; i2 <2;i2++)
            {
                out.println("<tr>");
                out.print("<th>" + recordArr0.get(i2) + "</th>");
                out.print("<th>" +recordArr1.get(i2) + "</th>");
                out.print("<th>" +recordArr2.get(i2) + "</th>");
                out.print("<th>" +recordArr3.get(i2) + "</th>");
                out.print("<th>" +recordArr4.get(i2) + "</th>");
                out.print("<th>" +recordArr5.get(i2) + "</th>");
                out.print("<th>" +recordArr6.get(i2) + "</th>");
                out.print("<th>" +recordArr7.get(i2) + "</th>");
                out.print("<th>" +recordArr8.get(i2) + "</th>");
                out.print("<th>" +recordArr9.get(i2) + "</th>");
                out.print("<th>" +recordArr10.get(i2) + "</th>");
                out.println("<th>" +recordArr11.get(i2) + "</th>");
                out.println("</tr>");

            }

            for (int i3 = 2; i3 <size;i3++)
            {
                out.println("<tr>");
                out.print("<td>" +  recordArr0.get(i3) + "</td>" );
                out.print("<td>" + recordArr1.get(i3 ) + "</td>" );
                out.print("<td>" + recordArr2.get(i3 ) + "</td>" );
                out.print("<td>" + recordArr3.get(i3 ) + "</td>" );
                out.print("<td>" + recordArr4.get(i3 ) + "</td>" );
                out.print("<td>" + recordArr5.get(i3 ) + "</td>" );
                out.print("<td>" + recordArr6.get(i3 ) + "</td>" );
                out.print("<td>" + recordArr7.get(i3 ) + "</td>" );
                out.print("<td>" + recordArr8.get(i3 ) + "</td>" );
                out.print("<td>" + recordArr9.get(i3 ) + "</td>" );
                out.print("<td>" + recordArr10.get(i3 ) + "</td>" );
                out.println("<td>" + recordArr11.get(i3 ) + "</td>" );
                out.println("</tr>");
            }

             out.println("</table>");
            out.println("<br>");
            out.println("<br>");
            out.println("<h4 class=\"title\">Compiled On: "+ tStamp + " </h4>");
           out.println("</body>");
           out.println("</html>");

/*
            for (int i = 0 ; i <size; i++)
            {
            out.print(recordArr0.get(i) + ",");
            out.print(recordArr1.get(i) + ",");
            out.print(recordArr2.get(i) + ",");
            out.print(recordArr3.get(i) + ",");
            out.print(recordArr4.get(i) + ",");
            out.print(recordArr5.get(i) + ",");
            out.print(recordArr6.get(i) + ",");
            out.print(recordArr7.get(i) + ",");
            out.print(recordArr8.get(i) + ",");
            out.print(recordArr9.get(i) + ",");
            out.print(recordArr10.get(i) + ",");
            out.print(recordArr11.get(i) + ",");
            out.println(",");
            */
        System.out.println("The Report Is Done Compiling");
        try {
            java.awt.Desktop.getDesktop().browse(java.net.URI.create("worldbankOut.html"));
        } catch (IOException e) {
            e.printStackTrace();
        }

    }


    public void close ()
    {
        out.close();
    }
    public void run()
    {
        open();
        splice();
        write();
        close();
    }

    public BufferedReader getIn() {
        return in;
    }

    public void setIn(BufferedReader in) {
        this.in = in;
    }

    public PrintWriter getOut() {
        return out;
    }

    public void setOut(PrintWriter out) {
        this.out = out;
    }

    public String[] getsTemp() {
        return sTemp;
    }

    public void setsTemp(String[] sTemp) {
        this.sTemp = sTemp;
    }

    public ArrayList<String> getRecordArr0() {
        return recordArr0;
    }

    public void setRecordArr0(ArrayList<String> recordArr0) {
        this.recordArr0 = recordArr0;
    }

    public ArrayList<String> getRecordArr1() {
        return recordArr1;
    }

    public void setRecordArr1(ArrayList<String> recordArr1) {
        this.recordArr1 = recordArr1;
    }

    public ArrayList<String> getRecordArr2() {
        return recordArr2;
    }

    public void setRecordArr2(ArrayList<String> recordArr2) {
        this.recordArr2 = recordArr2;
    }

    public ArrayList<String> getRecordArr3() {
        return recordArr3;
    }

    public void setRecordArr3(ArrayList<String> recordArr3) {
        this.recordArr3 = recordArr3;
    }

    public ArrayList<String> getRecordArr4() {
        return recordArr4;
    }

    public void setRecordArr4(ArrayList<String> recordArr4) {
        this.recordArr4 = recordArr4;
    }

    public ArrayList<String> getRecordArr5() {
        return recordArr5;
    }

    public void setRecordArr5(ArrayList<String> recordArr5) {
        this.recordArr5 = recordArr5;
    }

    public ArrayList<String> getRecordArr6() {
        return recordArr6;
    }

    public void setRecordArr6(ArrayList<String> recordArr6) {
        this.recordArr6 = recordArr6;
    }

    public ArrayList<String> getRecordArr7() {
        return recordArr7;
    }

    public void setRecordArr7(ArrayList<String> recordArr7) {
        this.recordArr7 = recordArr7;
    }

    public ArrayList<String> getRecordArr8() {
        return recordArr8;
    }

    public void setRecordArr8(ArrayList<String> recordArr8) {
        this.recordArr8 = recordArr8;
    }

    public ArrayList<String> getRecordArr9() {
        return recordArr9;
    }

    public void setRecordArr9(ArrayList<String> recordArr9) {
        this.recordArr9 = recordArr9;
    }

    public ArrayList<String> getRecordArr10() {
        return recordArr10;
    }

    public void setRecordArr10(ArrayList<String> recordArr10) {
        this.recordArr10 = recordArr10;
    }

    public ArrayList<String> getRecordArr11() {
        return recordArr11;
    }

    public void setRecordArr11(ArrayList<String> recordArr11) {
        this.recordArr11 = recordArr11;
    }

    public String gettStamp() {
        return tStamp;
    }

    public void settStamp(String tStamp) {
        this.tStamp = tStamp;
    }

    public int getiCount() {
        return iCount;
    }

    public void setiCount(int iCount) {
        this.iCount = iCount;
    }

    @Override
    public String toString() {
        return "WorldBank{" +
                "in=" + in +
                ", out=" + out +
                ", sTemp=" + Arrays.toString(sTemp) +
                ", recordArr0=" + recordArr0 +
                ", recordArr1=" + recordArr1 +
                ", recordArr2=" + recordArr2 +
                ", recordArr3=" + recordArr3 +
                ", recordArr4=" + recordArr4 +
                ", recordArr5=" + recordArr5 +
                ", recordArr6=" + recordArr6 +
                ", recordArr7=" + recordArr7 +
                ", recordArr8=" + recordArr8 +
                ", recordArr9=" + recordArr9 +
                ", recordArr10=" + recordArr10 +
                ", recordArr11=" + recordArr11 +
                ", tStamp='" + tStamp + '\'' +
                ", iCount=" + iCount +
                '}';
    }
}



