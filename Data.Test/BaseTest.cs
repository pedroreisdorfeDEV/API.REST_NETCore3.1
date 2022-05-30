using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using Xunit;

namespace Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTeste : IDisposable
    {
        private string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}"; 
        public ServiceProvider ServiceProvider { get; private set; } 

        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(o => 
                o.UseMySql($"Server=localhost;Port=3306;DataBase={dataBaseName};Uid=root;Pwd=...."), 
                  ServiceLifetime.Transient 
            );

            ServiceProvider = serviceCollection.BuildServiceProvider(); 
            using (var context = ServiceProvider.GetService<MyContext>()) 
            {
                context.Database.EnsureCreated(); 
            }
        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>())
            {
                context.Database.EnsureDeleted();
            }
        }
    }
}
