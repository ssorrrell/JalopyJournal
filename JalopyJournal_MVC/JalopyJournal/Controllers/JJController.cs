using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using JalopyJournal.DAL;
using JalopyJournal.Models;
using System.Diagnostics;
using System.Reflection;

namespace JalopyJournal.Controllers
{
    public class JJController : Controller
    {
        protected readonly JJContext db = new JJContext();

        protected void UpdateSortDirection(string sortDirection)
        {
            if (sortDirection == "asc")
                ViewBag.SortParm = "desc";
            else if (sortDirection == "desc")
                ViewBag.SortParm = "asc";
        }

        protected void PopulateCarDropDownList(object selectedCar = null)
        {
            var carQuery = from d in db.Car
                           orderby d.Description
                           select d;
            ViewBag.CarIDList = new SelectList(carQuery, "ID", "Description", selectedCar);
        }

        protected void UpdateCarDescription(int? carID)
        {
            if (carID != null)
            {
                var carQueryable = from s in db.Car.Where(d => d.ID == carID) select s;
                var car = carQueryable.First<Car>();
                ViewBag.CarDescription = car.Description;
            }
            else
            {
                ViewBag.CarDescription = null;
            }
        }

    }
}