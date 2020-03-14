using AnaliticAlways.Repository;
using AnaliticAlways.Repository.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace AnalyticAlways.Evaluacion
{
    public static class StartUp
    {
        private static ServiceProvider _serviceProvider;

        public static ServiceProvider ServiceProvider
        {
            get => _serviceProvider = _serviceProvider ?? new ServiceCollection().AddDbContext<AnalyticAlwaysContext>()
                      .AddSingleton<StockRepository>()
                      .BuildServiceProvider();
        }
    }
}

