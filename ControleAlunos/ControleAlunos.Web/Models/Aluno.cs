using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ControleAlunos.Web.Models
{
    public class Aluno : Pessoa
    {
        public int Id { get; set; }

        [Display(Name = "Matricula")]
        [Required(ErrorMessage = "Informe o número da matricula")]
        public int matricula { get; set; }

        [Display(Name = "Data Nascimento")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [Required(ErrorMessage = "Informe a data de nascimento")]
        public DateTime dataNascimento { get; set; }

        [Display(Name = "Data Cadastro")]        
        public DateTime? dataCadastro { get; set; }

        [Display(Name = "Enredeço")]
        [Required(ErrorMessage = "Informe o endereço")]
        public string endereco { get; set; }

        [Display(Name = "Sexo")]
        public string sexo { get; set; }

        [Display(Name = "Idade")]
        [Required(ErrorMessage = "Informe a idade")]
        public int idade { get; set; }

        public DateTime? dataAlteracao { get; set; }

        public string usuarioAlteracao { get; set; }

        [NotMapped]
        [Display(Name = "Nome")]
        public string nomePai { get; set; }

        [NotMapped]
        [Display(Name = "Nome")]
        //[Required(ErrorMessage = "Informe o nome da mãe")]
        public string nomeMae { get; set; }

        [NotMapped]
        [Display(Name = "RG")]
        //[Required(ErrorMessage = "Informe o RG do pai")]
        public string rgPai { get; set; }

        [NotMapped]
        [Display(Name = "RG")]
        //[Required(ErrorMessage = "Informe o RG da mãe")]
        public string rgMae { get; set; }

        [NotMapped]
        [Display(Name = "CPF")]
        //[Required(ErrorMessage = "Informe o CPF do pai")]
        public string cpfPai { get; set; }

        [NotMapped]
        [Display(Name = "CPF")]
        //[Required(ErrorMessage = "Informe o CPF da mãe")]
        public string cpfMae { get; set; }

        [NotMapped]
        [Display(Name = "Profissão")]
        //[Required(ErrorMessage = "Informe a profissão do pai")]
        public string profissaoPai { get; set; }

        [NotMapped]
        [Display(Name = "Profissão")]
       // [Required(ErrorMessage = "Informe a profissão da mãe")]
        public string profissaoMae { get; set; }

        [NotMapped]
        [Display(Name = "Telefone")]
        //[Required(ErrorMessage = "Informe o telefone do pai")]
        public string telefonePai { get; set; }

        [NotMapped]
        [Display(Name = "Telefone")]
        //[Required(ErrorMessage = "Informe o telefone da mãe")]
        public string telefoneMae { get; set; }

        [NotMapped]
        [Display(Name = "E-mail")]
        //[Required(ErrorMessage = "Informe o e-mail do pai")]
        public string emailPai { get; set; }

        [NotMapped]
        [Display(Name = "E-mail")]
        //[Required(ErrorMessage = "Informe o e.mail da mãe")]
        public string emailMae { get; set; }

        [Display(Name = "Cidade")]
        //[Required(ErrorMessage = "Informe a cidade")]
        public int CidadeId { get; set; }

        public virtual Cidade Cidade { get; set; }

        public virtual ICollection<Pais> Pais { get; set; }
    }
}