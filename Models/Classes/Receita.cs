using Calc.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calc.Models.Classes
{
    public class Receita  : IValidatableObject
    {
        public int ID { get; set; }

        [Display(Name = "Tipo de Receita")]
        public TipoReceita TipoReceita { get; set; }

        [Display(Name = "Forma de Recebimento")]
        public FormaRecebimento FormaRecebimento { get; set; }

        [Display(Name = "Data de Recebimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataRecebimento { get; set; }

        [DisplayFormat(DataFormatString = "{0:c2}", ApplyFormatInEditMode = true)]
        public float Valor { get; set; }

        public Parcelamento Parcelamento { get; set; }

        public int NumeroParcelas { get; set; }

        [Display(Name = "Primeiro Vencimento")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PrimeiraDataVencimento { get; set; }

        [Display(Name = "Descrição")]
        public String Descricao { get; set; }

        [Display(Name = "Observação")]
        public String Observacao { get; set; }

        public float SaldoReceita { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new ReceitaValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(erro => new ValidationResult(erro.ErrorMessage, new[] { erro.PropertyName }));
        }
    }

    public enum TipoReceita
    {
        Salario, Restituicao_IR, Indenizacao, Transferencia
    }

    public enum FormaRecebimento
    {
        Cheque, Dinheiro, Cartao
    }

    public enum Parcelamento
    {
        [Description("Única")]
        Unica,
        [Description("Parcelada")]
        Parcelado
    }
}


