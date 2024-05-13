using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Server.Business.DesafioColorado.InterfaceTipoTelefone;
using Server.Business.DesafioColorado.ITelefone;
using Server.Entities.DesafioColorado;

namespace Server.Api.DesafioColorado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TelefoneController : ControllerBase
    {
        private readonly ITelefone _iTelefone;

        public TelefoneController(ITelefone telefone)
        {
            _iTelefone = telefone;
        }

        [HttpGet(Order = 1)]
        public async Task<IActionResult> GetTipoTelefone()
        {

            try
            {
                var findAllTipoTelefone = await _iTelefone.FindAllAsync();
                return Ok(findAllTipoTelefone);
            }
            catch (MySqlException exMysql)
            {
                return BadRequest(exMysql.GetBaseException());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException());
            }


        }

        [HttpGet("{id}", Order = 2)]
        public async Task<IActionResult> GetTipoTelefoneFind(int id)
        {

            try
            {
                var findAllTipoTelefone = await _iTelefone.FindByIdAsync(id);
                return Ok(findAllTipoTelefone);
            }
            catch (MySqlException exMysql)
            {
                return BadRequest(exMysql.GetBaseException());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException());
            }

        }

        [HttpPost(Order = 4)]
        public async Task<IActionResult> InsereTelefone(TelefoneViewModel tipoTelefoneViewModel)
        {

            try
            {
                var findAllTipoTelefone = _iTelefone.InsertAsync(tipoTelefoneViewModel);
                return Ok();
            }
            catch (MySqlException exMysql)
            {
                return BadRequest(exMysql.GetBaseException());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException());
            }

        }

        [HttpPut("{id}", Order = 3)]
        public async Task<IActionResult> AtualizaTelefone(int id, [FromBody] TelefoneViewModel tipoTelefoneViewModel)
        {

            try
            {
                if (id != tipoTelefoneViewModel.IdTelefone)
                {
                    return BadRequest();
                }
                var findAllTipoTelefone = _iTelefone.UpdateAsync(tipoTelefoneViewModel);
                return Ok();
            }
            catch (MySqlException exMysql)
            {
                return BadRequest(exMysql.GetBaseException());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException());
            }

        }

        [HttpDelete("{id}", Order = 5)]
        public async Task<IActionResult> DeleteTipoTelefone(int id)
        {

            try
            {
                var DeletebyTelefone = await _iTelefone.FindByIdAsync(id);
                if (DeletebyTelefone == null) return BadRequest("Telefone não localizado");
                await _iTelefone.DeleteAsync(DeletebyTelefone);

                return Ok();
            }
            catch (MySqlException exMysql)
            {
                return BadRequest(exMysql.GetBaseException());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException());
            }

        }
    }
}
