using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    interface IKøretøjDimensioner
    {
        double Højde { get; set; }
        double Vægt { get; set; }
        double Længde { get; set; }
    }
}
