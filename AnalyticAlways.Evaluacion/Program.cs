using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace AnalyticAlways.Evaluacion
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("app.json");

            IConfigurationRoot configuration = builder.Build();

            Console.WriteLine(configuration.GetConnectionString("Storage"));
        }
    }
}
