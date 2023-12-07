using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Projekt_eins
{
    public class Haubtmenu
    {


        public static void haubtmenu_1()
        {

            Console.WriteLine("Bitte Wählen Sie!!");
            Console.WriteLine("[1] Produkt:");
            Console.WriteLine("[2] Einstellung:");
            Console.WriteLine("[3] Enden:");
            Console.Write("Ihre Eintage: ");
            string eingabe = Console.ReadLine();
            switch (eingabe)
            {
                case "1":
                    Produkt();

                    break;
                case "2":
                    Einstelllung_maneu();
                    break;
                case "3":
                    Environment.Exit(0);
                    break;
            }
        }

        public static void Produkt()
        {


            Console.WriteLine("Was möchten sie machen!!");

            Console.WriteLine("[1] Produkt Anlegen:");

            Console.WriteLine("[2] Produkt Lesen:");

            Console.WriteLine("[3] Produkt Aktuliesieren:");

            Console.WriteLine("[4] Produkt Löschen:");

            Console.WriteLine("[5] Zurück zum Hauntmenu:");

            string eingabe_P = Console.ReadLine();
            switch (eingabe_P)
            {
                case "1":
                    Produkt_Anlegen();

                    break;

                case "2":
                    DB_Produkte.Produkt_Lesen();

                    break;
                case "3":
                    Produkt_Aktuliesierenn();
                    break;
                case "4":
                    Produkt_Loschen();
                    break;
                case "5":
                    haubtmenu_1();
                    break;
                default:
                    Console.WriteLine("Falsche eingabe");

                    break;
            }

        }
        public static void Produkt_Anlegen()
        {

            Console.Write("ProduktNummer bitte eingeben: ");
            int artikelnummer = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("ProduktName bitte eingeben:");
            string produktname = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("ProduktBeschreibung bitte eingeben:");
            string beschreibung = Console.ReadLine();

            Console.WriteLine();

            Console.WriteLine("Produkt Anzahl bitte eingeben:");
            int anzahl = int.Parse(Console.ReadLine());

            Console.WriteLine();

            Console.WriteLine("Produkt Preis bitte eingeben:");
            double preis = Convert.ToDouble(Console.ReadLine());


            Produkt neuerProdukte = new Produkt(artikelnummer, produktname, beschreibung, anzahl, preis);

            DB_Produkte.Einfugen(neuerProdukte);
        }




        public static void Produkt_Loschen()
        {

            Console.WriteLine("Geben sie bitte die Artikel ID die Sie Löschen Möchten: ");
            int id = int.Parse(Console.ReadLine());

            DB_Produkte.Loschen(id);

        }


        public static void Produkt_Aktuliesierenn()
        {
            DB_Produkte.Produkt_Lesen();

            // user frage welche ID er update soll

            Console.WriteLine("Geben sie bitte die Artikel ID die Sie Updaten Möchten: ");

            int eingabe = Convert.ToInt32(Console.ReadLine());

            Produkt produkt = DB_Produkte.GetProduktByID(eingabe);

            if (produkt == null)
            {

                Console.WriteLine("So eine ID gibt es nicht");
                Produkt_Aktuliesierenn();
            }
            else { 
                Console.WriteLine("Produkt gefunden");

                Console.WriteLine("Artikelnummer Aktualieseiren: J/n");
                string anwort = Console.ReadLine();
                if (anwort == "J" || anwort == "j") 
                {
                    Console.WriteLine("Geben sie die artikelnummer ein:  ");
                    int artikelnummer = Convert.ToInt32(Console.ReadLine());
                    produkt.artikelnummer = artikelnummer;

                }

                Console.WriteLine("Produktname Aktualieseiren: J/n");
                anwort = Console.ReadLine();
                if (anwort == "J" || anwort == "j")
                {
                    Console.WriteLine("Geben sie die artikelname ein:  ");
                    string produktname = Console.ReadLine();
                    produkt.produktname = produktname;

                }

                Console.WriteLine("Produkt Beschreibung Aktualieseiren: J/n");
                anwort= Console.ReadLine();
                if (anwort == "J" || anwort == "j")
                {
                    Console.WriteLine("Geben sie die artikelname ein:  ");
                    string beschreibung = Console.ReadLine();
                    produkt.beschreibung = beschreibung;

                }

                Console.WriteLine("Produkt Anzahl Aktualieseiren: J/n");
                anwort= Console.ReadLine();
                
                if (anwort == "J" || anwort == "j")
                {
                    Console.WriteLine("Geben sie die anzahl ein:  ");
                    int anzahl = Convert.ToInt32(Console.ReadLine());
                    produkt.anzahl = anzahl;

                }

                Console.WriteLine("Produkt Preis Aktualieseiren: J/n");
                anwort= Console.ReadLine();
                if (anwort == "J" || anwort == "j")
                {
                    Console.WriteLine("Geben sie die artikelnummer ein:  ");
                    double preis = Convert.ToDouble(Console.ReadLine());
                    produkt.preis = preis;

                }
                DB_Produkte.Update(produkt);
            }
          
          


        }

        //UPDATE `prodkute` SET `id`='[value-1]',`artikelnummer`='[value-2]',`produktname`='[value-3]'
        //    ,`beschreibung`='[value-4]',`anzahl`='[value-5]',`preis`='[value-6]' WHERE 1


        public static void Einstelllung_maneu()
        {

            Console.WriteLine("Was möchten sie machen!!");

            Console.WriteLine("[1] Dark Mode.");

            Console.WriteLine("[2] Sound aus.");

            Console.WriteLine("[3] Einstellung Anzeigen");
            Console.WriteLine("[4] zurück zum Haubtmane!");
            string eingabe_E = Console.ReadLine();
            switch (eingabe_E)
            {
                case "1":
                    Einstellung.ToggelDarkMode();
                    break;
                case "2":
                    Einstellung.ToggelDarkSound();
                    break;
                case "3":
                    Einstelllung_maneu();
                    break;
                case "4":
                    haubtmenu_1();
                    break;
            }



        }




    }
}