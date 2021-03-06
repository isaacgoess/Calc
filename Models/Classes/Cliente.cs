﻿using Calc.Models.Validator;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;



namespace Calc.Models.Classes
{
    public class Cliente : IValidatableObject
    {
        public int Id { get; set; }

        [Display(Name = "Nome de Usuário")]
        public String Nome { get; set; }

        [Display(Name = "Aniversário")]
        public DateTime DataAniversario { get; set; }

        [Display(Name = "E-mail")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Digite um email valido")]
        public String Email { get; set; }

        [Display(Name = "Confirmação do Email")]
        [EmailAddress]
        [System.ComponentModel.DataAnnotations.Compare("Email", ErrorMessage = "Os emails não se coincidem!")]
        public String ConfirmarEmail { get; set; }

        public String Senha { get; set; }

        [Display(Name = "Confirmação de Senha")]
        public String ConfirmarSenha { get; set; }



        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validator = new ClienteValidator();
            var result = validator.Validate(this);
            return result.Errors.Select(erro => new ValidationResult(erro.ErrorMessage, new[] { erro.PropertyName }));

        }
    }
}