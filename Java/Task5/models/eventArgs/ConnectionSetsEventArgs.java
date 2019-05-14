package models.eventArgs;

public class ConnectionSetsEventArgs
{
    java.sql.Connection connection;

    public ConnectionSetsEventArgs(java.sql.Connection connection)
    {
        this.connection = connection;
    }

    public  java.sql.Connection getConnection()
    {
        return connection;
    }
}
