using System.Drawing;
using System.Drawing.Imaging;

namespace TagsCloudVisualization;

public class CloundBitMap : ITagCloudImage
{
    private readonly Bitmap bitmap;
    private readonly string filePath;
    private readonly Graphics graphics;

    public CloundBitMap(int width, int height, string filePath)
    {
        Validate(filePath, width, height);
        
        bitmap = new Bitmap(width, height);
        graphics = Graphics.FromImage(bitmap);
        graphics.Clear(Color.Black);
        this.filePath = filePath;
    }

    private static void Validate(string filePath, int width, int height)
    {
        if (!Directory.Exists(Path.GetDirectoryName(filePath))) throw new DirectoryNotFoundException();
        if (width <= 0 || height <= 0) throw new ArgumentException("size of image should be with positive number");
    }

    public Size Size() => bitmap.Size;
    
    public void Draw(Rectangle rec)
    {
        var red = new Pen(Color.Red);
        graphics.DrawRectangle(red, rec);
    }

    public void Save()
    {
        bitmap.Save(filePath, ImageFormat.Png);
    }

    public void Dispose()
    {
        bitmap.Dispose();
        graphics.Dispose();
    }
}