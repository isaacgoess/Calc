using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calc.Models.Classes
{
    public class Extrato : IComparable<Extrato>
    {
        public int Tipo { get; set; }
        public float Valor { get; set; }
        public DateTime DataRealizacao { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Definicao { get; set; }
        public string Pagamento { get; set; }
        public Parcelamento Parcelamento { get; set; }
        public Receita SaldoReceita { get; set; }
        public Despesa SaldoDespesa { get; set; }


        public int CompareTo(Extrato other)
        {
            return this.DataRealizacao.CompareTo(other.DataRealizacao);
        }
    }
}