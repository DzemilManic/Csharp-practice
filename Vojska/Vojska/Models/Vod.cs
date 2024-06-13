using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vojska.Models
{
    public class Vod
    {
        public ObservableCollection<Vojnik> listaVojnika;
        public Vod()
        {
            listaVojnika = new ObservableCollection<Vojnik>();
        }
        public void DodajVojnika(Vojnik vojnik)
        {
            listaVojnika.Add(vojnik);
        }
    }
}
