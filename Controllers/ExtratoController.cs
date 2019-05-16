using Calc.Models;
using Calc.Models.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Calc.Controllers
{
    public class ExtratoController : Controller
    {

        private CalcContext db = new CalcContext();


        public ActionResult Index(String buscarInicio, String buscarFim)
        {
            float totalDespesa = 0;
            float totalReceita = 0;
           // float totalSaldo = 0;
           // float SaldoPositivo = 0;
           // float SaldoNegativo = 0;
            Extrato item;
            var lista = new List<Extrato>();
            var despesas = db.Despesas.ToList();
            var receitas = db.Receitas.ToList();
            foreach (var obj in despesas && receitas)
            {
                for (int i = 1; i <= obj.NumParcelas; i++)
                {
                    item = new Extrato();
                    item.Valor = obj.Valor / obj.NumParcelas;
                    item.Tipo = 1;
                    item.Definicao = obj.Descricao + "/" + obj.TipoDespesa;
                    item.DataRealizacao = obj.DataRealizacao;
                    item.DataVencimento = obj.DataVencimentoParcela.AddMonths(i - 1);
                    item.Pagamento = i + "/" + obj.NumParcelas;

                    lista.Add(item);
                    if (item.DataVencimento.Month == DateTime.Today.Month)
                    {
                        totalDespesa += item.Valor;
                       // obj.SaldoDespesa = 0;
                        //SaldoNegativo = obj.SaldoDespesa;
                    }


                }
            }
            var receitas = db.Receitas.ToList();
            foreach (var obj in receitas)
            {
                for (int i = 1; i <= obj.NumeroParcelas; i++)
                {
                    item = new Extrato();
                    item.Valor = obj.Valor / obj.NumeroParcelas;
                    item.Tipo = 1;
                    item.Definicao = obj.TipoReceita + "/" + obj.Descricao;
                    item.DataRealizacao = obj.DataRecebimento;
                    item.DataVencimento = obj.PrimeiraDataVencimento.AddMonths(i - 1);
                    item.Pagamento = i + "/" + obj.NumeroParcelas;

                    lista.Add(item);
                    if (item.DataVencimento.Month == DateTime.Today.Month)
                    {
                        totalReceita += item.Valor;
                       // obj.SaldoReceita = 0;
                       // SaldoPositivo += obj.SaldoReceita;
                    }

                }
            }

            lista.Sort();

            if (!String.IsNullOrEmpty(buscarInicio) && !String.IsNullOrEmpty(buscarFim))
            {
                DateTime date1 = DateTime.Parse(buscarInicio);
                DateTime date2 = DateTime.Parse(buscarFim);
                ViewBag.Lista = lista.Where(x => x.DataRealizacao.CompareTo(date1) >= 0 && x.DataVencimento.CompareTo(date2) <= 0);
            }
            else
            {
                ViewBag.Lista = lista.Where(x => x.DataVencimento.Month == DateTime.Today.Month);
            }
            ViewBag.TotalDespesas = totalDespesa;
            ViewBag.TotalReceitas = totalReceita;
            ViewBag.TotalSaldo = totalReceita - totalDespesa;
            return View();

        }

    }
}


