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
    public class PessoasController : BaseController
    {
        #region Construtores

        public PessoasController(IConfiguration configuration)
            : base(configuration)
        {
            this._apiBaseUrl += "Pessoas";
        }

        #endregion

        #region GETs

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

        public async Task<IActionResult> Excluir(int? id)
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

        #endregion

        #region POSTs

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

        [HttpPost, ValidateAntiForgeryToken]
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

        [HttpPost, ActionName("Excluir"), ValidateAntiForgeryToken]
        public async Task<IActionResult> ExcluirCorminar(int id)
        {
            using var cliente = new HttpClient();
            using var resposta = await cliente.DeleteAsync($"{this._apiBaseUrl}/{id}");

            return resposta.StatusCode == HttpStatusCode.OK ? RedirectToAction(nameof(Index)) : RedirectToAction(nameof(Excluir), id);
        }

        #endregion
    }
}
