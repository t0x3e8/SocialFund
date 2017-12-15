using Microsoft.AspNetCore.Authorization;

namespace SF.App.Extensions {
    public class RegisteredAsAdminRequirement : IAuthorizationRequirement {

        public RegisteredAsAdminRequirement()
        {
        }
    }
}