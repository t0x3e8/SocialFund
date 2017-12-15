using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace SF.App.Extensions {
    public class SocialFundUserHandler : AuthorizationHandler<RegisteredAsUserRequirement>
    {        
        private IDictionary<string, int> simpleDb;
        public SocialFundUserHandler(IDictionary<string, int> db)
        {
            this.simpleDb = db;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RegisteredAsUserRequirement requirement)
        {
            if(!context.User.HasClaim(claim => claim.Type == ClaimTypes.Upn)) {
                return Task.CompletedTask;
            }

            var email = context.User.FindFirst(claim => claim.Type == ClaimTypes.Upn).Value;

            if (this.simpleDb[email] == 2) {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}