using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows;

namespace Napredak
{
    internal class Kruzni_indikator : Indikator_napretka
    {
        private Path path;

        public Kruzni_indikator(Canvas canvas, Color boja) : base(canvas, boja)
        {
            path = new Path
            {
                Stroke = new SolidColorBrush(boja),
                StrokeThickness = 2
            };

            canvas.Children.Add(path);
        }

        public override void Azuriraj(int procenat)
        {
            double centerX = canvas.ActualWidth / 2;
            double centerY = canvas.ActualHeight / 2;
            double radius = Math.Min(centerX, centerY) - path.StrokeThickness / 2;

            ArcSegment arcSegment = new ArcSegment
            {
                Point = new Point(centerX + radius * Math.Cos(2 * Math.PI * procenat / 100),
                                  centerY - radius * Math.Sin(2 * Math.PI * procenat / 100)),
                Size = new Size(radius, radius),
                SweepDirection = SweepDirection.Clockwise,
                IsLargeArc = procenat > 50
            };

            PathFigure pathFigure = new PathFigure
            {
                StartPoint = new Point(centerX, centerY),
                Segments = new PathSegmentCollection { arcSegment }
            };

            PathGeometry pathGeometry = new PathGeometry
            {
                Figures = new PathFigureCollection { pathFigure }
            };

            path.Data = pathGeometry;
        }
    }
}
