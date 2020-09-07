using System.ComponentModel.DataAnnotations;

namespace MinhaAplicacao_Cliente.Models
{
    public class ComandaModel : ModelBase<int>
    {
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Display(Name = "Status")]
        public StatusComanda StatusComanda { get; set; }

        [Display(Name = "Total")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        [DataType(DataType.Currency)]
        public decimal Total { get; set; }
    }

    public enum StatusComanda
    {
        Aerta = 1,
        Fechada = 2
    }
}
