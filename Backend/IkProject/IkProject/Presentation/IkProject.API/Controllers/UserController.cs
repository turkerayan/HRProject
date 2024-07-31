

using Azure.Core;
using FluentValidation;
using IkProject.Application.Constants;
using IkProject.Application.Features.Command.Create.Personel;
using IkProject.Application.Features.Command.Update.UpdateUser;
using IkProject.Application.Features.Queries.GetAdminDetails;
using IkProject.Domain.Identities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SendGrid.Helpers.Errors.Model;
using System.Runtime.InteropServices;
using System.Security.Claims;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace IkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        private IValidator<AppUser> _validator;


        public UserController(IMediator mediator, IValidator<AppUser> validator)
        {
            _mediator = mediator;
            _validator = validator;
        }
        #region
        //[Authorize("SiteManager")]
        //[HttpPost("addpersonal")]
        //public async Task<IActionResult> AddPersonal(PersonalCommend command)
        //{
        //    if (command.UserId == Guid.Empty)
        //    {
        //        command.UserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
        //    }
        //    await _mediator.Send(command);
        //    return StatusCode(StatusCodes.Status201Created, "basrili olustu");
        //}

        ////// PUT api/<UserController>/5
        ////[HttpPut("{id}")]
        ////public void Put(int id, [FromBody] string value)
        ////{
        ////}

        ////// DELETE api/<UserController>/5
        ////[HttpDelete("{id}")]
        ////public void Delete(int id)
        ////{
        ////}
        #endregion

        [Authorize("SiteManagerRole")]
        [HttpPost("addpersonal")]
        public async Task<IActionResult> AddPersonal(PersonalCommend command)
        {
            if (command.UserId == Guid.Empty || command.UserId is null)
            {
                command.UserId = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            var response = await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created, response);
        }

        [Authorize("CompanyManagerOrPersonalOrSiteManager")]
        [HttpGet("getadmindetails")]
        public async Task<IActionResult> GetAdminDetails()
        {
            var request = new GetAdminDetailsRequest();
            request.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (request.UserId is null)
            {
                throw new Exception(Messages.UserNotFound);                
            }
            var response = await _mediator.Send(request);
            return Ok(response);

        }


        [Authorize("CompanyManagerOrPersonalOrSiteManager")]
        [HttpPost("updateuser")]
        public async Task<IActionResult> UpdateUser(UpdateUserCommand request)
        {
            request.Id = User.FindFirstValue(ClaimTypes.NameIdentifier)??throw new NotFoundException(Messages.UserNotFound);            
            var response = await _mediator.Send(request);
            return Ok(response);
        }
    }
}
