using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class PrivatPersonbil : Personbil
    {
        public PrivatPersonbil(string navn, int årgang, string registreringsnummer, int sæder, bool beslag) 
            : base(navn,årgang,registreringsnummer) 
        {
            Sæder = sæder;
            HarIsofixBeslag = beslag;
        }

        public PrivatPersonbil(string navn, int årgang, string registreringsnummer, int sæder)
            : this(navn,årgang,registreringsnummer,sæder,false) { } //Default beslag = false


        public bool HarIsofixBeslag { get; set; }

        public override EnumKørekortType KørekortType
        {
            get
            {
                return EnumKørekortType.B;
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
                if (value < 2 || value > 7) 
                    throw new ArgumentOutOfRangeException("sæder skal være mellem 2 og 7");

                _sæder = value;
            }
        }
    }
}
