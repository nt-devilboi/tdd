using System.Drawing;
using FluentAssertions;
using TagsCloudVisualization;

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
}