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
    public class PessoasController : MinhaAplicacaoController
    {
        private readonly IPessoaServico _pessoaServico;
        private readonly IMapper _mapper;

        public PessoasController(IPessoaServico pessoaServico, IMapper mapper)
        {
            this._pessoaServico = pessoaServico;
            this._mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaModel>>> ObterTodos()
        {
            return this.Ok(this._mapper.Map<List<PessoaModel>>(await this._pessoaServico.SelecionarTodos()));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> ObterPorId(int id)
        {
            var pessoa = await this._pessoaServico.SelecionarPorId(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return Ok(this._mapper.Map<PessoaModel>(pessoa));
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> Adicionar(PessoaModel modelo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await this._pessoaServico.Inserir(this._mapper.Map<Pessoa>(modelo));

            return Ok(modelo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, PessoaModel modelo)
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
                await this._pessoaServico.Alterar(this._mapper.Map<Pessoa>(modelo));
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await this._pessoaServico.Existe(p => p.Id.Equals(id)))
                {
                    return NotFound();
                }

                throw;
            }

            return Ok(modelo);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<Pessoa>> Excluir(int id)
        {
            var pessoa = await this._pessoaServico.SelecionarPorId(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            await this._pessoaServico.Deletar(pessoa);

            return Ok();
        }
    }
}
