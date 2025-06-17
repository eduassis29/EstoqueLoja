using EstoqueLoja.API.DTOs;
using EstoqueLoja.WEB.Interfaces;
using EstoqueLoja.WEB.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueLoja.WEB.Controllers {
    public class LoginController : Controller {
        private readonly ITokenRepository _tokenRepository;

        public LoginController(ITokenRepository tokenRepository) {
            _tokenRepository = tokenRepository;
        }

        [HttpGet]
        public ActionResult Login() {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginDTO login) {
            var token = _tokenRepository.GenerateToken(login);

            if (string.IsNullOrEmpty(token)) {
                ModelState.AddModelError("", "Login inválido.");
                return View();
            }

            HttpContext.Session.SetString("JWToken", token);

            return RedirectToAction("Index", "Home");

        }
    }
}
