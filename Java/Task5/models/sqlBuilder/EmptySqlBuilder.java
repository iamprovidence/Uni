package models.sqlBuilder;

public class EmptySqlBuilder extends AbstractSqlBuilder
{
    public EmptySqlBuilder()
    {
        super("*");
    }

    public String generateSqlStatement(java.sql.Connection connection)
    {
        return "";
    }
}
