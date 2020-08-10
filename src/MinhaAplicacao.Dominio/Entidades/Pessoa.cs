using MinhaAplicacao.Dominio.Enums;
using System;

namespace MinhaAplicacao.Dominio.Entidades
{
    public class Pessoa : EntidadeBase<int>
    {
        public string Nome { get; set; }
        public Sexo? Sexo { get; set; }
        public string Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Naturalidade { get; set; }
        public string Nacionalidade { get; set; }
        public string CPF { get; set; }
    }
}
