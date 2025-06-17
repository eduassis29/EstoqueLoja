using EstoqueLoja.WEB.Models;

namespace EstoqueLoja.WEB.Interfaces {
    public interface ILojaRepository {
        void Add(Loja loja);

        void Update(Loja loja);

        Loja Delete(Loja loja);

        Loja GetById(int id);

        List<Loja> GetAll();

        bool SaveAllAsync();
    }
}