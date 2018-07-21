using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using HairSalon.ViewModels;

namespace HairSalon.Controllers
{
    public class ClientController : Controller
    {

        [HttpGet("/client/list")]
        public ActionResult ClientList()
        {

            List<Client> allClients = new List<Client>();
            allClients = Client.GetAll();

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
        public ActionResult Create(string client, string phone)
        {
            if (String.IsNullOrEmpty(Request.Form["select-stylist"]))
            {
                return View("Error");
            }

            int id = int.Parse(Request.Form["select-stylist"]);   
            Stylist thisStylist = Stylist.Find(id);
            int thisId = thisStylist.GetId();

            //int phone = int.Parse(Request.Form["phone"]);

            if (String.IsNullOrEmpty(client))
            {
                return View("Error");
            }

            Client newClient = new Client(client, thisId, phone);

            newClient.Save();

            return View("Success");
        }

        [HttpGet("/client/{id}/details")]
        public ActionResult Details(int id)
        {
            Client thisClient = Client.Find(id);

            return View(thisClient);
        }

        [HttpGet("/client/{id}/update-form")]
        public ActionResult Update(int id)
        {
           
            Client thisClient = Client.Find(id);

            return View(thisClient);
        }

        [HttpPost("/client/{id}/update")]
        public ActionResult Update(string client, string phone, int id)
        {

            Client thisClient = Client.Find(id);

            thisClient.Edit(client, phone);

            return View("ClientList");
        }

        [HttpGet("/client/deleteall")]
        public ActionResult Delete()
        {
           
            Client.DeleteAll();

            return RedirectToAction("ClientList");
        }

        [HttpGet("/client/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Client thisClient = Client.Find(id);
            thisClient.Delete();

            return RedirectToAction("ClientList");
        }


    }


}
