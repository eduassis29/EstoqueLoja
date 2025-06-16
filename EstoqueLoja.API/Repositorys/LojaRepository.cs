using EstoqueLoja.API.Interfaces;
using EstoqueLoja.API.Models;
using Microsoft.EntityFrameworkCore;

namespace EstoqueLoja.API.Repositorys {
    public class LojaRepository : ILojaRepository {

        private readonly EstoqueLojaContext _context;

        public LojaRepository(EstoqueLojaContext context) {
            _context = context;
        }

        public void Add(Loja loja) {
            _context.Lojas.Add(loja);
        }

        public void Delete(Loja loja) {
            _context.Lojas.Remove(loja);
        }

        public async Task<IEnumerable<Loja>> GetAll() {
            return await _context.Lojas.ToListAsync();
        }

        public async Task<Loja> GetById(int id) {
            return await _context.Lojas.Where(x => x.IdLoj == id).FirstOrDefaultAsync();
            
        }

        public async Task<bool> SaveAllAsync() {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Loja loja) {
            _context.Entry(loja).State = EntityState.Modified;

        }
    }
}
