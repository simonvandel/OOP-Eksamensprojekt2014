using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public abstract class Personbil : Køretøj
    {

        public Personbil(string navn, int årgang, string registreringsnummer) : base(navn, årgang, registreringsnummer) { }
        /*
        public struct Dimensioner
        {
            public double Højde { get; private set; }
            public double Længde { get; private set; }
            public double Bredde { get; private set; }

            public Dimensioner(double højde, double længde, double bredde)
            {
                Højde = højde;
                Længde = længde;
                Bredde = bredde;
            }
        }
         */ 
        //TODO dimensioner

        protected int _sæder;

        protected override double _minMotorstørrelse
        {
            get { return 0.7; }
        }
        protected override double _maxMotorstørrelse
        {
            get { return 10; }
        }
        public abstract int Sæder { get; set; }
        public Dimensioner3 Bagagerum { get; private set; } // TODO : skal sættes i constructor
    }


}
