package models.sqlBuilder;

public class ReadSqlBuilder extends AbstractSqlBuilder
{
    public ReadSqlBuilder()
    {
        super("Select");
    }
    public String generateSqlStatement(java.sql.Connection connection)
    {
        return "SELECT * FROM TableName";
    }
}
