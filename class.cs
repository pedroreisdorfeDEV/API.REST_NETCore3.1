using Api.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Domain.Entities
{
    public class UserEntitty : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
    }
}