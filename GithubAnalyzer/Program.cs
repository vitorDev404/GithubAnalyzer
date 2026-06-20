using GithubAnalyzer.Models;
using GithubAnalyzer.Services;

class Program
{
    static async Task Main (string[] args)
    {
        int option = 0;
        while(option != 3)
        {
            Console.WriteLine("1 - Search for a user");
            Console.WriteLine("2 - Search for a repository");
            Console.WriteLine("3 - Exit");
            option = int.Parse(Console.ReadLine());
            switch (option)
            {
                case 1:
                    await SearchUser(args);
                    break;
                case 2:
                    await SearchRepositorychUser(args);
                    break;
                case 3:
                    Console.WriteLine("Exiting");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }
    static async Task SearchUser(string [] args)
    {
        //Instancia para utilizar os metodos que existem em GitHubServices
        GithubServices services = new GithubServices();
        Console.WriteLine("Username: ");
        string usuario = Console.ReadLine();
        //await espera o retorno da API | services.GetUserAsync chamou o metodo do Service | GithubUser user espera receber um objeto do tipo GithubUser
        GithubUser user = await services.GetUserAsync(usuario);
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"Login: {user.Login}");
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"Name: {user.Name}");
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"Followers: {user.Followers}");
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"Following: {user.Following}");
        Console.WriteLine("-----------------------------");
        Console.WriteLine($"PublicRepos: {user.PublicRepos}");
    }
    static async Task SearchRepositorychUser(string[] args)
    {
        GithubServices services = new GithubServices();
        Console.WriteLine("Username: ");
        string usuario = Console.ReadLine();
        List<GithubRepository> repository = await services.GetUserReposAsync(usuario);
        foreach (var repo in repository)
        {
            Console.WriteLine("-----------------------------");
            Console.WriteLine($"Repositories of {usuario}:");
            Console.WriteLine($"Name:{repo.Name}");
            Console.WriteLine($"Description:{repo.Description}");
            Console.WriteLine($"Language:{repo.Language}");
            Console.WriteLine("-----------------------------");
        }
    }
}
