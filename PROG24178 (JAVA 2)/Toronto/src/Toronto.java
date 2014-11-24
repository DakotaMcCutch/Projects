import java.io.*;
import java.text.DecimalFormat;
import java.text.NumberFormat;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Calendar;

/**
 * Created by Dakota on 4/1/2014.
 */
public class Toronto {
    private BufferedReader in = null;
    private BufferedReader in2 = null;
    private PrintWriter out = null;
    private String[] sTemp;
    private ArrayList<Integer> data0= new ArrayList<Integer>();
    private ArrayList<Integer>data1= new ArrayList<Integer>();
    private ArrayList<Integer>data2= new ArrayList<Integer>();
    private ArrayList<Integer>data3= new ArrayList<Integer>();
    private ArrayList<Double>mean= new ArrayList<Double>();
    private ArrayList<Integer>monthTen= new ArrayList<Integer>();
    private ArrayList<Integer>monthTwenty= new ArrayList<Integer>();
    private ArrayList<Integer>monthEx= new ArrayList<Integer>();
    private double[] tenPer= new double[100000];
    private double[] twentyPer= new double[100000];
    private double[] exPer= new double[100000];
    private NumberFormat myFormat= new DecimalFormat("##.##");
    private String tStamp = new SimpleDateFormat("EEE, d MMMMM YYYY HH:mm:ss").format(Calendar.getInstance().getTime());
    private int total;
    public void setup ()
    {
        for (int i=0;i<12;i++)
        {
            monthTen.add(i,0);
            monthEx.add(i,0);
            monthTwenty.add(i,0);
        }
    }
    public void splice ()

    {
        boolean bMoreToDo;

        do {
            bMoreToDo = read(in);
            if (bMoreToDo) {
                data0.add((int) Double.parseDouble(sTemp[0]));
                total++;
                data1.add((int) Double.parseDouble(sTemp[1]));
                total++;
                data2.add((int) Double.parseDouble(sTemp[2]));
                total++;
                data3.add((int) Double.parseDouble(sTemp[3]));
                total++;
            }

        } while (bMoreToDo);
    }
    public void spliceMean ()
    {
        boolean bMoreToDo;

        do {
            bMoreToDo = read(in2);
            if (bMoreToDo) {
                mean.add(Double.parseDouble(sTemp[0]));
            }

        } while (bMoreToDo);
    }
    public void open() {
        File f = new File("torontohistorical.csv");
        try {
            in = new BufferedReader(new FileReader(f));
        } catch (FileNotFoundException e) {
            System.out.println("File Was Not Found Error -" + e);
        }
        File ff = new File("torontomeans.dat");
        try {
            in2 = new BufferedReader(new FileReader(ff));
        } catch (FileNotFoundException e) {
            System.out.println("File Was Not Found Error -" + e);
        }
    }

