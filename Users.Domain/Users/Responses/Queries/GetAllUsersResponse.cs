using Users.Domain.Common.Pagination.Responses;

namespace Users.Domain.Users.Responses.Queries;

public class GetAllUsersResponse : PagedResponse<GetAllUsersItemResponse>
{
    public GetAllUsersResponse(IEnumerable<GetAllUsersItemResponse> items) : base(items)
    {
    }
}