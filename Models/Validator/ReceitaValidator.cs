using Calc.Models.Classes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Calc.Models.Validator
{
    public class ReceitaValidator : AbstractValidator<Receita>
    {
        public ReceitaValidator()
        {
            RuleFor(receita => receita.Valor).GreaterThan(0).WithMessage("Receita precisa ser maior que zero!");
            RuleFor(receita => receita.DataRecebimento).Must(ValidarData).WithMessage("Data inválida!.");
            RuleFor(receita => receita.PrimeiraDataVencimento).Must(ValidarData).WithMessage("Data inválida!.");
        }

        private bool ValidarValor(float valor)
        {
            return valor > 0;
        }

        private bool ValidarData(DateTime date)
        {
            string expressao = @"^(0[1-9]|[12][0-9]|3[01])[- /.](0[1-9]|1[012])[- /.](19|20)\d\d$";

            Regex rg = new Regex(expressao);
            return rg.IsMatch(date.ToString("dd/MM/yyyy"));
        }
    }

}