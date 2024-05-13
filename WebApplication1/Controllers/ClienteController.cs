using System.Linq.Expressions;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Entities.DesafioColorado;
using static Server.Web.DesafioColocado.Helper;

namespace Server.Web.DesafioColocado.Controllers
{
    public class ClienteController : Controller
    {
        private Uri baseAddress = new Uri("http://localhost/ApiColorado");
        private readonly string _rota = "/cliente/";
        private readonly HttpClient _client;

        public ClienteController()
        {
            _client = new HttpClient();
            _client.BaseAddress = baseAddress;
        }

        public IActionResult Index()
        {
            var lstCliente = new ClientesViewModel();
            try
            {
                var responsetipoTelefone = _client.GetAsync(_client.BaseAddress + _rota).Result;
                if (responsetipoTelefone.IsSuccessStatusCode)
                {
                    string data = responsetipoTelefone.Content.ReadAsStringAsync().Result;
                    var json = JsonConvert.DeserializeObject<List<ClientesViewModel>>(data);
                    return View(json);
                }
            }
            catch (Exception)
            {

                throw;
            }
            return View();
        }


        [NoDirectAccess]
        public async Task<IActionResult> AddOrEdit(int id = 0)
        {
            var tipoTelefoneView = new ClientesViewModel();

            if (id == 0) return View(tipoTelefoneView);
            else
            {
                var transactionModel = _client.GetAsync(_client.BaseAddress + $"{_rota}{id}").Result;
                string data = transactionModel.Content.ReadAsStringAsync().Result;
                tipoTelefoneView = JsonConvert.DeserializeObject<ClientesViewModel>(data);
                return View(tipoTelefoneView);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(int id, [Bind("CodigoCliente,RazaoSocial,NomeFantasia,TipoPessoal,Documento,Endereco,Complemento,Bairro,Cidade,Cep,Complemento,UF,UsuarioInsercao")] ClientesViewModel transactionModel)
        {

            try
            {
                transactionModel.DataInsercao = DateTime.Now;
                if (ModelState.IsValid)
                {
                    if (id > 0)
                    {
                        string url = $"{baseAddress}{_rota}{id}";
                        var j = transactionModel.ToJson();
                        var result = _client.PutAsync(url, new StringContent(transactionModel.ToJson(), Encoding.UTF8, "application/json")).Result;
                        if (result.IsSuccessStatusCode)
                        {

                        }
                    }
                    else
                    {
                        string url = $"{baseAddress}{_rota}";
                        transactionModel.DataInsercao = DateTime.Now;
                        var j = transactionModel.ToJson();
                        var result = _client.PostAsync(url, new StringContent(transactionModel.ToJson(), Encoding.UTF8, "application/json")).Result;
                        if (result.IsSuccessStatusCode)
                        {

                        }
                    }
                    return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "Index", transactionModel) });

                }
                return Json(new { isValid = false, html = RenderRazorViewToString(this, "AddOrEdit", transactionModel) });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException());
            }
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transactionModel = _client.GetAsync(_client.BaseAddress + $"/TipoTelefone/{id}").Result;
            string data = transactionModel.Content.ReadAsStringAsync().Result;
            var tipoTelefoneView = JsonConvert.DeserializeObject<ClientesViewModel>(data);
            if (tipoTelefoneView == null)
            {
                return NotFound();
            }

            return View(tipoTelefoneView);
        }

        // POST: Transaction/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            string url = $"{baseAddress}/TipoTelefone/{id}";

            var result = _client.DeleteAsync(url).Result;
            if (result.IsSuccessStatusCode)
            {

            }
            return Json(new { html = Helper.RenderRazorViewToString(this, "Index", new TipoTelefoneViewModel()) });
        }
    }
}
