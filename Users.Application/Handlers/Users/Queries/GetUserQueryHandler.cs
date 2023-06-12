using AutoMapper;
using MediatR;
using Users.Data.Repositories;
using Users.Domain.Users.Requests.Queries;
using Users.Domain.Users.Responses.Queries;

namespace Users.Application.Handlers.Users.Queries;

public sealed class GetUserQueryHandler : IRequestHandler<GetUserQuery, GetUserResponse>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;

    public GetUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<GetUserResponse> Handle(GetUserQuery query, CancellationToken cancellationToken)
    {
        var userData = await _unitOfWork.UsersRepository.GetAsync(x =>
                x.Id == query.Id,
            cancellationToken);

        return _mapper.Map<GetUserResponse>(userData);
    }
}