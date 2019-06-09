namespace Library_management.View.Interfaces
{
    interface IMessageBox
    {
        string Header { get; set; }
        string Text { get; set; }

        bool? ShowDialog(Enums.MessageBoxButton messageBoxButton);
    }
}
