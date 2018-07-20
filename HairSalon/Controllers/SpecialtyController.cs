using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;

namespace HairSalon.Controllers
{
    public class SpecialtyController : Controller
    {
        

            [HttpGet("/specialty/index")]
            public ActionResult Index()
            {
                List<Specialty> allSpecialties = new List<Specialty>();
                allSpecialties = Specialty.GetAll();

                return View(allSpecialties);
            }

            // [HttpGet("/specialty/{id}/about")]
            // public ActionResult About(int id)
            // {
            //     Specialty thisSpecialty = Specialty.Find(id);
            //     List<Client> clientList = new List<Client>();
            //     clientList = thisSpecialty.GetClients();
            //
            //     return View("Details", clientList);
            // }

            [HttpGet("/specialty/{id}/delete")]
            public ActionResult Delete(int id)
            {
                Specialty thisSpecialty = Specialty.Find(id);
                thisSpecialty.Delete();

                return RedirectToAction("SpecialtyList");
            }

            [HttpGet("/specialty/new")]
            public ActionResult AddSpecialty()
            {
                return View();
            }

            [HttpPost("/specialty/new/add")]
            public ActionResult create(string newName)
            {
                if (String.IsNullOrEmpty(newName))
                {
                    return View("Error");
                }
                Specialty newSpecialty = new Specialty(newName, 0);
                newSpecialty.Save();

                string name = newSpecialty.Name;

                return View("Success", name);
            }



            public IActionResult Error()
            {
                return View();
            }
        }


    }
