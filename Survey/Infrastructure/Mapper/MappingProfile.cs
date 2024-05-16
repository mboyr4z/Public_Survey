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

            CreateMap<boss_createDto, Boss>().ReverseMap();
            CreateMap<boss_updateDto, Boss>().ReverseMap();

            CreateMap<author_createDto, Author>().ReverseMap();
            CreateMap<author_updateDto, Author>().ReverseMap();

            CreateMap<commentator_createDto, Commentator>().ReverseMap();
            CreateMap<commentator_updateDto, Commentator>().ReverseMap();

            CreateMap<company_createDto, Company>().ReverseMap();
            CreateMap<company_updateDto, Company>().ReverseMap();

            
        }
    }
}