    public boolean read(BufferedReader reader) {
        String line = null;
        boolean bRead = true;
        try {
            line = reader.readLine();

        } catch (IOException e) {
            System.out.println("Error Occurred during reading of file Found Error -" + e);
        }
        if (line == null) {
            bRead = false;
        } else {
            sTemp = line.split(",");
        }
        return bRead;
    }
    public void calc()
    {
        int temp=0;

        int size= mean.size();
        for (int i =0;i < size;i++) {

            //testing to see if temp is ten percent higher
            if (data0.get(i)== 1 && (data3.get(i) >= (mean.get(0)*1.10)))
            {
                temp = monthTen.get(1);
                monthTen.add(1,temp+1);
            }
           else if (data0.get(i)== 2 && (data3.get(i) >= (mean.get(1)*1.10)))
            {
                temp = monthTen.get(1);
                monthTen.add(2,temp+1);
            }
            else if (data0.get(i)== 3 && (data3.get(i) >= (mean.get(2)*1.10)))
            {
                temp = monthTen.get(1);
                monthTen.add(3,temp+1);
            }
            else if (data0.get(i)== 4 && (data3.get(i) >= (mean.get(3)*1.10)))
            {
                temp = monthTen.get(1);
                monthTen.add(4,temp+1);
            }
            else if (data0.get(i)== 5 && (data3.get(i) >= (mean.get(4)*1.10)))
            {
                temp = monthTen.get(1);
                monthTen.add(5,temp+1);
            }
            else  if (data0.get(i)== 6 && (data3.get(i) >= (mean.get(5)*1.10)))
            {
                temp = monthTen.get(1);
                monthTen.add(6,temp+1);
            }
            else  if (data0.get(i)== 7 && (data3.get(i) >= (mean.get(6)*1.10)))
            {
                temp = monthTen.get(1);
                monthTen.add(7,temp+1);
            }
            else if (data0.get(i)== 8 && (data3.get(i) >= (mean.get(7)*1.10)))
            {
                temp = monthTen.get(1);
                monthTen.add(8,temp+1);
            }
            else if (data0.get(i)== 9 && (data3.get(i) >= (mean.get(8)*1.10)))
            {
                temp = monthTen.get(1);
                monthTen.add(9,temp+1);
            }
            else  if (data0.get(i)== 10 && (data3.get(i) >= (mean.get(9)*1.10)))
            {
                temp = monthTen.get(1);
                monthTen.add(10,temp+1);
            }
            else  if (data0.get(i)== 11 && (data3.get(i) >= (mean.get(10)*1.10)))
            {
                temp = monthTen.get(1);
                monthTen.add(11,temp+1);
            }
            else if (data0.get(i)== 12 && (data3.get(i) >= (mean.get(11)*1.10)))
            {
                temp = monthTen.get(1);
                monthTen.add(12,temp+1);
            }


            //testing to see if temp is ten percent higher
            if (data0.get(i)== 1 && (data3.get(i) >= (mean.get(0)*1.20)))
            {
                temp = monthTwenty.get(1);
                monthTwenty.add(1,temp+1);
            }
            else if (data0.get(i)== 2 && (data3.get(i) >= (mean.get(1)*1.20)))
            {
                temp = monthTwenty.get(2);
                monthTwenty.add(2,temp+1);
            }
            else if (data0.get(i)== 3 && (data3.get(i) >= (mean.get(2)*1.20)))
            {
                temp = monthTwenty.get(3);
                monthTwenty.add(3,temp+1);
            }
            else if (data0.get(i)== 4 && (data3.get(i) >= (mean.get(3)*1.20)))
            {
                temp = monthTwenty.get(4);
                monthTwenty.add(4,temp+1);
            }
            else if (data0.get(i)== 5 && (data3.get(i) >= (mean.get(4)*1.20)))
            {
                temp = monthTwenty.get(5);
                monthTwenty.add(5,temp+1);
            }
            else  if (data0.get(i)== 6 && (data3.get(i) >= (mean.get(5)*1.20)))
            {
                temp = monthTwenty.get(6);
                monthTwenty.add(6,temp+1);
            }
            else  if (data0.get(i)== 7 && (data3.get(i) >= (mean.get(6)*1.20)))
            {
                temp = monthTwenty.get(7);
                monthTwenty.add(7,temp+1);
            }
            else if (data0.get(i)== 8 && (data3.get(i) >= (mean.get(7)*1.20)))
            {
                temp = monthTwenty.get(8);
                monthTwenty.add(8,temp+1);
            }
            else if (data0.get(i)== 9 && (data3.get(i) >= (mean.get(8)*1.20)))
            {
                temp = monthTwenty.get(9);
                monthTwenty.add(9,temp+1);
            }
            else  if (data0.get(i)== 10 && (data3.get(i) >= (mean.get(9)*1.20)))
            {
                temp = monthTwenty.get(10);
                monthTwenty.add(10,temp+1);
            }
            else  if (data0.get(i)== 11 && (data3.get(i) >= (mean.get(10)*1.20)))
            {
                temp = monthTwenty.get(11);
                monthTwenty.add(11,temp+1);
            }
            else if (data0.get(i)== 12 && (data3.get(i) >= (mean.get(11)*1.20)))
            {
                temp = monthTwenty.get(12);
                monthTwenty.add(12,temp+1);
            }


            //testing to see if temp is extreme (10 higher or lower then previous day)
            if (data0.get(i)== 1 &&((data3.get(i) - data3.get(i + 1)) >= 10 || (data3.get(i) - data3.get(i + 1)) >= -10) )
            {
                temp = monthEx.get(1);
                monthEx.add(1, temp + 1);
            }
            else if (data0.get(i)== 2 &&((data3.get(i) - data3.get(i + 1)) >= 10 || (data3.get(i) - data3.get(i + 1)) >= -10) )
            {
                temp = monthEx.get(2);
                monthEx.add(2, temp + 1);
            }
            else if (data0.get(i)== 3 &&((data3.get(i) - data3.get(i + 1)) >= 10 || (data3.get(i) - data3.get(i + 1)) >= -10) )
            {
                temp = monthEx.get(3);
                monthEx.add(3, temp + 1);
            }
            else if (data0.get(i)== 4 &&((data3.get(i) - data3.get(i + 1)) >= 10 || (data3.get(i) - data3.get(i + 1)) >= -10) )
            {
                temp = monthEx.get(4);
                monthEx.add(4, temp + 1);
            }
            else if (data0.get(i)== 5 &&((data3.get(i) - data3.get(i + 1)) >= 10 || (data3.get(i) - data3.get(i + 1)) >= -10) )
            {
                temp = monthEx.get(5);
                monthEx.add(5, temp + 1);
            }
            else if (data0.get(i)== 6 &&((data3.get(i) - data3.get(i + 1)) >= 10 || (data3.get(i) - data3.get(i + 1)) >= -10) )
            {
                    temp = monthEx.get(6);
                    monthEx.add(6, temp + 1);
            }
            else if (data0.get(i)== 7 &&((data3.get(i) - data3.get(i + 1)) >= 10 || (data3.get(i) - data3.get(i + 1)) >= -10) )
            {
                temp = monthEx.get(7);
                monthEx.add(7, temp + 1);
            }
            else if (data0.get(i)== 8 &&((data3.get(i) - data3.get(i + 1)) >= 10 || (data3.get(i) - data3.get(i + 1)) >= -10) )
            {
                temp = monthEx.get(8);
                monthEx.add(8, temp + 1);
            }
            else if (data0.get(i)== 9 &&((data3.get(i) - data3.get(i + 1)) >= 10 || (data3.get(i) - data3.get(i + 1)) >= -10) )
            {
                temp = monthEx.get(9);
                monthEx.add(9, temp + 1);
            }
            else if (data0.get(i)== 10 &&((data3.get(i) - data3.get(i + 1)) >= 10 || (data3.get(i) - data3.get(i + 1)) >= -10) )
            {
                temp = monthEx.get(10);
                monthEx.add(10, temp + 1);
            }
            else if (data0.get(i)== 11 &&((data3.get(i) - data3.get(i + 1)) >= 10 || (data3.get(i) - data3.get(i + 1)) >= -10) )
            {
                temp = monthEx.get(1);
                monthEx.add(1, temp + 1);
            }
            else if (data0.get(i)== 12 &&((data3.get(i) - data3.get(i + 1)) >= 10 || (data3.get(i) - data3.get(i + 1)) >= -10) )
            {
                temp = monthEx.get(12);
                monthEx.add(12, temp + 1);
            }
        }
        for (int i=1; i <12;i++) {
            double Ten=monthTen.get(i);
            double Twenty=monthTwenty.get(i);
            double Ex=monthEx.get(i);
            tenPer[i] = Double.parseDouble(myFormat.format((Ten/ 30)*100));
            twentyPer[i] = Double.parseDouble(myFormat.format((Twenty/ 30)*100));
            exPer[i] =Double.parseDouble(myFormat.format((Ex/ 30)*100));
        }
    }

