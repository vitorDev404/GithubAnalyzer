using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GithubAnalyzer.Models
{
    public class GithubUser
    {
        public string Login { get; set; }
        public string Name { get; set; }
        public int Followers { get; set; }
        public int Following { get; set; }
        [JsonPropertyName("public_repos")]
        public int PublicRepos { get; set; }
    }
}
