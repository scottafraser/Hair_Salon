using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using HairSalon.Models;

namespace HairSalon.ViewModels
{
    public class SalonData
    {
        public List<Client> AllClients { get; set; }
        public List<Stylist> AllStylists { get; set; }
        public List<Specialty> AllSpecialties { get; set; }

        public Client FoundClient { get; set; }
        public Stylist FoundStylist { get; set; }
        public Specialty FoundSpecialty { get; set; }

        public SalonData()
        {
            AllClients = Client.GetAll();
            AllSpecialties = Specialty.GetAll();
            AllStylists = Stylist.GetAll();
        }

        public void FindClient(int id)
        {
            FoundClient = Client.Find(id);
        }

        public void FindStylist(int id)
        {
            FoundStylist = Stylist.Find(id);
        }

        public void FindSpecialty(int id)
        {
            FoundSpecialty = Specialty.Find(id);
        }

    }
}