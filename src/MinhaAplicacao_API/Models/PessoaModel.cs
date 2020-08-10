using MinhaAplicacao.Dominio.Enums;
using MinhaAplicacao_API.Common.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace MinhaAplicacao_API.Models
{
    public class PessoaModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(80, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 2)]
        public string Nome { get; set; }

        public Sexo Sexo { get; set; }

        public string Email { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

        public string Naturalidade { get; set; }

        public string Nacionalidade { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [StringLength(14, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 14)]
        [ValidacaoCPF(ErrorMessage = "Por favor entre com um documento válido")]
        public string CPF { get; set; }
    }
}
