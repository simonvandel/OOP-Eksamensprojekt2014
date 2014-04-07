using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Firma : IHandlende
    {
        public Firma(int id, double saldo)
        {
            ID = id;
            Saldo = saldo;
        }

        public Firma(int id) : this(id, 0) { } //Standard Saldo er nul

        public int ID { get; set; } //TODO Modulus 11 validering

        private double _Saldo;

        public double Saldo
        {
            get { return _Saldo; }
            set
            {
                if (value + Kredit < 0) { throw new ArgumentOutOfRangeException("Må ikke væres minus"); }
                else { _Saldo = value; }
            }
        }
        
        public double Kredit { get; set; }
    }
}
