using Data.Context;
using Data.Implementations;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Xunit;
using Domain.Entities;

namespace Data.Test
{
    public class UsuarioCrudCompleto : BaseTest, IClassFixture<DbTeste> 
    {
        private IServiceProvider _serviceProvide;

        public UsuarioCrudCompleto(DbTeste dbTeste) 
        {
            _serviceProvide = dbTeste.ServiceProvider;
        }

        [Trait("CRUD", "UserEntity")] 
        [Fact(DisplayName = "CRUD de Usuário")]      
        public async Task E_Possivel_Realizar_CRUD_Usuario()
        {
            using (var context = _serviceProvide.GetService<MyContext>()) 
            {
                UserImplementation _repositorio = new UserImplementation(context); 
                UserEntity _entity = new UserEntity
                {  
                    Email = "teste@gmail.com",
                    Name = "Teste"
                };

                var _registroCriado = await _repositorio.InsertAsync(_entity); 
                Assert.NotNull(_registroCriado); 
                Assert.Equal("teste@gmail.com", _registroCriado.Email); 
                Assert.Equal("Teste", _registroCriado.Name);
                Assert.False(_registroCriado.Id == Guid.Empty);
            }
        }
    }
}
