using MediatR;
using Users.Domain.Common.Pagination.Requests;
using Users.Domain.Users.Responses.Queries;

namespace Users.Domain.Users.Requests.Queries;

public class GetAllUsersQuery : PagedRequest, IRequest<GetAllUsersResponse>
{
}