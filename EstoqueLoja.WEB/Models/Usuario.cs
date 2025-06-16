using System.ComponentModel.DataAnnotations;

namespace EstoqueLoja.WEB.Models {
    public class Usuario {
        public int IdUse { get; set; }

        public string NomeUse { get; set; }

        public string EmailUse { get; set; }

        public string PasswordUse { get; set; }

        public string RoleUse { get; set; }
    }
}
