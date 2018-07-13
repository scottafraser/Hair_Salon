using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class StylistController : Controller
    {

        [HttpGet("/stylist/list")]
        public ActionResult StylistList()
        {
            List<Stylist> allStylists = new List<Stylist>();
            allStylists = Stylist.GetAll();

            return View(allStylists);
        }

        [HttpGet("/stylist/{id}/about")]
        public ActionResult About(int id)
        {
            Stylist thisStylist = Stylist.Find(id);
            List<Client> clientList = new List<Client>();
            clientList = thisStylist.GetClients();

            return View("Details", clientList);
        }

        [HttpGet("/stylist/new")]
        public ActionResult AddStylist()
        {
         
            return View();
        }

        [HttpPost("/stylist/new/add")]
        public ActionResult create()
        {
            string newName = Request.Form["stylist"];
            Stylist newStylist = new Stylist(newName, 0);
            newStylist.Save();

            string name = newStylist.GetName();

            return View("Success", name);
        }



        public IActionResult Error()
        {
            return View();
        }
    }


}
