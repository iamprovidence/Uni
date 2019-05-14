package view.modelsView;

import javax.swing.*;
import java.awt.*;

public class FibonacciView extends AbstractView
{
    // FIELDS
    java.util.Random random;
    models.FibonacciGenerator fibonacciGenerator;

    Font font;

    // CONSTRUCTORS
    public FibonacciView()
    {
        random = new java.util.Random();
        fibonacciGenerator = new models.FibonacciGenerator();

        font = new Font("Verdana", Font.BOLD, 82);
    }

    // METHODS
    public void nextStep()
    {
        fibonacciGenerator.next();
    }
    public void show(Graphics2D g2d, JComponent component)
    {
        // get bounds
        Rectangle bounds = component.getBounds();

        // sets color
        Color randomBackColor = new Color (random.nextInt(256),random.nextInt(256),random.nextInt(256));

        g2d.setBackground(randomBackColor);
        g2d.setColor(getContrastColor(randomBackColor));

        // draw background and fibonacci number
        g2d.clearRect(bounds.x, bounds.y, bounds.width, bounds.height);
        drawCenteredString(g2d, Integer.toString(fibonacciGenerator.getNext()), bounds, font);
    }
    public void drawCenteredString(Graphics2D g, String text, Rectangle rect, Font font)
    {
        FontMetrics metrics = g.getFontMetrics(font);
        int x = rect.x + (rect.width - metrics.stringWidth(text)) / 2;
        int y = rect.y + ((rect.height - metrics.getHeight()) / 2) + metrics.getAscent();
        g.setFont(font);
        g.drawString(text, x, y);
    }
    private Color getContrastColor(Color color)
    {
        int d = 0;

        // Counting the perceptive luminance - human eye favors green color...
        double luminance = (0.299 * color.getRed() +
                            0.587 * color.getGreen() +
                            0.114 * color.getBlue())/255;

        if (luminance > 0.5)  d = 0;   // bright colors - black font
        else                  d = 255; // dark colors - white font

        return  new Color(d, d, d);
    }
}
