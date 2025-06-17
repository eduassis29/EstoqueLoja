using EstoqueLoja.WEB.Interfaces;
using EstoqueLoja.WEB.Models;
using Newtonsoft.Json;
using System.Text;

namespace EstoqueLoja.WEB.Repositorys {
    public class UsuarioRepository : IUsuarioRepository {
        private readonly string uprApi = "https://localhost:44359/api/Usuario/";

        public Usuario Add(Usuario usuario) {
            var usuarioCriado = new Usuario();
            try {
                using (var cliente = new HttpClient()) {
                    string jsonObjeto = JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "Add/", content);
                    resposta.Wait();
                    if(resposta.Result.IsSuccessStatusCode) {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        usuarioCriado = JsonConvert.DeserializeObject<Usuario>(retorno.Result);
                    }
                }
            }
            catch (Exception ex) { 
            
            }
            return usuarioCriado;
        }

        public Usuario Delete(Usuario usuario) {
            var usuarioDeletado = new Usuario();
            try {
                using (var cliente = new HttpClient()) {
                    var resposta = cliente.DeleteAsync(uprApi + $"Delete/{usuario.IdUse}").Result;
                    if (resposta.IsSuccessStatusCode) {
                        var retorno = resposta.Content.ReadAsStringAsync().Result;
                        usuarioDeletado = JsonConvert.DeserializeObject<Usuario>(retorno);
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Erro no ProdutoRepository", ex);
            }
            return usuarioDeletado;
        }

        public bool SaveAllAsync() {
            return true;
        }

        public void Update(Usuario usuario) {
            var usuarioCriado = new Usuario();
            try {
                using (var cliente = new HttpClient()) {
                    string jsonObjeto = JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PutAsync(uprApi + "Update", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode) {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        usuarioCriado = JsonConvert.DeserializeObject<Usuario>(retorno.Result);
                    }
                }
            }
            catch(Exception ex) { }
        }

        public Usuario GetById(int id) {
            var usuarioCriado = new Usuario();
            usuarioCriado.IdUse = id;
            try {
                using (var cliente = new HttpClient()) {
                    string jsonObjeto = JsonConvert.SerializeObject(usuarioCriado);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.GetAsync(uprApi + $"GetById/{id}");
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode) {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        usuarioCriado = JsonConvert.DeserializeObject<Usuario>(retorno.Result);
                    }
                }
            }
            catch (Exception ex) {

            }
            return usuarioCriado;
        }
    }
}
