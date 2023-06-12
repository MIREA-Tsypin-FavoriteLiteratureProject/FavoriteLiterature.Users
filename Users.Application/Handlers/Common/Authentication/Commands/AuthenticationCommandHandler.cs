using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Users.Application.Options;
using Users.Data.Repositories;
using Users.Domain.Authentication.Requests.Commands;
using Users.Domain.Authentication.Responses.Commands;

namespace Users.Application.Handlers.Common.Authentication.Commands;

public sealed class AuthenticationCommandHandler : IRequestHandler<AuthenticationCommand, AuthenticationResponse>
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly JwtOptions _jwtOptions;

    public AuthenticationCommandHandler(IUnitOfWork unitOfWork, IOptions<JwtOptions> jwtOptions)
    {
        _unitOfWork = unitOfWork;
        _jwtOptions = jwtOptions.Value;
    }

    public async Task<AuthenticationResponse> Handle(AuthenticationCommand command, CancellationToken cancellationToken)
    {
        var userData = await _unitOfWork.UsersRepository.GetAsync(x =>
                x.Email == command.Email,
            cancellationToken);
        if (userData == null)
        {
            throw new ArgumentException("User is not found!", nameof(command.Email));
        }

        var isValidUser = BCrypt.Net.BCrypt.Verify(command.Password, userData.PasswordHash);
        if (!isValidUser)
        {
            throw new ArgumentException("Password is not valid", nameof(command.Password));
        }

        var claims = new[]
        {
            new Claim(ClaimTypes.NameIdentifier, userData.Id.ToString()),
            new Claim(ClaimTypes.Email, userData.Email),
            new (ClaimTypes.Role, userData.RoleId)
        };

        var accessToken = GenerateAccessToken(claims);

        return new AuthenticationResponse(JwtBearerDefaults.AuthenticationScheme, accessToken, 
            _jwtOptions.LifetimeInMinutes);
    }

    private string GenerateAccessToken(IEnumerable<Claim> claims)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            claims: claims,
            expires: DateTime.UtcNow.AddMinutes(_jwtOptions.LifetimeInMinutes),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}