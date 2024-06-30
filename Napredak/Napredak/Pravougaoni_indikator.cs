using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Napredak
{
    internal class Pravougaoni_indikator : Indikator_napretka
    {
        private Rectangle rect;

        public Pravougaoni_indikator(Canvas canvas, Color boja) : base(canvas, boja)
        {
            rect = new Rectangle
            {
                Width = canvas.ActualWidth,
                Height = canvas.ActualHeight,
                Fill = new SolidColorBrush(boja)
            };
            canvas.Children.Add(rect);
        }

        public override void Azuriraj(int procenat)
        {
            double novaSirina = (canvas.ActualWidth * procenat) / 100;
            rect.Width = novaSirina;
        }
    }
}
