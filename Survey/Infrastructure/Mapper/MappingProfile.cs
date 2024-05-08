using AutoMapper;
using Entities;
using Entities.Dtos;
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
        }
    }
}