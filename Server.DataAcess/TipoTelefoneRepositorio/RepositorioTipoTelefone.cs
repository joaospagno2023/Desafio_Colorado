using Microsoft.EntityFrameworkCore;
using Server.Business.DesafioColorado.InterfaceTipoTelefone;
using Server.Business.DesafioColorado.ITelefone;
using Server.DataAcess.DesafioColorado.Config;
using Server.DataAcess.DesafioColorado.RepositorioGenerico;
using Server.Entities.DesafioColorado;

namespace Server.DataAcess.DesafioColorado.TipoTelefoneRepositorio
{
    public class RepositorioTipoTelefone : RepositoryGenerics<TipoTelefoneViewModel>, ITipoTelefone
    {
        private readonly DbContextOptions<AppDbContext> _OptionsBuilder;

        public RepositorioTipoTelefone()
        {
            _OptionsBuilder = new DbContextOptions<AppDbContext>();
        }


    }

}
