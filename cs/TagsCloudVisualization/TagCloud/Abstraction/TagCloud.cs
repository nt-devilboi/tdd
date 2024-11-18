using System.Drawing;

namespace TagsCloudVisualization;

// хочется сразу заиспользовать паттерн мост. использовать класс TagCloud, как абстракцию для создания всех деталей TagCloud
// замечу, что tagCloud не имеет интерфейса, ибо он по существу никогда не будет иметь другую реализацию, ибо вся логика внутри интерефейсов, а этот класс просто обёртка, которая ничего сама делать и не может. композиция на максиум кароче.
// здесь бы еще паттерн строитель, но это уже overhead.
public class TagCloud : IDisposable
{
    private readonly ICloudLayouter cloudLayouter;

    private readonly ITagCloudImage tagCloudImage;
    
    private bool IsDisposed;

    public TagCloud(ICloudLayouter cloudLayouter, ITagCloudImage tagCloudImage)
    {
        Validate(cloudLayouter, tagCloudImage);
        this.cloudLayouter = cloudLayouter;
        this.tagCloudImage = tagCloudImage;
    }


    private static void Validate(ICloudLayouter cloudLayouter, ITagCloudImage tagCloudImage)
    {
        if (cloudLayouter.Start.Y > tagCloudImage.Size().Height ||
            cloudLayouter.Start.X > tagCloudImage.Size().Width)
            throw new ArgumentException("the start position is abroad of image");
    }

    // было красиво было бы если, в аргументах принимали бы массив tags, по их популярности, а не random, но по задачи этого делать не нужно
    public void GenerateCloud(int countTag, int minSize, int maxSize)
    {
        for (var i = 0; i < countTag; i++)
        {
            var width = Random.Shared.Next(minSize, maxSize);
            var height = Random.Shared.Next(minSize, maxSize);
            var rec = cloudLayouter.PutNextRectangle(new Size(width, height));
            tagCloudImage.Draw(rec);
        }
    }

    public void Save()
    {
        tagCloudImage.Save();
    }

    public void Dispose()
    {
        Dispose(true);
    }

    private void Dispose(bool fromMethod)
    {
        if (!IsDisposed)
        {
            if (fromMethod)
            {
                // потенциально это может в будущем пригодится, еще есть tag 2 и 3.
            }

            tagCloudImage.Dispose();

            IsDisposed = true;
        }
    }
}