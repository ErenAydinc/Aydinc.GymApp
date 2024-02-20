using MediatR;
using Microsoft.AspNetCore.Mvc;
using Core.Security.Extensions;
using WebMVC.Models.Notifications;
using Newtonsoft.Json;
using AspNetCoreHero.ToastNotification.Abstractions;
using Starterkit._keenthemes.libs;
namespace WebMVC.Controllers;
public class BaseController : Controller
{
    protected IMediator Mediator =>
        _mediator ??=
            HttpContext.RequestServices.GetService<IMediator>()
            ?? throw new InvalidOperationException("IMediator cannot be retrieved from request services.");

    protected INotyfService Notyf =>
        _notyf ??=
            HttpContext.RequestServices.GetService<INotyfService>()
        ?? throw new InvalidOperationException("Notyf cannot be retrieved from request services.");

    protected IKTTheme Theme =>
        _theme ??=
               HttpContext.RequestServices.GetService<IKTTheme>()
        ?? throw new InvalidOperationException("KTTheme cannot be retrieved from request services.");

    protected WebApiConfiguration Configuration =>
        _configuration ??=
               HttpContext.RequestServices.GetService<WebApiConfiguration>()
        ?? throw new InvalidOperationException("KTTheme cannot be retrieved from request services.");

    private WebApiConfiguration? _configuration;
    private INotyfService? _notyf;
    private IMediator? _mediator;
    private IKTTheme? _theme;
    protected string getIpAddress()
    {
        string ipAddress = Request.Headers.ContainsKey("X-Forwarded-For")
            ? Request.Headers["X-Forwarded-For"].ToString()
            : HttpContext.Connection.RemoteIpAddress?.MapToIPv4().ToString()
                ?? throw new InvalidOperationException("IP address cannot be retrieved from request.");
        return ipAddress;
    }

    protected int getUserIdFromRequest() //todo authentication behavior?
    {
        int userId = HttpContext.User.GetUserId();
        return userId;
    }

}
