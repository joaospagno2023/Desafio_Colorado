using Server.Entities.DesafioColorado.Base;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Server.Entities.DesafioColorado
{
    public class ClientesViewModel : BaseJson
    {
        #region Contrutor

        #endregion

        #region Public
        [Key]
        [DisplayName("Codigo")]
        public int CodigoCliente { get; set; }

        [DisplayName("Razão Social")]
        [Required(ErrorMessage = "Este Campo é Obrigatorio.")]
        public string RazaoSocial { get; set; }

        [DisplayName("Nome Fantasia")]
        [Required(ErrorMessage = "Este Campo é Obrigatorio.")]
        public string NomeFantasia { get; set; }

        [DisplayName("Tipo Pessoa")]
        [Required(ErrorMessage = "Este Campo é Obrigatorio.")]
        public int? TipoPessoal { get; set; }

        [DisplayName("Documento")]
        [Required(ErrorMessage = "Este Campo é Obrigatorio.")]
        public string Documento { get; set; }

        [DisplayName("Endereco")]
        [Required(ErrorMessage = "Este Campo é Obrigatorio.")]
        public string Endereco { get; set; }

        [DisplayName("Complemento")]
        [Required(ErrorMessage = "Este Campo é Obrigatorio.")]
        public string Complemento { get; set; }

        [DisplayName("Bairro")]
        [Required(ErrorMessage = "Este Campo é Obrigatorio.")]
        public string Bairro { get; set; }

        [DisplayName("Cidade")]
        [Required(ErrorMessage = "Este Campo é Obrigatorio.")]
        public string Cidade { get; set; }

        [DisplayName("cep")]
        [Required(ErrorMessage = "Este Campo é Obrigatorio.")]
        public string Cep { get; set; }

        [DisplayName("UF")]
        [Required(ErrorMessage = "Este Campo é Obrigatorio.")]
        public string UF { get; set; }

        [DisplayName("Data Inclusão")]
        public DateTime? DataInsercao { get; set; }

        [DisplayName("Usuario Inclusão")]
        [Required(ErrorMessage = "Este Campo é Obrigatorio.")]
        public string UsuarioInsercao { get; set; }

        #endregion
    }
}
