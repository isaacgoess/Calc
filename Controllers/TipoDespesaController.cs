using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Calc.Models;
using Calc.Models.Classes;

namespace Calc.Controllers
{
    public class TipoDespesaController : Controller
    {
        private CalcContext db = new CalcContext();

        // GET: TipoDespesa
        public ActionResult Index(String busca)
        {
            if (String.IsNullOrEmpty(busca))
            {
                return View(db.TipoDespesas.ToList());
                // return View(db.TipoDespesas.Where(tipo => tipo.Situacao == true));
            }

            var result = db.TipoDespesas.Where(tipo => tipo.Nome.ToLower().Contains(busca) && tipo.Situacao == true);
            return View(result.ToList());
        }

        // GET: TipoDespesa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDespesa tipoDespesa = db.TipoDespesas.Where(tipo => tipo.Situacao == true && tipo.Id == id).SingleOrDefault<TipoDespesa>();
            if (tipoDespesa == null)
            {
                return HttpNotFound();
            }
            return View(tipoDespesa);
        }

        // GET: TipoDespesa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TipoDespesa/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nome,Situacao")] TipoDespesa tipoDespesa)
        {
            if (ModelState.IsValid)
            {
                db.TipoDespesas.Add(tipoDespesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tipoDespesa);
        }

        // GET: TipoDespesa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDespesa tipoDespesa = db.TipoDespesas.Find(id);
            if (tipoDespesa == null)
            {
                return HttpNotFound();
            }
            return View(tipoDespesa);
        }

        // POST: TipoDespesa/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nome,Situacao")] TipoDespesa tipoDespesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tipoDespesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tipoDespesa);
        }

        // GET: TipoDespesa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoDespesa tipoDespesa = db.TipoDespesas.Find(id);
            if (tipoDespesa == null)
            {
                return HttpNotFound();
            }
            return View(tipoDespesa);
        }

        // POST: TipoDespesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TipoDespesa tipoDespesa = db.TipoDespesas.Find(id);
            tipoDespesa.Situacao = false;
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
