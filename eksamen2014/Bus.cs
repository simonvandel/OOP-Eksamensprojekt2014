using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Bus : Køretøj
    {
        public Bus(string navn, int årgang, string registreringsnummer) : base(navn,årgang,registreringsnummer) { } //TODO lav specifik constructor

        protected override double _minMotorstørrelse
        {
            get { return 4.2; }
        }
        protected override double _maxMotorstørrelse
        {
            get { return 15; }
        }

        public TransportMuligheder Muligheder { get; set; }
        public double Vægt { get;  set; }
        public Dimensioner2 Dimensioner { get; set; }

        public override EnumKørekortType KørekortType
        {
            get
            {
                if (HarTrækkrog) return EnumKørekortType.DE;
                else return EnumKørekortType.D;
            }
        }
    }
}
