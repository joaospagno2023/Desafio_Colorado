using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Server.Entities.DesafioColorado;

namespace Server.DataAcess.DesafioColorado.Config
{
    public class AppDbContext : DbContext
    {
        protected readonly IConfiguration Configuration;
        public DbSet<ClientesViewModel> Clientes { get; set; }
        public DbSet<TipoTelefoneViewModel> TipoTelefone { get; set; }
        public DbSet<TelefoneViewModel> Telefones { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = GetStringConectionConfig();// Configuration.GetConnectionString("DefaultConnection");
                optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
                base.OnConfiguring(optionsBuilder);
            }
        }

        private string GetStringConectionConfig()
        {
            string strCon = "server=desafiocolorad.mysql.dbaas.com.br; port=3306; database=desafiocolorad; user=desafiocolorad; password=Jbn@2023#; Persist Security Info=False; Connect Timeout=300;Convert Zero Datetime=True";
            return strCon;
        }
    }
}
