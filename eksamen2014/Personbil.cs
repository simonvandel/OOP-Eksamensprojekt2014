using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public abstract class Personbil : Køretøj
    {

        public Personbil(string navn, int årgang, string registreringsnummer, DimensionerBagagerum bagagerum)
            : this(navn, årgang, registreringsnummer)
        {
            Bagagerum = bagagerum;
        }

        public Personbil(string navn, int årgang, string registreringsnummer)
            : base(navn, årgang, registreringsnummer) { }

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
        public DimensionerBagagerum Bagagerum { get; protected set; }
    }


}
