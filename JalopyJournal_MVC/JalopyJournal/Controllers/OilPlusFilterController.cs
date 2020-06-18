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
    public class OilPlusFilterController : JJController
    {
        // GET: OilPlusFilter
        public async Task<ActionResult> Index(int? carID, string sortOrder)
        {
            var oilPlusFilter = from s in db.OilPlusFilter.Include(a => a.Car)
                              select s;
            if (carID != null && carID > 0)
            {
                oilPlusFilter = oilPlusFilter.Where(d => d.CarID == carID);
                ViewBag.CarID = carID;
                UpdateCarDescription(carID);
            }

            var sortDirection = ControllerHelper.GetSortOrder(sortOrder);
            base.UpdateSortDirection(sortDirection);
            oilPlusFilter = OilPlusFilterManager.AddSortToQuery(oilPlusFilter, sortOrder);

            return View(await oilPlusFilter.ToListAsync());
        }

        // GET: OilPlusFilter/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilPlusFilter oilPlusFilter = await db.OilPlusFilter.FindAsync(id);
            if (oilPlusFilter == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (oilPlusFilter.CarID != null && oilPlusFilter.CarID > 0)
                {
                    ViewBag.CarID = oilPlusFilter.CarID;
                    UpdateCarDescription(oilPlusFilter.CarID);
                }
            }
            return View(oilPlusFilter);
        }

        // GET: OilPlusFilter/Create
        public ActionResult Create(int? carID)
        {
            if (carID != null && carID > 0)
                ViewBag.CarID = carID;
            else
                PopulateCarDropDownList();
            UpdateCarDescription(carID);
            return View();
        }

        // POST: OilPlusFilter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,OilType,OilFilter,Miles,Date,Cost,Notes,CarID")] OilPlusFilter oilPlusFilter)
        {
            if (ModelState.IsValid)
            {
                db.OilPlusFilter.Add(oilPlusFilter);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { CarID = oilPlusFilter.CarID });
            }

            if (oilPlusFilter.CarID > 0)
            {
                ViewBag.CarID = oilPlusFilter.CarID;
                UpdateCarDescription(oilPlusFilter.CarID);
            }
            else
            {
                PopulateCarDropDownList();
            }
            return View(oilPlusFilter);
        }

        // GET: OilPlusFilter/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilPlusFilter oilPlusFilter = await db.OilPlusFilter.FindAsync(id);
            if (oilPlusFilter == null)
            {
                return HttpNotFound();
            }
            if (oilPlusFilter.CarID > 0)
            {
                ViewBag.CarID = oilPlusFilter.CarID;
                UpdateCarDescription(oilPlusFilter.CarID);
                PopulateCarDropDownList(oilPlusFilter.CarID);
            }
            return View(oilPlusFilter);
        }

        // POST: OilPlusFilter/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,OilType,OilFilter,Miles,Date,Cost,Notes,CarID")] OilPlusFilter oilPlusFilter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oilPlusFilter).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { CarID = oilPlusFilter.CarID });
            }
            if (oilPlusFilter.CarID > 0)
            {
                ViewBag.CarID = oilPlusFilter.CarID;
                UpdateCarDescription(oilPlusFilter.CarID);
                PopulateCarDropDownList(oilPlusFilter.CarID);
            }
            return View(oilPlusFilter);
        }

        // GET: OilPlusFilter/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilPlusFilter oilPlusFilter = await db.OilPlusFilter.FindAsync(id);
            if (oilPlusFilter == null)
            {
                return HttpNotFound();
            }
            else if (oilPlusFilter.CarID > 0)
            {
                ViewBag.CarID = oilPlusFilter.CarID;
                UpdateCarDescription(oilPlusFilter.CarID);
            }
            return View(oilPlusFilter);
        }

        // POST: OilPlusFilter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilPlusFilter oilPlusFilter = await db.OilPlusFilter.FindAsync(id);
            if (oilPlusFilter.CarID > 0)
            {
                ViewBag.CarID = oilPlusFilter.CarID;
                UpdateCarDescription(oilPlusFilter.CarID);
            }
            db.OilPlusFilter.Remove(oilPlusFilter);
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
