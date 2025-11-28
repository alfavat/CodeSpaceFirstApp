using AutoMapper;
using MyApp.Domain.Entities;
using MyApp.Domain.Dtos;

namespace MyApp.Application;
public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<UserRegisterDto, User>();
    }
}
