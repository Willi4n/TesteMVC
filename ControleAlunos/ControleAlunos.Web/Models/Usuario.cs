using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ControleAlunos.Web.Models
{
    public class Usuario : Pessoa
    {
        public int Id { get; set; }

        public DateTime dataCadastro { get; set; }

        [Display(Name = "Senha ")]
        [Required(ErrorMessage = "Informe a senha")]
        public string senha { get; set; }

        public DateTime? dataAlteracao { get; set; }

        public string usuarioAlteracao { get; set; }
    }
}