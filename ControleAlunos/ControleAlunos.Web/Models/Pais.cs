using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleAlunos.Web.Models
{
    public class Pais : Pessoa
    {
        public int Id { get; set; }

        public string filiacao { get; set; }

        public DateTime? dataCadastro { get; set; }

        public DateTime? dataAlteracao { get; set; }

        public string usuarioAlteracao { get; set; }

        public int AlunoId { get; set; }

        public virtual Aluno Aluno { get; set; }
    }
}