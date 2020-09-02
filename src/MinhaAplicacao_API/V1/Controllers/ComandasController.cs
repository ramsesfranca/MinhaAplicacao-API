using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Services;
using MinhaAplicacao_API.Controllers;
using MinhaAplicacao_API.V1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAplicacao_API.V1.Controllers
{
    [ApiVersion("1.0")]
    public class ComandasController : MinhaAplicacaoController
    {
        private readonly IComandaServico _ComandaServico;
        private readonly IMapper _mapper;

        public ComandasController(IComandaServico ComandaServico, IMapper mapper)
        {
            this._ComandaServico = ComandaServico;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ComandaModel>>> ObterTodos()
        {
            return this.Ok(this._mapper.Map<List<ComandaModel>>(await this._ComandaServico.SelecionarTodos()));
        }

        [HttpPost]
        public async Task<ActionResult<Comanda>> Adicionar()
        {
            await this._ComandaServico.Inserir();

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Comanda>> Resetar(int id)
        {
            await this._ComandaServico.Resetar(id);

            return Ok();
        }
    }
}
