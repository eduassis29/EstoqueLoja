using EstoqueLoja.API.DTOs;
using EstoqueLoja.API.Models;

namespace EstoqueLoja.API.Interfaces {
    public interface ITokenRepository {
        string GenerateToken(LoginDTO loginDTO);

    }
}
