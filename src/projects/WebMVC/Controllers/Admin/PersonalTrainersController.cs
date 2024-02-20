using Application.Features.Auth.Commands.Login;
using Core.Application.Dtos;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Starterkit._keenthemes.libs;
using System.Security.Claims;
using Application.Features.PersonalTrainers.Commands.Create;
using Microsoft.AspNetCore.Authorization;

namespace WebMVC.Controllers.Admin;
public class PersonalTrainersController : BaseController
{
    private readonly ILogger<PersonalTrainersController> _logger;
    public PersonalTrainersController(ILogger<PersonalTrainersController> logger)
    {
        _logger = logger;
    }
    public IActionResult Index()
    {
        return View(Theme.GetPageView("Admin/PersonalTrainers","Index.cshtml"));
    }


    #region Methods

    [HttpPost("create")]
    //[Authorize]
    public async Task<IActionResult> Create(CreatePersonalTrainerCommand createPersonalTrainerCommand)
    {
        try
        {
            var userId =getUserIdFromRequest();
            CreatedPersonalTrainerResponse result = await Mediator.Send(createPersonalTrainerCommand);

            Notyf.Success("Personal Trainer Eklendi");
            return Index();
        }
        catch (Exception ex)
        {
            Notyf.Error(ex.Message);
            return View(Theme.GetPageView("Auth", "SignIn.cshtml"));
        }
    }

    #endregion
}
