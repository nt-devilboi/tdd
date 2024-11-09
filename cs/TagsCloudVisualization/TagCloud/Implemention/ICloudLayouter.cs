using System.Drawing;

namespace TagsCloudVisualization;

public abstract class ICloudLayouter // так это получается паттерн стратегия)) // а лучше вообще абстракт класс, здесь будет только работа с готовым вычислением точки
{
    private protected List<Rectangle> Rectangles;
    public Point Start { get; protected set; }

    protected ICloudLayouter(List<Rectangle> rectangles)
    {
        Rectangles = rectangles;
    }

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        var newPoint = GetNewRec(rectangleSize);
        return newPoint;
    }

    protected abstract Rectangle GetNewRec(Size rectangleSize);
}