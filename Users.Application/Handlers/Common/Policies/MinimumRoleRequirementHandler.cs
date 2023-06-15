using System.Security;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Users.Application.Policies;
using Users.Data.Repositories;

namespace Users.Application.Handlers.Common.Policies;

public sealed class MinimumRoleRequirementHandler  : AuthorizationHandler<MinimumRoleRequirement>
{
    private readonly IUnitOfWork _unitOfWork;

    public MinimumRoleRequirementHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    protected override async Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumRoleRequirement requirement)
    {
        var roleId = context.User.FindFirst(claim => claim.Type == ClaimTypes.Role)?.Value;
        
        var roleData = await _unitOfWork.RolesRepository.GetAsync(x => x.Name == roleId);
        var roleRequirementData = await _unitOfWork.RolesRepository.GetAsync(x => x.Name == requirement.RoleName);
        
        if (roleData == null || roleData.Weight > roleRequirementData!.Weight)
        {
            throw new SecurityException("No access!");
        }
        
        context.Succeed(requirement);
    }
}