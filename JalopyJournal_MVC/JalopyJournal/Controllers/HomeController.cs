using JalopyJournal.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Diagnostics;
using JalopyJournal.Models;

namespace JalopyJournal.Controllers
{
    public class HomeController : Controller
    {
        private JJContext db = new JJContext();

        public ActionResult Index()
        {
            var carList = from s in db.Car select s;

            //List<Car> carListItems = new List<Car>();
            List<Car> carListItems = carList.ToList<Car>();
            /*foreach (var car in carList)
            {
                carListItems.Add(new SelectListItem
                {
                    Text = car.Description,
                    Value = car.ID.ToString()
                });
            }*/
            ViewBag.CarList = carListItems;  
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Jalopy Journal is a car maintenance log by Stephen Sorrell copyright June 2020.";

            return View();
        }

        public ActionResult Seed()
        {
            ViewBag.Message = "Create initial data for testing";

            var JJSeedHelper = new JJSeedHelper(db);

            ViewBag.Message = "Running JJInitializer.Seed";
            Debug.WriteLine("Running JJInitializer.Seed");

            try
            {
                var carList = JJSeedHelper.AddCarData();
                JJSeedHelper.AddAirFilterData(carList);
                JJSeedHelper.AddFuelData(carList);
                JJSeedHelper.AddFuelAdditiveData(carList);
                JJSeedHelper.AddOilAdditiveData(carList);
                JJSeedHelper.AddOilPlusFilterData(carList);
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty,
                    "Seed Failed. " + ex.Message);
            }

            Debug.WriteLine("Finished JJInitializer.Seed");
            ViewBag.Message = ViewBag.Message + "\n\r" + "Finished JJInitializer.Seed";

            return View();
        }
    }
}