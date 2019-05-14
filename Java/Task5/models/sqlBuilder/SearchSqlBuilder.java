package models.sqlBuilder;

public class SearchSqlBuilder extends AbstractSqlBuilder
{
    public SearchSqlBuilder()
    {
        super("Search");
    }
    public String generateSqlStatement(java.sql.Connection connection)
    {
        return "SELECT * \nFROM TableName \nWHERE columnName LIKE '%template%'";
    }
}
