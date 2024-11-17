using System.Drawing;
using System.Drawing.Imaging;

namespace TagsCloudVisualization;

public class CloudBitMap : ITagCloudImage
{
    private readonly Bitmap bitmap;
    private readonly string filePath;
    private readonly Graphics graphics;
    private readonly Pen pen = new(Color.Red);
    private bool IsDisposed;

    public CloudBitMap(int width, int height, string filePath)
    {
        Validate(filePath, width, height);

        bitmap = new Bitmap(width, height);
        graphics = Graphics.FromImage(bitmap);
        graphics.Clear(Color.Black);
        this.filePath = filePath;
    }

    public Size Size() => bitmap.Size;

    public void Draw(Rectangle rec)
    {
        graphics.DrawRectangle(pen, rec);
    }

    public void Save()
    {
        bitmap.Save(filePath, ImageFormat.Png);
    }

    ~CloudBitMap()
    {
        Dispose(false);
    }

    private static void Validate(string filePath, int width, int height)
    {
        if (!Directory.Exists(Path.GetDirectoryName(filePath))) throw new DirectoryNotFoundException();
        if (width <= 0 || height <= 0) throw new ArgumentException("size of image should be with positive number");
    }

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }

    private void Dispose(bool fromMethod)
    {
        if (!IsDisposed)
        {
            if (fromMethod)
            {
                // представим, что здесь интерфейс логера. как будто гибкая штука)
                Console.WriteLine($"file saved in {filePath}");
            }

            bitmap.Dispose();
            graphics.Dispose();
            pen.Dispose();
            
            IsDisposed = true;
        }
    }
}