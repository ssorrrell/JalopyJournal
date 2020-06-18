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
    public class OilAdditiveController : JJController
    {
        // GET: OilAdditive
        public async Task<ActionResult> Index(int? carID, string sortOrder)
        {
            var oilAdditive = from s in db.OilAdditive.Include(a => a.Car)
                       select s;
            if (carID != null && carID > 0)
            {
                oilAdditive = oilAdditive.Where(d => d.CarID == carID);
                ViewBag.CarID = carID;
                UpdateCarDescription(carID);
            }

            var sortDirection = ControllerHelper.GetSortOrder(sortOrder);
            base.UpdateSortDirection(sortDirection);
            oilAdditive = OilAdditiveManager.AddSortToQuery(oilAdditive, sortOrder);

            return View(await oilAdditive.ToListAsync());
        }

        // GET: OilAdditive/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilAdditive oilAdditive = await db.OilAdditive.FindAsync(id);
            if (oilAdditive == null)
            {
                return HttpNotFound();
            }
            else
            {
                if (oilAdditive.CarID != null && oilAdditive.CarID > 0)
                {
                    ViewBag.CarID = oilAdditive.CarID;
                    UpdateCarDescription(oilAdditive.CarID);
                }
            }
            return View(oilAdditive);
        }

        // GET: OilAdditive/Create
        public ActionResult Create(int? carID)
        {
            if (carID != null && carID > 0)
                ViewBag.CarID = carID;
            else
                PopulateCarDropDownList();
            UpdateCarDescription(carID);
            return View();
        }

        // POST: OilAdditive/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,AdditiveType,Miles,Date,Cost,Notes,CarID")] OilAdditive oilAdditive)
        {
            if (ModelState.IsValid)
            {
                db.OilAdditive.Add(oilAdditive);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { CarID = oilAdditive.CarID });
            }

            if (oilAdditive.CarID > 0)
            {
                ViewBag.CarID = oilAdditive.CarID;
                UpdateCarDescription(oilAdditive.CarID);
            }
            else
            {
                PopulateCarDropDownList();
            }
            return View(oilAdditive);
        }

        // GET: OilAdditive/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilAdditive oilAdditive = await db.OilAdditive.FindAsync(id);
            if (oilAdditive == null)
            {
                return HttpNotFound();
            }
            if (oilAdditive.CarID > 0)
            {
                ViewBag.CarID = oilAdditive.CarID;
                UpdateCarDescription(oilAdditive.CarID);
                PopulateCarDropDownList(oilAdditive.CarID);
            }
            return View(oilAdditive);
        }

        // POST: OilAdditive/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,AdditiveType,Miles,Date,Cost,Notes,CarID")] OilAdditive oilAdditive)
        {
            if (ModelState.IsValid)
            {
                db.Entry(oilAdditive).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index", new { CarID = oilAdditive.CarID });
            }
            if (oilAdditive.CarID > 0)
            {
                ViewBag.CarID = oilAdditive.CarID;
                UpdateCarDescription(oilAdditive.CarID);
                PopulateCarDropDownList(oilAdditive.CarID);
            }
            return View(oilAdditive);
        }

        // GET: OilAdditive/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null || id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilAdditive oilAdditive = await db.OilAdditive.FindAsync(id);
            if (oilAdditive == null)
            {
                return HttpNotFound();
            }
            else if (oilAdditive.CarID > 0)
            {
                ViewBag.CarID = oilAdditive.CarID;
                UpdateCarDescription(oilAdditive.CarID);
            }
            return View(oilAdditive);
        }

        // POST: OilAdditive/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            if (id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            OilAdditive oilAdditive = await db.OilAdditive.FindAsync(id);
            if (oilAdditive.CarID > 0)
            {
                ViewBag.CarID = oilAdditive.CarID;
                UpdateCarDescription(oilAdditive.CarID);
            }
            db.OilAdditive.Remove(oilAdditive);
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
