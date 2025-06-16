using EstoqueLoja.API.Interfaces;
using EstoqueLoja.API.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueLoja.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]

    //[Authorize(Roles = "Admin")]
    public class ProdutoController : Controller {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository) {
            _produtoRepository = produtoRepository;
        }

        [HttpGet("GetAll")]
        public List<Produto> GetAll() {
            return _produtoRepository.GetAll();
        }

        [HttpPost("Add")]
        public async Task<ActionResult> RegisterProduto(Produto produto) {
            _produtoRepository.Add(produto);
            if (await _produtoRepository.SaveAllAsync()) {
                return Ok("Produto Registrado Com Sucesso");
            }
            return BadRequest("Não foi possível adicionar o produto");
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateProduto(Produto produto) {
            _produtoRepository.Update(produto);
            if(await _produtoRepository.SaveAllAsync()) {
                return Ok("Produto Alterado Com Sucesso");
            }
            return BadRequest("Não Foi possivel Aterar o produto");
        }

        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult> DeleteProduto(int id) {
            var produto = await _produtoRepository.GetById(id);
            if (produto == null) { 
                return NotFound("Produto não Encontrado");
            }

            _produtoRepository.Delete(produto);
            if (await _produtoRepository.SaveAllAsync()) {
                return Ok("Produto Excluido com Sucesso");
            }
            return BadRequest("Não foi possível Excluir Produto");
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetProdutoById(int id) {
            var produto = await _produtoRepository.GetById(id);
            if (produto == null) {
                return NotFound("Não foi possível encontrar o Produto");
            }
            return Ok(produto);
        }
    }
}
