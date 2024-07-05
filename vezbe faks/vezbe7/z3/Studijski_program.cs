using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace z3
{
    public class Studijski_program
        
    {
        Studijski_program() 
        {
            Studenti = new List<Student>();    
        }
        public string Naziv { get; set; }
        public List<Student> Studenti { get; set; }
    }
}
