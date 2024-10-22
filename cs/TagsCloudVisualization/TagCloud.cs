using System.Drawing;

namespace TagsCloudVisualization;

// хочется сразу заиспользовать паттерн мост. использовать класс TagCloud, как абстракцию для создания всех деталей TagCloud
public class TagCloud
{
    private ICloudLayouter cloudLayouter;

    public TagCloud(ICloudLayouter cloudLayouter)
    {
        this.cloudLayouter = cloudLayouter;
    }

    // хочется, чтоб здесь мы получали уже готовый tagCloud с изображением и т.д, но пока всё проще 
    public List<Rectangle> Create()
    {
        var rectangles = new List<Rectangle>();
        for (int i = 0; i < 10; i++)
        {
            rectangles.Add(cloudLayouter.PutNextRectangle(new Size(100, 100)));
        }

        return rectangles;
    }
}