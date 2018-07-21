using System.Collections.Generic;
using MySql.Data.MySqlClient;
using HairSalon;
using System;

namespace HairSalon.Models
{
    public class Client
    {
        private string _clientName;
        private int _id;
        private int _stylistId;
        private int _phoneNumber;


        public Client(string clientName, int stylistId, int phoneNumber, int id = 0)
        {
            _clientName = clientName;
            _stylistId = stylistId;
            _id = id;
            _phoneNumber = phoneNumber;
        }

        public override bool Equals(System.Object otherClient)
        {
            if (!(otherClient is Client))
            {
                return false;
            }
            else
            {
                Client newClient = (Client)otherClient;
                bool idEquality = this.GetId() == newClient.GetId();
                bool clientNameEquality = this.GetClientName() == newClient.GetClientName();
                bool stylistEquality = this.GetStylistId() == newClient.GetStylistId();
                bool numberEquality = this.GetPhoneNumber() == newClient.GetPhoneNumber();
                return (idEquality && clientNameEquality && stylistEquality && numberEquality);
            }
        }
        public override int GetHashCode()
        {
            return this.GetClientName().GetHashCode();
        }

        public string GetClientName()
        {
            return _clientName;
        }
        public int GetId()
        {
            return _id;
        }
        public int GetStylistId()
        {
            return _stylistId;
        }

        public int GetPhoneNumber()
        {
            return _phoneNumber;
        }

        public void Save()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();

            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"INSERT INTO clients (client_name, stylist_id, phone_number) VALUES (@clientName, @stylistId, @phoneNumber);";


            cmd.Parameters.AddWithValue("@clientName", this._clientName);
            cmd.Parameters.AddWithValue("@stylistId", this._stylistId);
            cmd.Parameters.AddWithValue("@phoneNumber", this._phoneNumber);

            cmd.ExecuteNonQuery();
            _id = (int)cmd.LastInsertedId;
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public static List<Client> GetAll()
        {
            List<Client> allClients = new List<Client> { };
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients;";
            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            while (rdr.Read())
            {
                int clientId = rdr.GetInt32(0);
                string clientName = rdr.GetString(1);
                int stylistId = rdr.GetInt32(2);
                int phoneNumber = rdr.GetInt32(3);
                Client newClient = new Client(clientName, stylistId, phoneNumber, clientId);
                allClients.Add(newClient);
            }
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return allClients;
        }



        public static Client Find(int id)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"SELECT * FROM clients WHERE id = (@searchId);";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = id;
            cmd.Parameters.Add(searchId);

            var rdr = cmd.ExecuteReader() as MySqlDataReader;
            int clientId = 0;
            string clientName = "";
            int stylistId = 0; ;
            int phoneNumber = 0;

            while (rdr.Read())
            {
                clientId = rdr.GetInt32(0);
                clientName = rdr.GetString(1);
                stylistId = rdr.GetInt32(2);
                phoneNumber = rdr.GetInt32(3);
            }
            Client newClient = new Client(clientName, stylistId, clientId, phoneNumber);
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
            return newClient;
        }

        public void Edit(string newName, int newStylistId, int newPhoneNumber)
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"UPDATE recipes SET this.GetClientName() = @newName, this.SylistId = @newStylistId, this.GetPhoneNumber() = @newPhoneNumber WHERE id = @searchId;";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = _id;
            cmd.Parameters.Add(searchId);

            cmd.Parameters.AddWithValue("@newName", newName);
            cmd.Parameters.AddWithValue("@newStylistId", newStylistId);
            cmd.Parameters.AddWithValue("@newPhoneNumber", newPhoneNumber);

            cmd.ExecuteNonQuery();
            _clientName = newName;
            _stylistId = newStylistId;
            _phoneNumber = newPhoneNumber;

            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }


        //public static Client FindStylist(Client client)
        //{
        //    MySqlConnection conn = DB.Connection();
        //    conn.Open();
        //    var cmd = conn.CreateCommand() as MySqlCommand;
        //    cmd.CommandText = @"SELECT * FROM stylists WHERE id = (@searchId);";

        //    cmd.Parameters.AddWithValue("@searchId", client.GetStylistId());

        //    var rdr = cmd.ExecuteReader() as MySqlDataReader;
        //    int Id = 0;
        //    string Name = "";

        //    while (rdr.Read())
        //    {
        //        Id = rdr.GetInt32(0);
        //        Name = rdr.GetString(1);

        //    }
        //    Stylist newStylist = new Stylist(Name, Id);
        //    conn.Close();
        //    if (conn != null)
        //    {
        //        conn.Dispose();
        //    }
        //    return newStylist;
        //}

        public static void DeleteAll()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients;";
            cmd.ExecuteNonQuery();
            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }

        public void Delete()
        {
            MySqlConnection conn = DB.Connection();
            conn.Open();
            var cmd = conn.CreateCommand() as MySqlCommand;
            cmd.CommandText = @"DELETE FROM clients WHERE Id = @searchId";

            MySqlParameter searchId = new MySqlParameter();
            searchId.ParameterName = "@searchId";
            searchId.Value = _id;
            cmd.Parameters.Add(searchId);

            cmd.ExecuteNonQuery();


            conn.Close();
            if (conn != null)
            {
                conn.Dispose();
            }
        }


    }
}
