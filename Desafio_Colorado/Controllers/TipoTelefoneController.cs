using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Server.Business.DesafioColorado.InterfaceTipoTelefone;
using Server.Entities.DesafioColorado;

namespace Server.Api.DesafioColorado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TipoTelefoneController : ControllerBase
    {
        private readonly ITipoTelefone _iTipoTelefone;

        public TipoTelefoneController(ITipoTelefone iTipoTelefone)
        {
            _iTipoTelefone = iTipoTelefone;
        }


        [HttpGet(Order = 1)]
        public async Task<IActionResult> GetTipoTelefone()
        {

            try
            {
                var findAllTipoTelefone = await _iTipoTelefone.FindAllAsync();
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
                var findAllTipoTelefone = await _iTipoTelefone.FindByIdAsync(id);
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
        public async Task<IActionResult> InsereTelefone(TipoTelefoneViewModel tipoTelefoneViewModel)
        {

            try
            {
                var findAllTipoTelefone = _iTipoTelefone.InsertAsync(tipoTelefoneViewModel);
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
        public async Task<IActionResult> AtualizaTelefone(int id, [FromBody] TipoTelefoneViewModel tipoTelefoneViewModel)
        {

            try
            {
                if (id != tipoTelefoneViewModel.CodigoTipoTelefone)
                {
                    return BadRequest();
                }
                var findAllTipoTelefone = _iTipoTelefone.UpdateAsync(tipoTelefoneViewModel);
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
                var DeletebyTelefone = await _iTipoTelefone.FindByIdAsync(id);
                if (DeletebyTelefone == null) return BadRequest("Telefone não localizado");
                await _iTipoTelefone.DeleteAsync(DeletebyTelefone);

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
