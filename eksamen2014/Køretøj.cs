using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public abstract class Køretøj
    {
        public enum EnumKørekortType { A, B, C, D, BE, CE, DE}
        public enum EnumBrændstof { Diesel, Benzin}
        public enum EnumEnergiklasse { A, B, C, D}

        private string _navn;
        private double _km;
        private double _nyPris;
        protected double _motorstørrelse;
        protected abstract double _minMotorstørrelse { get;}
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
        public String Registreringsnummer { get; set; } // TODO registreringsnummer
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
        public bool Trækkrog { get; set; } // TODO virtual
        public abstract EnumKørekortType KørekortType { get; private set; }
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
        public EnumBrændstof Brændstof { get; set; } // TODO virtual
        public EnumEnergiklasse Energiklasse { get; } // TODO logic

        public override string ToString() 
        {
            throw new NotImplementedException();
        } // TODO tostring
    }
}
