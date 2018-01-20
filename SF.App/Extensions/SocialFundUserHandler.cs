using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using SF.App.Models.Data;
using SF.App.Models.Repositories;

namespace SF.App.Extensions
{
    public class SocialFundUserHandler : AuthorizationHandler<RegisteredAsUserRequirement>
    {
        public IEmployeeRepository EmployeeRepository { get; set; }
        public SocialFundUserHandler(IEmployeeRepository employeeRepository)
        {
            this.EmployeeRepository = employeeRepository;
        }
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, RegisteredAsUserRequirement requirement)
        {
            if (!context.User.HasClaim(claim => claim.Type == ClaimTypes.Upn))
            {
                return Task.CompletedTask;
            }

            var email = context.User.FindFirst(claim => claim.Type == ClaimTypes.Upn).Value;
            var employee = this.EmployeeRepository.Get(email);

            if (employee != null && (employee.RoleName == "User" || employee.RoleName == "Admin")) {
                context.Succeed(requirement);
            }
            else
            {
                context.Fail();
            }

            return Task.CompletedTask;
        }
    }
}