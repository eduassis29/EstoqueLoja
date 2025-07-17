using EstoqueLoja.API.Interfaces;
using EstoqueLoja.API.Models;
using EstoqueLoja.API.Repositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueLoja.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]

    [Authorize(Roles = "Admin")]
    public class UsuarioController : Controller {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository) { 
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost("Add")]
        [AllowAnonymous]
        public async Task<ActionResult> AddUser(Usuario usuario) {
            _usuarioRepository.Add(usuario);
            if (await _usuarioRepository.SaveAllAsync()) {
                return Ok("Usuario Adicionado com Sucesso");
            }
            return BadRequest("Não foi possivel Adicionar o Usuario");
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetUserById(int id) {
            var usuario = await _usuarioRepository.GetById(id);
            if (usuario == null) {
                return NotFound("Não foi possível encontrar o Usuario");
            }
            return Ok(usuario);
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateUsuario(Usuario usuario) {
            _usuarioRepository.Update(usuario);
            if (await _usuarioRepository.SaveAllAsync()) {
                return Ok("Usuario Alterado Com Sucesso");
            }
            return BadRequest("Não Foi possivel Aterar o Usuario");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteUsuario(int id) {
            var usario = await _usuarioRepository.GetById(id);
            if (usario == null) {
                return NotFound("Usuario não Encontrado");
            }

            _usuarioRepository.Delete(usario);
            if (await _usuarioRepository.SaveAllAsync()) {
                return Ok("Usuario Excluido com Sucesso");
            }
            return BadRequest("Não foi possível Excluir Usuario");
        }
    }
}
