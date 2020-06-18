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
using Microsoft.Ajax.Utilities;

namespace JalopyJournal.Controllers
{
    public class AirFilterController : JJController
    {
        public async Task<ActionResult> Index(int? carID, string sortOrder)
        {
            var airFilter = from s in db.AirFilter select s;
            if (carID != null && carID > 0)
            {
                airFilter = airFilter.Where(d => d.CarID == carID);
                ViewBag.CarID = carID;
                UpdateCarDescription(carID);
            }
            
            var sortDirection = ControllerHelper.GetSortOrder(sortOrder);
            UpdateSortDirection(sortDirection);
            airFilter = AirFilterManager.AddSortToQuery(airFilter, sortOrder);

            return View(await airFilter.ToListAsync());
        }

        // GET: AirFilter/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirFilter airFilter = await db.AirFilter.FindAsync(id);
            if (airFilter == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (airFilter.CarID != null && airFilter.CarID > 0)
                {
                    ViewBag.CarID = airFilter.CarID;
                    UpdateCarDescription(airFilter.CarID);
                }
            }
            return View(airFilter);
        }

        // GET: AirFilter/Create
        public ActionResult Create(int? carID)
        {
            if (carID != null && carID > 0)
                ViewBag.CarID = carID;
            else
                PopulateCarDropDownList();
            UpdateCarDescription(carID);
            return View();
        }

        // POST: AirFilter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,FilterType,Miles,Date,Cost,Notes,CarID")] AirFilter airFilter)
        {
            if (ModelState.IsValid)
            {
                db.AirFilter.Add(airFilter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { CarID = airFilter.CarID });
            }

            if (airFilter.CarID > 0)
            {
                ViewBag.CarID = airFilter.CarID;
                UpdateCarDescription(airFilter.CarID);
            }
            return View(airFilter);
        }

        // GET: AirFilter/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirFilter airFilter = await db.AirFilter.FindAsync(id);
            if (airFilter == null)
            {
                return HttpNotFound();
            }
            if (airFilter.CarID > 0)
            {
                ViewBag.CarID = airFilter.CarID;
                UpdateCarDescription(airFilter.CarID);
                PopulateCarDropDownList(airFilter.CarID);
            }
            return View(airFilter);
        }

        // POST: AirFilter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,FilterType,Miles,Date,Cost,Notes,CarID")] AirFilter airFilter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(airFilter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { CarID = airFilter.CarID });
            }
            if (airFilter.CarID > 0)
            {
                ViewBag.CarID = airFilter.CarID;
                UpdateCarDescription(airFilter.CarID);
                PopulateCarDropDownList(airFilter.CarID);
            }
            return View(airFilter);
        }

        // GET: AirFilter/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AirFilter airFilter = await db.AirFilter.FindAsync(id);
            if (airFilter == null)
            {
                return HttpNotFound();
            }
            else if (airFilter.CarID > 0)
            {
                ViewBag.CarID = airFilter.CarID;
                UpdateCarDescription(airFilter.CarID);
            }
            return View(airFilter);
        }

        // POST: AirFilter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AirFilter airFilter = await db.AirFilter.FindAsync(id);
            if (airFilter.CarID > 0)
            {
                ViewBag.CarID = airFilter.CarID;
                UpdateCarDescription(airFilter.CarID);
            }
            db.AirFilter.Remove(airFilter);
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
