using System;
using System.Windows.Forms;

namespace FourForms
{
    public partial class Window : UserControl
    {
        public class PanelSizeEventArgs : EventArgs
        {
            public int Width { get; set; }
            public int Height { get; set; }
        }
        public Window()
        {
            InitializeComponent();

            typeof(Control).GetProperty("DoubleBuffered", 
                System.Reflection.BindingFlags.NonPublic | 
                System.Reflection.BindingFlags.Instance | 
                System.Reflection.BindingFlags.SetProperty).SetValue(graphicPanel, true, null);
        }

        public Panel GraphicPanel => graphicPanel;
        public Button SuspendBtn => suspendBtn;
        public Button ResumeBtn => resumeBtn;

        public event EventHandler<PaintEventArgs> PanelPaint;
        public event EventHandler<PanelSizeEventArgs> PanelResized;
        public event EventHandler ResumeButtonClick;
        public event EventHandler SuspendButtonClick;
        
        public void InvalidatePanel() => graphicPanel.Invalidate();

        private void suspendBtn_Click(object sender, EventArgs e)
        {            
            suspendBtn.Enabled = false;
            resumeBtn.Enabled = true;

            SuspendButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void resumeBtn_Click(object sender, EventArgs e)
        {
            resumeBtn.Enabled = false;
            suspendBtn.Enabled = true;

            ResumeButtonClick?.Invoke(this, EventArgs.Empty);
        }

        private void graphicPanel_Paint(object sender, PaintEventArgs e)
        {
            PanelPaint?.Invoke(sender, e);
        }

        private void graphicPanel_SizeChanged(object sender, EventArgs e)
        {
            PanelResized?.Invoke(this, new PanelSizeEventArgs() { Width = graphicPanel.Width, Height = graphicPanel.Height});
        }
    }
}
