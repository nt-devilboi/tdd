using System.Drawing;

namespace TagsCloudVisualization;

public class CircularCloudLayouter : ICloudLayouter
{
    private readonly List<Rectangle> rectangles; 
    private double angle;
    private const double A = 1;

    public CircularCloudLayouter(Point center)
    {
        CheckValid(center);
        rectangles = new List<Rectangle>();
        Start = center;
    }

    public Point Start { get; set; }

    public Rectangle PutNextRectangle(Size rectangleSize)
    {
        var rec = Rectangle.Empty;
        do
        {
            angle += Math.PI / 14;
            var radius = A * angle;
            var x = (int)(Start.X + radius * Math.Cos(angle));
            var y = (int)(Start.Y + radius * Math.Sin(angle));
            rec = new Rectangle(new Point(x, y), rectangleSize);
        } while (AnyIntersectWithRec(rec));

        TryMoveToCenter(ref rec);
        rectangles.Add(rec);
        return rec;
    }

    private void CheckValid(Point center)
    {
        if (center.X < 0) throw new ArgumentException("X has value less than 0");
        if (center.Y < 0) throw new ArgumentException("Y has value less than 0");
    }
    
    private void TryMoveToCenter(ref Rectangle rec)
    {
        while (true)
        {
            var isMoved = false;
            if (Start.Y - rec.Bottom > 2 && !AnyIntersectWithRec(rec.NewWithOffSet(0, +2)))
            {
                rec.Y += 1;
                isMoved = true;
            }

            if (rec.Top - Start.Y > 2 && !AnyIntersectWithRec(rec.NewWithOffSet(0, -2)))
            {
                rec.Y -= 1;
                isMoved = true;
            }

            if (rec.Left - Start.X > 2 && !AnyIntersectWithRec(rec.NewWithOffSet(-2, +2)))
            {
                rec.X -= 1;
                isMoved = true;
            }

            if (Start.X - rec.Right > 2 && !AnyIntersectWithRec(rec.NewWithOffSet(+2)))
            {
                rec.X += 1;
                isMoved = true;
            }

            if (!isMoved) break;
        }
    }

    private bool AnyIntersectWithRec(Rectangle rec)
    {
        return rectangles.Any(rectangle => rectangle.IntersectsWith(rec));
    }
}