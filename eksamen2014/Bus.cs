﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Bus : Køretøj, IKøretøjDimensioner, ITransportMuligheder
    {
        public Bus(string navn, int årgang, string registreringsnummer) 
            : base(navn,årgang,registreringsnummer) { }

        protected override double _minMotorstørrelse
        {
            get { return 4.2; }
        }
        protected override double _maxMotorstørrelse
        {
            get { return 15; }
        }
        public double Vægt { get; set; }
        public double Højde { get; set; }
        public double Længde { get; set; }

        public int Siddepladser { get; set; }
        public int Sovepladser { get; set; }
        public bool HarToilet { get; set; }

        public override EnumKørekortType KørekortType
        {
            get
            {
                if (HarTrækkrog) return EnumKørekortType.DE;
                else return EnumKørekortType.D;
            }
        }
    }
}
