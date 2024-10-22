using System.Drawing;

namespace TagsCloudVisualization;

public class CircularCloudLayouter : ICloudLayouter
{
    private Point curRecPlace;
    private Point center;
    private int count;
    private List<Rectangle> rectangles; // типо паттерн лекговес, но не он.
    private Direction dir = Direction.Down;
    private int StepAvailable = 1;
    private int stepNow = 1;

    public CircularCloudLayouter(Point center, List<Rectangle> rectangles)
    {
        this.center = curRecPlace;
        curRecPlace = center;
        this.rectangles = rectangles;
    }

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        var rec = Rectangle.Empty;
        if (rectangles.Count == 0)
        {
            rec = new Rectangle(curRecPlace, rectangleSize);
            rectangles.Add(rec);
            return rec;
        }

        StepAvailable--;
        if (dir == Direction.Down)
        {
            curRecPlace.Y += rectangles[^1].Height;
        }

        else if (dir == Direction.Right)
        {
            curRecPlace.X += rectangles[^1].Width;
        }

        else if (dir == Direction.Up)
        {
            curRecPlace.Y -= rectangleSize.Height;
        }

        if (StepAvailable == 0)
        {
            switch (dir)
            {
                case Direction.Down:
                    dir = Direction.Right;
                    break;
                case Direction.Right:
                    dir = Direction.Up;
                    stepNow++;
                    break;
                case Direction.Up:
                    dir = Direction.Left;
                    break;
                case Direction.Left:
                    dir = dir = Direction.Down;
                    stepNow++;
                    break;
            }

            StepAvailable = stepNow;
        }

        rec = new Rectangle(curRecPlace, rectangleSize);
        rectangles.Add(rec);
        return rec;
    }

    private Rectangle MoveToFreeSpace(Rectangle rectangle)
    {
        /*
        foreach (var rec in rectangles)
        {
            if (rectangle.Top < rec.Bottom)
            {
                var rectangleBottom = rectangle.Bottom - rec.Top;
                var point = new Point(rectangle.X, rectangle.Y + rectangleBottom);
                rectangle = new Rectangle(point, rectangle.Size);
            }
            // и так далее
        }
        */

        return rectangle;
    }
}
// как будто ttd удобно в том случае, когда не ты не можешь увидеть всё решение сразу, и постепенно пишешь тесты и реализуешь по под задачам логику.