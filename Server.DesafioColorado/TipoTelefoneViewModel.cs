using System.Collections;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Server.Entities.DesafioColorado.Base;

namespace Server.Entities.DesafioColorado
{
    public class TipoTelefoneViewModel : BaseJson
    {
        [Key]
        [DisplayName("Codigo")]
        [Required(ErrorMessage = "Este Campo é Obrigatorio.")]
        public int CodigoTipoTelefone { get; set; }

        [DisplayName("Descrição")]
        [Required(ErrorMessage = "Este Campo é Obrigatorio.")]
        [MaxLength(24, ErrorMessage = "Maximum 12 characters only")]
        public string DescricaoTelefone { get; set; }

        [DisplayName("Data Inclusão")]
        public DateTime? DataInsercao { get; set; }

        [DisplayName("Usuario Inclusão")]
        public string UsuarioInsercao { get; set; }

    }
}
