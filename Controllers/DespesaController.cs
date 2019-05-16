using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Calc.Models;
using Calc.Models.Classes;

namespace Calc.Controllers
{
    public class DespesaController : Controller
    {
        private CalcContext db = new CalcContext();

        // GET: Despesa
        public ActionResult Index()
        {
            var despesas = db.Despesas.Include(d => d.TipoDespesa);
            return View(despesas.ToList());
        }

        // GET: Despesa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesas.Find(id);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            return View(despesa);
        }

        // GET: Despesa/Create
        public ActionResult Create()
        {
            ViewBag.TipoDespesaId = new SelectList(db.TipoDespesas, "Id", "Nome");
            return View();
        }

        // POST: Despesa/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Descricao,Caracteristica,Situacao,Valor,TipoDespesaId,DataVencimentoParcela,DataRealizacao,NumParcelas")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                db.Despesas.Add(despesa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TipoDespesaId = new SelectList(db.TipoDespesas, "Id", "Nome", despesa.TipoDespesaId);
            return View(despesa);
        }

        // GET: Despesa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesas.Find(id);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            ViewBag.TipoDespesaId = new SelectList(db.TipoDespesas, "Id", "Nome", despesa.TipoDespesaId);
            return View(despesa);
        }

        // POST: Despesa/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Descricao,Caracteristica,Situacao,Valor,TipoDespesaId,DataVencimentoParcela,DataRealizacao,NumParcelas")] Despesa despesa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(despesa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TipoDespesaId = new SelectList(db.TipoDespesas, "Id", "Nome", despesa.TipoDespesaId);
            return View(despesa);
        }

        // GET: Despesa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despesa despesa = db.Despesas.Find(id);
            if (despesa == null)
            {
                return HttpNotFound();
            }
            return View(despesa);
        }

        // POST: Despesa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Despesa despesa = db.Despesas.Find(id);
            db.Despesas.Remove(despesa);
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
