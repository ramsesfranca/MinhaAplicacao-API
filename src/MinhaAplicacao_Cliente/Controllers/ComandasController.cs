using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using MinhaAplicacao_Cliente.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace MinhaAplicacao_Cliente.Controllers
{
    public class ComandasController : BaseController
    {
        #region Construtores

        public ComandasController(IConfiguration configuration)
            : base(configuration)
        {
            this._apiBaseUrl += "Comandas";
        }

        #endregion

        #region GETs

        public async Task<IActionResult> Index()
        {
            List<ComandaModel> mdeolo;

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(this._apiBaseUrl);

                mdeolo = JsonConvert.DeserializeObject<List<ComandaModel>>(await response.Content.ReadAsStringAsync());
            }

            return View(mdeolo);
        }

        public async Task<IActionResult> Adicionar()
        {
            using var resposta = await new HttpClient().PostAsync(this._apiBaseUrl, null);

            if (resposta.StatusCode != HttpStatusCode.OK)
            {
                var message = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                ModelState.Clear();
                ModelState.AddModelError(string.Empty, message);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Resetar(int id)
        {
            using var resposta = await new HttpClient().PutAsync($"{this._apiBaseUrl}/{id}", null);

            if (resposta.StatusCode != HttpStatusCode.OK)
            {
                var message = resposta.Content.ReadAsStringAsync().GetAwaiter().GetResult();

                ModelState.Clear();
                ModelState.AddModelError(string.Empty, message);
            }

            return RedirectToAction(nameof(Index));
        }

        #endregion
    }
}
