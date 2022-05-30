using Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Test
{
    public abstract class BaseTest
    {
        public BaseTest()
        {

        }
    }

    public class DbTeste : IDisposable
    {
        public string dataBaseName = $"dbApiTest_{Guid.NewGuid().ToString().Replace("-", string.Empty)}"; // para cada teste será criado um banco de dados. Gera um guid para não ficar repetindo

        public ServiceProvider ServiceProvider { get; private set; }

        public DbTeste()
        {
            var serviceCollection = new ServiceCollection();
            serviceCollection.AddDbContext<MyContext>(o => o.UseMySql($"Server=localhost;Port=3306;DataBase={dataBaseName};Uid=root;Pwd=7667"), ServiceLifetime.Transient); // transiente cria conexão com banco de dados para cada requisição

            ServiceProvider = serviceCollection.BuildServiceProvider(); // agora tenho um provedor aqui. Banco de dadps buildado para serviceCollection
            using (var context = ServiceProvider.GetService<MyContext>()) // using, pq após ser criado o context vai ser retirado da memória. Injetei MyContext no GetService
            {
                context.Database.EnsureCreated(); // concluindo minha criação do banco de dados
            } // criando banco de dados e fazendo as migrações

        
        }

        public void Dispose()
        {
            using (var context = ServiceProvider.GetService<MyContext>()) // using, pq após ser criado o context vai ser retirado da memória. Injetei MyContext no GetService
            {
                context.Database.EnsureDeleted();
            }
        }
    }

}
