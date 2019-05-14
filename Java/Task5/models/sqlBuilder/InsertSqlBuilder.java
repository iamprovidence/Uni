package models.sqlBuilder;

public class InsertSqlBuilder extends AbstractSqlBuilder
{
    public InsertSqlBuilder()
    {
        super("Insert");
    }
    public String generateSqlStatement(java.sql.Connection connection)
    {
        return "INSERT INTO TableName (column1, column2, column3, ...) \nVALUES (value1, value2, value3, ...)";
    }
}
