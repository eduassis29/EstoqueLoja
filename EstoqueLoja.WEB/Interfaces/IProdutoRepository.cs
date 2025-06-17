using EstoqueLoja.WEB.Models;

namespace EstoqueLoja.WEB.Interfaces {
    public interface IProdutoRepository {
        Produto Add(Produto produto);

        Produto Update(Produto produto);

        Produto Delete(Produto produto);

        Produto GetById(int id);

        List<Produto> GetAll();

        bool SaveAllAsync();
    }
}
