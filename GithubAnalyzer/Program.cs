using GithubAnalyzer.Models;
using GithubAnalyzer.Services;

class Program
{
    static async Task Main (string[] args)
    {
        //Instancia para utilizar os metodos que existem em GitHubServices
        GithubServices services = new GithubServices();
        Console.WriteLine("Digite o nome do usuário do GitHub:");
        string usuario = Console.ReadLine() ;
        //await espera o retorno da API | services.GetUserAsync chamou o metodo do Service | GithubUser user espera receber um objeto do tipo GithubUser
        GithubUser user = await services.GetUserAsync(usuario);
        Console.WriteLine($"Login: {user.Login}");
        Console.WriteLine($"Name: {user.Name}");
        Console.WriteLine($"Followers: {user.Followers}");
        Console.WriteLine($"Following: {user.Following}");
        Console.WriteLine($"PublicRepos: {user.PublicRepos}");
    }
}
