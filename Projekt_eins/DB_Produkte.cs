using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using MySqlConnector;

namespace Projekt_eins
{
    public class DB_Produkte
    {
        public static string connectionString = "Server=localhost; Database=c_sharp_datenbank; User=root; Password=;";
        public static MySqlConnection connection;

        public static void Verbinden()
        {
            try
            {
                connection = new MySqlConnection(connectionString);
                connection.Open();
                Console.WriteLine("Verbindung aufgebaut");
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }





        public static void Produkt_Lesen()
        {
            string query = "SELECT * FROM produkte;";

            MySqlCommand command = new MySqlCommand(query, connection);


            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                string id = reader["id"].ToString();
                string artikelnummer = reader["artikelnummer"].ToString();
                string produktname = reader["produktname"].ToString();
                string beschreibung = reader["beschreibung"].ToString();
                string anzahl = reader["anzahl"].ToString();
                string preis = reader["preis"].ToString();


                Console.WriteLine($"ID: {id}, " +
                    
                                    $"Artikelnummer: {artikelnummer}, " +
                                    $"Produktname: {produktname}, " +
                                    $"Beschreibung: {beschreibung} ," +
                                    $"Anzahl: {anzahl}, " +
                                    $"Preis: {preis}, ");
            }


            reader.Dispose();

        }



        public static void Einfugen(Produkt neuerProdukte)
        {
            string query = "INSERT INTO `produkte`(artikelnummer,produktname,beschreibung,anzahl,preis) " +
                "VALUES (@artikelnummer,@produktname,@beschreibung,@anzahl,@preis)";


            MySqlCommand command = new MySqlCommand(query, connection);

            command.Parameters.AddWithValue("@artikelnummer", neuerProdukte.artikelnummer);
            command.Parameters.AddWithValue("@produktname", neuerProdukte.produktname);
            command.Parameters.AddWithValue("@beschreibung", neuerProdukte.beschreibung);
            command.Parameters.AddWithValue("@anzahl", neuerProdukte.anzahl);
            command.Parameters.AddWithValue("@preis", neuerProdukte.preis);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Produkt wurde eingefügt");
            }
            else { Console.WriteLine("Fehler beim einfügen das Produkt."); }
        }



        public static void Loschen(int id)
        {

            string query = "DELETE FROM produkte WHERE id = @id;";

            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected > 0)
            {
                Console.WriteLine("Produkt wurde gelöscht");
            }
            else { Console.WriteLine("Fehler beim Löschen das Produkt."); };


        }



        public static void Update(Produkt produkt) 
        {
            string query = "UPDATE produkte SET artikelnummer=@artikelnummer,produktname=@produktname,beschreibung=@beschreibung," +
                "anzahl=@anzahl,preis=@preis WHERE id=@id;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", produkt.id);
            command.Parameters.AddWithValue("@artikelnummer", produkt.artikelnummer);
            command.Parameters.AddWithValue("@produktname", produkt.produktname);
            command.Parameters.AddWithValue("@beschreibung", produkt.beschreibung);
            command.Parameters.AddWithValue("@anzahl", produkt.anzahl);
            command.Parameters.AddWithValue("@preis", produkt.preis);

            int rowsAffected = command.ExecuteNonQuery();
            if (rowsAffected >0) { Console.WriteLine("gemacht"); }

        }

        public static Produkt GetProduktByID(int id) // hier soll mir eine produkt zurück schicken statt Void
        {


         

            string query = "SELECT * FROM produkte WHERE id=@id;";
            MySqlCommand command = new MySqlCommand(query, connection);
            command.Parameters.AddWithValue("@id", id);
            //hier kommt die code für die abfrage und dann ein produkt 

            MySqlDataReader reader = command.ExecuteReader();


            while (reader.Read())
            {
                int artikelid = Convert.ToInt32(reader["id"]);

                int artikelnummer = Convert.ToInt32(reader["artikelnummer"]);

                string produktname = reader["produktname"].ToString();

                string beschreibung = reader["beschreibung"].ToString();

                int anzahl = Convert.ToInt32(reader["anzahl"]);

                double preis = Convert.ToDouble(reader["preis"]);

                reader.Dispose();
                return new Produkt(artikelid, artikelnummer, produktname, beschreibung, anzahl, preis);
            }


            reader.Dispose();

            return null;
        }

    }


  
}
