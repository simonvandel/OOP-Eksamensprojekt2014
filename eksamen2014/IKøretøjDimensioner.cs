using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    interface IKøretøjDimensioner
    {
        double Højde { get; private set; }
        double Vægt { get; private set; }
        double Længde { get; private set; }
    }
}
