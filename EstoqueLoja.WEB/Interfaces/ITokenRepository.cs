using EstoqueLoja.API.DTOs;

namespace EstoqueLoja.WEB.Interfaces {
    public interface ITokenRepository {
        string GenerateToken(LoginDTO loginDTO);
    }
}
