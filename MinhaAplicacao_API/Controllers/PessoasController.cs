using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MinhaAplicacao.Dominio.Entidades;
using MinhaAplicacao.Dominio.Interfaces.Services;
using MinhaAplicacao_API.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MinhaAplicacao_API.Controllers
{
    //[Route("api/pessoas")]
    [Route("[controller]")]
    public class PessoasController : MinhaAplicacaoController
    {
        private readonly IPessoaServico _pessoaServico;
        private readonly IMapper _mapper;

        public PessoasController(IPessoaServico pessoaServico, IMapper mapper)
        {
            this._pessoaServico = pessoaServico;
            this._mapper = mapper;
        }

        // GET: api/Pessoas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PessoaModel>>> GetPessoas()
        {
            return this.Ok(this._mapper.Map<List<PessoaModel>>(await this._pessoaServico.SelecionarTodos()));
        }

        // GET: api/Pessoas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pessoa>> GetPessoa(int id)
        {
            var pessoa = await this._pessoaServico.SelecionarPorId(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            return pessoa;
        }

        [HttpPost]
        public async Task<ActionResult<Pessoa>> PostPessoa(PessoaModel modelo)
        {
            await this._pessoaServico.Inserir(this._mapper.Map<Pessoa>(modelo));

            return CreatedAtAction("GetPessoa", new { id = modelo.Id }, modelo);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutPessoa(int id, PessoaModel modelo)
        {
            if (id != modelo.Id)
            {
                return BadRequest();
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
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Pessoas/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Pessoa>> DeletePessoa(int id)
        {
            var pessoa = await this._pessoaServico.SelecionarPorId(id);

            if (pessoa == null)
            {
                return NotFound();
            }

            await this._pessoaServico.Deletar(pessoa);

            return pessoa;
        }
    }
}
