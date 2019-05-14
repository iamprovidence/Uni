package src;

public class SwingProgram
{
    public static void main(String args[])
    {
        launch(new view.frames.MainFrame());
    }

    public static void launch(javax.swing.JFrame frame)
    {
        frame.setDefaultCloseOperation(javax.swing.JFrame.EXIT_ON_CLOSE);
        frame.setVisible(true);
    }
}

