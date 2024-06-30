using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace Napredak
{
    internal abstract class Indikator_napretka
    {
        protected Canvas canvas;
        protected Brush boja;

        public Indikator_napretka(Canvas canvas, Color boja)
        {
            this.canvas = canvas;
            this.boja = new SolidColorBrush(boja);
        }
        public abstract void Azuriraj(int procenat);
    }
}
