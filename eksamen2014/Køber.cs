using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Køber
    {
        public Køber(string navn, IHandlende handlende)
        {
            Handlende = handlende;
            Handlende.Navn = navn;
        }

        public IHandlende Handlende;

        public override string ToString()
        {
            return Handlende.ToString();
        }
    }
}
