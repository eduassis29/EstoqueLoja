using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueLoja.WEB.Models {
    public class ItensEstoque {
        public int? IdPro { get; set; }

        public int IdLoj { get; set; }

        public int? QuantidadeIte { get; set; }

        public virtual Loja IdLojNavigation { get; set; }

        public virtual Produto IdProNavigation { get; set; }
    }
}
