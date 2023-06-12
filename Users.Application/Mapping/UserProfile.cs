using AutoMapper;
using Users.Data.Entities;
using Users.Domain.Registration.Requests.Commands;
using Users.Domain.Users.Responses.Queries;

namespace Users.Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<RegistrationCommand, User>();

        CreateMap<User, GetUserResponse>();
    }
}