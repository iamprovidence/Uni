package view.controlModels;

import models.sqlBuilder.*;

public class QueryListModel extends javax.swing.DefaultListModel<AbstractSqlBuilder>
{
    // FIELDS
    java.util.List<AbstractSqlBuilder> elements;

    // CONSTRUCTORS
    public QueryListModel()
    {
        elements = java.util.Arrays.asList
                (
                    new EmptySqlBuilder(),
                    new ReadSqlBuilder(),
                    new InsertSqlBuilder(),
                    new SearchSqlBuilder(),
                    new DeleteSqlBuilder(),
                    new UpdateSqlBuilder()
                );
    }

    // METHODS
    public void populate()
    {
        this.addAll(elements);
    }
    public void clear()
    {
        this.removeAllElements();
    }
}
