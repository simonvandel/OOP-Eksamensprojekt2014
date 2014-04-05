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
            List<Køretøj> garage = new List<Køretøj>();

            garage.Add(new PrivatPersonbil("Audi A6", 2011, "AB12345"));
            garage.Add(new ErhvervPersonbil("Ford Transporter", 2000, "XY54321"));
            garage.Add(new Autocamper("SuperCamper9000", 1998, "AZ13579", EnumVarmesystem.Gas));
            garage.Add(new Lastbil("Scandia 5", 2005, "WQ18652"));
            garage.Add(new Bus("Bus 12", 1950, "AA11111"));


            Random rnd = new Random();

            foreach (Køretøj p in garage)
            {
                p.Km = rnd.Next(0,500000);
                p.KmPerLiter = rnd.Next(1,30);
                p.HarTrækkrog = true;
                Console.WriteLine(p);
                Console.WriteLine("Ny Pris: " + p.NyPris);
                Console.WriteLine();
            }

            Console.ReadLine();


        }
    }
}
