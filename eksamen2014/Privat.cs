using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Privat : Handlende
    {
        public Privat(int id, decimal saldo) : base(id, saldo) { }
        public Privat(int id) : this(id, 0) { } //Standard Saldo er nul

        public override decimal Kredit
        {
            get { return 0; }
            set
            {
                Console.WriteLine("Privat personer kan ikke have kredit");
            }
        }
    }
}
