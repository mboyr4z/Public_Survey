using AutoMapper;
using Entities;
using Entities.Dtos;
using Entities.Models;
using Microsoft.AspNetCore.Identity;

namespace StoreApp.Infrastructure.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<RoleDtoForCreation, IdentityRole>().ReverseMap();
            
            CreateMap<account_LoginDto, IdentityUser>().ReverseMap();
            CreateMap<account_RegisterDto, IdentityUser>().ReverseMap();

            CreateMap<boss_createDto, Boss>();
            CreateMap<boss_updateDto, Boss>();

            CreateMap<author_createDto, Author>();
            CreateMap<author_updateDto, Author>();

            CreateMap<commentator_createDto, Commentator>();
            CreateMap<commentator_updateDto, Commentator>();

            CreateMap<company_createDto, Company>();
            CreateMap<company_updateDto, Company>();

            
        }
    }
}