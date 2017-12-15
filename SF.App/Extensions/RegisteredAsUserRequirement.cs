using Microsoft.AspNetCore.Authorization;

namespace SF.App.Extensions {
    public class RegisteredAsUserRequirement : IAuthorizationRequirement {

        public RegisteredAsUserRequirement()
        {
        }
    }
}