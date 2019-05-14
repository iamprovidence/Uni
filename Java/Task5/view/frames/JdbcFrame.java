package view.frames;

import models.eventArgs.*;
import models.interfaces.*;
import models.sqlBuilder.*;

import view.controlModels.*;

import javax.swing.*;
import javax.swing.event.*;
import java.awt.*;
import java.awt.event.*;
import java.sql.*;
import java.util.*;

public class JdbcFrame extends JFrame implements IConnectionSubject, IConnectionListener
{
    // CONSTS
    private static final int DEFAULT_WIDTH = 800;
    private static final int DEFAULT_HEIGHT = 500;

    // FIELDS
    // - connection fields
    private boolean isConnected;
    private Connection connection;

    // - controls
    private JTextArea queryTextBox;
    private JMenuItem disconnectMenuItem;

    // - controls' models
    private QueryListModel queryListModel;
    private ReadOnlyTableModel tableModel;

    // - event listener
    private java.util.List<models.interfaces.IConnectionListener> connectionListenerList;

    // CONSTRUCTORS
    public JdbcFrame()
    {
        super("DbManager");

        // checks for database driver
        if (!IsDriverInstalled())
        {
            showErrorDialog("Where is your PostgreSQL JDBC Driver? Include in your library path!");
            System.exit(0);
        }
        else
        {
            System.setProperty("jdbc.drivers", "org.postgresql.Driver");
        }

        initializeFields();

        configSizes();

        addListeners();

        addMenu();

        buildInterface();

        updateInterface();
    }
    private boolean IsDriverInstalled()
    {
        try
        {
            Class.forName("org.postgresql.Driver");
        }
        catch (ClassNotFoundException ex)
        {
            return false;
        }
        return true;
    }
    private void initializeFields()
    {
        isConnected = false;
        connection = null;

        queryTextBox = new JTextArea();
        queryListModel = new QueryListModel();
        tableModel = new ReadOnlyTableModel();

        connectionListenerList = new ArrayList<models.interfaces.IConnectionListener>();
    }
    private void configSizes()
    {
        // size
        setSize(DEFAULT_WIDTH, DEFAULT_HEIGHT);
        setMinimumSize(new Dimension(DEFAULT_WIDTH, DEFAULT_HEIGHT));

        // get screen dimensions
        Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();

        // center frame in screen
        setLocation(screenSize.width/2 - DEFAULT_WIDTH/2, screenSize.height/2 - DEFAULT_HEIGHT/2);
    }
    private void buildInterface()
    {

        // right panel
        JPanel centerRightPanel = new JPanel(new GridLayout(2, 1, 10, 10));

        // query panel
        JPanel queryPanel = new JPanel(new BorderLayout(10,10));

        JPanel queryLinePanel = new JPanel(new BorderLayout(10,10));
        queryLinePanel.add(new JLabel("Query:"), BorderLayout.WEST);

        // query button
        JButton queryBtn = new JButton("Query");
        queryBtn.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                // check if is connected
                if (!isConnected)
                {
                    showErrorDialog("No connection");
                    return;
                }

                // checks query
                String query = queryTextBox.getText();

                if (!query.isEmpty())    executeQuery(query);
                else                     showErrorDialog("Query is empty");
            }
        });
        this.getRootPane().setDefaultButton(queryBtn);
        queryLinePanel.add(queryBtn, BorderLayout.EAST);

        queryPanel.add(queryLinePanel, BorderLayout.NORTH);

        // sql commands list
        JList queryList = new JList(queryListModel);
        queryList.setPreferredSize(new Dimension(100, 50));
        queryList.addListSelectionListener(new ListSelectionListener()
        {
            public void valueChanged(ListSelectionEvent e)
            {
                if (isConnected)
                {
                    AbstractSqlBuilder sqlBuilder = (AbstractSqlBuilder)queryList.getSelectedValue();
                    queryTextBox.setText(sqlBuilder.generateSqlStatement(JdbcFrame.this.connection));
                }
            }
        });
        queryPanel.add(new JScrollPane(queryList) , BorderLayout.EAST);
        queryPanel.add(queryTextBox, BorderLayout.CENTER);
        centerRightPanel.add(queryPanel);


        // panel with table (result)
        JPanel scrollingTable = new JPanel(new BorderLayout());
        JTable table = new JTable(tableModel);
        scrollingTable.add(new JScrollPane(table));
        scrollingTable.add(table.getTableHeader(), BorderLayout.NORTH);
        scrollingTable.add(table, BorderLayout.CENTER);

        JPanel resultsPanel = new JPanel(new BorderLayout(10,10));
        resultsPanel.add(new JLabel("Results:"), BorderLayout.NORTH);
        resultsPanel.add(new JScrollPane(scrollingTable), BorderLayout.CENTER);

        centerRightPanel.add(resultsPanel);

        // add center panel
        JPanel centerPanel = new JPanel(new BorderLayout(10, 10));

        view.panels.TreePanel treePanel = new view.panels.TreePanel();
        this.addConnectionListener(treePanel);

        centerPanel.add(treePanel, BorderLayout.WEST);
        centerPanel.add(centerRightPanel, BorderLayout.CENTER);

        // add everything to main panel
        JPanel mainPanel = new JPanel(new BorderLayout(10, 10));
        mainPanel.add(centerPanel, BorderLayout.CENTER);
        mainPanel.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));

        // add main panel to frame
        add(mainPanel);
    }

    private void addListeners()
    {
        this.setDefaultCloseOperation(JFrame.DO_NOTHING_ON_CLOSE);
        this.addWindowListener(new WindowAdapter()
        {
            public void windowClosing(WindowEvent e)
            {
                exit();
            }
        });

        // update interface on connection changed
        this.addConnectionListener(this);
    }
    private void addMenu()
    {
        JMenuBar menuBar = new JMenuBar();

        // DataBase
        JMenu menu = new JMenu("DataBase");

        // - connect
        JMenuItem menuItem = new JMenuItem("Connect");
        menuItem.setIcon(new ImageIcon("Task5/resources/pictograms/connect_16x16.png"));
        menuItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_O, ActionEvent.CTRL_MASK));
        menuItem.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                showConnectionDialog();
            }
        });
        menu.add(menuItem);

        // - disconnect
        menuItem = new JMenuItem("Disconnect");
        disconnectMenuItem = menuItem;
        menuItem.setIcon(new ImageIcon("Task5/resources/pictograms/disconnect_16x16.png"));
        menuItem.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                disconnectIfNeeded();
            }
        });
        menu.add(menuItem);

        menu.addSeparator();

        // - exit
        menuItem = new JMenuItem("Exit");
        menuItem.setIcon(new ImageIcon("Task5/resources/pictograms/logout_16x16.png"));
        menuItem.setAccelerator(KeyStroke.getKeyStroke(KeyEvent.VK_W, ActionEvent.CTRL_MASK));
        menuItem.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                exit();
            }
        });
        menu.add(menuItem);

        menuBar.add(menu);

        // Info
        menu = new JMenu("Info");
        menu.addMouseListener(new MouseAdapter()
        {
            public void mouseClicked(java.awt.event.MouseEvent e)
            {
                JOptionPane.showMessageDialog(JdbcFrame.this, "Created by Kizlo Taras");
            }
        });
        menuBar.add(menu);

        setJMenuBar(menuBar);
    }

    private void updateInterface()
    {
        disconnectMenuItem.setEnabled(isConnected);
        tableModel.clear();
        queryTextBox.setText("");

        if (isConnected) queryListModel.populate();
        else             queryListModel.clear();
    }


    // METHODS
    private void disconnectIfNeeded()
    {
        if (connection != null && isConnected)
        {
            try
            {
                connection.close();
                isConnected = false;
                fireDisconnectedListener();
            }
            catch(java.sql.SQLException ex)
            {
                showErrorDialog("Can not disconnect");
            }
        }
    }
    private void connect(view.models.ConnectionData connectionData)
    {
        // get connection
        try
        {
            connection = DriverManager.getConnection(
                    connectionData.getConnection(),
                    connectionData.getUser(),
                    connectionData.getPassword());

            isConnected = true;
        }
        catch(java.sql.SQLException ex)
        {
            showErrorDialog("Can not connect");
            return;
        }

        // update interface
        fireConnectedListener();
    }


    public void executeQuery(String sqlQuery)
    {
        tableModel.clear();

        try
        {
            java.sql.Statement statement = connection.createStatement();
            boolean isResultSet = statement.execute(sqlQuery);

            if (isResultSet)
            {
                ResultSet resultSet = statement.getResultSet();
                ResultSetMetaData resultSetMetaData = resultSet.getMetaData();
                int columnCount = resultSetMetaData.getColumnCount();

                // sets column names
                for (int i = 0; i < columnCount; ++i)
                {
                    tableModel.addColumn(resultSetMetaData.getColumnName(i+1));
                }

                // insert data
                while (resultSet.next())
                {
                    Object[] values = new Object[columnCount];
                    for (int i = 0; i < columnCount; ++i)
                    {
                        values[i] = resultSet.getString(i+1);
                    }
                    tableModel.addRow(values);
                }
                resultSet.close();
            }
            else
            {
                tableModel.addColumn("Executed");
            }
        }
        catch (SQLException ex)
        {
            showErrorDialog(ex.getMessage());
        }
    }


    private void showErrorDialog(String message)
    {
        JOptionPane.showMessageDialog(JdbcFrame.this, message, "Error", JOptionPane.ERROR_MESSAGE);
    }
    private void exit()
    {
        disconnectIfNeeded();
        System.exit(0);
    }
    private void showConnectionDialog()
    {
        view.dialogs.ConnectionDialog cd = new view.dialogs.ConnectionDialog(JdbcFrame.this, true);
        view.models.ConnectionData connectionData = cd.getConnectionData();

        if (connectionData != null)
        {
            disconnectIfNeeded();
            connect(connectionData);
        }
    }

    // Connection listener
    public void addConnectionListener(IConnectionListener connectionListener)
    {
        connectionListenerList.add(connectionListener);
    }
    public void removeConnectionListener(IConnectionListener connectionListener)
    {
        connectionListenerList.remove(connectionListener);
    }
    public void fireConnectedListener()
    {
        for (int i = 0; i < connectionListenerList.size(); ++i)
        {
            connectionListenerList.get(i).connectedSet(this, new ConnectionSetsEventArgs(this.connection));
        }
    }
    public void fireDisconnectedListener()
    {
        for (int i = 0; i < connectionListenerList.size(); ++i)
        {
            connectionListenerList.get(i).connectedUnSet(this, null);
        }
    }

    // if connection is set or unset — update interface
    public void connectedSet(Object object, ConnectionSetsEventArgs eventArgs)
    {
        updateInterface();
    }

    public void connectedUnSet(Object object, Object eventArgs)
    {
        updateInterface();
    }
}
