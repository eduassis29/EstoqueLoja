using EstoqueLoja.API.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueLoja.API.DTOs {
    public class ItensEstoqueDTO {
        public int? IdPro { get; set; }

        [Key]
        public int IdLoj { get; set; }

        public int? QuantidadeIte { get; set; }
    }
}
