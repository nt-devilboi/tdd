using System.Drawing;
using FluentAssertions;
using TagsCloudVisualization;

namespace TagsCloudVisuliazation.Test;

public class CloudBitMapTests
{
    [Test]
    public void CloudBitMap_DirectoryShouldBeExist()
    {
        var filePath = "./../../../OuterWild/notIntersect-50.png";
        Action action = () => new CloundBitMap(5, 5, filePath);
        action.Should().Throw<DirectoryNotFoundException>();
    }
 
    [Test]
    public void CloudBitMap_ShouldBe_SizeWithPositiveNumbers()
    {
        var filePath = "./../../../photos/notIntersect-50.png";
        Action action = () => new CloundBitMap(-1, 5, filePath);
        action.Should().Throw<ArgumentException>();
    }

}