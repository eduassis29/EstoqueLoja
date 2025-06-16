

using EstoqueLoja.API.Interfaces;
using EstoqueLoja.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueLoja.API.Repositorys {
    public class ItensEstoqueRepository : IItensEstoqueRepository {

        private readonly EstoqueLojaContext _context;

        public ItensEstoqueRepository(EstoqueLojaContext context) {
            _context = context;
        }

        public void Add(ItensEstoque itensEstoque) {
            _context.ItensEstoques.Add(itensEstoque);
        }

        public void Delete(ItensEstoque itensEstoque) {
            _context.ItensEstoques.Remove(itensEstoque);
        }

        public async Task<IEnumerable<ItensEstoque>> GetAll() {
            return await _context.ItensEstoques.ToListAsync();
        }

        public async Task<ItensEstoque> GetByIdLoja(int idLoja) {
            return await _context.ItensEstoques.Where(x => x.IdLoj == idLoja).FirstOrDefaultAsync();
        }

        public async Task<ItensEstoque> GetByIdProduto(int idLoja) {
            return await _context.ItensEstoques.Where(x => x.IdLoj == idLoja).FirstOrDefaultAsync();
        }

        public async Task<bool> SaveAllAsync() {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(ItensEstoque itensEstoque) {
            _context.Entry(itensEstoque).State = EntityState.Modified;
        }
    }
}
