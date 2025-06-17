using EstoqueLoja.API.Interfaces;
using EstoqueLoja.API.Models;
using Microsoft.EntityFrameworkCore;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace EstoqueLoja.API.Repositorys {
    public class UsuarioRepository : IUsuarioRepository {

        private readonly EstoqueLojaContext _context;

        public UsuarioRepository(EstoqueLojaContext context) {
            _context = context;
        }

        public void Add(Usuario usuario) {
            _context.Usuarios.Add(usuario);
        }

        public void Delete(Usuario usuario) {
            _context.Usuarios.Remove(usuario);
        }

        public async Task<bool> SaveAllAsync() {
            return await _context.SaveChangesAsync() > 0;
        }

        public void Update(Usuario usuario) {
            _context.Entry(usuario).State = EntityState.Modified;
        }

        public async Task<Usuario> GetById(int id) {
            return await _context.Usuarios.Where(x => x.IdUse == id).FirstOrDefaultAsync();
        }

        public Usuario GetByNome(string nome) {
            return _context.Usuarios.Where(x => x.NomeUse == nome).FirstOrDefault();
        }
    }
}
