using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using HairSalon.ViewModels;

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

        [HttpGet("/stylist/{id}/stylistlist")]
        public ActionResult Specialties(int id)
        {
            Specialty thisSpecialty = Specialty.Find(id);
            List<Stylist> allStylists = thisSpecialty.GetStylists();

            return View("StylistList", allStylists);
        }

        [HttpGet("/stylist/{id}/update-form")]
        public ActionResult Update(int id)
        {
            
            Stylist thisStylist = Stylist.Find(id);

            return View(thisStylist);
        }

        [HttpPost("/stylist/{id}/update")]
        public ActionResult Update(string stylist, int id)
        {

            Stylist thisStylist = Stylist.Find(id);
            thisStylist.Edit(stylist);
            List<Stylist> allStylists = Stylist.GetAll();

            return View("StylistList", allStylists);
        }


        [HttpGet("/stylist/{id}/about")]
        public ActionResult About(int id)
        {
            Stylist thisStylist = Stylist.Find(id);
            List<Client> clientList = new List<Client>();
            clientList = thisStylist.GetClients();
            List<Specialty> thisSpec = thisStylist.GetSpecialties();

            SalonData newSalonData = new SalonData();
            newSalonData.FindStylist(id);
            newSalonData.AllClients = clientList;
            newSalonData.AllSpecialties = thisSpec;

            return View("Details", newSalonData);
        }

        [HttpGet("/stylist/deleteall")]
        public ActionResult Delete()
        {
            Stylist.DeleteAll();

            return RedirectToAction("StylistList");
        }


        [HttpGet("/stylist/{id}/delete")]
        public ActionResult Delete(int id)
        {
            Stylist thisStylist = Stylist.Find(id);
            thisStylist.Delete();

            return RedirectToAction("StylistList");
        }

        //[HttpGet("/stylist/{id}/delete-spec")]
        //public ActionResult Delete(int id)
        //{
        //    Stylist thisStylist = Stylist.Find(id);
        //    thisStylist.DeleteSpec();

        //    return RedirectToAction("StylistList");
        //}

        [HttpGet("/stylist/new")]
        public ActionResult AddStylist()
        {
         
            return View();
        }

        [HttpPost("/stylist/new/add")]
        public ActionResult create()
        {
            string newName = Request.Form["stylist"];

            if (String.IsNullOrEmpty(newName))
            {
                return View("Error");
            }

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
