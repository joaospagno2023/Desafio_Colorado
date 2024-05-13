using Microsoft.EntityFrameworkCore;
using Server.Business.DesafioColorado.ITelefone;
using Server.DataAcess.DesafioColorado.Config;
using Server.DataAcess.DesafioColorado.RepositorioGenerico;
using Server.Entities.DesafioColorado;

namespace Server.DataAcess.DesafioColorado.Telefone
{
    public class RepositorioTelefone : RepositoryGenerics<TelefoneViewModel>, ITelefone
    {
        private readonly DbContextOptions<AppDbContext> _OptionsBuilder;

        public RepositorioTelefone()
        {
            _OptionsBuilder = new DbContextOptions<AppDbContext>();
        }


    }

}
