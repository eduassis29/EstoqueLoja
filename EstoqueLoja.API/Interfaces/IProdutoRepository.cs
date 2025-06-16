using EstoqueLoja.API.Models;

namespace EstoqueLoja.API.Interfaces {
    public interface IProdutoRepository {
        void Add(Produto produto);

        void Update(Produto produto);

        void Delete(Produto produto);

        Task<Produto> GetById(int id);

        List<Produto> GetAll();

        Task<bool> SaveAllAsync();
    }
}
