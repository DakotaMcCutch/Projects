package csv;

import java.io.BufferedReader;
import java.io.IOException;
import java.io.InputStream;
import java.io.InputStreamReader;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.util.ArrayList;

/**
 * Created by Dakota on 7/21/2014.
 */
public class Csv2Database {
    private  ArrayList<Person> parsedPersons = new ArrayList<Person>();
    private  ArrayList<Person> addedPersons = new ArrayList<Person>();
    private static final String DB_URL = "jdbc:mysql://localhost:3306/dev";//Database URL
    private static final String DB_USER = "root";//Database Username
    private static final String DB_PASS = "1234";//Database Password

   private JdbcHelper jdbc = new JdbcHelper();
    /*
        1. firstName
        2. lastName
        3. companyName
        4. address
        5. city
        6. province
        7. postal
        8. phone1
        9. phone2
        10. email
        11. web
        */

    public ArrayList<Person> addPersons(ArrayList<Person> persons)
    {
          jdbc = new JdbcHelper();
        String sql = "INSERT INTO Person (firstName, lastName, companyName, address, city, province, postal, phone1, phone2, email, web) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)";

        for (int i=0 ; i < persons.size(); i++ ) {
            Person person = persons.get(i);
            if (isPersonExist(person)) {
                jdbc.connect(DB_URL, DB_USER, DB_PASS);

                ArrayList<Object> params = new ArrayList<Object>();
                params.add(person.getFirstName());// setting of the First name to the Params list to be sent to the jdbc
                params.add(person.getLastName());// setting of the Last Name to the Parrams list to be sent to the jdbc
                params.add(person.getCompanyName());// setting of the Company Name to the Parrams list to be sent to the jdbc
                params.add(person.getAddress());// setting of the Address to the Parrams list to be sent to the jdbc
                params.add(person.getCity());// setting of the City to the Parrams list to be sent to the jdbc
                params.add(person.getProvince());// setting of the Province to the Parrams list to be sent to the jdbc
                params.add(person.getPostal());// setting of the Postal to the Parrams list to be sent to the jdbc
                params.add(person.getPhone1());// setting of the Phone1 to the Parrams list to be sent to the jdbc
                params.add(person.getPhone2());// setting of the Phone2 to the Parrams list to be sent to the jdbc
                params.add(person.getEmail());// setting of the Email to the Parrams list to be sent to the jdbc
                params.add(person.getWeb());// setting of the Website to the Parrams list to be sent to the jdbc
                jdbc.update(sql, params);
                addedPersons.add(person);
                jdbc.disconnect();
            }
        }

        return addedPersons;
    }
    public Csv2Database()//constructor for UserDatabase
    {
         jdbc = new JdbcHelper();
    }

    public ArrayList<Person> readCsv(InputStream is) {
        //open
        Person temp = new Person();
        BufferedReader br = new BufferedReader(new InputStreamReader(is));
        String line = null;
        boolean bRead = true;
        while (bRead) {
            try {
                line = br.readLine();

            } catch (IOException e) {
                System.out.println("Error Occurred during reading of file Found Error -" + e);
            }

            if (line == null) {

                bRead=false;

            } else {
                line = line.replaceAll(", " , "").replaceAll("\"", "");
                String[] sTemp = (line.split(","));
                temp = new Person();
                temp.setPerson(sTemp[0].trim(),sTemp[1].trim(),sTemp[2].trim(),sTemp[3].trim(),sTemp[4].trim(),sTemp[5].trim(),sTemp[6].trim(),sTemp[7].trim(),sTemp[8].trim(),sTemp[9].trim(),sTemp[10].trim());
                this.parsedPersons.add(temp);

            }
        }

        return this.parsedPersons;
    }

    public boolean isPersonExist(Person person)
    {
        jdbc = new JdbcHelper();
        jdbc.connect(DB_URL, DB_USER, DB_PASS);
        boolean bValid = true;
        String sql = "SELECT * FROM person WHERE firstName=? AND lastName=? AND companyName=? AND address=? AND city=? AND province=? AND postal=? AND phone1=? AND phone2=? AND email=? AND web=?";
        ArrayList<Object> params = new ArrayList<Object>();
        params.add(person.getFirstName());// setting of the First name to the Params list to be sent to the jdbc
        params.add(person.getLastName());// setting of the Last Name to the Parrams list to be sent to the jdbc
        params.add(person.getCompanyName());// setting of the Company Name to the Parrams list to be sent to the jdbc
        params.add(person.getAddress());// setting of the Address to the Parrams list to be sent to the jdbc
        params.add(person.getCity());// setting of the City to the Parrams list to be sent to the jdbc
        params.add(person.getProvince());// setting of the Province to the Parrams list to be sent to the jdbc
        params.add(person.getPostal());// setting of the Postal to the Parrams list to be sent to the jdbc
        params.add(person.getPhone1());// setting of the Phone1 to the Parrams list to be sent to the jdbc
        params.add(person.getPhone2());// setting of the Phone2 to the Parrams list to be sent to the jdbc
        params.add(person.getEmail());// setting of the Email to the Parrams list to be sent to the jdbc
        params.add(person.getWeb());// setting of the Website to the Parrams list to be sent to the jdbc
       try
        {
           ResultSet result = jdbc.query(sql, params);
            if (result.next())
            {
                bValid =false;
            }
            else
            {
                bValid=true;
            }
        } catch (SQLException e) {
           e.printStackTrace();
        }
       jdbc.disconnect();
        return bValid;
    }
    public ArrayList<Person> getParsedPersons() {
        return parsedPersons;
    }

    public void setParsedPersons(ArrayList<Person> parsedPersons) {
        this.parsedPersons = parsedPersons;
    }

    public ArrayList<Person> getAddedPersons() {
        return addedPersons;
    }

    public void setAddedPersons(ArrayList<Person> addedPersons) {
        this.addedPersons = addedPersons;
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

}
