using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SF.App.Models.Data;

namespace SF.App.Extensions {
    public class SocialFundAdminHandler : AuthorizationHandler<RegisteredAsAdminRequirement>
    {
        private SocialFundDBContext dBContext;
        public SocialFundAdminHandler(SocialFundDBContext dBContext)
        {
            this.dBContext = dBContext;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RegisteredAsAdminRequirement requirement)
        {
            if(!context.User.HasClaim(claim => claim.Type == ClaimTypes.Upn)) {
                return Task.CompletedTask;
            }

            var email = context.User.FindFirst(claim => claim.Type == ClaimTypes.Upn).Value;
            var employee = dBContext.Employees.Find(emp => emp.Email == email);

            if (employee != null && employee.RoleName == "Admin") {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}