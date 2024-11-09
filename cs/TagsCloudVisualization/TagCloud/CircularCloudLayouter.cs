using System.Drawing;

namespace TagsCloudVisualization;

public class CircularCloudLayouter : ICloudLayouter
{
    private Point lastPos;

    private readonly List<Rectangle> rectangles; // типо паттерн лекговес, но не он.

    // но сейчас есть косяк в том, что сам лист создаёт пользователь. то есть у него изнчально власть над листом и он после добавление в этот класс может его как-то менять или даже удалить.
    private double angle;
    private const double A = 1;

    public CircularCloudLayouter(Point center, List<Rectangle> rectangles) : base(rectangles)
    {
        CheckValid(center);

        lastPos = center;
        this.rectangles = rectangles;
        Start = center;
    }

    private void CheckValid(Point center)
    {
        if (center.X < 0) throw new ArgumentException("X has value less than 0");
        if (center.Y < 0) throw new ArgumentException("Y has value less than 0");
    }

    protected override Rectangle GetNewRec(Size rectangleSize)
    {
        var rec = Rectangle.Empty;
        do
        {
            angle += Math.PI / 4;
            var radius = A * angle;
            var x = (int)(lastPos.X + radius * Math.Cos(angle));
            var y = (int)(lastPos.Y + radius * Math.Sin(angle));
            rec = new Rectangle(new Point(x, y), rectangleSize);
        } while (IntersectWithRec(rec));

        TryMoveToFreeSpace(ref rec);
        lastPos = rec.Location;
        rectangles.Add(rec);
        return rec;
    }

    private void TryMoveToFreeSpace(ref Rectangle rec)
    {
        while (Start.Y - rec.Bottom > 2 && !IntersectWithRec(rec.NewWithOffSet(0, +2))) rec.Y += 1;
        while (rec.Top - Start.Y > 2 && !IntersectWithRec(rec.NewWithOffSet(0, -2))) rec.Y -= 1;
        while (rec.Left - Start.X > 2 && !IntersectWithRec(rec.NewWithOffSet(-2, +2))) rec.X -= 1;
        while (Start.X - rec.Right > 2 && !IntersectWithRec(rec.NewWithOffSet(+2))) rec.X += 1;
    }

    private bool IntersectWithRec(Rectangle rec)
    {
        return rectangles.Any(rectangle => rectangle.IntersectsWith(rec));
    }
}
// как будто ttd удобно в том случае, когда не ты не можешь увидеть всё решение сразу, и постепенно пишешь тесты и реализуешь по под задачам логику.