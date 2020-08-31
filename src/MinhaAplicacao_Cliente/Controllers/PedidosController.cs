using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using MinhaAplicacao_Cliente.Models;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace MinhaAplicacao_Cliente.Controllers
{
    public class PedidosController : BaseController
    {
        private readonly string _apiBaseUrlComandas;
        private readonly string _apiBaseUrlCardapios;

        #region Construtores

        public PedidosController(IConfiguration configuration)
            : base(configuration)
        {
            this._apiBaseUrlComandas = $"{this._apiBaseUrl}Comandas";
            this._apiBaseUrlCardapios = $"{this._apiBaseUrl}Cardapios";
            this._apiBaseUrl += "Pedidos";
        }

        #endregion

        #region GETs

        public async Task<IActionResult> Index()
        {
            List<PedidoModel> mdeolo;

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync(this._apiBaseUrl);

                mdeolo = JsonConvert.DeserializeObject<List<PedidoModel>>(await response.Content.ReadAsStringAsync());
            }

            return View(mdeolo);
        }

        public async Task<IActionResult> Adicionar()
        {
            using var httpClient = new HttpClient();
            using var responseComandas = await httpClient.GetAsync(this._apiBaseUrlComandas);
            using var responseCardapios = await httpClient.GetAsync(this._apiBaseUrlCardapios);

            var modelo = new PedidoModel
            {
                SelectComandas = this.ConverteSelectListItemComando(JsonConvert.DeserializeObject<IEnumerable<ComandaModel>>(await responseComandas.Content.ReadAsStringAsync())),
                SelectCardapios = this.ConverteSelectListItemCardapio(JsonConvert.DeserializeObject<IEnumerable<CardapioModel>>(await responseCardapios.Content.ReadAsStringAsync()))
            };

            return View(modelo);
        }

        public async Task<IActionResult> Atualizar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PedidoModel mdeolo;

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync($"{this._apiBaseUrl}/{id}");

                mdeolo = JsonConvert.DeserializeObject<PedidoModel>(await response.Content.ReadAsStringAsync());

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

            PedidoModel mdeolo;

            using (var httpClient = new HttpClient())
            {
                using var response = await httpClient.GetAsync($"{this._apiBaseUrl}/{id}");

                mdeolo = JsonConvert.DeserializeObject<PedidoModel>(await response.Content.ReadAsStringAsync());

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
        public async Task<IActionResult> Adicionar(PedidoModel modelo)
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

            using var httpClient = new HttpClient();
            using var response = await httpClient.GetAsync(this._apiBaseUrlComandas);

            modelo.SelectComandas = this.ConverteSelectListItemComando(JsonConvert.DeserializeObject<IEnumerable<ComandaModel>>(await response.Content.ReadAsStringAsync()));

            return View(modelo);
        }

        [HttpPost, ValidateAntiForgeryToken]
        public async Task<IActionResult> Atualizar(int id, PedidoModel modelo)
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

        private IEnumerable<SelectListItem> ConverteSelectListItemComando(IEnumerable<ComandaModel> comandos)
        {
            return comandos.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Codigo
            });
        }

        private IEnumerable<SelectListItem> ConverteSelectListItemCardapio(IEnumerable<CardapioModel> comandos)
        {
            return comandos.Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.Nome
            });
        }
    }
}
