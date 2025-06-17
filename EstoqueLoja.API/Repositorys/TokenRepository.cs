using EstoqueLoja.API.DTOs;
using EstoqueLoja.API.Interfaces;
using EstoqueLoja.API.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace EstoqueLoja.API.Repositorys {
    public class TokenRepository : ITokenRepository {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;

        public TokenRepository(IUsuarioRepository usuarioRepository, IConfiguration configuration) {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
        }



        public string GenerateToken(LoginDTO loginDTO) {
            var userDataBase = _usuarioRepository.GetByNome(loginDTO.NomeUse);
            if (loginDTO.NomeUse != userDataBase.NomeUse || loginDTO.PasswordUse != userDataBase.PasswordUse) {
                return string.Empty;
            }
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["jwt:secretKey"] ?? string.Empty));
            var issuer = _configuration["jwt:issuer"];
            var audience = _configuration["jwt:audience"];

            var singinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var tokenOptions = new JwtSecurityToken(
                issuer: issuer,
                audience: audience,
                claims: new[] {
                    new Claim(type: ClaimTypes.Name, userDataBase.NomeUse),
                    new Claim(type: ClaimTypes.Role, userDataBase.RoleUse),
                },
                expires: DateTime.Now.AddHours(2),
                signingCredentials: singinCredentials
                );
            var token = new JwtSecurityTokenHandler().WriteToken(tokenOptions);

            return token;
        }
    }
}
