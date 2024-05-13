using Microsoft.EntityFrameworkCore;
using Server.Business.DesafioColorado.InterfaceCliente;
using Server.DataAcess.DesafioColorado.Config;
using Server.DataAcess.DesafioColorado.RepositorioGenerico;
using Server.Entities.DesafioColorado;

namespace Server.DataAcess.DesafioColorado.ClienteRepositorio
{
    public class RepositorioCliente : RepositoryGenerics<ClientesViewModel>, ICliente
    {
        private readonly DbContextOptions<AppDbContext> _OptionsBuilder;

        public RepositorioCliente()
        {
            _OptionsBuilder = new DbContextOptions<AppDbContext>();
        }

    }

}
