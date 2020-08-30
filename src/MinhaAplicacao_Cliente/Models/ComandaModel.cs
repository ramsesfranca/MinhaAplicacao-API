using System.ComponentModel.DataAnnotations;

namespace MinhaAplicacao_Cliente.Models
{
    public class ComandaModel : ModelBase<int>
    {
        [Display(Name = "Código")]
        public string Codigo { get; set; }

        [Display(Name = "Status")]
        public StatusComanda StatusComanda { get; set; }
    }

    public enum StatusComanda
    {
        Aerta = 1,
        Fechada = 2
    }
}
