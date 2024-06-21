using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezbe1z3
{
    public class Kvadrat
    {
        public float a;
        public Kvadrat(float v)
        {
            a = v;
        }
        public float Obim() 
        {
            return 4 * a;
        }
        public double Povrsina()
        {
            return Math.Pow(a, 2);
        }
    }
}
