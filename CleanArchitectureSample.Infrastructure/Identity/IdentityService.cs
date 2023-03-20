﻿using CleanArchitectureSample.Application.Common.Interfaces;
using CleanArchitectureSample.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitectureSample.Infrastructure.Identity;

public class IdentityService : IIdentityService
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory;
    private readonly IAuthorizationService authorizationService;

    public IdentityService(
        UserManager<ApplicationUser> userManager,
        IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
        IAuthorizationService authorizationService)
    {
        this.userManager = userManager;
        this.userClaimsPrincipalFactory = userClaimsPrincipalFactory;
        this.authorizationService = authorizationService;
    }

    public async Task<string?> GetUserNameAsync(string userId) 
        => (await this.userManager.Users.FirstAsync(u => u.Id == userId)).UserName;

    public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
    {
        var user = new ApplicationUser
        {
            UserName = userName,
            Email = userName,
        };

        var result = await this.userManager.CreateAsync(user, password);

        return (result.ToApplicationResult(), user.Id);
    }

    public async Task<bool> IsInRoleAsync(string userId, string role)
    {
        var user = this.userManager.Users.SingleOrDefault(u => u.Id == userId);
        return user != null && await this.userManager.IsInRoleAsync(user, role);
    }

    public async Task<bool> AuthorizeAsync(string userId, string policyName)
    {
        var user = this.userManager.Users.SingleOrDefault(u => u.Id == userId);
        if (user == null)
        {
            return false;
        }

        var principal = await this.userClaimsPrincipalFactory.CreateAsync(user);
        var result = await this.authorizationService.AuthorizeAsync(principal, policyName);

        return result.Succeeded;
    }

    public async Task<Result> DeleteUserAsync(string userId)
    {
        var user = this.userManager.Users.SingleOrDefault(u => u.Id == userId);
        return user != null ? await DeleteUserAsync(user) : Result.Success();
    }

    public async Task<Result> DeleteUserAsync(ApplicationUser user)
    {
        var result = await this.userManager.DeleteAsync(user);
        return result.ToApplicationResult();
    }
}
