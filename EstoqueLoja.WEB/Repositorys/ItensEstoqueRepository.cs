using EstoqueLoja.WEB.Interfaces;
using EstoqueLoja.WEB.Models;
using Newtonsoft.Json;
using System.Text;

namespace EstoqueLoja.WEB.Repositorys {
    public class ItensEstoqueRepository : IItensEstoqueRepository {
        private readonly string uprApi = "https://localhost:44359/api/ItensEstoque/";

        public void Add(ItensEstoque itensEstoque) {
            var itensCriados = new ItensEstoque();
            try {
                using (var cliente = new HttpClient()) {
                    string jsonObjeto = JsonConvert.SerializeObject(itensEstoque);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "Add/", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode) {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        itensCriados = JsonConvert.DeserializeObject<ItensEstoque>(retorno.Result);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public ItensEstoque Delete(ItensEstoque itensEstoque) {
            var itensEstoqueDeletado = new ItensEstoque();
            try {
                using (var cliente = new HttpClient()) {
                    var resposta = cliente.DeleteAsync(uprApi + $"Delete/{itensEstoque.IdLoj}").Result;
                    if (resposta.IsSuccessStatusCode) {
                        var retorno = resposta.Content.ReadAsStringAsync().Result;
                        itensEstoqueDeletado = JsonConvert.DeserializeObject<ItensEstoque>(retorno);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Erro no ProdutoRepository", ex);
            }
            return itensEstoqueDeletado;
        }

        public bool SaveAllAsync() {
            return true;
        }

        public void Update(ItensEstoque itensEstoque) {
            var itensCriados = new ItensEstoque();
            try {
                using (var cliente = new HttpClient()) {
                    string jsonObjeto = JsonConvert.SerializeObject(itensEstoque);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PutAsync(uprApi + "Update", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode) {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        itensCriados = JsonConvert.DeserializeObject<ItensEstoque>(retorno.Result);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
        }

        public ItensEstoque GetByIdLoja(int id) {
            var itensCriados = new ItensEstoque();
            itensCriados.IdLoj = id;
            try {
                using (var cliente = new HttpClient()) {
                    string jsonObjeto = JsonConvert.SerializeObject(itensCriados);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.GetAsync(uprApi + $"GetById/{id}");
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode) {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        itensCriados = JsonConvert.DeserializeObject<ItensEstoque>(retorno.Result);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return itensCriados;
        }

        public List<ItensEstoque> GetAll() {
            var retorno = new List<ItensEstoque>();
            try {
                using (var cliente = new HttpClient()) {
                    var resposta = cliente.GetStringAsync(uprApi + "GetAll");
                    resposta.Wait();
                    retorno = JsonConvert.DeserializeObject<ItensEstoque[]>(resposta.Result).ToList();
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return retorno;
        }
    }
}
