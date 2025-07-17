using EstoqueLoja.API.DTOs;
using EstoqueLoja.WEB.Interfaces;
using Newtonsoft.Json;
using System.Text;

namespace EstoqueLoja.WEB.Repositorys {
    public class TokenRepository : ITokenRepository {
        private readonly string uprApi = "https://localhost:44359/api/Token";

        public string GenerateToken(LoginDTO loginDTO) {
            string token = string.Empty;
            try {
                using (var cliente = new HttpClient()) {
                    string jsonObjeto = JsonConvert.SerializeObject(loginDTO);
                    var content = new StringContent(jsonObjeto, Encoding.UTF8, "application/json");
                    var resposta = cliente.PostAsync(uprApi + "/Login", content);
                    resposta.Wait();
                    if (resposta != null) {
                        var retorno = resposta.Result.Content.ReadAsStringAsync();
                        retorno.Wait();
                        token = retorno.Result;
                    }
                }
            }
            catch (Exception ex) {
                Console.WriteLine("Erro ao gerar token: " + ex.Message);
            }
            return token;
        }
    }
}
