using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Starterkit._keenthemes.libs;
using Starterkit.Controllers;
using WebMVC.Attributes;

namespace WebMVC.Controllers.Admin;
public class HomeController : BaseController
{
    private readonly ILogger<HomeController> _logger;
    //private readonly IKTTheme _theme;
    //private readonly WebApiConfiguration _configuration;
    public HomeController(ILogger<HomeController> logger/* IKTTheme theme, IConfiguration configuration*/)
    {
        _logger = logger;
        //_theme = theme;
        //const string configurationSection = "WebAPIConfiguration";
        //_configuration =
        //    configuration.GetSection(configurationSection).Get<WebApiConfiguration>()
        //    ?? throw new NullReferenceException($"\"{configurationSection}\" section cannot found in configuration.");
    }
    //[AydincAuthorize]
    //[Authorize]
    public IActionResult Index()
    {
        var id = getUserIdFromRequest();
        return View(Theme.GetPageView("Admin/Home", "AdminIndex.cshtml"));
    }
}
