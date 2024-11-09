using System.Drawing;

namespace TagsCloudVisualization;

public interface ITagCloudImage : IDisposable
{
    Size Size();
    void Draw(Rectangle rec);

    void DrawBackGround();

    void Save();
}