﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Auktionshus
    {
        public decimal Profit { get; private set; }


        private Dictionary<int, SalgsObjekt> _tilSalg;
        private Dictionary<int, SalgsObjekt> _solgte;

        public IEnumerable<Køretøj> GetSolgteEnumerable() 
        {
            IEnumerable<Køretøj> Køretøjer = from keyValue in _solgte
                                            select keyValue.Value.Køretøj;

            return Køretøjer;
        }        
        
        public IEnumerable<Køretøj> Søg(Func<Køretøj, bool> pred)
        {

            IEnumerable<Køretøj> tempList = LavKøretøjsListe();

            return tempList.Where(pred);

        }

        private IEnumerable<Køretøj> LavKøretøjsListe()
        {
            return from keyValue in _tilSalg
                   select keyValue.Value.Køretøj;
        }

        public IEnumerable<Køretøj> SøgNavn(string navn)
        {
            navn = navn.ToLower();

            return Søg(k => k.Navn.ToLower().Contains(navn));
        }

        public IEnumerable<Køretøj> SøgTransportMuligheder(int MinSiddepladser)
        {
            IEnumerable<Køretøj> køretøjer = LavKøretøjsListe();

            return køretøjer.OfType<ITransportMuligheder>().
                Where(it => it.Siddepladser >= MinSiddepladser && it.HarToilet == true)
                .Cast<Køretøj>();
        }

        public IEnumerable<Køretøj> SøgStortKørekort(double maksVægt)
        {
            IEnumerable<Køretøj> køretøjer = LavKøretøjsListe();

            return køretøjer.Where(k => k.KørekortType == EnumKørekortType.C
                                        || k.KørekortType == EnumKørekortType.D
                                        || k.KørekortType == EnumKørekortType.CE
                                        || k.KørekortType == EnumKørekortType.DE)
                                        .OfType<IKøretøjDimensioner>().Where(ik => ik.Vægt < maksVægt)
                                        .Cast<Køretøj>();

        }

        public IEnumerable<Køretøj> SøgKørtPris(double maxKm, decimal maxPris)
        {
            IEnumerable<SalgsObjekt> salgsobjekter = from keyValue in _tilSalg
                                                     select keyValue.Value;

            IEnumerable<Køretøj> filterPris = salgsobjekter.Where(s =>
                s.MinPris < maxPris).Select(s => s.Køretøj);

            IEnumerable<PrivatPersonbil> filterKm = filterPris.OfType<PrivatPersonbil>().Where(p => p.Km < maxKm);



            return filterKm.Cast<Køretøj>();

        }

        public EnumEnergiklasse Gennemsnitlig()
        {
            IEnumerable<Køretøj> køretøjer = LavKøretøjsListe();
            decimal average = køretøjer.Average(k => (decimal)k.Energiklasse);

            return (EnumEnergiklasse)Math.Floor(average);
        }

        public IEnumerable<Køretøj> SøgPostnummer(int postnummer, int radius)
        {
            IEnumerable<SalgsObjekt> salgsobjekter = _tilSalg.Select(x => x.Value).
                Where(x => x.Sælger.Postnummer >= postnummer - radius && x.Sælger.Postnummer <= postnummer + radius);

            return from salgsobjekt in salgsobjekter
                   select salgsobjekt.Køretøj;
        }

        public Auktionshus()
        {
            _tilSalg = new Dictionary<int, SalgsObjekt>();
            _solgte = new Dictionary<int, SalgsObjekt>();
        }



        public int SætTilSalg(Køretøj k, Sælger s, decimal minPris)
        {
            return SætTilSalg(k, s, minPris, s.ModtagNotifikationOmBud);
        }

        public int SætTilSalg(Køretøj k, Sælger s, decimal minPris, EventHandler<KøbsdetaljerEventArgs> notifikationsMetode)
        {
            SalgsObjekt salgsObjekt = new SalgsObjekt(k, s, minPris);
            int auktionsnummer = salgsObjekt.Autktionsnummer;

            _tilSalg.Add(auktionsnummer, salgsObjekt);

            salgsObjekt.notifikationsMetode += notifikationsMetode;


            return auktionsnummer;
        }

        public bool ModtagBud(Køber køber, int auktionsNummer, decimal bud)
        {
            bool budGodkendt = false;
            SalgsObjekt salgsObjekt = HentSalgsObjekt(auktionsNummer);

            if (salgsObjekt != null)
            {
                decimal køberSaldo = køber.Handlende.Saldo;

                if (køberSaldo >= salgsObjekt.MinPris
                    && bud > salgsObjekt.HøjesteBud)
                {
                    salgsObjekt.HøjesteBud = bud;
                    salgsObjekt.VindendeKøber = køber;
                    salgsObjekt.Notificer(køber, bud, auktionsNummer);

                    budGodkendt = true;
                }
            }

            return budGodkendt;
        }

        public bool AccepterBud(Sælger sælger, int auktionsNummer)
        {
            bool budAccepteret = false;

            SalgsObjekt salgsObjekt = HentSalgsObjekt(auktionsNummer);

            if (salgsObjekt != null && salgsObjekt.Sælger == sælger)
            {
                decimal salær = UdregnSalær(salgsObjekt.HøjesteBud);

                salgsObjekt.VindendeKøber.Handlende.Saldo -= salgsObjekt.HøjesteBud; //TODO flyt ind i køber
                sælger.Handlende.Saldo += salgsObjekt.HøjesteBud - salær; //TODO flyt ind i sælger

                _tilSalg.Remove(auktionsNummer);
                _solgte.Add(auktionsNummer, salgsObjekt);

                Profit += salær;
                budAccepteret = true;

                Console.WriteLine("bud fra " + salgsObjekt.VindendeKøber + " med " + salgsObjekt.HøjesteBud);
            }

            return budAccepteret;
        }

        private class SalgsObjekt
        {
            private static int næsteAuktionsnummer;

            public Køretøj Køretøj;
            public Sælger Sælger;
            public event EventHandler<KøbsdetaljerEventArgs> notifikationsMetode = delegate { };
            public decimal MinPris { get; private set; }
            public int Autktionsnummer { get; private set; }
            public decimal HøjesteBud { get; set; }
            public Køber VindendeKøber { get; set; }



            public SalgsObjekt(Køretøj køretøj, Sælger s, decimal minPris)
            {
                Autktionsnummer = næsteAuktionsnummer;
                Køretøj = køretøj;
                Sælger = s;
                MinPris = minPris;
                næsteAuktionsnummer++;
            }

            public void Notificer(Køber køber, decimal bud, int auktionsNummer)
            {
                notifikationsMetode(this, new KøbsdetaljerEventArgs(køber, bud, auktionsNummer));
            }
        }

        private SalgsObjekt HentSalgsObjekt(int auktionsNummer)
        {
            SalgsObjekt salgsObjekt = null;

            try
            {
                salgsObjekt = _tilSalg[auktionsNummer];
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Kunne ikke finde auktionsnummer " + auktionsNummer);
            }

            return salgsObjekt;
        }

        private decimal UdregnSalær(decimal salgsPris)
        {
            decimal salær = 0;

            if (salgsPris < 10000) salær = 1900;
            else if (salgsPris < 50000) salær = 2250;
            else if (salgsPris < 100000) salær = 2550;
            else if (salgsPris < 150000) salær = 2850;
            else if (salgsPris < 200000) salær = 3400;
            else if (salgsPris < 300000) salær = 3700;
            else salær = 4400;

            return salær;
        }





    }
}
