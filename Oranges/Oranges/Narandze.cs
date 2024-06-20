using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Oranges
{
    public class Narandze
    {
        public bool zdrava { get; set; }
        public string oznaka {  get; set; }
        public int id { get; set; }
        private static int nextId = 1;
        public Narandze() {
            this.id = nextId++;
        }
    }
}
