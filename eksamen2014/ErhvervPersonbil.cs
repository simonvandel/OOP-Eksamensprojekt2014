using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class ErhvervPersonbil : Personbil
    {
        public ErhvervPersonbil(string navn, int årgang, string registreringsnummer) 
            : base(navn,årgang,registreringsnummer) { }
        
        public bool HarSikkerhedsbøjle { get; set; }
        public double Lasteevne { get; set; }

        public override EnumKørekortType KørekortType
        {
            get {
                if (Lasteevne > 750) return EnumKørekortType.BE;
                else return EnumKørekortType.B;
            }
        }
        public override int Sæder
        {
            get
            {
                return _sæder;
            }
            set
            {
                if (value != 2)
                    throw new ArgumentOutOfRangeException("sæder skal være 2");

                _sæder = value;
            }
        }
        public override bool HarTrækkrog
        {
            get
            {
                return _harTrækkrog;
            }
            set
            {
                if (value == false)
                    throw new ArgumentOutOfRangeException("Skal være true");

                _harTrækkrog = value;
            }
        }
    }
}
