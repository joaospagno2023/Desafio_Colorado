using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Server.Entities.DesafioColorado.Base;

namespace Server.Entities.DesafioColorado
{

    public class TelefoneViewModel : BaseJson
    {
        [Key]
        [DisplayName("Codigo")]
        public int IdTelefone { get; set; }
        [DisplayName("Numero Telefone")]
        public string NumeroTelefone { get; set; }
        [DisplayName("Operadora")]
        public string Operadora { get; set; }
        [DisplayName("Ativo")]
        public bool Ativo { get; set; }
        public int CodigoCliente { get; set; }
        [DisplayName("Data Inclusão")]
        public DateTime? DataInsercao { get; set; }

        [DisplayName("Usuario Inclusão")]
        public string UsuarioInsercao { get; set; }
    }
}
