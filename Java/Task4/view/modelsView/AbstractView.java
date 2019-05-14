package view.modelsView;

public abstract class AbstractView
{
    public abstract void nextStep();
    public abstract void show(java.awt.Graphics2D g2d, javax.swing.JComponent component);
}
