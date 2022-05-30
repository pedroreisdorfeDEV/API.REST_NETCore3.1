﻿using AutoMapper;
using Domain.Dtos.User;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrossCutting.Mappings
{
    public class EntityToDtoProfile : Profile
    {
        public EntityToDtoProfile()
        {
            CreateMap<UserDto, UserEntity>().ReverseMap(); 

            CreateMap<UserDtoCreateResult, UserEntity>().ReverseMap();

            CreateMap<UserDtoUpdateResult, UserEntity>().ReverseMap(); 

        }
    }
}
