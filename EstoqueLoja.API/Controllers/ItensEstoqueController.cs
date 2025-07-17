using AutoMapper;
using EstoqueLoja.API.DTOs;
using EstoqueLoja.API.Interfaces;
using EstoqueLoja.API.Models;
using EstoqueLoja.API.Repositorys;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueLoja.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]

    [Authorize(Roles = "Admin")]
    public class ItensEstoqueController : Controller {

        private readonly IItensEstoqueRepository _itensEstoqueRepository;
        private readonly IMapper _mapper;

        public ItensEstoqueController(IItensEstoqueRepository itensEstoqueRepository, IMapper mapper) {
            _itensEstoqueRepository = itensEstoqueRepository;
            _mapper = mapper;
        }

        [HttpGet("GetAll")]
        public async Task<IEnumerable<ItensEstoqueDTO>> GetItens() {
            var itensEstoque = await _itensEstoqueRepository.GetAll();
            var itensEstoqueDTO = _mapper.Map<List<ItensEstoqueDTO>>(itensEstoque);
            return itensEstoqueDTO;
        }

        [HttpPost("Add")]
        public async Task<ActionResult> RegisterItens(ItensEstoqueDTO itensEstoqueDTO) {
            var itensEstoque = _mapper.Map<ItensEstoque>(itensEstoqueDTO);
            _itensEstoqueRepository.Add(itensEstoque);
            if (await _itensEstoqueRepository.SaveAllAsync()) {
                return Ok("Item Registrado com Sucesso");
            }
            return BadRequest("Não Foi possivel registrar o Item");
        }

        [HttpPut("Update")]
        public async Task<ActionResult> UpdateItensEstoque(ItensEstoqueDTO itensEstoqueDTO) {
            var itensEstoque = _mapper.Map<ItensEstoque>(itensEstoqueDTO);
            _itensEstoqueRepository.Update(itensEstoque);
            if (await _itensEstoqueRepository.SaveAllAsync()) {
                return Ok("Itens alterados com Sucesso");
            }
            return BadRequest("Não foi possivel Aterar os Itens");
        }

        [HttpDelete("Delete/{idLoja}")]
        public async Task<ActionResult> DeleteItensEstoqueLoja(int idLoja) {

            var itens = await _itensEstoqueRepository.GetByIdLoja(idLoja);
            if (itens == null) { 
                return NotFound("Não foi possível Encontrar a Loja");
            }

            _itensEstoqueRepository.Delete(itens);
            if (await _itensEstoqueRepository.SaveAllAsync()) {
                return Ok("Item da Loja Deletado com Sucesso");
            }
            return BadRequest("Não foi possível Deletar o Item da Loja");
        }

        [HttpGet("GetById/{id}")]
        public async Task<ActionResult> GetProdutoById(int id) {
            var produto = await _itensEstoqueRepository.GetByIdLoja(id);
            if (produto == null) {
                return NotFound("Não foi possível encontrar o Produto");
            }
            return Ok(produto);
        }
    }
}
