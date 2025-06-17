using EstoqueLoja.API.DTOs;
using EstoqueLoja.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueLoja.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class TokenController : Controller {
        public readonly ITokenRepository _TokenRepository;

        public TokenController(ITokenRepository tokenRepository) { 
            _TokenRepository = tokenRepository;
        }

        [HttpPost("Login")]
        public ActionResult Login(LoginDTO login) { 
            var loginUser = _TokenRepository.GenerateToken(login);
            if (loginUser == null) {
                return Unauthorized();
            }
            return Ok(loginUser);
        }
    }
}
