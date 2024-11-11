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
        if (Directory.Exists(this.filePath)) throw new DirectoryNotFoundException();

        bitmap = new Bitmap(width, height);
        graphics = Graphics.FromImage(bitmap);
        graphics.Clear(Color.Black);
        this.filePath = filePath;
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