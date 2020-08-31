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
    public class PedidosController : MinhaAplicacaoController
    {
        private readonly IPedidoServico _PedidoServico;
        private readonly IMapper _mapper;

        public PedidosController(IPedidoServico PedidoServico, IMapper mapper)
        {
            this._PedidoServico = PedidoServico;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PedidoModel>>> ObterTodos()
        {
            return this.Ok(this._mapper.Map<List<PedidoModel>>(await this._PedidoServico.SelecionarTodos(p => p.Comanda)));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pedido>> ObterPorId(int id)
        {
            var Pedido = await this._PedidoServico.SelecionarPorId(id);

            if (Pedido == null)
            {
                return NotFound();
            }

            return Ok(this._mapper.Map<PedidoModel>(Pedido));
        }

        [HttpPost]
        public async Task<ActionResult<Pedido>> Adicionar(PedidoModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this._PedidoServico.Inserir(this._mapper.Map<Pedido>(modelo));

            return Ok(modelo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, PedidoModel modelo)
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
                await this._PedidoServico.Alterar(this._mapper.Map<Pedido>(modelo));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this._PedidoServico.Existe(p => p.Id.Equals(id)))
                {
                    return NotFound();
                }

                throw;
            }

            return Ok(modelo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pedido>> Excluir(int id)
        {
            var Pedido = await this._PedidoServico.SelecionarPorId(id);

            if (Pedido == null)
            {
                return NotFound();
            }

            await this._PedidoServico.Deletar(Pedido);

            return Ok();
        }
    }
}
