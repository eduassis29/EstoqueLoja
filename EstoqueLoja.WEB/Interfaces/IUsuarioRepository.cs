using EstoqueLoja.WEB.Models;

namespace EstoqueLoja.WEB.Interfaces {
    public interface IUsuarioRepository {
        Usuario Add(Usuario usuario);

        void Update(Usuario usuario);

        Usuario Delete(Usuario usuario);

        Usuario GetById(int id);

        bool SaveAllAsync();
    }
}
