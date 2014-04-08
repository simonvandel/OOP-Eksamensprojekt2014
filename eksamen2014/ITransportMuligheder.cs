using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    interface ITransportMuligheder
    {
        int Siddepladser { get; set; }
        int Sovepladser { get; set; }
        bool HarToilet { get; set; }
    }
}
