using AutoMapper;
using MediatR;
using Users.Data.Repositories;
using Users.Domain.Users.Requests.Queries;
using Users.Domain.Users.Responses.Queries;

namespace Users.Application.Handlers.Users.Queries;

public sealed class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, GetAllUsersResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetAllUsersResponse> Handle(GetAllUsersQuery query, CancellationToken cancellationToken)
    {
        var userData = await _unitOfWork.UsersRepository.GetAllAsync(
            query.Skip, query.Take, cancellationToken);

        return new GetAllUsersResponse(_mapper.Map<IEnumerable<GetAllUsersItemResponse>>(userData));
    }
}