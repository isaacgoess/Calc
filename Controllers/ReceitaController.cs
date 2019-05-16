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
    public class ReceitaController : Controller
    {
        private CalcContext db = new CalcContext();

        // GET: Receita
        public ActionResult Index(String buscar, String buscarIni, String buscarFim)
        {
            DateTime date1, date2;

            if (String.IsNullOrEmpty(buscarIni) && String.IsNullOrEmpty(buscar) && String.IsNullOrEmpty(buscarFim))
            {
                return View(db.Receitas.ToList());
            }
            if (String.IsNullOrEmpty(buscarIni))
            {
                date1 = new DateTime(0001, 01, 01);
            }
            else
            {
                date1 = DateTime.Parse(buscarIni);
            }
            if (String.IsNullOrEmpty(buscarFim))
            {
                date2 = DateTime.Today;
            }
            else
            {
                date2 = DateTime.Parse(buscarFim);
            }

            var result = db.Receitas.Where(x => x.DataRecebimento.CompareTo(date1) >= 0 && x.DataRecebimento.CompareTo(date2) < 0 && x.TipoReceita.ToString().ToLower().Contains(buscar));

            return View(result.ToList());
        }

        // GET: Receita/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receitas.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // GET: Receita/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Receita/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TipoReceita,FormaRecebimento,DataRecebimento,Valor,Parcelamento,NumeroParcelas,PrimeiraDataVencimento,Descricao,Observacao")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                db.Receitas.Add(receita);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(receita);
        }

        // GET: Receita/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receitas.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // POST: Receita/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TipoReceita,FormaRecebimento,DataRecebimento,Valor,Parcelamento,NumeroParcelas,PrimeiraDataVencimento,Descricao,Observacao")] Receita receita)
        {
            if (ModelState.IsValid)
            {
                db.Entry(receita).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(receita);
        }

        // GET: Receita/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Receita receita = db.Receitas.Find(id);
            if (receita == null)
            {
                return HttpNotFound();
            }
            return View(receita);
        }

        // POST: Receita/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Receita receita = db.Receitas.Find(id);
            db.Receitas.Remove(receita);
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
