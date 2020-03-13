using System;
using System.Collections.Generic;

namespace AnaliticAlways.Repository.Entity
{
    public partial class Stock
    {
        public int Id { get; set; }
        public string PointOfSale { get; set; }
        public string Product { get; set; }
        public DateTime Date { get; set; }
        public int Count { get; set; }
    }
}
