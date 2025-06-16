using EstoqueLoja.WEB.Interfaces;
using EstoqueLoja.WEB.Models;
using Newtonsoft.Json;
using System.Text;

namespace EstoqueLoja.WEB.Repositorys {
    public class UsuarioRepository : IUsuarioRepository {
        private readonly string uprApi = "https://localhost:44359/api/Usuario";

        public void Add(Usuario usuario) {
            var usuarioCriado = new Usuario();
            try {
                using (var cliente = new HttpClient()) {
                    var jsonObjeto = JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi+"Add", content);
                    resposta.Wait();
                    if(resposta.Result.IsSuccessStatusCode) {
                        var retorno = 200;
                    }
                }
            }
            catch (Exception ex) { 
            
            }
        }

        public void Delete(Usuario usuario) {
            var usuarioCriado = new Usuario();
            usuarioCriado.IdUse = usuario.IdUse;
            try {
                using (var cliente = new HttpClient()) {
                    var jsonObjeto = JsonConvert.SerializeObject(usuarioCriado);
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

        public void Update(Usuario usuario) {
            try {
                using (var cliente = new HttpClient()) {
                    var jsonObjeto = JsonConvert.SerializeObject(usuario);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "Update", content);
                    resposta.Wait();
                    if (resposta.Result.IsSuccessStatusCode) {
                        var retorno = 200;
                    }
                }
            }
            catch(Exception ex) { }
        }

        public async Task<Usuario> GetById(int id) {
            var usuarioCriado = new Usuario();
            usuarioCriado.IdUse = id;
            try {
                using (var cliente = new HttpClient()) {
                    var jsonObjeto = JsonConvert.SerializeObject(usuarioCriado);
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
            return usuarioCriado;
        }
    }
}
