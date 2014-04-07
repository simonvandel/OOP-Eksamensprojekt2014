using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    class Auktionshus
    {
        public int SætTilSalg(Køretøj k, Sælger s, decimal minPris) 
        {
            return 0;
        }

        public int SætTilSalg(Køretøj k, Sælger s, decimal minPris, Action notifikationsMetode)
        {
            return 0;
        }

        public bool ModtagBud(Køber køber, int auktionsNummer, decimal bud)
        {
            return true;
        }

        public bool AccepterBud(Sælger sælger, int auktionsNummer)
        {
            return true;
        }

        //TODO søgefunktion

        //TODO gennemsnitlig energiklasse
    }
}
