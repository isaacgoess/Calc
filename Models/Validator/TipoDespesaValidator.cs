//using Calc.Models.Classes;
//using FluentValidation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace Calc.Models.Validator
//{
//    public class TipoDespesaValidator : AbstractValidator<TipoDespesa>
//    {
//        CalcContext db = null;

//        public TipoDespesaValidator()
//        {
//            this.db = new CalcContext();
//            RuleFor(tipoDespesa => tipoDespesa.Nome).MaximumLength(255).WithMessage("Máximo de 255 caracteres");
//            RuleFor(tipoDespesa => tipoDespesa.Nome).Must((tipo, nome) => { return UniqueName(tipo.Id, tipo.Nome); }).WithMessage("Tipo de Categoria de Despesa Cadastrada");
//        }

//        private bool ValidaEntrada(String nome)
//        {

//            return true;
//        }

//        private bool UniqueName(int id, String nome)
//        {

//            int count = 0;
//            string nomeTipo = String.Empty;
//            nome = nome.Trim().ToLower();
//            if (id == 0)
//            {
//               // Se ID = 0, inserção
//                count = this.db.TipoDespesas
//                                  .Where(x => x.Nome.Trim().ToLower() == nome && x.Situacao == true).Count();

//                return count == 0;
//            }
//            else if (!String.IsNullOrEmpty(nome))
//            {
//                // Atualização....
//                var result = this.db.TipoDespesas
//                                 .Where(x => x.Id != id && x.Nome.Trim().ToLower() == nome && x.Situacao == true)
//                                 .Select(x => new { nome = x.Nome });

//                count = result.Count();
//                // Se resultado = NULL, trocou para um nome que não existe => OK
//                // Se resultado igual a algum nome, há um TipoDespesa já cadastrado
//                nomeTipo = result.FirstOrDefault() == null ? String.Empty : result.FirstOrDefault().nome.Trim().ToLower();

//                return count == 0 || (count == 1 && !nomeTipo.Equals(nome));
//            }
//            else
//            {
//                // deletando... não precisa validar
//                return true;
//            }
//        }
//    }
//}