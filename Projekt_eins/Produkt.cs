using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt_eins
{
    public class Produkt
    {
        public int id;
        public int artikelnummer;
        public string produktname;
        public string beschreibung;
        public int anzahl;
        public double preis;

        public Produkt() { }
        
        public Produkt(int artikelnummer, string produktname, string beschreibung, int anzahl, double preis)
        {
         
            this.artikelnummer = artikelnummer;
            this.produktname = produktname;
            this.beschreibung = beschreibung;
            this.anzahl = anzahl;
            this.preis = preis;
        }
        public Produkt(int id,int artikelnummer, string produktname, string beschreibung, int anzahl, double preis)
        {
            this.id = id;
            this.artikelnummer = artikelnummer;
            this.produktname = produktname;
            this.beschreibung = beschreibung;
            this.anzahl = anzahl;
            this.preis = preis;
        }



    }
}
