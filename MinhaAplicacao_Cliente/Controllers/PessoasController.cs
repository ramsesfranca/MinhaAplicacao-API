using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MinhaAplicacao_Cliente.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAplicacao_Cliente.Controllers
{
    public class PessoasController : Controller
    {
        private readonly string _apiBaseUrl;

        public PessoasController(IConfiguration configuration)
        {
            this._apiBaseUrl = configuration.GetValue<string>("WebAPIBaseUrl");
        }

        public async Task<IActionResult> Index()
        {
            List<PessoaModel> mdeolo;

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(this._apiBaseUrl);

                mdeolo = JsonConvert.DeserializeObject<List<PessoaModel>>(await response.Content.ReadAsStringAsync());
            }

            return View(mdeolo);
        }

        public IActionResult Adicionar()
        {
            return View();
        }

        public async Task<IActionResult> Atualizar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PessoaModel mdeolo;

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync($"{this._apiBaseUrl}/{id}");

                mdeolo = JsonConvert.DeserializeObject<PessoaModel>(await response.Content.ReadAsStringAsync());

                if (mdeolo == null)
                {
                    return NotFound();
                }
            }

            return View(mdeolo);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Adicionar(PessoaModel modelo)
        {
            if (ModelState.IsValid)
            {
                using var cliente = new HttpClient();
                var contuúdo = new StringContent(JsonConvert.SerializeObject(modelo), Encoding.UTF8, "application/json");
                using var resposta = await cliente.PostAsync(this._apiBaseUrl, contuúdo);

                if (resposta.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction(nameof(Index));
                }

                var message = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                ModelState.Clear();
                ModelState.AddModelError(string.Empty, message);
            }

            return View(modelo);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Atualizar(int id, PessoaModel modelo)
        {
            if (id != modelo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                using var cliente = new HttpClient();
                var contuúdo = new StringContent(JsonConvert.SerializeObject(modelo), Encoding.UTF8, "application/json");
                using var resposta = await cliente.PutAsync($"{this._apiBaseUrl}/{id}", contuúdo);

                if (resposta.StatusCode == HttpStatusCode.OK)
                {
                    return RedirectToAction(nameof(Index));
                }

                var message = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                ModelState.Clear();
                ModelState.AddModelError(string.Empty, message);
            }

            return View(modelo);
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
