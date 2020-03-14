using System;
using System.IO;
using System.Net;

namespace AnalyticAlways.Evaluacion
{
    public static class FontsOfData
    {
        public static Stream GetCSV(bool desarrollo, Uri uri)
        {
            if(desarrollo)
                return new FileStream("Stock.csv", FileMode.Open, FileAccess.Read);
            
            var net = new WebClient();
            var data = net.DownloadData(uri.ToString());
            return new MemoryStream(data);
        }
    }
}
