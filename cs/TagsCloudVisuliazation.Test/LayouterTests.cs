using System.Drawing;
using FluentAssertions;
using TagsCloudVisualization;
using TagsCloudVisuliazation.Test.Extension;

namespace TagsCloudVisuliazation.Test;

public class LayouterTests
{
    [TestCase(3, -2, TestName = "X ShouldBeMoreThan 0")]
    [TestCase(-3, 2, TestName = "Y ShouldBeMoreThan 0")]
    public void CircularCloudLayouter_CheckConstructor(int y, int x)
    {
        Action action = () => new CircularCloudLayouter(new Point(y, x));
        action.Should().Throw<ArgumentException>();
    }

    [Test]
    public void CircularCloudLayouter_Rectangles_ShouldBeHave_Neighbor()
    {
        var layoter = new CircularCloudLayouter(new Point(250, 250));
   
        CheckAllRectanglesHasNeighbor(layoter);
    }

    private void CheckAllRectanglesHasNeighbor(CircularCloudLayouter layoter)
    {
        var prev = layoter.PutNextRectangle(new Size(30, 30));
        var cur = layoter.PutNextRectangle(new Size(30, 30));
        var list = new List<Rectangle> { prev };
        for (int i = 0; i < 30; i++)
        {
            cur.HasNeighbor(list).Should().BeTrue();
            
            list.Add(cur);
            cur = layoter.PutNextRectangle(new Size(30, 30));
        }
    }
}