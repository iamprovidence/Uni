package models.sqlBuilder;

public class UpdateSqlBuilder extends AbstractSqlBuilder
{
    public UpdateSqlBuilder()
    {
        super("Update");
    }
    public String generateSqlStatement(java.sql.Connection connection)
    {
        return "UPDATE TableName \nSET column1 = value1, column2 = value2, ... \nWHERE condition";
    }
}
