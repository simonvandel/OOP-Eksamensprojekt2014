using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Firma : IHandlende
    {
        public int ID { get; set; } //Modulus 11 validering
        public double Saldo { get; set; } 
        public double Kredit { get; set; }
    }
}
