using EstoqueLoja.API.Models;

namespace EstoqueLoja.API.Interfaces {
    public interface IItensEstoqueRepository {
        void Add(ItensEstoque itensEstoque);

        void Update(ItensEstoque itens);

        void Delete(ItensEstoque itens);

        Task<ItensEstoque> GetByIdLoja(int idLoja);

        Task<ItensEstoque> GetByIdProduto(int idProduto);

        Task<IEnumerable<ItensEstoque>> GetAll();

        Task<bool> SaveAllAsync();
    }
}
