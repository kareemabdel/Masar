using System;
using System.Collections.Generic;
using System.Security.Claims;

namespace Masar.Infrastructure.Services
{
    public interface ICurrentUserService
    {
        Guid GetUserId();
        string GetUserLanguageKey();
        string GetUserEmail();
        bool IsAuthenticated();
        bool IsInRole(string role);
        bool IsAdmin();
        IEnumerable<Claim> GetUserClaims();
    }
}
