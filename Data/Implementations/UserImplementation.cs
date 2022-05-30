﻿using Data.Context;
using Data.Repository;
using Domain.Entities;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class UserImplementation : BaseRepository<UserEntity>, IUserRepository
    {
        private DbSet<UserEntity> _dataset;

        public UserImplementation(MyContext context) : base(context) 
        {
            _dataset = context.Set<UserEntity>(); 
        }
        public async Task<UserEntity> FindByLogin(string email) 
        {
            return await _dataset.FirstOrDefaultAsync(u => u.Email.Equals(email));  
        }
    }
}
