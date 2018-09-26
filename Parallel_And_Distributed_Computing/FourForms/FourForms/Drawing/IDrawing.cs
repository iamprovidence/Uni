namespace FourForms
{
    interface IDrawing
    {
        int Width { get; set; }
        int Height { get; set; }
        System.Drawing.Bitmap Show();
        void PerformStep();
    }
}
