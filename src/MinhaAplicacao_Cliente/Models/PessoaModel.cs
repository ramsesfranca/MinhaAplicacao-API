using MinhaAplicacao_Cliente.Common.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace MinhaAplicacao_Cliente.Models
{
    public class PessoaModel : ModelBase<int>
    {
        [Display(Name = "Nome")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(80, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        [Display(Name = "Sexo")]
        public Sexo Sexo { get; set; }

        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Display(Name = "Data Nascimento")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        [Display(Name = "Naturalidade")]
        public string Naturalidade { get; set; }

        [Display(Name = "Nacionalidade")]
        public string Nacionalidade { get; set; }

        [Display(Name = "CPF")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 14)]
        [ValidacaoCPF(ErrorMessage = "Por favor entre com um documento válido")]
        public string CPF { get; set; }
    }

    public enum Sexo
    {
        Masculino = 1,
        Feminino = 2
    }
}
