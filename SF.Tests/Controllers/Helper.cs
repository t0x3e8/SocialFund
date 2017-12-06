using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

public static class Helper {
    public static ControllerContext CreateControllerContextWithUserClaim()
    {
        var controllerContext = new ControllerContext {
            HttpContext = new DefaultHttpContext{
                User = new ClaimsPrincipal(new ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, "abcd@email.me")
                }, "sometAuthentication"))
            }
        };

        return controllerContext;
    }
}