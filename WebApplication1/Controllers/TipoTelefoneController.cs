using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Server.Entities.DesafioColorado;
using System;
using System.Text;
using static Server.Web.DesafioColocado.Helper;

namespace Server.Web.DesafioColocado.Controllers;

public class TipoTelefoneController : Controller
{
    private Uri baseAddress = new Uri("http://localhost/ApiColorado");
    private readonly HttpClient _client;

    public TipoTelefoneController()
    {
        _client = new HttpClient();
        _client.BaseAddress = baseAddress;
    }

    public IActionResult Index()
    {
        var lstTipoTelefone = new List<TipoTelefoneViewModel>();
        try
        {
            var responsetipoTelefone = _client.GetAsync(_client.BaseAddress + "/TipoTelefone").Result;
            if (responsetipoTelefone.IsSuccessStatusCode)
            {
                string data = responsetipoTelefone.Content.ReadAsStringAsync().Result;
                var json = JsonConvert.DeserializeObject<List<TipoTelefoneViewModel>>(data);
                return View(json);
            }

            return View(lstTipoTelefone);
        }
        catch (Exception ex)
        {
            return View(lstTipoTelefone);
        }
    }

    [NoDirectAccess]
    public async Task<IActionResult> AddOrEdit(int id = 0)
    {
        var tipoTelefoneView = new TipoTelefoneViewModel();

        if (id == 0) return View(tipoTelefoneView);
        else
        {
            var transactionModel = _client.GetAsync(_client.BaseAddress + $"/TipoTelefone/{id}").Result;
            string data = transactionModel.Content.ReadAsStringAsync().Result;
            tipoTelefoneView = JsonConvert.DeserializeObject<TipoTelefoneViewModel>(data);
            return View(tipoTelefoneView);
        }
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult AddOrEdit(int id, [Bind("CodigoTipoTelefone,DescricaoTelefone,DataInsercao,UsuarioInsercao")] TipoTelefoneViewModel transactionModel)
    {

        try
        {

            if (ModelState.IsValid)
            {
                if (id > 0)
                {
                    string url = $"{baseAddress}/TipoTelefone/{id}";
                    var j = transactionModel.ToJson();
                    var result = _client.PutAsync(url, new StringContent(transactionModel.ToJson(), Encoding.UTF8, "application/json")).Result;
                    if (result.IsSuccessStatusCode)
                    {

                    }
                }
                else
                {
                    string url = $"{baseAddress}/TipoTelefone/";
                    transactionModel.DataInsercao = DateTime.Now;
                    var j = transactionModel.ToJson();
                    var result = _client.PostAsync(url, new StringContent(transactionModel.ToJson(), Encoding.UTF8, "application/json")).Result;
                    if (result.IsSuccessStatusCode)
                    {

                    }
                }
                return Json(new { isValid = true, html = Helper.RenderRazorViewToString(this, "index", transactionModel) });

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
        var tipoTelefoneView = JsonConvert.DeserializeObject<TipoTelefoneViewModel>(data);
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