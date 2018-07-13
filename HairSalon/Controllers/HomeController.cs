using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("/")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet("/stylist/list")]
        public ActionResult StylistList()
        {
            List<Stylist> allStylists = new List<Stylist>();
            allStylists = Stylist.GetAll();

            return View(allStylists);
        }


        public IActionResult Error()
        {
            return View();
        }
    }

   
}
