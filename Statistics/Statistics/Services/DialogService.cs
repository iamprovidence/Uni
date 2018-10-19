namespace Statistics
{
    static class DialogService
    {
        public static void ShowErrorMessage(string message, string header = "Помилка")
        {
            System.Windows.Forms.MessageBox.Show(message, header,
                System.Windows.Forms.MessageBoxButtons.OK,
                System.Windows.Forms.MessageBoxIcon.Error,
                System.Windows.Forms.MessageBoxDefaultButton.Button1);
        }
    }
}
