using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Autocamper : Køretøj
    {
        protected override double _minMotorstørrelse
        {
            get { return 2.4; }
        }

        protected override double _maxMotorstørrelse
        {
            get { return 6.2; }
        }
        
        // TODO alt
    }
}
