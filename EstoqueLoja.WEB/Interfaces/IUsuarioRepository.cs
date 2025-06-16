using EstoqueLoja.WEB.Models;

namespace EstoqueLoja.WEB.Interfaces {
    public interface IUsuarioRepository {
        void Add(Usuario usuario);

        void Update(Usuario usuario);

        void Delete(Usuario usuario);

        Task<Usuario> GetById(int id);

        Task<bool> SaveAllAsync();
    }
}
