package view.panels;

import view.modelsView.AbstractView;

import java.awt.*;
import javax.swing.*;

public class ThreadPanel extends JPanel implements Runnable, java.awt.event.ActionListener
{
    // FIELDS
    AbstractView viewModel;
    int threadDelay;

    Thread thread;
    boolean isRuning;

    // CONSTRUCTORS
    public ThreadPanel(AbstractView viewModel, int threadDelay)
    {
        this.viewModel = viewModel;
        this.threadDelay = threadDelay;

        this.thread = new Thread(this);
        this.thread.start();

        this.isRuning = true;
    }

    // METHODS
    public void actionPerformed(java.awt.event.ActionEvent e)
    {
        if (isRuning) thread.suspend();
        else          thread.resume();

        isRuning = !isRuning;
    }
    public void paintComponent(Graphics g)
    {
        super.paintComponent(g);
        viewModel.show((Graphics2D) g, this);
    }
    public void run()
    {
        try
        {
            while (true)
            {
                viewModel.nextStep();
                repaint();

                Thread.sleep(threadDelay);
            }
        }
        catch(InterruptedException e)
        {
            System.err.println(e.getMessage());
        }
    }
}

