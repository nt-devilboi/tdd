using System.Drawing;

namespace TagsCloudVisualization;

public interface ICloudLayouter // так это получается паттерн стратегия))
{
    Rectangle PutNextRectangle(Size rectangleSize);
}


// вопросы
// 1. могу я добавить допоплнительный слой абстракций, который будет использовать этот интерфейс? есть ли в этом смысл