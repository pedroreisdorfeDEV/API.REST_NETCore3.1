using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; } // struct Guid representa um identificador único global: um valor de 16 bytes que, se gerado randomicamente, irá gerar um identificador (quase) único.

        private DateTime? _createAt // "?" pq recebe um null
        {
            get { return _createAt; } // recebe e retorna a property interna
            set { _createAt = (value == null ? DateTime.UtcNow : value); }
            // no set se faz um tratameto. Se se chegar null, ai receberá um DateTime.UtcNow(data é hora do meu servidr local). Caso não for null (:), então passo o valor que está vindo como parâmetro
        }

        public DateTime? UpdateAt { get; set; }

    }
}




