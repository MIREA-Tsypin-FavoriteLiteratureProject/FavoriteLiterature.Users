using Microsoft.AspNetCore.Authorization;

namespace Users.Application.Policies;

public class MinimumRoleRequirement : IAuthorizationRequirement
{
    public string RoleName { get; init; }

    public MinimumRoleRequirement(string roleName)
    {
        RoleName = roleName;
    }
}