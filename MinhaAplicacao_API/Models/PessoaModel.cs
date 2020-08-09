using MinhaAplicacao.Dominio.Enums;
using System;

namespace MinhaAplicacao_API.Models
{
    public class PessoaModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public Sexo Sexo { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; }
        public string CPF { get; set; }
    }
}
