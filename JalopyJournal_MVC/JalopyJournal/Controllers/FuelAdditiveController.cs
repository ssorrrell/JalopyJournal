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
    public class FuelAdditiveController : JJController
    {

        // GET: FuelAdditive
        public async Task<ActionResult> Index(int? carID, string sortOrder)
        {
            var fuelAdditive = from s in db.FuelAdditive.Include(f => f.Car)
                      select s;
            if (carID != null && carID > 0)
            {
                fuelAdditive = fuelAdditive.Where(d => d.CarID == carID);
                ViewBag.CarID = carID;
                UpdateCarDescription(carID);
            }

            var sortDirection = ControllerHelper.GetSortOrder(sortOrder);
            UpdateSortDirection(sortDirection);
            fuelAdditive = FuelAdditiveManager.AddSortToQuery(fuelAdditive, sortOrder);

            return View(await fuelAdditive.ToListAsync());
        }

        // GET: FuelAdditive/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelAdditive fuelAdditive = await db.FuelAdditive.FindAsync(id);
            if (fuelAdditive == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (fuelAdditive.CarID != null && fuelAdditive.CarID > 0)
                {
                    ViewBag.CarID = fuelAdditive.CarID;
                    UpdateCarDescription(fuelAdditive.CarID);
                }
            }
            return View(fuelAdditive);
        }

        // GET: FuelAdditive/Create
        public ActionResult Create(int? carID)
        {
            if (carID != null && carID > 0)
                ViewBag.CarID = carID;
            else
                PopulateCarDropDownList();
            UpdateCarDescription(carID);
            return View();
        }

        // POST: FuelAdditive/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,AdditiveType,Miles,Date,Cost,Notes,CarID")] FuelAdditive fuelAdditive)
        {
            if (ModelState.IsValid)
            {
                db.FuelAdditive.Add(fuelAdditive);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { CarID = fuelAdditive.CarID });
            }

            if (fuelAdditive.CarID > 0)
            {
                ViewBag.CarID = fuelAdditive.CarID;
                UpdateCarDescription(fuelAdditive.CarID);
            }
            return View(fuelAdditive);
        }

        // GET: FuelAdditive/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelAdditive fuelAdditive = await db.FuelAdditive.FindAsync(id);
            if (fuelAdditive == null)
            {
                return HttpNotFound();
            }
            if (fuelAdditive.CarID > 0)
            {
                ViewBag.CarID = fuelAdditive.CarID;
                UpdateCarDescription(fuelAdditive.CarID);
                PopulateCarDropDownList(fuelAdditive.CarID);
            }
            return View(fuelAdditive);
        }

        // POST: FuelAdditive/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,AdditiveType,Miles,Date,Cost,Notes,CarID")] FuelAdditive fuelAdditive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fuelAdditive).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { CarID = fuelAdditive.CarID });
            }
            if (fuelAdditive.CarID > 0)
            {
                ViewBag.CarID = fuelAdditive.CarID;
                UpdateCarDescription(fuelAdditive.CarID);
                PopulateCarDropDownList(fuelAdditive.CarID);
            }
            return View(fuelAdditive);
        }

        // GET: FuelAdditive/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FuelAdditive fuelAdditive = await db.FuelAdditive.FindAsync(id);
            if (fuelAdditive == null)
            {
                return HttpNotFound();
            }
            else if (fuelAdditive.CarID > 0)
            {
                ViewBag.CarID = fuelAdditive.CarID;
                UpdateCarDescription(fuelAdditive.CarID);
            }
            return View(fuelAdditive);
        }

        // POST: FuelAdditive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            FuelAdditive fuelAdditive = await db.FuelAdditive.FindAsync(id);
            if (fuelAdditive.CarID > 0)
            {
                ViewBag.CarID = fuelAdditive.CarID;
                UpdateCarDescription(fuelAdditive.CarID);
            }
            db.FuelAdditive.Remove(fuelAdditive);
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
