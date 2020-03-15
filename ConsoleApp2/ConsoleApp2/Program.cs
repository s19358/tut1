using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        static async Task Main(string[] args) //without async , await won't work
        {
            var url = args[0]; 
            //var url = @"https://www.pja.edu.pl/"; // @ for escape characters
            var httpClient = new HttpClient(); //Http Get req will take the page's source code

            var response = await httpClient.GetAsync(url); // async --> paralel thread

            var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

            var content = await response.Content.ReadAsStringAsync(); //paralel
            var matches = regex.Matches(content);

            foreach (var match in matches)
            {
                Console.WriteLine(match.ToString());
            }

        }
    }
}
