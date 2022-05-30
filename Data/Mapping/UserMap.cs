﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Mapping
{
    public class UserMap : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder) 
        {
            builder.ToTable("User"); 

            builder.HasKey(u => u.Id); 

            builder.HasIndex(u => u.Email).IsUnique(); 

            builder.Property(u => u.Name).IsRequired().HasMaxLength(60); 

            builder.Property(u => u.Email).HasMaxLength(100); 
        }
    }
}
