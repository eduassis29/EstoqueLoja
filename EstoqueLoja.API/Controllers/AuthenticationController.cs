using EstoqueLoja.API.DTOs;
using EstoqueLoja.API.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueLoja.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class AuthenticationController : Controller {
        private readonly ITokenRepository _tokenRepository;

        public AuthenticationController(ITokenRepository tokenRepository) {
            _tokenRepository = tokenRepository;
        }

        [HttpPost("login")]
        public ActionResult Login(LoginDTO loginDTO) {
            var token = _tokenRepository.GenerateToken(loginDTO);
            if(token == "") {
                return Unauthorized();
            }
            return Ok(token);
        }

    }
}
