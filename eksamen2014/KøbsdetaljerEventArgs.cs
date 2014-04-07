using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace eksamen2014
{
    public class KøbsdetaljerEventArgs
    {
        public KøbsdetaljerEventArgs(Køber køber, decimal bud, int auktionsNummer)
        {
            Budafgiver = køber;
            Bud = bud;
            AuktionsNummer = auktionsNummer;
        }

        public Køber Budafgiver;
        public decimal Bud;
        public int AuktionsNummer;
    }
}
