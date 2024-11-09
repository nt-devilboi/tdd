// See https://aka.ms/new-console-template for more information

using System.Drawing;
using System.Drawing.Imaging;
using System.Security.Cryptography.X509Certificates;
using TagsCloudVisualization;

var rectangles = new List<Rectangle>();
var circularCloudLayouter = new CircularCloudLayouter(new Point(500, 500), rectangles);
using var tagImage = new CloundBitMap(1000, 1000, "./../../../photos/notIntersect-300.png");
using var tagCloud = new TagCloud(circularCloudLayouter, tagImage);
tagCloud.Create(150, 20, 20);

tagCloud.Save();

var list = new List<int>(0);