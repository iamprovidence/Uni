package view.modelsView;

import javax.swing.*;
import java.awt.*;

public class HighlightTextView extends AbstractView
{
    // FIELDS
    models.HighlightText highlightText;
    Font font;
    int fontSize;

    // CONSTRUCTORS
    public HighlightTextView()
    {
        highlightText = new models.HighlightText("Lorem ipsum");

        fontSize = 22;
        font = new Font("Verdana", Font.BOLD, fontSize);
    }

    // METHODS
    public void nextStep()
    {
        highlightText.nextChar();
    }
    public void show(Graphics2D g2d, JComponent component)
    {
        // draw background
        g2d.setBackground(Color.RED);
        g2d.clearRect(0, 0, component.getWidth(), component.getHeight());

        // calc font center
        g2d.setFont(font);
        FontMetrics metrics = g2d.getFontMetrics();
        int y = ((component.getHeight() - metrics.getHeight()) / 2) + metrics.getAscent();

        // draw text
        for (int i = 0; i < highlightText.count(); ++i)
        {
            if (i < highlightText.getAmount()) g2d.setColor(Color.WHITE);
            else                               g2d.setColor(Color.GRAY);

            g2d.drawString(highlightText.charAt(i),(i+1)*fontSize, y);
        }
    }
}
