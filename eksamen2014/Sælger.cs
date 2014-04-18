using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Sælger : Køber
    {
        public Sælger(string navn, IHandlende handlende) : base(navn, handlende) { }

        public int Postnummer { get; set; }

        public void ModtagNotifikationOmBud(object sender, KøbsdetaljerEventArgs e)
        {
            Console.WriteLine(string.Format("{0} har budt {1} kr. på auktion nr. {2}",
                e.Budafgiver, e.Bud, e.AuktionsNummer));
        }

        public override string ToString()
        {
            return Handlende.ToString();
        }
    }
}
