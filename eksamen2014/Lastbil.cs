﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Lastbil : Køretøj
    {
        public Lastbil(string navn, int årgang, string registreringsnummer, double lasteevne) 
            : base(navn,årgang,registreringsnummer) {
                Lastevne = lasteevne;
        } //TODO lav specifik constructor
        
        public Lastbil(string navn, int årgang, string registreringsnummer)
            : this(navn, årgang, registreringsnummer, 0) { }
        
        public double Lastevne { get; private set; } //QA hvorfor private set?
        public double Vægt { get; set; }
        public Dimensioner2 Dimensioner { get; set; }

        protected override double _minMotorstørrelse
        {
            get { return 4.2; }
        }
        protected override double _maxMotorstørrelse
        {
            get { return 15; }
        }

        public override EnumBrændstof Brændstof
        {
            get
            {
                return EnumBrændstof.Diesel;
            }
            set
            {
                if (value == EnumBrændstof.Benzin) throw new ArgumentException("Lastbiler kan ikke benytte benzin");
            }
        }

        public override EnumKørekortType KørekortType
        {
            get
            {
                if (HarTrækkrog) return EnumKørekortType.CE;
                else return EnumKørekortType.C;
            }
        }
    }
}
