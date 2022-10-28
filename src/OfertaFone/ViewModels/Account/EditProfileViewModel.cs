﻿using Microsoft.AspNetCore.Mvc.Rendering;
using OfertaFone.WebUI.Tipo;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OfertaFone.WebUI.ViewModels.Account
{
    public class EditProfileViewModel : IValidatableObject
    {
        [Required]
        public string Login { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public bool Enabled { get; set; }

        public List<SelectListItem> Perfis { get; set; }

        [Required]
        public int? PerfilUsuarioId { get; set; }

        public TipoPessoa TipoPessoas { get; set; }

        [Required]
        public string CpfCnpj { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Image { get; set; }

        [Required]
        public DateTime? DataNascimento { get; set; }

        public EditProfileViewModel()
        {
            Perfis = new List<SelectListItem>();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var results = new List<ValidationResult>();
            return results;
        }
    }
}
