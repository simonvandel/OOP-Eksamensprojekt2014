using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public interface IHandlende
    {
        String Navn { get; set; }

        int ID { get; set; }

        decimal Saldo { get; set; }

        decimal Kredit { get; set; }
    }
}
