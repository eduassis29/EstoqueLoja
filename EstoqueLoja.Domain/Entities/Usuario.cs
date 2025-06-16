using EstoqueLoja.Domain.Validation;

namespace EstoqueLoja.API.Models {
    public class Usuario {
        public int IdUse { get; set; }
        public string NomeUse { get; set; }
        public string EmailUse { get; set; }
        public byte[] PasswordHashUse { get; private set; }
        public byte[] PasswordSaltUse { get; private set; }

        public Usuario(int idUse, string nomeUse, string emailUse) {
            DomainExceptionValidation.When(idUse < 0, "O Id tem que ser positivo");
            DomainExceptionValidation.When(idUse == null, "O Id não pode ser nulo");
            IdUse = idUse;
            ValidateDomain(nomeUse, emailUse);
        }

        public Usuario(string nomeUse, string emailUse) {
            ValidateDomain(nomeUse, emailUse);
        }

        public void AlterarSenha(byte[] passwordHash, byte[] passwordSalt) {
            PasswordHashUse = passwordHash;
            PasswordSaltUse = passwordSalt;
        }

        private void ValidateDomain(string nomeUse, string emailUse) {
            DomainExceptionValidation.When(nomeUse.Length == null, "O Nome não pode ser nulo");
            DomainExceptionValidation.When(emailUse.Length == null, "O Email não pode ser nulo");
            DomainExceptionValidation.When(nomeUse.Length > 250, "O Nome não pode ter mais de 250 caracteres");
            DomainExceptionValidation.When(emailUse.Length > 100, "O Email não pode ter mais de 100 caracteres");
            NomeUse = nomeUse;
            EmailUse = emailUse;
        }
    }
}
