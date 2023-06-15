namespace Users.Domain.Registration.Responses.Commands;

public class RegistrationResponse
{
    public Guid Id { get; init; }

    public RegistrationResponse(Guid id)
        => Id = id;
}