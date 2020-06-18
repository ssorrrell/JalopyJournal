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
using JalopyJournal.ViewModels;

namespace JalopyJournal.Controllers
{
    public class CarController : JJController
    {
        // GET: Car
        public async Task<ActionResult> Index(int? carID, string sortOrder)
        {
            var car = from s in db.Car
                            select s;
            if (carID != null && carID > 0)
                car = car.Where(d => d.ID == carID);

            var sortDirection = ControllerHelper.GetSortOrder(sortOrder);
            UpdateSortDirection(sortDirection);
            car = CarManager.AddSortToQuery(car, sortOrder);

            List<Car> carListItems = car.ToList<Car>();
            ViewBag.CarList = carListItems;

            return View(await car.ToListAsync());
        }

        // GET: Car/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Car.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // GET: Car/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Car/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Description")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Car.Add(car);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(car);
        }

        // GET: Car/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Car.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Car/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Description")] Car car)
        {
            if (ModelState.IsValid)
            {
                db.Entry(car).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(car);
        }

        // GET: Car/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Car car = await db.Car.FindAsync(id);
            if (car == null)
            {
                return HttpNotFound();
            }
            return View(car);
        }

        // POST: Car/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Car car = await db.Car.FindAsync(id);
            db.Car.Remove(car);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        //Car Select Functions
        public ActionResult CarSelector()
        {
            var carList = PopulateCarList();
            return View(carList);
        }

        // Private Functions
        private List<CarIndex> PopulateCarList()
        {   // Provide information for the check box array using the AssignedCourseData view model
            var allCars = db.Car;
            var viewModel = new List<CarIndex>();
            foreach (var carItem in allCars)
            {
                viewModel.Add(new CarIndex
                {
                    ID = carItem.ID,
                    Description = carItem.Description,
                });
            }
            return viewModel;
        }

        //Car Home Funtions
        public ActionResult CarHome(int? carID)
        {
            Car car = db.Car.Find(carID);
            if (car == null)
            {
                return HttpNotFound();
            }
            var viewModel = new CarIndex();
            viewModel.ID = car.ID;
            viewModel.Description = car.Description;
            return View(viewModel);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
