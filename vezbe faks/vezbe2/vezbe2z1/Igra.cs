﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace vezbe2z1
{
    internal class Igra
    {
        public void Igraj()
        {
            Igrac igrac = new Igrac();
            Racunar racunar = new Racunar();
            int brPogodaka = 0, brGenerisanja = 0;
            while (true)
            {
                igrac.GetBroj();
                if (igrac.Broj == -1)
                    break;
                racunar.GetBroj();
                brGenerisanja++;
                if(igrac.Broj == racunar.Broj)
                    brPogodaka++;
            }
            float procent = (float)brPogodaka / brGenerisanja * 100;
            Console.WriteLine($"Igrac je pogodio {brPogodaka} puta");
            Console.WriteLine($"Procenat uspesnosti je {procent}%");
        }
    }
}
