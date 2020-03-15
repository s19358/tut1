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
            int counter = 0;

            if (args.Length == 0)
            {
                throw new ArgumentNullException();
            }
            var url = args[0];
            //var url = @"https://www.pja.edu.pl/"; // @ for escape characters

            try
            {
                var httpClient = new HttpClient(); //Http Get req will take the page's source code

                var response = await httpClient.GetAsync(url); // async --> paralel thread

                var regex = new Regex("[a-z]+[a-z0-9]*@[a-z]+\\.[a-z]+", RegexOptions.IgnoreCase);

                var content = await response.Content.ReadAsStringAsync(); //paralel

                MatchCollection matches = regex.Matches(content);

                foreach (var match in matches)
                {
                    counter += 1;
                    Console.WriteLine(match.ToString());
                }
                if (counter == 0)
                {
                    Console.WriteLine("No email addresses found");
                }
                httpClient.Dispose();

            }
            catch (Exception ex) {
                Console.WriteLine("Error while downloading the page");
            }


           

        }
    }
}
