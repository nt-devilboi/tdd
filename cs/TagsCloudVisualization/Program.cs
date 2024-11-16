// See https://aka.ms/new-console-template for more information

using System.Drawing;
using TagsCloudVisualization;

// хоть расскладки могут быть разные как и способы рисования. меня напрягает, что они оба друг от друга зависимы размером и поинтом. или это норм в данном случае?
var circularCloudLayouter = new CircularCloudLayouter(new Point(500, 500));
using var tagImage = new CloundBitMap(1000, 1000, "./../../../photos/test_on2e.png");
using var tagCloud = new TagCloud(circularCloudLayouter, tagImage);
tagCloud.GenerateCloud(4, 30, 30);
tagCloud.Save();