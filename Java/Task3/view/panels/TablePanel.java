package view.panels;

import javax.swing.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

public class TablePanel extends javax.swing.JPanel
{
    // FIELDS
    private view.controlModels.AddressBookTableModel tableModel;
    private JTable table;

    // CONSTRUCTORS
    public TablePanel(view.controlModels.AddressBookTableModel tableModel)
    {
        setLayout(new java.awt.BorderLayout());

        createSearchField();
        createTable(tableModel);
        createButtons();
    }
    private void createSearchField()
    {
        JPanel searchFieldPanel = new JPanel(new java.awt.BorderLayout());

        // search field
        JTextField searchField = new JTextField();
        searchFieldPanel.add(searchField, java.awt.BorderLayout.CENTER);

        // search button
        JButton searchBtn = new JButton("Search");
        searchBtn.addActionListener(new ActionListener()
        {
            public void actionPerformed(ActionEvent e)
            {
                tableModel.filter(searchField.getText());
            }
        });
        searchFieldPanel.add(searchBtn, java.awt.BorderLayout.EAST);

        add(searchFieldPanel, java.awt.BorderLayout.NORTH);
    }
    private void createTable(view.controlModels.AddressBookTableModel tableModel)
    {
        this.tableModel = tableModel;
        table = new JTable(tableModel);

        add(new JScrollPane(table), java.awt.BorderLayout.CENTER);
    }
    private void createButtons()
    {
        // add
        JButton add = new JButton("Add", new ImageIcon("Task3/resources/pictograms/add_20x20.png"));
        add.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent e)
            {
                tableModel.addRow(new models.Contact("Name", "380-XX-XX-XX-XXX"));
            }
        });

        // remove
        JButton remove = new JButton("Remove", new ImageIcon("Task3/resources/pictograms/remove_20x20.png"));
        remove.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent e)
            {
                int row = table.getSelectedRow();
                if (row != -1) tableModel.removeRow(row);
            }
        });

        JPanel buttons = new JPanel();
        buttons.add(add);
        buttons.add(remove);

        add(buttons, java.awt.BorderLayout.SOUTH);
    }
}
