using Microsoft.AspNetCore.Authorization;

namespace WebMVC.Attributes;

public class AydincAuthorize : AuthorizeAttribute
{
    protected bool AuthorizeCore(HttpContext httpContext)
    {
        // Cookie'den token'ı alın
        var accessToken = httpContext.Request.Cookies["AccessToken"];

        // Token kontrolü yapın (örneğin, geçerli olup olmadığını kontrol edin)
        if (!string.IsNullOrEmpty(accessToken))
        {
            return true;
        }

        return false;
    }

    //private bool IsTokenValid(string accessToken)
    //{
    //    // Token'ın geçerliliğini kontrol edin (örneğin, doğrulama yapın)
    //    // Geçerli ise true, değilse false dönün
    //}
}
