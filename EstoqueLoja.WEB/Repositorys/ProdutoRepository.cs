using EstoqueLoja.WEB.Interfaces;
using EstoqueLoja.WEB.Models;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EstoqueLoja.WEB.Repositorys {
    public class ProdutoRepository : IProdutoRepository {
        private readonly string uprApi = "https://localhost:44359/api/Produto";

        public void Add(Produto produto) {
            var produtoCriado = new Produto();
            try {
                using (var cliente = new HttpClient()) {
                    var jsonObjeto = JsonConvert.SerializeObject(produto);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "Add", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode) {
                        var retorno = 200;
                    }
                }
            }
            catch (Exception ex) {

            }
        }

        public void Delete(Produto produto) {
            var produtoCriado = new Usuario();
            produtoCriado.IdUse = produto.IdPro;
            try {
                using (var cliente = new HttpClient()) {
                    var jsonObjeto = JsonConvert.SerializeObject(produtoCriado);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "Delete", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode) {
                        var retorno = 200;
                    }
                }
            }
            catch (Exception ex) {

            }
        }

        public async Task<bool> SaveAllAsync() {
            return true;
        }

        public void Update(Produto produto) {
            try {
                using (var cliente = new HttpClient()) {
                    var jsonObjeto = JsonConvert.SerializeObject(produto);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "Update", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode) {
                        var retorno = 200;
                    }
                }
            }
            catch (Exception ex) { }
        }

        public async Task<Produto> GetById(int id) {
            var produtoCriado = new Produto();
            produtoCriado.IdPro = id;
            try {
                using (var cliente = new HttpClient()) {
                    var jsonObjeto = JsonConvert.SerializeObject(produtoCriado);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "Delete", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode) {
                        var retorno = 200;
                    }
                }
            }
            catch (Exception ex) {

            }
            return produtoCriado;
        }

        public List<Produto> GetAll() {
            var retorno = new List<Produto>();
            try {
                using (var cliente = new HttpClient()) {
                    var resposta = cliente.GetStringAsync(uprApi + "GetAll");
                    resposta.Wait();
                    retorno = JsonConvert.DeserializeObject<Produto[]>(resposta.Result).ToList();
                }
            }
            catch (Exception ex) {

            }
            return retorno;
        }
    }
}
