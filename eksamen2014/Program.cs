using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    class Program
    {
        static void Main(string[] args)
        {
            Personbil p = new PrivatPersonbil("Audi A6", 2009, "AB12345");
            Console.WriteLine(p);
            Console.WriteLine(p.NyPris);
            Console.ReadLine();
        }
    }
}
