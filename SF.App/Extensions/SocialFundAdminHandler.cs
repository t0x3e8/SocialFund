using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SF.App.Models.Data;
using SF.App.Models.Repositories;

namespace SF.App.Extensions {
    public class SocialFundAdminHandler : AuthorizationHandler<RegisteredAsAdminRequirement>
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public SocialFundAdminHandler(IEmployeeRepository employeeRepository)
        {
            this.EmployeeRepository = employeeRepository;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RegisteredAsAdminRequirement requirement)
        {
            if(!context.User.HasClaim(claim => claim.Type == ClaimTypes.Upn)) {
                return Task.CompletedTask;
            }

            var email = context.User.FindFirst(claim => claim.Type == ClaimTypes.Upn).Value;
            var employee = this.EmployeeRepository.Get(email);

            if (employee != null && employee.RoleName == "Admin") {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}