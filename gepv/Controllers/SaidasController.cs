using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using gepv.Models;
using Microsoft.AspNet.Identity;
using Rotativa;

namespace gepv.Controllers
{
    public class SaidasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Saidas
        [Authorize]
        public ActionResult Index()
        {
            return View(db.Saidas.ToList());
        }
        [Authorize]
        // GET: Saidas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saida saida = db.Saidas.Find(id);
            if (saida == null)
            {
                return HttpNotFound();
            }
            return View(saida);
        }

        // GET: Saidas/Create
        [Authorize]
        public ActionResult Create()
        {
            return View();
        }

        // POST: Saidas/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Quantidade,DataSaida")] Saida saida, int Cliente, int Produto)
        {
            saida.Cliente = db.Clientes.Find(Cliente);
            saida.Produto = db.Produtos.Find(Produto);
            saida.Usuario = db.Users.Find(User.Identity.GetUserId());
            saida.DataSaida = DateTime.Now;
            saida.Preco = db.Produtos.Find(Produto).Preco * saida.Quantidade;
            if (db.Produtos.Find(Produto).Quantidade < saida.Quantidade)
            {
                ViewBag.Erro = "A quantidade que pretende é maior que o disponível em stock";
                return View(saida);
            }
            else
            {
                if (ModelState.IsValid)
                {
                    db.Saidas.Add(saida);
                    db.Produtos.Find(Produto).Quantidade = -saida.Quantidade;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
            }
            return View(saida);
        }

        // GET: Saidas/Edit/5
        [Authorize]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saida saida = db.Saidas.Find(id);
            if (saida == null)
            {
                return HttpNotFound();
            }
            return View(saida);
        }

        // POST: Saidas/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Quantidade,DataSaida")] Saida saida)
        {
            if (ModelState.IsValid)
            {
                db.Entry(saida).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(saida);
        }

        // GET: Saidas/Delete/5
        [Authorize]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Saida saida = db.Saidas.Find(id);
            if (saida == null)
            {
                return HttpNotFound();
            }
            return View(saida);
        }

        // POST: Saidas/Delete/5
        [Authorize]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Saida saida = db.Saidas.Find(id);
            db.Saidas.Remove(saida);
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
     
        public ActionResult PrintInvoice(string data)
        {

            return new Rotativa.ActionAsPdf("Relatorios", new { data = data });
        } 
        public ActionResult Relatorios(string data) 
        {
            ViewBag.Data = data;
            
            return View(db.Saidas.ToList().Where(x=>x.DataSaida>DateTime.Parse(data)));
        }
    }
}
