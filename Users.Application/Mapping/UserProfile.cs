using AutoMapper;
using Users.Data.Entities;
using Users.Domain.Registration.Requests.Commands;

namespace Users.Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegistrationCommand, User>();
    }
}