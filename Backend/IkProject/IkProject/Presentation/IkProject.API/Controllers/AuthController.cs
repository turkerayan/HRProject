using FluentValidation;
using IkProject.Application.Features.Command.AddRequestLeave;
using IkProject.Application.Features.Command.Create.AddSiteManager;
using IkProject.Application.Features.Command.Create.CreateCompanyManager;
using IkProject.Application.Features.Command.Create.Personel;
using IkProject.Application.Features.Command.Create.Register;
using IkProject.Application.Features.Command.Create.RePasswordToken;
using IkProject.Application.Features.Command.Delete.DeleteCompany;
using IkProject.Application.Features.Command.Update.UpdateCompanyManager;
using IkProject.Application.Features.Command.Update.UpdatePassword;

using IkProject.Application.Features.Quaries.Login;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace IkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("RegisterSiteManager")]
        public async Task<IActionResult> Register(CreateSiteManagerCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created, "basrili olustu");
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register(RegisterCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created, "basrili olustu");
        }
        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginQueryRequest query)
        {
            var response = await _mediator.Send(query);
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost("RePasswordToken")]
        public async Task<IActionResult> GenerateRePasswordResetToken([FromBody] RePasswordTokenCommand commend)
        {
            await _mediator.Send(commend);
            return StatusCode(StatusCodes.Status200OK);
        }
        [HttpPut("UpdatePassword")]
        public async Task<IActionResult> VerifyRePasswordToken([FromBody] UpdatePasswordCommand commend)
        {
            await _mediator.Send(commend);
            return StatusCode(StatusCodes.Status200OK, commend.ResetToken);
        }
        [Authorize("SiteManagerRole")]
        [HttpPost("CreateCompanyManager")]
        public async Task<IActionResult> CreateCompanyManager(CreateCompanyManagerCommend request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created, response);
        }
        [Authorize("SiteManagerRole")]
        [HttpPost("UpdateCompanyManager")]
        public async Task<IActionResult> UpdateCompanyManager(UpdateCompanyManagerCommand request)
        {
            await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK);
        }
        [Authorize("CompanyManagerRole")]
        [HttpPost("CreatePersonal")]
        public async Task<IActionResult> CreatePersonal(PersonalCommend commend)
        {
            if (commend.UserId is null || commend.UserId == Guid.Empty)
            {
                commend.UserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            await _mediator.Send(commend);
            return StatusCode(StatusCodes.Status201Created, "Basrili olustu");
        }

    }
}
