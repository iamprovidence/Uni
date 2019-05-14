package view.frames;

import view.modelsView.HighlightTextView;
import view.panels.ThreadControl;

import javax.swing.*;
import java.awt.*;

public class ThreadFrame extends JFrame
{
    // CONST
    public static final int DEFAULT_WIDTH = 1200;
    public static final int DEFAULT_HEIGHT = 400;

    // CONSTRUCTORS
    public ThreadFrame()
    {
        // sets title, size, layout
        setTitle("Thread Frame");
        setSize(DEFAULT_WIDTH, DEFAULT_HEIGHT);
        Dimension dimension = new Dimension(DEFAULT_WIDTH, DEFAULT_HEIGHT);
        setMinimumSize(dimension);
        setMaximumSize(dimension);
        setLayout(new GridLayout(1, 3)); // 1 rows, 3 cols

        // get screen dimensions
        dimension = Toolkit.getDefaultToolkit().getScreenSize();

        // center frame in screen
        setLocation(dimension.width/2 - DEFAULT_WIDTH/2, dimension.height/2 - DEFAULT_HEIGHT/2);

        // add panels to frame
        add(new ThreadControl(new view.modelsView.FibonacciView(), 2000));
        add(new ThreadControl(new view.modelsView.GraphView(), 10));
        add(new ThreadControl(new HighlightTextView(), 500));
    }
}
