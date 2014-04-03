using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Lastbil : Køretøj, IKøretøjDimensioner
    {
        protected override double _minMotorstørrelse
        {
            get { return 4.2; }
        }
        protected override double _maxMotorstørrelse
        {
            get { return 15; }
        }
        

        public double Lastevne { get;private  set; }
        public double Højde { get; set; }
        public double Vægt { get;set; }
        public double Længde { get;  set; }
        // TODO : kørekorttype
    }
}
