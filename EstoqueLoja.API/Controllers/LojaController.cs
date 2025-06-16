using EstoqueLoja.API.Interfaces;
using EstoqueLoja.API.Models;
using EstoqueLoja.API.Repositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueLoja.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]

    [Authorize(Roles = "Admin")]
    public class LojaController : Controller {

        private readonly ILojaRepository _lojaRepository;

        public LojaController(ILojaRepository lojaRepository) { 
            _lojaRepository = lojaRepository;
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IEnumerable<Loja>>> GetLojas() {
            return Ok(await _lojaRepository.GetAll());
        }

        [HttpPost("Add")]
        public async Task<ActionResult> RegisterLoja(Loja loja) {
            _lojaRepository.Add(loja);
            if (await _lojaRepository.SaveAllAsync()) { 
                return Ok("Loja Adicionada com Sucesso");
            }
            return BadRequest("Erro ao Adicionar a Loja");
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateLoja(Loja loja) {
            _lojaRepository.Update(loja);
            if (await _lojaRepository.SaveAllAsync()) {
                return Ok("Loja Alterada Com Sucesso");
            }
            return BadRequest("Não foi possivel Alterar a Loja");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteLoja(int id) {
            var loja = await _lojaRepository.GetById(id);
            if (loja == null) { 
                return NotFound("Loja Não Encontrada");
            }

            _lojaRepository.Delete(loja);
            if(await _lojaRepository.SaveAllAsync()) {
                return Ok("Loja Deletada com Sucesso");
            }
            return BadRequest("Loja não pode ser Deletada");
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetLojaById(int id) {
            var loja = await _lojaRepository.GetById(id);
            if(loja == null) {
                return NotFound("Não foi possivel encontrar a loja");
            }
            return Ok(loja);
        }
    }
}
