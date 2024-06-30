using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Napredak
{
    public interface IObavestivaStvar
    {
        void ObavestiNapredak(int procenat);
    }
    public interface ObavestivaStvar
    {
        void Obavesti(int trenutnoIzvrseno, int ukupno);
    }


}
