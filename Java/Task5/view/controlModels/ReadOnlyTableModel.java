package view.controlModels;

public class ReadOnlyTableModel extends javax.swing.table.DefaultTableModel
{
    public boolean isCellEditable(int rowIndex, int columnIndex)
    {
        return false;
    }

    public void clear()
    {
        this.setColumnCount(0);
        this.setRowCount(0);
    }
}
