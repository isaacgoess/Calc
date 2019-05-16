using Calc.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Calc.Models.Classes
{
    public class ListaReceita : IValidatableObject
    {
        public int Id { get; set; }
        public String Nome { get; set; }

        IEnumerable<ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            var validator = new ListaReceitaValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(erro => new ValidationResult(erro.ErrorMessage, new[] { erro.PropertyName }));
        }
    }
}