using AutoMapper;
using MediatR;
using Users.Data.Entities;
using Users.Data.Repositories;
using Users.Domain.Registration.Requests.Commands;
using Users.Domain.Registration.Responses.Commands;

namespace Users.Application.Handlers.Common.Registration.Commands;

public sealed class RegistrationCommandHandler : IRequestHandler<RegistrationCommand, RegistrationResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public RegistrationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<RegistrationResponse> Handle(RegistrationCommand command, CancellationToken cancellationToken)
    {
        var isUserExists = await _unitOfWork.UsersRepository.ExistsAsync(x =>
                x.Email == command.Email,
            cancellationToken);
        if (isUserExists)
        {
            throw new ArgumentException("A user with this Email already exists. Enter another one.", nameof(command.Email));
        }

        var user = _mapper.Map<User>(command)
            .SetPassword(command.Password);

        // TODO: Изменить в будущем
        user.RoleId = "user";

        await _unitOfWork.BeginTransactionAsync(new[]
        {
            () => _unitOfWork.UsersRepository.Add(user)
        });

        return new RegistrationResponse(user.Id);
    }
}