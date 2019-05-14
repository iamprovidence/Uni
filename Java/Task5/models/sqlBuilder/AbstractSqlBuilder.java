package models.sqlBuilder;

public abstract class AbstractSqlBuilder
{
    // FIELDS
    String shownName;

    // CONSTRUCTORS
    public AbstractSqlBuilder(String shownName)
    {
        this.shownName = shownName;
    }

    // METHODS
    public abstract String generateSqlStatement(java.sql.Connection connection);
    public String toString()
    {
        return shownName;
    }
}
