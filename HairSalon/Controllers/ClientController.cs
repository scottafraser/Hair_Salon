using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {

        [HttpGet("/client/list")]
        public ActionResult ClientList()
        {
            List<Client> allClients = new List<Client>();
            allClients = Client.GetAll();

            //this doesnt work yet
            if (allClients.Count == 0)
            {
                View("NoClients");
            }
            return View(allClients);
        }


        [HttpGet("/client/new")]
        public ActionResult AddClient()
        {
            List<Stylist> allStylists = new List<Stylist>();
            allStylists = Stylist.GetAll();

            return View(allStylists);
        }

        [HttpPost("/client/new/add")]
        public ActionResult Create()
        {
            int id = int.Parse(Request.Form["select-stylist"]);
          
            Stylist thisStylist = Stylist.Find(id);
            int thisId = thisStylist.GetId();

            string newName = Request.Form["client"];

            if (String.IsNullOrEmpty(newName))
            {
                return View("Error");
            }
            Client newClient = new Client(newName, thisId, 0);

            newClient.Save();

            return View("Success");
        }

        [HttpGet("/client/deleteall")]
        public ActionResult Delete()
        {
           
            Client.DeleteAll();

            return RedirectToAction("ClientList");
        }


    }


}
