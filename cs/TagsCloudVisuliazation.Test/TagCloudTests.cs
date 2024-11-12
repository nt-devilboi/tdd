using System.Drawing;
using FluentAssertions;
using TagsCloudVisualization;

namespace TagsCloudVisuliazation.Test;

public class TagCloudTests
{
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
        var filePath = "./../../../OuterWild/notIntersect-50.png";
        Action action = () => new CloundBitMap(5, 5, filePath);
        action.Should().Throw<DirectoryNotFoundException>();
    }


    [Test]
    public void TagCloud_StartPosition_ShouldBe_In_Image()
    {
        var circularCloudLayouter = new CircularCloudLayouter(new Point(6, 3));
        var tagImage = new CloundBitMap(5, 5, "./../../../photos/ph");
        Action action = () => new TagCloud(circularCloudLayouter, tagImage);
        action.Should().Throw<ArgumentException>().WithMessage("the start position is abroad of image");
    }

    [Test]
    public void CircularCLoudLayouter_ShouldBeCorrect_CountTag()
    {
        var Layouter = new CircularCloudLayouter(new Point(500, 500));

        var countTag = 50;
        for (int i = 0; i < countTag; i++) Layouter.PutNextRectangle(new Size(10, 10));
    }
}