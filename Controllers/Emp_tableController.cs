using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Notification.Models;

namespace Notification.Controllers
{
    public class Emp_tableController : Controller
    {
        private EmployeeEntities1 db = new EmployeeEntities1();

        // GET: Emp_table
        public ActionResult Index()
        {
            return View(db.Emp_table.ToList());
        }

        // GET: Emp_table/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp_table emp_table = db.Emp_table.Find(id);
            if (emp_table == null)
            {
                return HttpNotFound();
            }
            return View(emp_table);
        }

        // GET: Emp_table/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Emp_table/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name,Address")] Emp_table emp_table)
        {
            if (ModelState.IsValid)
            {
                db.Emp_table.Add(emp_table);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(emp_table);
        }

        // GET: Emp_table/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp_table emp_table = db.Emp_table.Find(id);
            if (emp_table == null)
            {
                return HttpNotFound();
            }
            return View(emp_table);
        }

        // POST: Emp_table/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name,Address")] Emp_table emp_table)
        {
            if (ModelState.IsValid)
            {
                db.Entry(emp_table).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(emp_table);
        }

        // GET: Emp_table/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Emp_table emp_table = db.Emp_table.Find(id);
            if (emp_table == null)
            {
                return HttpNotFound();
            }
            return View(emp_table);
        }

        // POST: Emp_table/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Emp_table emp_table = db.Emp_table.Find(id);
            db.Emp_table.Remove(emp_table);
            db.SaveChanges();
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
