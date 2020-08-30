using System.ComponentModel.DataAnnotations;

namespace MinhaAplicacao_API.V1.Models
{
    public class CardapioModel : ModelBase<int>
    {
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency)]
        public decimal Preco { get; set; }
    }
}
