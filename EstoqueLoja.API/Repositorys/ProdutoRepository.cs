using EstoqueLoja.API.Interfaces;
using EstoqueLoja.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueLoja.API.Repositorys {
    public class ProdutoRepository : IProdutoRepository {

        private readonly EstoqueLojaContext _context;

        public ProdutoRepository(EstoqueLojaContext context) {
            _context = context;
        }

        public void Add(Produto produto) {
            _context.Produtos.Add(produto);
        }

        public void Delete(Produto produto) {
            _context.Produtos.Remove(produto);
        }

        public List<Produto> GetAll() {
            return _context.Produtos.ToList();
        }

        public async Task<Produto> GetById(int id) {
            return await _context.Produtos.Where(x => x.IdPro == id).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync() {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Produto produto) {
            _context.Entry(produto).State = EntityState.Modified;
        }
    }
}
