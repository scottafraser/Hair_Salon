using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using HairSalon.Models;
using HairSalon.ViewModels;

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

            


            [HttpGet("/specialty/{id}/delete")]
            public ActionResult Delete(int id)
            {
                Specialty thisSpecialty = Specialty.Find(id);
                thisSpecialty.Delete();

                return RedirectToAction("Index");
            }

            [HttpGet("/specialty/new")]
            public ActionResult Create()
            {
                List<Stylist> allStylists = Stylist.GetAll();

                return View(allStylists);
            }

            [HttpPost("/specialty/new/add")]
            public ActionResult MakeSpecialty()
            {
                if (String.IsNullOrEmpty(Request.Form["select-stylist"]))
                {
                    return View("Error");
                }

                int id = int.Parse(Request.Form["select-stylist"]);
                Stylist thisStylist = Stylist.Find(id);

                string newName = Request.Form["specialty"];

                if (String.IsNullOrEmpty(newName))
                {
                    return View("Error");
                }
                Specialty newSpecialty = new Specialty(newName, 0);

                newSpecialty.Save();
                newSpecialty.AddStylist(thisStylist);

                return View("Success");
            }



            public IActionResult Error()
            {
                return View();
            }
        }


    }
