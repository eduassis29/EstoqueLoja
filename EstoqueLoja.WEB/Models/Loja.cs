using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EstoqueLoja.WEB.Models {
    public class Loja {
        public int IdLoj { get; set; }

        public string NomeLoj { get; set; }

        public string EnderecoLoj { get; set; }

        [InverseProperty("IdLojNavigation")]
        public virtual ItensEstoque ItensEstoque { get; set; }
    }
}

