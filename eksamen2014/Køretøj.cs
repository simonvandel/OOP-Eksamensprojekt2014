using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public abstract class Køretøj
    {
        public Køretøj() { }

        public Køretøj(string navn, int årgang, string registreringsnummer)
        {
            Navn = navn;
            Årgang = årgang;
            Registreringsnummer = registreringsnummer;
        }
        
        private string _navn;
        private double _km;
        private string _registreringsnummer;
        private double _nyPris;
        protected double _motorstørrelse;
        protected bool _harTrækkrog;
        protected abstract double _minMotorstørrelse { get; }
        protected abstract double _maxMotorstørrelse { get; }

        public String Navn
        {
            get { return _navn; }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Navn må ikke være null");
                }

                _navn = value;
                    
            }
        }
        public double Km { 
            get { 
                    return _km; 
                } 
            set {
                    if (value < 0)
                    {
                        throw new ArgumentOutOfRangeException("km må ikke være negativ");
                    }
                    _km = value;
                } 
        }
        public String Registreringsnummer { 
            get { 
                int antalSynligeTegn = _registreringsnummer.Count() - 4;
                string synligeTegn = _registreringsnummer.Substring(2, antalSynligeTegn);
                return string.Format("**{0}**", synligeTegn);
                }
            set {
                char[] førsteToTegn = value.ToCharArray(0, 2);
                char[] sidsteTegn = value.ToCharArray(2,value.Count() - 2);
                
                if (førsteToTegn.Count(c => char.IsLetter(c)) == 2
                    && sidsteTegn.Count() == 5
                    && sidsteTegn.Count(c => char.IsDigit(c)) == 5)
                {
                    _registreringsnummer = value;
                }
                else
                {
                    throw new InvalidRegistreringsnummerException("Ikke gyldigt registreringsnummer");
                }
                }
        } 
        public int Årgang { get; private set; }
        public double NyPris { 
            get {
                return _nyPris;
                }
            set {
                if (value < 0) _nyPris = 0;
                else _nyPris = value;
                }
        }
        public virtual bool HarTrækkrog {
            get { return _harTrækkrog; }
            set { _harTrækkrog = value; }
        }
        public abstract EnumKørekortType KørekortType { get; }
        public double Motorstørrelse
        {
            get
            {
                return _motorstørrelse;
            }
            set
            {
                if (value < _minMotorstørrelse || value > _maxMotorstørrelse)
                {
                    throw new ArgumentOutOfRangeException("motorstørrelse ikke valid");
                }
                else
                {
                    _motorstørrelse = value;
                }
            }
        }
        public double KmPerLiter { get; set; }
        public virtual EnumBrændstof Brændstof { get; set; }

        public virtual EnumEnergiklasse Energiklasse 
        { 
            get {
                if (Årgang < 2010)
                {
                    if (Brændstof == EnumBrændstof.Diesel) return BeregnEnergiKlasse(23,18,13);
                    else return BeregnEnergiKlasse(18,14,10);
                }
                else
                {
                    if (Brændstof == EnumBrændstof.Diesel) return BeregnEnergiKlasse(25, 20, 15);
                    else return BeregnEnergiKlasse(20,16,12);
                }
            } 
        }

        private EnumEnergiklasse BeregnEnergiKlasse(int aklasse, int bklasse, int cklasse)
        {
            if (KmPerLiter >= aklasse) { return EnumEnergiklasse.A; }
            else if (KmPerLiter >= bklasse) { return EnumEnergiklasse.B; }
            else if (KmPerLiter >= cklasse) { return EnumEnergiklasse.C; }
            else { return EnumEnergiklasse.D; }
        }

        public override string ToString() 
        {
            return string.Format("{0} - {1} årgang {2} - kørt {3} km", Registreringsnummer, Navn, Årgang, Km);
        } // TODO add flere punkter?
    }
}
