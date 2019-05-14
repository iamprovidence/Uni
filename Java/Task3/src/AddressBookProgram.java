package src;

public class AddressBookProgram
{
    public static void main(String args[])
    {
        launch(new view.frames.AddressBookFrame());
    }

    public static void launch(javax.swing.JFrame frame)
    {
        frame.setVisible(true);
    }
}