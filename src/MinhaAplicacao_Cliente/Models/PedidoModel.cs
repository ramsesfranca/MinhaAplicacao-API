using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MinhaAplicacao_Cliente.Models
{
    public class PedidoModel : ModelBase<int>
    {
        [Display(Name = "Comanda")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int ComandaId { get; set; }

        [Display(Name = "Cardápio")]
        [Required(ErrorMessage = "O campo {0} é obrigatório")]
        public int CardapioId { get; set; }

        [Display(Name = "Data/Hora")]
        public DateTime DataHoraCadastro { get; set; }

        public ComandaModel Comanda { get; set; }
        public CardapioModel Cardapio { get; set; }

        public IEnumerable<SelectListItem> SelectComandas { get; set; }
        public IEnumerable<SelectListItem> SelectCardapios { get; set; }
    }
}
