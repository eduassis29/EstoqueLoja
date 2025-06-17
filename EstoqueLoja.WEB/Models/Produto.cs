using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueLoja.WEB.Models {
    public class Produto {
        public int IdPro { get; set; }

        public string NomePro { get; set; }

        public double? PrecoPro { get; set; }

        [InverseProperty("IdLojNavigation")]
        public virtual ICollection<ItensEstoque> ItensEstoques { get; set; }
    }
}
