using System.Drawing;
using FluentAssertions;
using TagsCloudVisualization;

namespace TagsCloudVisuliazation.Test;

public class TagCloudTest
{
    private const string PathPhoto = "./../../../photos/WithErrorFrom";
    private TagCloud tagCloud;

    [SetUp]
    public void Setup()
    {
        var circularCloudLayouter = new CircularCloudLayouter(new Point(500, 500));
        var tagImage = new CloundBitMap(1000, 1000, PathPhoto);
        tagCloud = new TagCloud(circularCloudLayouter, tagImage);
    }

    [Test]
    public void TagCloud_NotIntersect()
    {
        var rectangles = new List<Rectangle>();
        
        tagCloud.GenerateCloud(50, 100, 100);

        CheckIntercets(rectangles);
    }

    
    [TearDown]
    public void CheckResult()
    {
        if (TestContext.CurrentContext.Test.MethodName.StartsWith("TagCloud"))
        {
            TestContext.WriteLine($"Tag cloud visualization saved to file {PathPhoto} + {TestContext.CurrentContext.Test.MethodName}");
        }
        
        tagCloud.Dispose();
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