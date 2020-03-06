using System;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var url = "https://www.pja.edu.pl/";
            var httpClient = new HttpClient();


            var response = await httpClient.GetAsync(url);
            var regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            var content = response.Content;
            var matches = regex.Matches(content.ToString());

            foreach(var match in matches)
            {
                Console.WriteLine(match.ToString());
            }



           // Console.WriteLine("Hello World!");
        }
    }
}
