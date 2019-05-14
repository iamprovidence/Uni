package view.dialogs;

import javax.swing.*;
import java.awt.*;

public class ConnectionDialog extends JDialog
{
    // CONSTS
    private static final int DEFAULT_WIDTH = 400;
    private static final int DEFAULT_HEIGHT = 200;

    private static final String DEFAULT_CONNECTION_STR = "jdbc:postgresql://127.0.0.1:5432/DataBaseName";
    private static final String DEFAULT_USER_STR = "postgres";
    private static final String DEFAULT_PASSWORD_STR = "1111";

    // FIELDS
    view.models.ConnectionData connectionData;

    JTextField connectionTf;
    JTextField userTf;
    JTextField passwordTf;

    // CONSTRUCTORS
    public ConnectionDialog(JFrame owner, boolean modal)
    {
        super(owner, modal);

        initializeFields();
        configParameters();
        buildInterface();

        setVisible(true);
        this.setDefaultCloseOperation(JDialog.DISPOSE_ON_CLOSE);
    }
    private void initializeFields()
    {
        connectionData = null;

        connectionTf = new JTextField(DEFAULT_CONNECTION_STR);
        userTf = new JTextField(DEFAULT_USER_STR);
        passwordTf = new JTextField(DEFAULT_PASSWORD_STR);
    }
    private void configParameters()
    {
        // size
        setSize(DEFAULT_WIDTH, DEFAULT_HEIGHT);
        setMinimumSize(new Dimension(DEFAULT_WIDTH, DEFAULT_HEIGHT));

        // get screen dimensions
        Dimension screenSize = Toolkit.getDefaultToolkit().getScreenSize();

        // center frame in screen
        setLocation(screenSize.width/2 - DEFAULT_WIDTH/2, screenSize.height/2 - DEFAULT_HEIGHT/2);

        setResizable(false);

        // title
        setTitle("Connection data");
    }
    private void buildInterface()
    {
        // add inputs
        JPanel inputsPanel = new JPanel(new GridLayout(3,2,5,15));

        inputsPanel.add(new JLabel("Connection"));
        inputsPanel.add(connectionTf);

        inputsPanel.add(new JLabel("User"));
        inputsPanel.add(userTf);

        inputsPanel.add(new JLabel("Password"));
        inputsPanel.add(passwordTf);

        inputsPanel.setBorder(BorderFactory.createEmptyBorder(10, 10, 10, 10));

        add(inputsPanel, BorderLayout.CENTER);

        // add buttons
        JButton confirm = new JButton("Confirm");
        confirm.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent e)
            {
                if (isDataValid())
                {
                    connectionData = new view.models.ConnectionData(
                            connectionTf.getText(),
                            userTf.getText(),
                            passwordTf.getText());

                    ConnectionDialog.this.dispose();
                }
            }
        });
        add(confirm, BorderLayout.SOUTH);
        this.getRootPane().setDefaultButton(confirm);
    }
    private boolean isDataValid()
    {
        if (connectionTf.getText().isEmpty())
        {
            showErrorDialog("Connection string can not be empty");
            return false;
        }
        if (userTf.getText().isEmpty())
        {
            showErrorDialog("User string can not be empty");
            return false;
        }
        if (passwordTf.getText().isEmpty())
        {
            showErrorDialog("Password string can not be empty");
            return false;
        }
        return true;
    }

    // PROPERTIES
    public view.models.ConnectionData getConnectionData()
    {
        return connectionData;
    }

    // METHODS
    private void showErrorDialog(String message)
    {
        JOptionPane.showMessageDialog(ConnectionDialog.this, message, "Error", JOptionPane.ERROR_MESSAGE);
    }
}
