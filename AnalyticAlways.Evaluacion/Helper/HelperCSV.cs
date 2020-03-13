using AnaliticAlways.Repository.Entity;
using CsvHelper;
using CsvHelper.Configuration;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace AnalyticAlways.Evaluacion.Helper
{
    public static class HelperCSV
    {
        public static List<Stock> GetAllStocks(StreamReader stream)
        {
            using (var csv = new CsvReader(stream, CultureInfo.InvariantCulture))
            {
                csv.Configuration.RegisterClassMap<StockMap>();
                csv.Configuration.Delimiter = ";";
                return csv.GetRecords<Stock>().ToList();
            }
        }

    }

    public sealed class StockMap : ClassMap<Stock>
    {
        public StockMap()
        {
            Map(m => m.PointOfSale);
            Map(m => m.Product);
            Map(m => m.Date);
            Map(m => m.Count).Name("Stock");
        }
    }
}
