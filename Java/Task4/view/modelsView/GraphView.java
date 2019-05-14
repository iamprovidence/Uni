package view.modelsView;

import javax.swing.*;
import java.awt.*;
import java.awt.geom.Point2D;

public class GraphView extends AbstractView
{
    // FIELDS
    models.Graph graph;
    java.util.Queue<Point2D> trace;

    int pointLimit;
    double phi;
    double phiStep;

    // CONSTRUCTORS
    public GraphView()
    {
        graph = new models.Graph(50);
        trace = new java.util.ArrayDeque<Point2D>();

        pointLimit = 150;
        phi = 0;
        phiStep = 0.01;
    }

    // METHODS
    public void nextStep()
    {
        phi += phiStep;
        trace.add(graph.FoliumOfDescartes(phi));
        if (trace.size() >= pointLimit) trace.remove();
    }
    public void show(Graphics2D g2d, JComponent component)
    {
        g2d.setBackground(Color.DARK_GRAY);
        g2d.clearRect(0, 0, component.getWidth(), component.getHeight());

        // transform to center and rotate axes to correct math axes
        java.awt.geom.AffineTransform oldTransform = g2d.getTransform();
        g2d.translate(component.getWidth()/2, component.getHeight()/2);
        g2d.rotate(Math.toRadians(-90));

        // drawing trace
        float saturation = 0;
        for (Point2D point : trace)
        {
            g2d.setColor(Color.getHSBColor(0.6F,0.6F + saturation, 1));
            g2d.fillOval((int)point.getX(), (int)point.getY(), 5, 5);

            saturation += 0.1/pointLimit;
        }

        // reset transform
        g2d.setTransform(oldTransform);
    }
}

