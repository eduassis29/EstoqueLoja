using EstoqueLoja.API.Models;

namespace EstoqueLoja.API.Interfaces {
    public interface IUsuarioRepository {
        void Add(Usuario usuario);

        void Update(Usuario usuario);

        void Delete(Usuario usuario);

        Usuario GetByName(string nome);

        Task<Usuario> GetById(int id);

        Task<bool> SaveAllAsync();
    }
}
