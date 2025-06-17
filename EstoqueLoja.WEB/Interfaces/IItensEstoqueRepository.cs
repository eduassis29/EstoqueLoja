using EstoqueLoja.WEB.Models;

namespace EstoqueLoja.WEB.Interfaces {
    public interface IItensEstoqueRepository {
        void Add(ItensEstoque itensEstoque);

        void Update(ItensEstoque itens);

        ItensEstoque Delete(ItensEstoque itens);

        ItensEstoque GetByIdLoja(int idLoja);

        List<ItensEstoque> GetAll();

        bool SaveAllAsync();
    }
}
