using Microsoft.AspNetCore.Mvc;
using MinhaAplicacao_Cliente.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace MinhaAplicacao_Cliente.Controllers
{
    public class PessoasController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<PessoaModel> mdeolo;

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync("https://localhost:44398/pessoas"))
                {
                    mdeolo = JsonConvert.DeserializeObject<List<PessoaModel>>(await response.Content.ReadAsStringAsync());
                }
            }

            return View(mdeolo);
        }

        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pessoa = await _context.Pessoas
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pessoa == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pessoa);
        //}

        //public IActionResult Create()
        //{
        //    return View();
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Nome,Sexo,Email,DataNascimento,Naturalidade,Nacionalidade,CPF,Id,DataHoraCadastro,DataHoraModificado")] Pessoa pessoa)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(pessoa);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(pessoa);
        //}

        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pessoa = await _context.Pessoas.FindAsync(id);
        //    if (pessoa == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(pessoa);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Edit(int id, [Bind("Nome,Sexo,Email,DataNascimento,Naturalidade,Nacionalidade,CPF,Id,DataHoraCadastro,DataHoraModificado")] Pessoa pessoa)
        //{
        //    if (id != pessoa.Id)
        //    {
        //        return NotFound();
        //    }

        //    if (ModelState.IsValid)
        //    {
        //        try
        //        {
        //            _context.Update(pessoa);
        //            await _context.SaveChangesAsync();
        //        }
        //        catch (DbUpdateConcurrencyException)
        //        {
        //            if (!PessoaExists(pessoa.Id))
        //            {
        //                return NotFound();
        //            }
        //            else
        //            {
        //                throw;
        //            }
        //        }
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(pessoa);
        //}

        //public async Task<IActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var pessoa = await _context.Pessoas
        //        .FirstOrDefaultAsync(m => m.Id == id);
        //    if (pessoa == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(pessoa);
        //}

        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> DeleteConfirmed(int id)
        //{
        //    var pessoa = await _context.Pessoas.FindAsync(id);
        //    _context.Pessoas.Remove(pessoa);
        //    await _context.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

        //private bool PessoaExists(int id)
        //{
        //    return _context.Pessoas.Any(e => e.Id == id);
        //}
    }
}
