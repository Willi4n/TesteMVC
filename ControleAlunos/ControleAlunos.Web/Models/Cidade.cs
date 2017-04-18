using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ControleAlunos.Web.Models
{
    public class Cidade
    {
        public int Id { get; set; }

        public string nome { get; set; }

        public string estado { get; set; }

        public string cep { get; set; }

        public DateTime? dataCadastro { get; set; }

        public DateTime? dataAlteracao { get; set; }

        public string usuarioAlteracao { get; set; }

        public virtual ICollection<Aluno> Alunos { get; set; }
    }
}