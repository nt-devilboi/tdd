// See https://aka.ms/new-console-template for more information

using System.Drawing;
using TagsCloudVisualization;

// хоть расскладки могут быть разные как и способы рисования. меня напрягает, что они оба друг от друга зависимы размером и поинтом. или это норм в данном случае?
var circularCloudLayouter = new CircularCloudLayouter(new Point(650, 650));
using var tagImage = new CloundBitMap(1300, 1300, "./../../../photos/notIntersect-200.png");
using var tagCloud = new TagCloud(circularCloudLayouter, tagImage);
tagCloud.GenerateCloud(200, 30, 40);
tagCloud.Save();