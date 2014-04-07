using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Privat : IHandlende
    {
        public int ID { get; set; }
        public double Saldo { get; set; } // TODO Må ikke gå i minus
        public double Kredit { get { return 0; } set { } }
    }
}
