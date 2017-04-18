using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleAlunos.Web.Models
{
    public abstract class Pessoa
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "Informe um nome")]
        public string nome { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "Informe um e-mail")]
        public string cpf { get; set; }

        [Display(Name = "RG")]
        [Required(ErrorMessage = "Informe o numero do rg")]
        public string rg { get; set; }

        [Display(Name = "Telefone")]
        [Required(ErrorMessage = "Informe o telefone")]
        public string telefone { get; set; }

        [Display(Name = "E-mail")]
        [Required(ErrorMessage = "Informe um e-mail")]
        public string email { get; set; }
    }
}