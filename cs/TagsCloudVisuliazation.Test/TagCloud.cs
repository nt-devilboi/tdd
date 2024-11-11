using System.Drawing;
using FluentAssertions;
using TagsCloudVisualization;

namespace TagsCloudVisuliazation.Test;

public class Tests
{
    [SetUp]
    public void Setup()
    {
    }

    [TestCase(3, -2, TestName = "X ShouldBeMoreThan 0")]
    [TestCase(-3, 2, TestName = "Y ShouldBeMoreThan 0")]
    public void CircularCloudLayouter_CheckConstructor(int y, int x)
    {
        Action action = () => new CircularCloudLayouter(new Point(y, x));
        action.Should().Throw<ArgumentException>();
    }

    [Test]
    public void CloudBitMap_DirectoryShouldBeExist()
    {
        Action action = () => new CloundBitMap(5, 5, "./../../../OuterWild/notIntersect-50.png");
        action.Should().Throw<DirectoryNotFoundException>();
    }

    [Test]
    public void TagCloud_StartHidesOverImage()
    {
        var circularCloudLayouter = new CircularCloudLayouter(new Point(6, 3));
        var tagImage = new CloundBitMap(5, 5, "./../../../photos/notIntersect-50.png");
        Action action = () => new TagCloud(circularCloudLayouter, tagImage);
        action.Should().Throw<ArgumentException>().WithMessage("start hides over image");
    }

    [Test]
    public void TagCloud_NotIntersect()
    {
        var rectangles = new List<Rectangle>();
        var circularCloudLayouter = new CircularCloudLayouter(new Point(500, 500));
        var tagImage = new CloundBitMap(1000, 1000, "./../../../photos/notIntersect-50.png");
        var tagCloud = new TagCloud(circularCloudLayouter, tagImage);
        tagCloud.Create(50, 100, 100);

        try
        {
            CheckIntercets(rectangles);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            tagCloud.Save();
        }
    }

    private static void CheckIntercets(List<Rectangle> rectangles)
    {
        for (int i = 0; i < rectangles.Count; i++)
        for (int j = i + 1; j < rectangles.Count; j++)
        {
            rectangles[i].IntersectsWith(rectangles[j]).Should().BeFalse();
        }
    }
}