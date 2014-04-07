using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eksamen2014
{
    public class Auktionshus
    {
        //private Dictionary<int, SalgsObjekt> _tilSalg;

        //public Auktionshus()
        //{
        //    _tilSalg = new Dictionary<int, SalgsObjekt>();
        //}

        

        //public int SætTilSalg(Køretøj k, Sælger s, decimal minPris) 
        //{
        //    SalgsObjekt salgsObjekt = new SalgsObjekt(k, s, minPris);
        //    int auktionsnummer = salgsObjekt.Autktionsnummer;

        //    _tilSalg.Add(auktionsnummer, salgsObjekt);

        //    // TODO notifikation
        //    salgsObjekt.notifikationsMetode = s.ModtagNotifikationOmBud;


        //    return auktionsnummer;
        //}

        //public int SætTilSalg(Køretøj k, Sælger s, decimal minPris, Action notifikationsMetode)
        //{
        //    return 0;
        //}

        //public bool ModtagBud(Køber køber, int auktionsNummer, decimal bud)
        //{
        //    bool budGodkendt = false;
        //    SalgsObjekt salgsObjekt;
        //    try
        //    {
        //        salgsObjekt = _tilSalg[auktionsNummer];

        //        double køberSaldo = køber.Handlende.Saldo;

        //        if(true)
        //        //if(køberSaldo >= salgsObjekt.MinPris
        //        //    && bud > salgsObjekt.HøjesteBud)
        //        {
        //            salgsObjekt.HøjesteBud = bud;
        //            salgsObjekt.VindendeKøber = køber;
        //            salgsObjekt.notifikationsMetode(this, new EventArgs()); // TODO
        //            budGodkendt = true;
        //        }

               
        //    }
        //    catch (KeyNotFoundException)
        //    {
        //        Console.WriteLine("Kunne ikke finde auktionsnummer " + auktionsNummer);
        //    }
            

            

        //    return budGodkendt;
        //}

        //public bool AccepterBud(Sælger sælger, int auktionsNummer)
        //{
        //    return true;
        //}

        //private class SalgsObjekt
        //{
        //    private static int næsteAuktionsnummer;

        //    Object Objekt ;
        //    Sælger Sælger;
        //    public EventHandler notifikationsMetode;
        //    public decimal MinPris { get; private set; }
        //    public int Autktionsnummer {get; private set;}
        //    public decimal HøjesteBud { get; set; }
        //    public Køber VindendeKøber { get; set; }

        //    public SalgsObjekt(Object o, Sælger s, decimal minPris)
        //    {
        //        Autktionsnummer = næsteAuktionsnummer;
        //        Objekt = o;
        //        Sælger = s;
        //        MinPris = minPris;

        //        næsteAuktionsnummer++;
        //    }
        //}

        //TODO søgefunktion

        //TODO gennemsnitlig energiklasse
    }
}
