package view.models;

public class ConnectionData
{
    // FIELDS
    private String connection;
    private String user;
    private String password;

    // CONSTRUCTORS
    public ConnectionData(String connection, String user, String password)
    {
        this.connection = connection;
        this.user = user;
        this.password = password;
    }

    // METHODS
    public String getConnection()
    {
        return connection;
    }
    public String getUser()
    {
        return user;
    }
    public String getPassword()
    {
        return password;
    }

    public void setConnection(String connection)
    {
        this.connection = connection;
    }
    public void setUser(String user)
    {
        this.user = user;
    }
    public void setPassword(String password)
    {
        this.password = password;
    }

}
