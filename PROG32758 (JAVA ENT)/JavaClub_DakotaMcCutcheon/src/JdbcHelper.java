import java.sql.*;
import java.util.ArrayList;


public class JdbcHelper
{

    private Connection connection = null; //Private Global For SQL Connection
    private Statement statement = null; //Private Global For SQL Statements
    private ResultSet result = null; //Private Global For SQL Results

    private String activeSql = ""; //Private Global For Active Sql
    private PreparedStatement activeStatement = null; //Private Global For SQL PreparedStatements

    public JdbcHelper()
    {
    }


    public void connect (String url, String user, String pass)  //SQL Connection Execution Method
    {
        try
        {
            Class.forName ("com.mysql.jdbc.Driver");
        }
        catch (ClassNotFoundException ee)
        {
            ee.printStackTrace ();
            System.err.print ("Class.forName Error-" + ee);
        }
        try
        {
            connection = DriverManager.getConnection (url, user, pass);
        }
        catch (SQLException e)
        {
            e.printStackTrace ();
            System.err.println ("Connection could not be established Error-" + e);
        }

        try
        {
            statement = connection.createStatement ();
        }
        catch (SQLException e)
        {
            e.printStackTrace ();
            System.err.println ("Statement could not be created Error-" + e);
        }
    }


    public void disconnect ()  //SQL Disconnect Execution Method
    {
        try
        {
            connection.close ();
            statement.close();  
            activeStatement.close();            
        }
        catch (SQLException e)
        {
            e.printStackTrace ();
            System.err.println ("Connection could not be closed Error-" + e);
        }
    }


    public ResultSet query (String sql)  //SQL Query Execution Method
    {
        try
        {
            result = statement.executeQuery (sql); //Runs The SQL Query
        }
        catch (SQLException e)
        {
            e.printStackTrace ();
            System.err.println ("Query could not be run Error-" + e);
        }
        return result;
    }


    public ResultSet query (String sql, ArrayList < Object > params)  //Prepared SQL Query Execution Method
    {
        try
        {
            if (!sql.equals (activeSql))
            {
                activeStatement = connection.prepareStatement (sql);
                activeSql = sql;
            }
            if (params != null)
            {
                setParametersForPreparedStatement (params);
            }

            result = activeStatement.executeQuery ();
        }
        catch (SQLException e)
        {
            e.printStackTrace();
            System.err.println ("ResultSet query method Error-" + e);
        }
        return result;
    }


    public int update (String sql)  //Runs The SQL Query
    {
        int result = -1;
        try
        {
            result = statement.executeUpdate(sql);
        }
        catch (SQLException e)
        {
            e.printStackTrace ();
            System.err.println ("Update Couldn't Execute Error-" + e);
        }
        return result;
    }


    public int update (String sql, ArrayList < Object > params)  //Runs The prepared SQL Query
    {
        int result = -1;
            try
            {
            	if (!sql.equals (activeSql))
                {
                activeStatement = connection.prepareStatement (sql);
                }
            	if(params != null)
            	{
            		setParametersForPreparedStatement (params);
            		result = activeStatement.executeUpdate();
            	}
            }
            catch (SQLException e)
            {
                e.printStackTrace ();
                System.err.println ("Update Couldn't Execute Error-" + e);
            }        
       
        return result;
    }


    public PreparedStatement prepareStatement (String sql)  //Self explanatory
    {
        try
        {
            if (!sql.equals (activeSql))
            {
                activeStatement = connection.prepareStatement (sql);
                activeSql = sql;
            }
        }
        catch (SQLException e)
        {
             e.printStackTrace();
            System.err.println ("SQLException in prepareStatment method Error-" + e);
        }
        catch (Exception e)
        {
            e.printStackTrace ();
            System.err.println ("Exception in prepareStatment method Error-" + e);
        }

        return activeStatement;
    }

    @SuppressWarnings("")
    private void setParametersForPreparedStatement (ArrayList < Object > params)//sets up the prepared statement
    {
        try
        {
            for (int i = 0 ; i < params.size () ; ++i)
            {
                Object param = params.get(i);
                if (param instanceof Integer)
                {
                    activeStatement.setInt (i+1, Integer.valueOf((String) param));
                }
                else if (param instanceof Double)
                {
                    activeStatement.setDouble (i+1, Double.valueOf((String) param));
                }
                else if (param instanceof String)
                {
                    activeStatement.setString (i+1, (String)param);
                }
            }
        }
        catch (SQLException e)
        {
            e.printStackTrace();
            System.err.println ("setParametersForPreparedStatement Method Error-" + e);
        }
        catch (ClassCastException e)
        {
            e.printStackTrace();
            System.err.println ("ClassCastException Error-"+e);
        }
    }


    public Statement getStatement ()
    {
        return statement;
    }


    public void setStatement (Statement statement)
    {
        this.statement = statement;
    }


    public ResultSet getResult ()
    {
        return result;
    }


    public void setResult (ResultSet result)
    {
       this.result = result;
    }


    public Connection getConnection ()
    {
        return connection;
    }


    public void setConnection (Connection connection)
    {
        this.connection = connection;
    }


    public String getActiveSql ()
    {
        return activeSql;
    }


    public void setActiveSql (String activeSql)
    {
        this.activeSql = activeSql;
    }


    public PreparedStatement getActiveStatement ()
    {
        return activeStatement;
    }


    public void setActiveStatement (PreparedStatement activeStatement)
    {
        this.activeStatement = activeStatement;
    }



}
