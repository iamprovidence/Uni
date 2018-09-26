using System.Drawing;

namespace FourForms
{
    abstract class DrawBase : IDrawing, System.IDisposable
    {
        // FIELDS
        protected int height;
        protected int width;

        protected Bitmap bitmap;
        protected Graphics graphics;
        // PROPERTIES
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if (value != height)
                {
                    height = value;
                    CreateNewDrawingTools();
                    ResetImage();
                }
            }
        }
        public int Width
        {
            get
            {
                return width;
            }
            set
            {
                if (value != width)
                {
                    width = value;
                    CreateNewDrawingTools();
                    ResetImage();
                }
            }
        }
        // CONSTRUCTORS
        public DrawBase(int width, int height)
        {
            this.width = width;
            this.height = height;

            CreateNewDrawingTools();
        }
        // METHOD
        protected void CreateNewDrawingTools()
        {
            bitmap?.Dispose();
            graphics?.Dispose();

            this.bitmap = new Bitmap(width, height);
            this.graphics = Graphics.FromImage(bitmap);
            this.graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
        }
        public abstract void PerformStep();
        public abstract Bitmap Show();
        protected abstract void ResetImage();
        public virtual void Dispose()
        {
            graphics.Dispose();
            bitmap.Dispose();
        }
        public void PanelSizeChange(object sender, Window.PanelSizeEventArgs e)
        {
            this.Width = e.Width;
            this.Height = e.Height;
        }
    }
}
