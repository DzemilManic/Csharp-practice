using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezbe1z3
{
    public class Krug
    {
        public float pp;
        public Krug(float v)
        {
            pp = v;
        }
        public double Obim()
        {
            return 2 * pp * Math.PI;
        }
        public double Povrsina()
        {
            return Math.Pow(pp, 2) * Math.PI;
        }

    }
}
