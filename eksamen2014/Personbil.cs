using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Personbil : Køretøj
    {
        public class Bagagerum
        {
            public double Højde { get; private set; }
            public double Længde { get; private set; }
            public double Bredde { get; private set; }

            public Bagagerum(double højde, double længde, double bredde)
            {
                Højde = højde;
                Længde = længde;
                Bredde = bredde;
            }
        }

        protected override double _minMotorstørrelse
        {
            get { return 0.7; }
        }
        protected override double _maxMotorstørrelse
        {
            get { return 10; }
        }
        public int Sæder { get; set; } // TODO input validering
        public Bagagerum Bagagerum { get; private set; } // TODO : skal sættes i constructor
        // TODO privat vs erhverv
    }
}
