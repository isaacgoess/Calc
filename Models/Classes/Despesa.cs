using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Calc.Models.Validator;
using System.Linq;
using System.Web;

namespace Calc.Models.Classes
{
    public class Despesa
    {
        public int Id { get; set; }

        [Display(Name = "Descrição")]
        public String Descricao { get; set; }
        [DefaultValue(0)]

        [Display(Name = "Característica:")]
        public CaracteristicaDespesa Caracteristica { get; set; }

        [Display(Name = "Situação:")]
        public Boolean Situacao { get; set; }

        [Display(Name = "Valor:")]
        public float Valor { get; set; }

        public int TipoDespesaId { get; set; }
        public TipoDespesa TipoDespesa { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataVencimentoParcela { get; set; }
        public DateTime DataRealizacao { get; set; }
        public int NumParcelas { get; set; }

        public float SaldoDespesa { get; set; }

        public enum CaracteristicaDespesa
        {
            Fixa = 0,
            Variavel = 1

        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new DespesaValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(erro => new ValidationResult(erro.ErrorMessage, new[] { erro.PropertyName }));
        }
    }
}