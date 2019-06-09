namespace Library_management.View.Interfaces
{
    interface IFileDialog
    {
        bool Multiselect { get; set; }
        string[] FileNames { get; }
        string Filter { get; set; }
        
        bool? ShowDialog();
    }
}
