package view.panels;

import javax.swing.*;
import javax.swing.tree.*;
import java.awt.*;
import java.sql.*;

public class TreePanel extends JPanel implements models.interfaces.IConnectionListener
{
    // CONST
    private static String DEFAULT_ROOT_TEXT = "No Database";

    // FIELDS
    private JTree tree;
    private DefaultTreeModel treeModel;

    // constructors
    public TreePanel()
    {
        super(new BorderLayout(10, 10));

        initializeFields();
        buildInterface();
        resetTree();
    }
    private void initializeFields()
    {
        tree = new JTree();
        treeModel = (DefaultTreeModel)tree.getModel();
    }
    private void buildInterface()
    {

        setPreferredSize(new Dimension(160, 600));
        add(new JLabel("Structure:"), BorderLayout.NORTH);

        JScrollPane scrollingTree = new JScrollPane();

        DefaultTreeCellRenderer renderer = (DefaultTreeCellRenderer) tree.getCellRenderer();
        renderer.setClosedIcon(new ImageIcon("Task5/resources/pictograms/closed_database_16x16.png"));
        renderer.setOpenIcon(new ImageIcon("Task5/resources/pictograms/open_database_16x16.png"));
        renderer.setLeafIcon(new ImageIcon("Task5/resources/pictograms/data_16x16.png"));

        scrollingTree.setViewportView(tree);
        add(scrollingTree, BorderLayout.CENTER);
    }

    // METHODS
    private void buildDataBaseTreeStructure(Connection connection) throws SQLException
    {
        DefaultMutableTreeNode root = (DefaultMutableTreeNode)treeModel.getRoot();

        DatabaseMetaData databaseMetaData = connection.getMetaData();

        // sets DB name
        root.setUserObject(connection.getCatalog());

        // sets tables name
        root.removeAllChildren();
        ResultSet tables = databaseMetaData.getTables(null, null, null, new String[]{"TABLE"});
        while (tables.next())
        {
            // sets columns name
            DefaultMutableTreeNode tableTreeNode = new DefaultMutableTreeNode(tables.getString(3));
            ResultSet columns = databaseMetaData.getColumns(null, null, tables.getString(3), null);
            while (columns.next())
            {
                String columnName = columns.getString("COLUMN_NAME");
                tableTreeNode.add(new DefaultMutableTreeNode(columnName));
            }
            root.add(tableTreeNode);
            columns.close();
        }
        tables.close();

        treeModel.reload(root);
    }
    private void resetTree()
    {
        DefaultMutableTreeNode root = (DefaultMutableTreeNode)treeModel.getRoot();
        root.setUserObject(DEFAULT_ROOT_TEXT);
        root.removeAllChildren();
        treeModel.reload(root);
    }

    // Connection listener
    public void connectedSet(Object object, models.eventArgs.ConnectionSetsEventArgs eventArgs)
    {
        try
        {
            buildDataBaseTreeStructure(eventArgs.getConnection());
        }
        catch (SQLException ex)
        {
            ex.printStackTrace();
        }
    }

    public void connectedUnSet(Object object, Object eventArgs)
    {
        resetTree();
    }
}
