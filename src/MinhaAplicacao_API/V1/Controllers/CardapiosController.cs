using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Services;
using MinhaAplicacao_API.Controllers;
using MinhaAplicacao_API.V1.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAplicacao_API.V1.Controllers
{
    [ApiVersion("1.0")]
    public class CardapiosController : MinhaAplicacaoController
    {
        private readonly ICardapioServico _CardapioServico;
        private readonly IMapper _mapper;

        public CardapiosController(ICardapioServico CardapioServico, IMapper mapper)
        {
            this._CardapioServico = CardapioServico;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CardapioModel>>> ObterTodos()
        {
            return this.Ok(this._mapper.Map<List<CardapioModel>>(await this._CardapioServico.SelecionarTodos()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cardapio>> ObterPorId(int id)
        {
            var Cardapio = await this._CardapioServico.SelecionarPorId(id);

            if (Cardapio == null)
            {
                return NotFound();
            }

            return Ok(this._mapper.Map<CardapioModel>(Cardapio));
        }

        [HttpPost]
        public async Task<ActionResult<Cardapio>> Adicionar(CardapioModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this._CardapioServico.Inserir(this._mapper.Map<Cardapio>(modelo));

            return Ok(modelo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, CardapioModel modelo)
        {
            if (id != modelo.Id)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                await this._CardapioServico.Alterar(this._mapper.Map<Cardapio>(modelo));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this._CardapioServico.Existe(p => p.Id.Equals(id)))
                {
                    return NotFound();
                }

                throw;
            }

            return Ok(modelo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Cardapio>> Excluir(int id)
        {
            var Cardapio = await this._CardapioServico.SelecionarPorId(id);

            if (Cardapio == null)
            {
                return NotFound();
            }

            await this._CardapioServico.Deletar(Cardapio);

            return Ok();
        }
    }
}
