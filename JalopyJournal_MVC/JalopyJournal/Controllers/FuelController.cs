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

namespace JalopyJournal.Controllers
{
    public class FuelController : JJController
    {
        // GET: AirFilter
        public async Task<ActionResult> Index(int? carID, string sortOrder)
        {
            var fuelQueryable = from s in db.Fuel.Include(a => a.Car)
                            select s;
            if (carID != null && carID > 0)
            {
                fuelQueryable = fuelQueryable.Where(d => d.CarID == carID);
                ViewBag.CarID = carID;
                UpdateCarDescription(carID);
            }

            var sortDirection = ControllerHelper.GetSortOrder(sortOrder);
            UpdateSortDirection(sortDirection);
            fuelQueryable = FuelManager.AddSortToQuery(fuelQueryable, sortOrder);

            return View(await fuelQueryable.ToListAsync());
        }

        // GET: Fuel/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuel fuel = await db.Fuel.FindAsync(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (fuel.CarID != null && fuel.CarID > 0)
                {
                    ViewBag.CarID = fuel.CarID;
                    UpdateCarDescription(fuel.CarID);
                }
            }
            return View(fuel);
        }

        // GET: Fuel/Create
        public ActionResult Create(int? carID)
        {
            if (carID != null && carID > 0)
                ViewBag.CarID = carID;
            else
                PopulateCarDropDownList();
            UpdateCarDescription(carID);
            return View();
        }

        // POST: Fuel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Quantity,FuelType,Miles,Date,Cost,Notes,CarID")] Fuel fuel)
        {
            if (ModelState.IsValid)
            {
                db.Fuel.Add(fuel);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { CarID = fuel.CarID });
            }

            if (fuel.CarID > 0)
            {
                ViewBag.CarID = fuel.CarID;
                UpdateCarDescription(fuel.CarID);
            }
            return View(fuel);
        }

        // GET: Fuel/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuel fuel = await db.Fuel.FindAsync(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            if (fuel.CarID > 0)
            {
                ViewBag.CarID = fuel.CarID;
                UpdateCarDescription(fuel.CarID);
                PopulateCarDropDownList(fuel.CarID);
            }
            return View(fuel);
        }

        // POST: Fuel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Quantity,FuelType,Miles,Date,Cost,Notes,CarID")] Fuel fuel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuel).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { CarID = fuel.CarID });
            }
            if (fuel.CarID > 0)
            {
                ViewBag.CarID = fuel.CarID;
                UpdateCarDescription(fuel.CarID);
                PopulateCarDropDownList(fuel.CarID);
            }
            return View(fuel);
        }

        // GET: Fuel/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Fuel fuel = await db.Fuel.FindAsync(id);
            if (fuel == null)
            {
                return HttpNotFound();
            }
            else if (fuel.CarID > 0)
            {
                ViewBag.CarID = fuel.CarID;
                UpdateCarDescription(fuel.CarID);
            }
            return View(fuel);
        }

        // POST: Fuel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Fuel fuel = await db.Fuel.FindAsync(id);
            if (fuel.CarID > 0)
            {
                ViewBag.CarID = fuel.CarID;
                UpdateCarDescription(fuel.CarID);
            }
            db.Fuel.Remove(fuel);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
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
