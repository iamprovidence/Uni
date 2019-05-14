package view.panels;

import view.modelsView.AbstractView;

import java.awt.*;
import javax.swing.*;

public class ThreadControl extends JPanel
{
    public ThreadControl(AbstractView viewModel, int threadDelay)
    {
        // set layout
        this.setLayout(new BorderLayout());

        // add thread panel
        ThreadPanel threadPanel = new ThreadPanel(viewModel, threadDelay);
        this.add(threadPanel, BorderLayout.CENTER);

        // add suspend/resume button to the bottom
        JButton threadBtn = new JButton("Suspend");
        threadBtn.addActionListener(new java.awt.event.ActionListener()
        {
            public void actionPerformed(java.awt.event.ActionEvent e)
            {
                if (threadBtn.getText() == "Suspend") threadBtn.setText("Resume");
                else                                  threadBtn.setText("Suspend");
            }
        });
        threadBtn.addActionListener(threadPanel);

        this.add(threadBtn, BorderLayout.SOUTH);
    }
}
