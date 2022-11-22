using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RoundedRectangle
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            //now draw a rectangle of the following
            int width = 200;
            int height = 400;
            int top = 100;
            int left = 100;

            int roundPercentage = 20;

            Point[] points = new Point[4];

            int right = left + width;
            int bottom = top + height;
            points[0] = new Point(left, top);
            points[1] = new Point(right, top);
            points[2] = new Point(right, bottom);
            points[3] = new Point(left, bottom);

            Line[] lines = new Line[4];

            double shortestDist = Double.MaxValue;
            for(int i=0; i<4; ++i)
            {
                lines[i] = new Line();
                lines[i].Stroke = System.Windows.Media.Brushes.Black;
                lines[i].Fill = System.Windows.Media.Brushes.Black;

                Point cur = points[i];
                Point next = points[(i + 1) % 4];
                lines[i].X1 = cur.X;
                lines[i].Y1 = cur.Y;
                lines[i].X2 = next.X;
                lines[i].Y2 = next.Y;

                double segmentLen = dist(lines[i]);
                if (segmentLen < shortestDist)
                    shortestDist = segmentLen;
            }

            double shrinkLen = shortestDist * roundPercentage / 100.0;

            for (int i = 0; i < 4; ++i)
            {
                shorten(lines[i], shrinkLen);
            }

            BezierSegment[] beziers = new BezierSegment[4];
            QuadraticBezierSegment[] qBeziers = new QuadraticBezierSegment[4];
            Path[] paths = new Path[4];

            for(int i=0; i<4; ++i)
            {
                //current line point2 to next line point1
                Line curr = lines[i];
                Line next = lines[(i + 1) % 4];

                Point start = new Point(curr.X2, curr.Y2);
                Point end = new Point(next.X1, next.Y1);
                Point controlPt = points[(i + 1) % 4];

                double kappa = 0.552228474;
                Point controlPt1 = new Point(start.X + (controlPt.X - start.X) * kappa, start.Y + (controlPt.Y - start.Y) * kappa);
                Point controlPt2 = new Point(end.X + (controlPt.X - end.X) * kappa, end.Y + (controlPt.Y - end.Y) * kappa);

                beziers[i] = new BezierSegment(controlPt1, controlPt2, end, true);

                qBeziers[i] = new QuadraticBezierSegment(controlPt, end, true);

                //paths[i] = createPath(start, qBeziers[i]);
                paths[i] = createPath(start, beziers[i]);
            }

            //add line to the main grid
            for(int i=0; i<4; ++i)
            {
                mainGrid.Children.Add(lines[i]);
            }

            for(int i=0; i<4; ++i)
            {
                mainGrid.Children.Add(paths[i]);
            }
            
        }

        public static double dist(Line line)
        {
            double xDiff = line.X1 - line.X2;
            double yDiff = line.Y1 - line.Y2;
            return Math.Sqrt(xDiff * xDiff + yDiff * yDiff);
        }

        public static void shorten(Line line, double shortenLen)
        {
            double segmentLen = dist(line);
            Point midPoint = new Point((line.X1 + line.X2)/2, (line.Y1 + line.Y2)/2);
            double shrinkPercentage = shortenLen / segmentLen;

            Point pt1 = new Point(-(midPoint.X - line.X1) *(1 - shrinkPercentage), -(midPoint.Y - line.Y1) * (1-shrinkPercentage));

            Point pt2 = new Point(-(midPoint.X - line.X2) * (1 - shrinkPercentage), -(midPoint.Y - line.Y2) * (1 - shrinkPercentage));

            line.X1 = pt1.X + midPoint.X;
            line.Y1 = pt1.Y + midPoint.Y;

            line.X2 = pt2.X + midPoint.X;
            line.Y2 = pt2.Y + midPoint.Y;
        }

        public static Path createPath(Point startPoint, BezierSegment segment)
        {
            PathSegmentCollection pscollection = new PathSegmentCollection();
            pscollection.Add(segment);

            PathFigure pf = new PathFigure();
            pf.Segments = pscollection;
            pf.StartPoint = startPoint;

            PathFigureCollection pfcollection = new PathFigureCollection();
            pfcollection.Add(pf);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pfcollection;

            Path path = new Path();
            path.Data = pathGeometry;
            path.Stroke = System.Windows.Media.Brushes.Black;
            path.StrokeThickness = 2;

            return path;
        }

        public static Path createPath(Point startPoint, QuadraticBezierSegment segment)
        {
            PathSegmentCollection pscollection = new PathSegmentCollection();
            pscollection.Add(segment);

            PathFigure pf = new PathFigure();
            pf.Segments = pscollection;
            pf.StartPoint = startPoint;

            PathFigureCollection pfcollection = new PathFigureCollection();
            pfcollection.Add(pf);

            PathGeometry pathGeometry = new PathGeometry();
            pathGeometry.Figures = pfcollection;

            Path path = new Path();
            path.Data = pathGeometry;
            path.Stroke = System.Windows.Media.Brushes.Black;
            path.StrokeThickness = 2;

            return path;
        }
    }
}
