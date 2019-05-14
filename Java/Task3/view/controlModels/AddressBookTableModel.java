package view.controlModels;

import view.controlModels.interfaces.DataChangedListener;

public class AddressBookTableModel extends javax.swing.table.AbstractTableModel
{
    // FIELDS
    models.ContactList contacts;

    java.util.List<DataChangedListener> dataChangedListeners; // observer pattern

    // CONSTRUCTORS
    public AddressBookTableModel()
    {
        contacts = new models.ContactList();

        dataChangedListeners = new java.util.ArrayList<DataChangedListener>();
    }
    public void setContacts(models.ContactList contacts)
    {
        this.contacts = contacts;

        fireTableDataChanged();
        fireDataChangedEvent();
    }
    public models.ContactList getContacts()
    {
        return contacts;
    }

    // METHODS
    public int getRowCount()
    {
        return contacts.size();
    }
    public int getColumnCount()
    {
        return 3;
    }
    public boolean isCellEditable(int rowIndex, int columnIndex)
    {
        if (columnIndex == 0) return false;
        return true;
    }
    public String getColumnName(int column)
    {
        switch (column)
        {
            case 0: return "№";
            case 1: return "Name";
            case 2: return "Phone";

            default: return null;
        }
    }
    public Class getColumnClass(int column)
    {
        switch (column)
        {
            case 0: return Integer.class;
            case 1: return String.class;
            case 2: return String.class;

            default: return Object.class;
        }
    }
    public Object getValueAt(int row, int column)
    {
        switch (column)
        {
            case 0: return row + 1;
            case 1: return contacts.get(row).getName();
            case 2: return contacts.get(row).getPhone();

            default: return null;
        }
    }

    public void setValueAt(Object aValue, int rowIndex, int columnIndex)
    {
        switch (columnIndex)
        {
            case 1: contacts.get(rowIndex).setName (aValue.toString()); break;
            case 2: contacts.get(rowIndex).setPhone(aValue.toString()); break;
        }

        fireDataChangedEvent();
    }

    public void addRow(models.Contact contact)
    {
        contacts.add(contact);

        fireTableRowsInserted(contacts.size(), contacts.size());
        fireDataChangedEvent();
    }
    public void removeRow(int row)
    {
        contacts.remove(row);

        fireTableRowsDeleted(row, row);
        fireDataChangedEvent();
    }
    public void clear()
    {
        fireDataChangedEvent();
        fireTableRowsDeleted(0, contacts.size());

        contacts.clear();
    }
    // sort/filter
    public void filter(String name)
    {
        int t = 0;
        for (int i = 0; i < contacts.size(); ++i)
        {
            models.Contact contact = contacts.get(i);

            // put values that satisfy the condition to the top
            if (containsIgnoreCase(contact.getName(), name))
            {
                models.Contact temp = contacts.get(t);
                contacts.set(t, contact);
                contacts.set(i, temp);

                ++t;
            }
        }

        fireTableDataChanged();
    }
    private boolean containsIgnoreCase(String str, String searchStr)
    {
        if(str == null || searchStr == null) return false;

        final int length = searchStr.length();
        if (length == 0)  return true;

        for (int i = str.length() - length; i >= 0; i--)
        {
            if (str.regionMatches(true, i, searchStr, 0, length))
            {
                return true;
            }
        }
        return false;
    }

    // Data changed event
    public void addDataChangedListener(DataChangedListener listener)
    {
        dataChangedListeners.add(listener);
    }
    protected void fireDataChangedEvent()
    {
        for (DataChangedListener listener : dataChangedListeners)
        {
            listener.dataChanged();
        }
    }
}
