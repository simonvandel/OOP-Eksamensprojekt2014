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

            Autocamper autokamper1 = new Autocamper("SuperCamper9000", 2013, "AZ13579", EnumVarmesystem.Gas);
            autokamper1.Siddepladser = 20;
            autokamper1.HarToilet = true;

            Autocamper autokamper2 = new Autocamper("SølvCamper5000", 1995, "AW33212", EnumVarmesystem.Oliefyr);
            autokamper2.Siddepladser = 5;
            autokamper1.HarToilet = false;

            PrivatPersonbil audi = new PrivatPersonbil("Audi A6", 2011, "AB12345", 7);
            audi.Km = 2500;
            audi.KmPerLiter = 25;
            audi.HarIsofixBeslag = true;
            audi.HarTrækkrog = true;

            PrivatPersonbil skoda = new PrivatPersonbil("Skoda Octavia", 1999, "WE12512", 4, new DimensionerBagagerum() {Bredde = 200, Højde = 50, Længde = 100 } );
            skoda.Brændstof = EnumBrændstof.Benzin;
            skoda.KmPerLiter = 12;

            ErhvervPersonbil Transporter = new ErhvervPersonbil("Ford Transporter", 1990, "XY54321");
            Transporter.Km = 500000;

            ErhvervPersonbil Berlingo = new ErhvervPersonbil("Citroën Berlingo", 2010, "XY54321");
            
            Lastbil scandia = new Lastbil("Scandia 5", 2005, "WQ18652");

            Bus BogBus = new Bus("Bog Bussen", 1950, "AA11111");
            BogBus.Vægt = 1000;

            List<Køretøj> garage = new List<Køretøj>();

            garage.Add(autokamper2);
            garage.Add(skoda);
            garage.Add(audi);
            garage.Add(Transporter);
            garage.Add(autokamper1);
            garage.Add(scandia);
            garage.Add(BogBus);

            Auktionshus au = new Auktionshus();

            Sælger Simon = new Sælger();
            Simon.Handlende = new Privat(183101, 5000000);
            Simon.Postnummer = 5000;

            Sælger Sørensen = new Sælger();
            Sørensen.Postnummer = 8000;
            Sørensen.Handlende = new Firma(1231, 100000000);
            


            Køber Lars = new Køber();
            Lars.Handlende = new Privat(11, 20000);

            Køber Børge = new Køber();
            Børge.Handlende = new Privat(11223, 1000000);

            Køber Joakim = new Køber();
            Joakim.Handlende = new Firma(1123, 200000000);
            
            int auktionsnummer = au.SætTilSalg(garage[0], Simon, 10000);
            au.SætTilSalg(garage[1], Simon, 10000);
            au.SætTilSalg(garage[2], Sørensen, 10000);
            au.SætTilSalg(garage[3], Sørensen, 10000);
            au.SætTilSalg(garage[4], Simon, 500);

            
            // demo søg 1
            Console.WriteLine("søger efter navn \"audi\"");
            SøgningsTest(au,au.SøgNavn("audi"));

            // demo søg 2 
            Console.WriteLine("søger efter 10+ sæder og toilet"); 
            SøgningsTest(au, au.SøgTransportMuligheder(10));

            // demo søg 3
            Console.WriteLine("Søger efter fartøjer der kræver stort kørekort, og vejer under 2000kg");
            SøgningsTest(au, au.SøgStortKørekort(2000));

            // demo søg 4
            Console.WriteLine("Under 1mil, og 50.000 km - sorteret");
            SøgningsTest(au, au.SøgKørtPris(1000, 5000000));
            
            // demo søg 5
            Console.WriteLine("finder biler til salg indenfor radius");
            SøgningsTest(au, au.SøgPostnummer(4000, 2000));

            // Gennemsnitlig
            Console.WriteLine("Gennemsnitlig " + au.Gennemsnitlig());

            au.ModtagBud(Lars, auktionsnummer, 15000);
            au.ModtagBud(Børge, auktionsnummer, 5000);
            au.ModtagBud(Joakim, auktionsnummer, 2000000);

            if (au.AccepterBud(Simon, auktionsnummer))
            {
                Console.WriteLine("Bud accepteret");
            }
            
            foreach (Køretøj k in au.GetSolgteEnumerable())
            {
                Console.WriteLine(k.Navn);
            }

            Console.ReadLine();


        }

        public static void SøgningsTest(Auktionshus au, IEnumerable<Køretøj> matches)
        {
            foreach (var item in matches)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}
