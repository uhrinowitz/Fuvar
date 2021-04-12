using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fuvar
{
    class Táblázat
    {
        public string eredetiSor;
        public int id;
        public DateTime indulás;
        public int időtartam;
        public double távolság;
        public double viteldíj;
        public double borravaló;
        public string fizetésiMód;
        public Táblázat(string sor)
        {
            eredetiSor = sor;
            string[] sorAdatok = sor.Split(';');
            id = int.Parse(sorAdatok[0]);
            indulás = DateTime.Parse(sorAdatok[1]);
            időtartam = int.Parse(sorAdatok[2]);
            távolság = double.Parse(sorAdatok[3]);
            viteldíj = double.Parse(sorAdatok[4]);
            borravaló = double.Parse(sorAdatok[5]);
            fizetésiMód = sorAdatok[6];
        }
        public override string ToString()
        {
            return eredetiSor;
        }
        public string getSorAdatok(Táblázat táblázat)
        {
            
            return eredetiSor;
        }

        public string getSorAdatok(int a)
        {
            string eredetiSor = "";
            return eredetiSor + a;
        }

    }
}
