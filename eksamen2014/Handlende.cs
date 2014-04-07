﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public abstract class Handlende : IHandlende
    {
        public Handlende(int id, decimal saldo)
        {
            ID = id;
            Saldo = saldo;
        }

        protected decimal _Saldo;

        public int ID { get; set; }
        
        public decimal Saldo
        {
            get { return _Saldo; }
            set
            {
                if (value + Kredit < 0) { throw new ArgumentOutOfRangeException("Må ikke væres minus"); }
                else { _Saldo = value; }
            }
        }

        public virtual decimal Kredit { get; set; }

    }
}
