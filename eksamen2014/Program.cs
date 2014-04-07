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

            Autocamper autokamper = new Autocamper("SuperCamper9000", 1998, "AZ13579", EnumVarmesystem.Oliefyr);
            autokamper.Siddepladser = 20;
            autokamper.HarToilet = true;

            PrivatPersonbil audi = new PrivatPersonbil("Audi A6", 2011, "AB12345", 5);
            audi.Km = 250000;
            audi.KmPerLiter = 18;

            ErhvervPersonbil fordTransporter = new ErhvervPersonbil("Ford Transporter", 2000, "XY54321");
            fordTransporter.Km = 500000;

            Lastbil scandia = new Lastbil("Scandia 5", 2005, "WQ18652");

            Bus Bus12 = new Bus("Bus 12", 1950, "AA11111");

            List<Køretøj> garage = new List<Køretøj>();

            garage.Add(audi);
            garage.Add(fordTransporter);
            garage.Add(autokamper);
            garage.Add(scandia);
            garage.Add(Bus12);

            Auktionshus au = new Auktionshus();

            Sælger Simon = new Sælger();
            Simon.Handlende = new Privat(183101, 123123123123);
            Simon.Postnummer = 5000;

            Sælger Sørensen = new Sælger();
            Sørensen.Postnummer = 8000;
            Sørensen.Handlende = new Firma(1231, 122131231251);
            


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
            au.SætTilSalg(garage[4], Simon, 10000);



            // demo søg 1
            //SøgningsTest(au,au.SøgNavn("audi"));

            // demo søg 2
            //SøgningsTest(au, au.SøgTransportMuligheder(10));

            // demo søg 3
            //SøgningsTest(au, au.SøgStortKørekort(2000));

            // demo søg 4
            //SøgningsTest(au, au.SøgKørtPris(1000000, 50000));
            // demo søg 5
            //SøgningsTest(au, au.SøgPostnummer(6000, 2000));

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
        }
    }
}
