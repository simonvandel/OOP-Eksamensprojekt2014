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

        private double _kmPerLiter;

        protected override EnumEnergiklasse BeregnEnergiKlasse(int aklasse, int bklasse, int cklasse)
        {
            if (Varmesystem == EnumVarmesystem.Oliefyr) { _kmPerLiter = KmPerLiter * 0.7; }
            else if (Varmesystem == EnumVarmesystem.Strøm) { _kmPerLiter = KmPerLiter * 0.8; }
            else { _kmPerLiter = KmPerLiter * 0.9; }
            
            if (_kmPerLiter >= aklasse) { return EnumEnergiklasse.A; }
            else if (_kmPerLiter >= bklasse) { return EnumEnergiklasse.B; }
            else if (_kmPerLiter >= cklasse) { return EnumEnergiklasse.C; }
            else { return EnumEnergiklasse.D; }
        }
    }
}
