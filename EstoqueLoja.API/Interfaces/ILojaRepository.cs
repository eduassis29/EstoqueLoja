using EstoqueLoja.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueLoja.API.Interfaces {
    public interface ILojaRepository {
        void Add(Loja loja);

        void Update(Loja loja);

        void Delete(Loja loja);

        Task<Loja> GetById(int id);

        Task<IEnumerable<Loja>> GetAll();

        Task<bool> SaveAllAsync();
    }
}
