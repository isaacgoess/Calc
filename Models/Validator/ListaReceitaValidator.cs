using Calc.Models.Classes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Calc.Models.Validator
{
    public class ListaReceitaValidator : AbstractValidator<ListaReceita>
    {
            //    CalcContext db = null;

        public ListaReceitaValidator()
        {
            // this.db = new CalcContext();
            RuleFor(tipoDespesa => tipoDespesa.Nome).MaximumLength(255).WithMessage("Máximo de 255 caracteres");
           // RuleFor(tipoDespesa => tipoDespesa.Nome).Must(UniqueName).WithMessage("Tipo de Categoria de Despesa Cadastrada");
        }

        //private bool UniqueName(String nome)
        //{
            //var result = this.db.ListaReceitas
            //                     .Where(x => x.Nome.ToLower() == nome.ToLower())
            //                     .Count();

            //return result == 0;
        //}

    }
}