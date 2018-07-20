using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;

namespace HairSalon.Models
{
    public class Specialty
    {
        public string Name { get; set; }
        public int Id { get; set; }

        public Specialty(string name, int id = 0)
        {
            Name = name;
            Id = id;
        }
        public override bool Equals(System.Object otherSpecialty)
        {
            if (!(otherSpecialty is Specialty))
            {
                return false;
            }
            else
            {
                Specialty newSpecialty = (Specialty)otherSpecialty;
                bool NameEquality = Name == newSpecialty.Name;
                bool IdEquality = Id == newSpecialty.Id;
                return (IdEquality && NameEquality);
            }
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO specialties (name) VALUES (@Name);";

            cmd.Parameters.AddWithValue("@Name", this.Name);

            cmd.ExecuteNonQuery();
            Id = (int)cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

        }

        public void AddStylist(Stylist newStylist)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO stylists_specialties(stylist_id, specialty_id) VALUES (@Id, @stylistId);";
                     
            cmd.Parameters.AddWithValue("@Id", this.Id);
            cmd.Parameters.AddWithValue("@stylistId", newStylist.GetId());

            cmd.ExecuteNonQuery();
            Id = (int)cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }

        }
        public static List<Specialty> GetAll()
        {
            List<Specialty> allSpecialties = new List<Specialty> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int SpecialtyId = rdr.GetInt32(0);
                string SpecialtyName = rdr.GetString(1);
                Specialty newSpecialty = new Specialty(SpecialtyName, SpecialtyId);
                allSpecialties.Add(newSpecialty);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allSpecialties;
        }
        public static Specialty Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM specialties WHERE id = (@searchId);";

            cmd.Parameters.AddWithValue("@searchId", id);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int SpecialtyId = 0;
            string SpecialtyName = "";

            while (rdr.Read())
            {
                SpecialtyId = rdr.GetInt32(0);
                SpecialtyName = rdr.GetString(1);
            }
            Specialty newSpecialty = new Specialty(SpecialtyName, SpecialtyId);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newSpecialty;
        }

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public List<Stylist> GetStylists()
        {
            List<Stylist> allStylistWithSpec = new List<Stylist> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT stylists.* FROM specialties
                JOIN stylists_specialties ON (specialties.id = stylists_specialties.specialty_id)
                JOIN stylists ON (stylists_specialties.stylist_id = stylists.id)
                WHERE specialties.id = @specialtyId;";

            cmd.Parameters.AddWithValue("@specialtyId", this.Id);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int id = rdr.GetInt32(0);
                string name = rdr.GetString(1);

                Stylist newStylist = new Stylist(name, id);
                allStylistWithSpec.Add(newStylist);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allStylistWithSpec;
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM specialties WHERE Id = @searchId; DELETE FROM stylists WHERE stylist_id = @searchId;";

            cmd.Parameters.AddWithValue("@searchId", this.Id);

            cmd.ExecuteNonQuery();


            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

    }
}