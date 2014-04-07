using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Autocamper : Køretøj
    {
        public Autocamper(string navn, int årgang, string registreringsnummer, EnumVarmesystem varmesystem) 
            : base(navn,årgang,registreringsnummer) 
        {
            Varmesystem = varmesystem;
        }

        protected override double _minMotorstørrelse
        {
            get { return 2.4; }
        }

        protected override double _maxMotorstørrelse
        {
            get { return 6.2; }
        }

        public TransportMuligheder Muligheder { get; set; }
        public override EnumKørekortType KørekortType
        {
            get { return EnumKørekortType.B; }
        }

        public EnumVarmesystem Varmesystem { get; set; }


        protected override EnumEnergiklasse BeregnEnergiKlasse(int aklasse, int bklasse, int cklasse, double kmperliter)
        {
            if (Varmesystem == EnumVarmesystem.Oliefyr) { kmperliter *= 0.7; }
            else if (Varmesystem == EnumVarmesystem.Strøm) { kmperliter *= 0.8; }
            else { kmperliter *= 0.9; }

            return base.BeregnEnergiKlasse(aklasse, bklasse, cklasse, kmperliter);
        }
    }
}
