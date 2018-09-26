using System;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace FourForms
{
    public partial class MainForm : Form
    {
        struct WindowConfig
        {
            public DrawBase Drawing { get; set; }
            public Window Window { get; set; }
            public int Delay { get; set; }
        }
        // FIELDS
        Thread[] threads;
        DrawBase[] animation;
        WindowConfig[] windowConfiguration;
        int amount;
        // CONSTRUCTORS
        public MainForm()
        {
            InitializeComponent();
            amount = 4;

            // drawing initialize
            animation = new DrawBase[amount];
            animation[0] = new HeartBeat(window1.GraphicPanel.Width, window1.GraphicPanel.Height);
            animation[1] = new PurpleRain(window2.GraphicPanel.Width, window2.GraphicPanel.Height);
            animation[2] = new Radar(window3.GraphicPanel.Width, window3.GraphicPanel.Height);
            animation[3] = new Shuffle(window4.GraphicPanel.Width, window4.GraphicPanel.Height);
            // configuration initialize
            windowConfiguration = new WindowConfig[amount];
            windowConfiguration[0] = new WindowConfig() { Drawing = animation[0], Window = window1, Delay = 10 };
            windowConfiguration[1] = new WindowConfig() { Drawing = animation[1], Window = window2, Delay = 100 };
            windowConfiguration[2] = new WindowConfig() { Drawing = animation[2], Window = window3, Delay = 25 };
            windowConfiguration[3] = new WindowConfig() { Drawing = animation[3], Window = window4, Delay = 250 };

            // create threads
            threads = new Thread[amount];
            for (int i = 0; i < amount; ++i)
            {
                threads[i] = new Thread(RunWindow);
                threads[i].Start(windowConfiguration[i]);
            }
            // sign up for events
            int index = 0;
            foreach (Window window in scaleTbl.Controls.OfType<Window>())
            {
                int localIndex = index;

                // resizing
                window.PanelResized += animation[localIndex].PanelSizeChange;
                // painting
                window.PanelPaint += (o, e) => e.Graphics.DrawImage(animation[localIndex].Show(), 0, 0);

                // threads controling
                window.SuspendButtonClick += (o, e) => threads[localIndex].Suspend();
                window.ResumeButtonClick += (o, e) => threads[localIndex].Resume();

                ++index;
            }
        }

        // METHODS
        private void RunWindow(object config)
        {
            WindowConfig configuration = (WindowConfig)config;            
            try
            {
                while (true)
                {
                    configuration.Drawing.PerformStep();
                    configuration.Window.InvalidatePanel();
                    Thread.Sleep(configuration.Delay);
                }
            }
            catch (ThreadAbortException)
            {
                // ignore
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (System.Threading.Thread thread in threads)
            {
                if(thread?.ThreadState == ThreadState.Suspended)
                {
                    thread?.Resume();
                }
                thread?.Abort();
            }
            foreach (DrawBase drawing in animation)
            {
                drawing?.Dispose();
            }
        }
    }
}
