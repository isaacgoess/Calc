using FluentValidation;
using System;
using System.Text.RegularExpressions;

namespace Calc.Models.Classes
{
    public class DespesaValidator : AbstractValidator<Despesa>
    {
      //  PlaninhaFinanceiraContext db = null;


        public DespesaValidator()
        {
         //   this.db = new PlaninhaFinanceiraContext();
            RuleFor(despesa => despesa.Descricao).NotEmpty().WithName("Descrição Obrigatória!");
            RuleFor(despesa => despesa.Valor).GreaterThan(0).WithName("Despesa precisa ser maior que zero!");
           // RuleFor(despesa => despesa.TipoDespesaId).Must(ExistsTipoDespesa).WithMessage("Tipo de Despesa Inexistente!");
            RuleFor(despesa => despesa.DataVencimentoParcela).Must(DataValida).WithMessage("Data inválida!");
        }

        private bool DataValida(DateTime data)
        {
            string expressao = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$";

            Regex rg = new Regex(expressao);
            return rg.IsMatch(data.ToString("dd/MM/yyyy"));
        }

        //private bool ExistsTipoDespesa(int TipoDespesaId)
        //{
        //    var result = this.db.TipoDespesas
        //                     .Where(x => x.Id == TipoDespesaId)
        //                     .Count();
        //    return result == 1;
        //}


    }
}