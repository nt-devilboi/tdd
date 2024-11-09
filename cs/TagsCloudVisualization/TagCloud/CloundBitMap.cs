using System.Drawing;
using System.Drawing.Imaging;

namespace TagsCloudVisualization;

public class CloundBitMap : ITagCloudImage
{
    private readonly Bitmap bitmap;
    private readonly string path;
    private readonly Graphics graphics;
    public CloundBitMap(int width, int height, string path)
    {
        bitmap = new Bitmap(width, height);
        graphics = Graphics.FromImage(bitmap);
        graphics.Clear(Color.Black);
        this.path = path;
    }


    public Size Size() => bitmap.Size;

    public void Draw(Rectangle rec)
    {
        var red = new Pen(Color.Red);
        graphics.DrawRectangle(red, rec);
    }

    public void DrawBackGround()
    {
        graphics.Clear(Color.Black);
        graphics.Dispose();
    }

    public void Save()
    {
        bitmap.Save(path, ImageFormat.Png);
    }

    public void Dispose()
    {
        bitmap.Dispose();
        graphics.Dispose();
    }
}