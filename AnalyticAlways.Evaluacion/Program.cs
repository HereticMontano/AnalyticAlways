using AnaliticAlways.Repository;
using AnalyticAlways.Evaluacion.Helper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace AnalyticAlways.Evaluacion
{
    class Program
    {
        private static IConfigurationRoot _configuration;

        private static AnalyticAlwaysContext _db;
        static void Main(string[] args)
        {
            Configuration();
            ProcessData();
        }

        private static void Configuration()
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("app.json");
            _configuration = builder.Build();

            var configContext = new DbContextOptionsBuilder<AnalyticAlwaysContext>().UseSqlServer(_configuration.GetConnectionString("Storage"));
            _db = new AnalyticAlwaysContext(configContext.Options);
        }

        private static void ProcessData()
        {
            var data = new FontsOfData(new Uri(_configuration.GetSection("URL:CSV").Value));

            var fileCsv = data.GetCSV();
            if (fileCsv != null)
            {
                
                _db.Database.ExecuteSqlRaw("TRUNCATE TABLE Stock");

                var elements = HelperCSV.GetAllStocks(new StreamReader(fileCsv));

                /*Por problemas de performance para meter 17 millones de registros uso una libreria de terceros, 17 millones de registro en 292960 ms = 5 minutos*/
                _db.BulkInsert(elements, operation =>
                {
                    operation.AutoMapOutputDirection = false;
                    operation.BatchSize = 10000;
                });
            }
        }
    }
}
