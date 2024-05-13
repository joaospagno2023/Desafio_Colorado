using Microsoft.AspNetCore.Mvc;
using MySqlConnector;
using Server.Business.DesafioColorado.InterfaceCliente;
using Server.Entities.DesafioColorado;

namespace Server.Api.DesafioColorado.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ICliente _iCliente;

        public ClienteController(ICliente cliente)
        {
            _iCliente = cliente;
        }


        #region Methods

        [HttpGet(Order = 1)]
        public async Task<IActionResult> Get()
        {
            try
            {
                var ClienteGet = await _iCliente.FindAllAsync();
                return Ok(ClienteGet);
            }
            catch (MySqlException exmysql)
            {
                return BadRequest(exmysql.GetBaseException());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.GetBaseException());
            }
        }

        [HttpGet("{id}", Order = 2)]
        public async Task<IActionResult> GetClienteByID(int id)
        {
            try
            {
                var ClienteGetID = await _iCliente.FindByIdAsync(id);
                return Ok(ClienteGetID);
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

        [HttpPost(Order = 3)]

        public async Task ClientePost(ClientesViewModel clienteView)
        {
            await _iCliente.UpdateAsync(clienteView);
        }


        [HttpPut("{id}", Order = 4)]
        public async Task AtualizarCliente(int id, ClientesViewModel produto)
        {
            await _iCliente.UpdateAsync(produto);
        }

        [HttpDelete("{id}", Order = 5)]
        public async Task DeleteCliente(int id)
        {
            var clienteGet = await _iCliente.FindByIdAsync(id);

            var DeleteCliente = _iCliente.DeleteAsync(clienteGet);
        }


        #endregion
    }
}
