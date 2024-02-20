using Application.Features.Auth.Commands.Login;
using Application.Features.Auth.Commands.Register;
using Core.Application.Dtos;
using Core.CrossCuttingConcerns.Exceptions.Types;
using Core.Security.Entities;
using Core.Security.JWT;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Starterkit._keenthemes.libs;
using System.Configuration;
using System.Security.Claims;
using WebMVC;
using WebMVC.Controllers;
using WebMVC.Models.Notifications;

namespace Starterkit.Controllers;

public class AuthController : BaseController
{
    private readonly ILogger<DashboardsController> _logger;
    private readonly IKTTheme _theme;
    private readonly WebApiConfiguration _configuration;
    public AuthController(ILogger<DashboardsController> logger, IKTTheme theme, IConfiguration configuration)
    {
        _logger = logger;
        _theme = theme;
        const string configurationSection = "WebAPIConfiguration";
        _configuration =
            configuration.GetSection(configurationSection).Get<WebApiConfiguration>()
            ?? throw new NullReferenceException($"\"{configurationSection}\" section cannot found in configuration.");
    }

    [HttpGet("/signin")]
    public IActionResult SignIn()
    {
        return View(_theme.GetPageView("Auth", "SignIn.cshtml"));
    }

    [HttpGet("/signup")]
    public IActionResult SignUp()
    {
        return View(_theme.GetPageView("Auth", "SignUp.cshtml"));
    }

    [HttpGet("/reset-password")]
    public IActionResult ResetPassword()
    {
        return View(_theme.GetPageView("Auth", "ResetPassword.cshtml"));
    }

    [HttpGet("/new-password")]
    public IActionResult NewPassword()
    {
        return View(_theme.GetPageView("Auth", "NewPassword.cshtml"));
    }

    #region Methods
    [HttpPost("Login")]
    public async Task<IActionResult> Login(UserForLoginDto userForLoginDto)
    {
        try
        {
            LoginCommand loginCommand = new() { UserForLoginDto = userForLoginDto, IpAddress = getIpAddress() };
            LoggedResponse result = await Mediator.Send(loginCommand);

            if (result.RefreshToken is not null)
                setRefreshTokenToCookie(result.RefreshToken);
            //if (result.AccessToken is not null)
            //    setAccessTokenToCookie(result.AccessToken);
            var claims =new ClaimsIdentity(result?.AccessToken?.Claims,CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,new ClaimsPrincipal(claims));
            Notyf.Success("Giriþ Baþarýlý");
            return RedirectToAction("Index","Home");
        }
        catch (Exception ex)
        {
            Notyf.Error(ex.Message);
            return View(_theme.GetPageView("Auth", "SignIn.cshtml"));
        }
    }
    [HttpPost("Register")]
    public async Task<IActionResult> Register(UserForRegisterDto userForRegisterDto)
    {
        try
        {
            RegisterCommand registerCommand = new() { UserForRegisterDto = userForRegisterDto, IpAddress = getIpAddress() };
            RegisteredResponse result = await Mediator.Send(registerCommand);
            setRefreshTokenToCookie(result.RefreshToken);
            //return Created(uri: "", result.AccessToken);
            if (result != null)
            {
                Notyf.Success("Kullanýcý Kaydý Baþarýlý");
                return View(_theme.GetPageView("Auth", "SignUp.cshtml"));
            }
            else
            {

                return View(_theme.GetPageView("Auth", "SignUp.cshtml"));
            }
        }
        catch (Exception ex)
        {
            Notyf.Error("asasdasd");
            return View(_theme.GetPageView("Auth", "SignUp.cshtml"));
        }
        
        
    }
    #endregion

    #region Utilities
    private string getRefreshTokenFromCookies() =>
    Request.Cookies["refreshToken"] ?? throw new ArgumentException("Refresh token is not found in request cookies.");

    private void setRefreshTokenToCookie(RefreshToken<int, int> refreshToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true, Expires = DateTime.UtcNow.AddDays(7) };
        Response.Cookies.Append(key: "refreshToken", refreshToken.Token, cookieOptions);
    }

    private void setAccessTokenToCookie(AccessToken accessToken)
    {
        CookieOptions cookieOptions = new() { HttpOnly = true, Expires = accessToken.ExpirationDate };
        Response.Cookies.Append(key: "X-Access-Token","Bearer"+" "+ accessToken.Token , cookieOptions);
    }
    #endregion
}
