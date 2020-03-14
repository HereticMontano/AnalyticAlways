using AnaliticAlways.Repository.Entity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AnaliticAlways.Repository.Repository
{
    public class StockRepository
    {
        private AnalyticAlwaysContext _context;

        public StockRepository(AnalyticAlwaysContext context) => _context = context;

        //Se ejecuta un TRUNCATE por velocidad, pero tener en cuenta que el usuario de SQL de producion necesita permiso para executar un TRUNCATE.
        public void TruncateTable() => _context.Database.ExecuteSqlRaw("TRUNCATE TABLE Stock");

        /*Por problemas de performance para meter 17 millones de registros (y no morir de impaciencia) 
          uso una libreria de terceros, 17 millones de registro en 292960 ms = 5 minutos*/
        public void Insert(List<Stock> elements) => _context.BulkInsert(elements, operation =>
        {
            operation.AutoMapOutputDirection = false;
            operation.BatchSize = 10000;
        });
    }
}
