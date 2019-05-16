using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calc.Models.Classes
{
    public class TipoDespesa
    {
        public int Id { get; set; }

        [Display(Name = "Nome")]
        public string Nome { get; set; }

        public string Caracteristica { get; set; }

        [Display(Name = "Situação")]
        
        public Boolean Situacao { get; set; }

        public virtual ICollection<Despesa> ListaDespesa { get; set; }

        //public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        //{
        //    var validator = new TipoDespesaValidator();
        //    var result = validator.Validate(this);
        //    return result.Errors.Select(erro => new ValidationResult(erro.ErrorMessage, new[] { erro.PropertyName }));
        //}
    }
}