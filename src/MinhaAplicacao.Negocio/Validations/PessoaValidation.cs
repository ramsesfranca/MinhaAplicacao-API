using FluentValidation;
using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Services;

namespace MinhaAplicacao.Negocio.Validations
{
    public class PessoaValidation : AbstractValidator<Pessoa>
    {
        public PessoaValidation(IPessoaServico PessoaServico)
        {
            RuleFor(x => x).Custom((pessoa, contexto) =>
            {
                if (PessoaServico.Existe(u => u.CPF.Equals(pessoa.CPF) &&
                                              u.Id != pessoa.Id).Result)
                {
                    contexto.AddFailure("CPF", "Este campo já foi cadastrado");
                }
            });
        }
    }
}
