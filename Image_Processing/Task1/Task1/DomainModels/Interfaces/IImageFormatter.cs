namespace Task1.DomainModels.Interfaces
{
    interface IImageFormatter
    {
        string Name { get; }
        string Extension { get; }

        System.IO.Stream Format(System.Drawing.Image imageToFormat);
    }
}
