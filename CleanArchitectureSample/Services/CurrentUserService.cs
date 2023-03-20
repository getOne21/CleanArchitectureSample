using CleanArchitectureSample.Application.Common.Interfaces;
using System.Security.Claims;

namespace CleanArchitectureSample.Services;

public class CurrentUserService : ICurrentUserService
{
    private readonly IHttpContextAccessor httpContextAccessor;

    public CurrentUserService(IHttpContextAccessor httpContextAccessor) 
        => this.httpContextAccessor = httpContextAccessor;

    public string? UserId
        => this.httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);
}
