using EstoqueLoja.WEB.Interfaces;
using EstoqueLoja.WEB.Models;
using Newtonsoft.Json;
using System.Collections.Immutable;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EstoqueLoja.WEB.Repositorys {
    public class ProdutoRepository : IProdutoRepository {
        private readonly string uprApi = "https://localhost:44359/api/Produto/";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public ProdutoRepository(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }

        private HttpClient CriarHttpClientComToken() {
            var httpClient = new HttpClient();
            var token = _httpContextAccessor.HttpContext?.Session?.GetString("JWToken");

            if (!string.IsNullOrEmpty(token)) {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            };

            return httpClient;
        }

        public Produto Add(Produto produto) {
            var produtoCriado = new Produto();
            try {
                using (var cliente = CriarHttpClientComToken()) {
                    string jsonObjeto = JsonConvert.SerializeObject(produto);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "Add/", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode) {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        produtoCriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return produtoCriado;
        }

        public Produto Delete(Produto produto) {
            var produtoDeletado = new Produto ();
            try {
                using (var cliente = CriarHttpClientComToken()) {
                    var resposta = cliente.DeleteAsync(uprApi + $"Delete/{produto.IdPro}").Result;
                    if (resposta.IsSuccessStatusCode) {
                        var retorno = resposta.Content.ReadAsStringAsync().Result;
                        produtoDeletado = JsonConvert.DeserializeObject<Produto>(retorno);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Erro no ProdutoRepository",ex);
            }
            return produtoDeletado;
        }

        public bool SaveAllAsync() {
            return true;
        }

        public Produto Update(Produto produto) {
            var produtoCriado = new Produto();
            try {
                using (var cliente = CriarHttpClientComToken()) {
                    string jsonObjeto = JsonConvert.SerializeObject(produto);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PutAsync(uprApi + "Update", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode) {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        produtoCriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            return produtoCriado;
        }

        public Produto GetById(int id) {
            var produtoCriado = new Produto { IdPro = id };
            try {
                using (var cliente = CriarHttpClientComToken()) {
                    var resposta = cliente.GetAsync(uprApi + $"GetById/{id}");
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode) {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        retorno.Wait();
                        produtoCriado = JsonConvert.DeserializeObject<Produto>(retorno.Result);
                    }
                }
            }
            catch (HttpRequestException httpEx) {
                Console.WriteLine("Erro HTTP: " + httpEx.Message);
            }
            catch (Exception ex) {
                Console.WriteLine("Erro geral: " + ex.Message);
            }

            return produtoCriado;
        }

        public List<Produto> GetAll() {
            var retorno = new List<Produto>();
            try {
                using (var cliente = CriarHttpClientComToken()) {
                    var resposta = cliente.GetStringAsync(uprApi + "GetAll");
                    resposta.Wait();
                    retorno = JsonConvert.DeserializeObject<Produto[]>(resposta.Result).ToList();
                    Console.WriteLine(retorno);
                }
            }
            catch (Exception ex) {
                Console.WriteLine(ex);
            }
            
            return retorno;
        }
    }
}
