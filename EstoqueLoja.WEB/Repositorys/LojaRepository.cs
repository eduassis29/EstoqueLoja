using EstoqueLoja.WEB.Interfaces;
using EstoqueLoja.WEB.Models;
using Newtonsoft.Json;
using System.Text;

namespace EstoqueLoja.WEB.Repositorys {
        public class LojaRepository : ILojaRepository {
            private readonly string uprApi = "https://localhost:44359/api/Loja/";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public LojaRepository(IHttpContextAccessor httpContextAccessor) {
            _httpContextAccessor = httpContextAccessor;
        }

        private HttpClient CriarHttpClientComToken() {
            var httpClient = new HttpClient();
            var token = _httpContextAccessor.HttpContext?.Session?.GetString("JWToken");

            if (!string.IsNullOrEmpty(token)) {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            }
            ;

            return httpClient;
        }

        public void Add(Loja loja) {
                var lojaCriada = new Loja();
                try {
                    using (var cliente = CriarHttpClientComToken()) {
                        string jsonObjeto = JsonConvert.SerializeObject(loja);
                        var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                        var resposta = cliente.PostAsync(uprApi + "Add", content);
                        resposta.Wait();
                        if (resposta.Result.IsSuccessStatusCode) {
                            var retorno = resposta.Result.Content.ReadAsStringAsync();
                            lojaCriada = JsonConvert.DeserializeObject<Loja>(retorno.Result);
                    }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }
        }

            public Loja Delete(Loja loja) {
                var lojaDeletada = new Loja();
                try {
                    using (var cliente = CriarHttpClientComToken()) {
                        var resposta = cliente.DeleteAsync(uprApi + $"Delete/{loja.IdLoj}").Result;
                        if (resposta.IsSuccessStatusCode) {
                            var retorno = resposta.Content.ReadAsStringAsync().Result;
                            lojaDeletada = JsonConvert.DeserializeObject<Loja>(retorno);
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine("Erro no ProdutoRepository", ex);
                }
                return lojaDeletada;
            }

        public bool SaveAllAsync() {
                return true;
            }

            public void Update(Loja loja) {
                var lojaCriada = new Loja();
                try {
                    using (var lojas = CriarHttpClientComToken()) {
                        string jsonObjeto = JsonConvert.SerializeObject(loja);
                        var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                        var resposta = lojas.PutAsync(uprApi + "Update", content);
                    resposta.Wait();
                        if (resposta.Result.IsSuccessStatusCode) {
                            var retorno = resposta.Result.Content.ReadAsStringAsync();
                            lojaCriada = JsonConvert.DeserializeObject<Loja>(retorno.Result);
                    }
                    }
                }
                    catch (Exception ex) {
                        Console.WriteLine(ex);
                    }
        }

            public Loja GetById(int id) {
                var lojaCriada = new Loja();
                lojaCriada.IdLoj = id;
                try {
                    using (var lojas = CriarHttpClientComToken()) {
                        string jsonObjeto = JsonConvert.SerializeObject(lojaCriada);
                        var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                        var resposta = lojas.GetAsync(uprApi + $"GetById/{id}");
                        resposta.Wait();
                        if (resposta.Result.IsSuccessStatusCode) {
                            var retorno = resposta.Result.Content.ReadAsStringAsync();
                            lojaCriada = JsonConvert.DeserializeObject<Loja>(retorno.Result);
                        }
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }
            return lojaCriada;
            }

            public List<Loja> GetAll() {
                var retorno = new List<Loja>();
                try {
                    using (var cliente = CriarHttpClientComToken()) {
                        var resposta = cliente.GetStringAsync(uprApi + "GetAll");
                        resposta.Wait();
                        retorno = JsonConvert.DeserializeObject<Loja[]>(resposta.Result).ToList();
                    }
                }
                catch (Exception ex) {
                    Console.WriteLine(ex);
                }
            return retorno;
            }
    }
}
