using AnaliticAlways.Repository.Entity;
using AnaliticAlways.Repository.Repository;
using AnalyticAlways.Evaluacion.Helper;
using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.DependencyInjection;

namespace AnalyticAlways.Evaluacion
{
    class Program
    {
        private static StockRepository _repo;

        static void Main(string[] args)
        {
            Configuration();
            ProcessData();
        }

        private static void Configuration()
        {
            _repo = StartUp.ServiceProvider.GetService<StockRepository>();
        }

        private static void ProcessData()
        {
            Console.WriteLine("Descargando");
            List<Stock> stocks = new List<Stock>();
            using (var fileCsv = FontsOfData.GetCSV(false, new Uri("https://interview2208.blob.core.windows.net/interview/Stock.CSV?sp=r&st=2020-01-07T06:09:04Z&se=2021-01-07T14:09:04Z&spr=https&sv=2019-02-02&sr=b&sig=A34uhCv1LATDR7XdeDy1OaZSOknZmjXKsf59j05GNfE%3D")))
                stocks = HelperCSV.GetAllStocks(new StreamReader(fileCsv));
           
            if (stocks.Count > 0)
            {
                Console.WriteLine("Truncando");
                _repo.TruncateTable();
                Console.WriteLine("Insertando");
                _repo.Insert(stocks);
            }
        }
    }
}