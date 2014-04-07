using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public interface IHandlende
    {
        int ID { get; set; }
        double Saldo { get; set; } // TODO virke med kredit
        double Kredit { get; set; }
    }
}
