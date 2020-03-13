using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace AnalyticAlways.Evaluacion
{
   public class FontsOfData
    {
        private Uri _url;
        public FontsOfData(Uri url)
        {
            _url = url;
        }

        public Stream GetCSV()
        {
            return new FileStream("Stock.csv", FileMode.Open, FileAccess.Read);

            var net = new WebClient();
            var data = net.DownloadData(_url.ToString());
            return new MemoryStream(data);
        }
    }
}
