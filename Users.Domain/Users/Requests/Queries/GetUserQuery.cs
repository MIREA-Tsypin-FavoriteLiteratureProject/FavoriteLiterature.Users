using MediatR;
using Users.Domain.Users.Responses.Queries;

namespace Users.Domain.Users.Requests.Queries;

public class GetUserQuery : IRequest<GetUserResponse>
{
    public Guid Id { get; init; }

    public GetUserQuery(Guid id) 
        => Id = id;
}