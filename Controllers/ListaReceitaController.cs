using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Calc.Models;
using Calc.Models.Classes;

namespace Calc.Controllers
{
    public class ListaReceitaController : Controller
    {
        private CalcContext db = new CalcContext();

        // GET: ListaReceita
        public ActionResult Index()
        {
            return View(db.ListaReceitas.ToList());
        }

        // GET: ListaReceita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaReceita listaReceita = db.ListaReceitas.Find(id);
            if (listaReceita == null)
            {
                return HttpNotFound();
            }
            return View(listaReceita);
        }

        // GET: ListaReceita/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ListaReceita/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome")] ListaReceita listaReceita)
        {
            if (ModelState.IsValid)
            {
                db.ListaReceitas.Add(listaReceita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listaReceita);
        }

        // GET: ListaReceita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaReceita listaReceita = db.ListaReceitas.Find(id);
            if (listaReceita == null)
            {
                return HttpNotFound();
            }
            return View(listaReceita);
        }

        // POST: ListaReceita/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome")] ListaReceita listaReceita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listaReceita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listaReceita);
        }

        // GET: ListaReceita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListaReceita listaReceita = db.ListaReceitas.Find(id);
            if (listaReceita == null)
            {
                return HttpNotFound();
            }
            return View(listaReceita);
        }

        // POST: ListaReceita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListaReceita listaReceita = db.ListaReceitas.Find(id);
            db.ListaReceitas.Remove(listaReceita);
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
