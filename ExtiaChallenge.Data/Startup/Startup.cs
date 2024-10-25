using ExtiaChallenge.Data.Contracts;
using ExtiaChallenge.Data.Models;
using ExtiaChallenge.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Prism.Ioc;
using System.IO;

namespace ExtiaChallenge.Data.Startup
{
    public static class Startup
    {
        public static void RegisterServices(IContainerRegistry containerRegistry)
        {
            var configuration = new ConfigurationBuilder()
         .SetBasePath(Directory.GetCurrentDirectory())
         .AddJsonFile("efpt.config.json", optional: false, reloadOnChange: true)
         .Build();

            var connectionString = configuration.GetConnectionString("ExtiaChallengeConnection");

            containerRegistry.Register<DbContextOptions<ExtiaChallengeContext>>(container =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ExtiaChallengeContext>();
                optionsBuilder.UseSqlServer(connectionString);
                return optionsBuilder.Options;
            });

            containerRegistry.Register<ExtiaChallengeContext>();
            containerRegistry.Register<ISoldierService, SoldierService>();
        }
    }
}
