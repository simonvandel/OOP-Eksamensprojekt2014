﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Firma : Handlende
    {
        public Firma(int id, decimal saldo) : base(id, saldo) { }
        public Firma(int id) : this(id, 0) { } //Standard Saldo er nul
    }
}
