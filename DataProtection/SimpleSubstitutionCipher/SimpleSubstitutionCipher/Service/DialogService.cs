namespace SimpleSubstitutionCipher.Service
{
    static class DialogService
    {
        public static void ErrorMessage(string message, string header = "Error")
        {
            System.Windows.Forms.MessageBox.Show(message, header,
                        System.Windows.Forms.MessageBoxButtons.OK,
                        System.Windows.Forms.MessageBoxIcon.Error,
                        System.Windows.Forms.MessageBoxDefaultButton.Button1);
        }
    }
}
