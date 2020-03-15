using System;
using System.IO;
using System.Net.Http;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    public class Program
    {
        static async Task Main(string[] args) 
        {
          
             string _filePath = Path.GetDirectoryName(System.AppDomain.CurrentDomain.BaseDirectory);
            _filePath = Directory.GetParent(_filePath).FullName;

           
            using (var reader = new StreamReader(_filePath))
            {
                var line = reader.ReadLine();
                Console.WriteLine(line);
                
            }


        }

        private static object GetResourceStream(string filePath)
        {
            throw new NotImplementedException();
        }
    }
}
