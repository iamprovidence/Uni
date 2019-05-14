package models.sqlBuilder;

public class DeleteSqlBuilder extends AbstractSqlBuilder
{
    public DeleteSqlBuilder()
    {
        super("Delete");
    }
    public String generateSqlStatement(java.sql.Connection connection)
    {
        return "DELETE FROM TableName \nWHERE columnName='value'";
    }
}
