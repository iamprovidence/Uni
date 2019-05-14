package src;

import view.frames.JdbcFrame;

public class JDBCProgram
{
    public static void main(String args[])
    {
        launch(new JdbcFrame());
    }

    public static void launch(javax.swing.JFrame frame)
    {
        frame.setVisible(true);
    }
}