    public void write() {
        File f = new File("torontoanalysis.html");
        try {
            out = new PrintWriter(new BufferedWriter(new FileWriter(f)));
        } catch (IOException e) {
            System.out.println("Couldn't Write To File Found Error -" + e);
        }
        int size = data0.size();

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
        out.println("tr:first-child");
        out.println("{");
        out.println("background: lightblue;");
        out.println("}");
        out.println("</style>");
        out.println("<meta charset=\"utf-8\">");
        out.println("<title></title>");
        out.println("</head>");
        out.println("<body>");
        out.println("<h1 class=\"title\">Report <br>Toronto Temperature<br> Compiled On: "+ tStamp + " </h1>");

        out.println("<table>");
        out.println("<tr>");
        out.print("<th>1</th>");
        out.print("<th>2</th>");
        out.print("<th>3</th>");
        out.print("<th>4</th>");
        out.print("<th>5</th>");
        out.print("<th>6</th>");
        out.print("<th>7</th>");
        out.print("<th>8</th>");
        out.print("<th>9</th>");
        out.print("<th>10</th>");
        out.print("<th>11</th>");
        out.print("<th>12</th>");
        out.print("<th>Description:</th>");
        out.println("</tr>");
        out.println("<tr>");
        for (int i=1;i<13;i++) {
            out.print("<td>" +monthTen.get(i)  +"</td>");
        }
        out.print("<td>Total Number of Days with a daily temperature 10% or higher than the mean temperature for that month.</td>");
        out.println("</tr>");
        out.println("<tr>");
        for (int i=1;i<13;i++) {
            out.print("<td>" +monthTwenty.get(i)  +"</td>");
        }
        out.print("<td>Total Number of Days with a daily temperature 20% or higher than the mean temperature for that month.</td>");
        out.println("</tr>");
        out.println("<tr>");
        for (int i=1;i<13;i++) {
            out.print("<td>" +monthEx.get(i)  +"</td>");
        }
        out.print("<td>Total number of extreme changes of temperature.  This is a count of the number of days that are 10 degrees Celsius (18 degrees Fahrenheit) above or below that of the previous day.</td>");
        out.println("</tr>");
        out.println("<tr>");
        for (int i=1;i<13;i++) {
            out.print("<td>" +tenPer[i]  +"%</td>");
        }
        out.print("<td>% of days that have a daily temperature 10% or higher than the mean for that month.</td>");
        out.println("</tr>");
        out.println("<tr>");
        for (int i=1;i<13;i++) {
            out.print("<td>" +twentyPer[i]  +"%</td>");
        }
        out.print("<td>% of days that have a daily temperature 20% or higher than the mean for that month.</td>");
        out.println("</tr>");
        out.println("<tr>");
        for (int i=1;i<13;i++) {
            out.print("<td>" + exPer[i]+"%</td>");
        }
        out.print("<td>% of days that represent extreme changes of temperature.</td>");
        out.println("</tr>");
        out.println("<tr>");
        out.print("<td>" +total +"</td>");
        out.print("<td>Total number of records processed</td>");
        out.println("</tr>");
        out.println("</table>");

        out.println("<table>");
            out.println("<tr>");
            out.print("<th>Month</th>");
            out.print("<th>Day</th>");
            out.print("<th>Year</th>");
            out.println("<th>Temperature</th>");
            out.println("</tr>");
        for (int i = 0; i <size;i++)
        {
            out.println("<tr>");
            out.print("<td>" +  data0.get(i) + "</td>" );
            out.print("<td>" + data1.get(i) + "</td>" );
            out.print("<td>" + data2.get(i) + "</td>" );
            out.println("<td>" + data3.get(i) + "\u00b0F</td>" );
            out.println("</tr>");
        }
        out.println("</table>");

        out.println("<br>");
        out.println("<br>");
        out.println("<h4 class=\"title\">Number Of Records processed</h4>");
        out.println("<h4 class=\"title\">Compiled On: "+ tStamp + " </h4>");
        out.println("</body>");
        out.println("</html>");

/*
            for (int i = 0 ; i <size; i++)
            {
            out.print(data0.get(i) + ",");
            out.print(data1.get(i) + ",");
            out.print(data2.get(i) + ",");
            out.print(data3.get(i) + ",");
            out.println(",");
            */
        System.out.println("The Report Is Done Compiling");
    }


    public void close ()
    {
        out.close();
    }
    public void run()
    {
        setup();
        open();
        splice();
        spliceMean();
        calc();
        write();
        close();
        try
        {
            java.awt.Desktop.getDesktop().browse(java.net.URI.create("torontoanalysis.html"));
        } catch (IOException e) {
            e.printStackTrace();
        }
    }
}
