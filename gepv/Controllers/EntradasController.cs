using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gepv.Models;

namespace gepv.Controllers
{
    public class EntradasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Entradas
        public ActionResult Index()
        {
            return View(db.Entradas.ToList());
        }

        // GET: Entradas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View(entrada);
        }

        // GET: Entradas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Entradas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantidade,Datachegada")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entradas.Add(entrada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(entrada);
        }

        // GET: Entradas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View(entrada);
        }

        // POST: Entradas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantidade,Datachegada")] Entrada entrada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(entrada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(entrada);
        }

        // GET: Entradas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Entrada entrada = db.Entradas.Find(id);
            if (entrada == null)
            {
                return HttpNotFound();
            }
            return View(entrada);
        }

        // POST: Entradas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Entrada entrada = db.Entradas.Find(id);
            db.Entradas.Remove(entrada);
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
