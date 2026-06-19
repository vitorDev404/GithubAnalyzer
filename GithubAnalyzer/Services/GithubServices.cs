using GithubAnalyzer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace GithubAnalyzer.Services
{
    public class GithubServices
    {
        public async Task<GithubUser> GetUserAsync(string login)
        {
            // Cria uma instância do HttpClient para fazer a requisição HTTP
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Add("User-Agent", "C# App");//Adiciona o cabeçalho User-Agent à requisição

            string url = $"https://api.github.com/users/{login}";//Requisição GET para a API do GitHub
            // Aqui você aguarda a resposta da API
            //O que GetStringAsync faz?
            //GET -> URL -> Recebe resposta -> Retorna o conteúdo como string

            string resposta = await client.GetStringAsync(url);
            //Objeto que vai armazenar:Login,Name,Followers,Following,PublicRepos
            GithubUser user = JsonSerializer.Deserialize<GithubUser>(resposta, new JsonSerializerOptions {PropertyNameCaseInsensitive = true });
            //Console.WriteLine(resposta);
            return user;
        }
    }
}
