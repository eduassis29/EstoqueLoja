using EstoqueLoja.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueLoja.API.Interfaces {
    public interface IProdutoRepository {
        void Add(Produto produto);

        void Update(Produto produto);

        void Delete(Produto produto);

        Task<Produto> GetById(int id);

        Task<IEnumerable<Produto>> GetAll();

        Task<bool> SaveAllAsync();
    }
}
