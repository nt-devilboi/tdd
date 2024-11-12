using System.Drawing;

namespace TagsCloudVisualization;

public static class ExtensionRectangle
{
    public static Rectangle СopyWithOffSet(this Rectangle rectangle, int x = 0, int y = 0)
    {
        rectangle.Offset(x, y);
        return rectangle;
    }
}