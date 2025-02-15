using Microsoft.AspNetCore.Authorization;

namespace Masar.Application.Common.Extensions.Helpers
{
    public class Policies
    {
        public const string Admin =  "Admin";
        public const string User = "User";
       


        public static AuthorizationPolicy AdminPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .RequireRole(Admin).Build();
        }

        public static AuthorizationPolicy AuditorPolicy()
        {
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser()
                .RequireRole(User).Build();
        }

       


    }
}
