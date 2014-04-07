using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public abstract class Køretøj
    {
        public Køretøj(string navn, int årgang, string registreringsnummer, double km, 
            double nypris, bool trækkrog, double kmpl, EnumBrændstof brændstof)
        {
            Navn = navn;
            Årgang = årgang;
            Registreringsnummer = registreringsnummer;
            Km = km;
            NyPris = nypris;
            HarTrækkrog = trækkrog;
            KmPerLiter = kmpl;
            Brændstof = brændstof;
        }
        // TODO køretøjs constructor skal være meget simpel - skal kun indeholde fællestræk

        public Køretøj(string navn, int årgang, string regristringsnummer)
            : this(navn, årgang, regristringsnummer, 0, 0, true, 0, EnumBrændstof.Diesel) { } //TODO trækkrog default burde være false, men det fucker med ErhvervsPersonbil
        
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

        public EnumEnergiklasse Energiklasse 
        { 
            get {
                if (Årgang < 2010)
                {
                    if (Brændstof == EnumBrændstof.Diesel) return BeregnEnergiKlasse(23,18,13, KmPerLiter);
                    else return BeregnEnergiKlasse(18,14,10, KmPerLiter);
                }
                else
                {
                    if (Brændstof == EnumBrændstof.Diesel) return BeregnEnergiKlasse(25, 20, 15, KmPerLiter);
                    else return BeregnEnergiKlasse(20,16,12, KmPerLiter);
                }
            } 
        }

        protected virtual EnumEnergiklasse BeregnEnergiKlasse(int aklasse, int bklasse, int cklasse, double kmperliter)
        {
            if (kmperliter >= aklasse) { return EnumEnergiklasse.A; }
            else if (kmperliter >= bklasse) { return EnumEnergiklasse.B; }
            else if (kmperliter >= cklasse) { return EnumEnergiklasse.C; }
            else { return EnumEnergiklasse.D; }
        }

        public override string ToString() 
        {
            return string.Format("{0} - {1} årgang {2} - {3} {4}" + Environment.NewLine +
                "Kørekorttype {5} - Energiklasse {6} - kørt {7} km",
                Registreringsnummer, Navn, Årgang, Brændstof, HarTrækkrog ? "med trækkrog " : "", KørekortType, Energiklasse, Km);
        } // TODO add flere punkter?
    }
}
