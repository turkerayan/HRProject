using Azure.Core;
using IkProject.Application.Features.Command.Create.PermissionRequest;
using IkProject.Application.Features.Command.Create.PermissionType;
using IkProject.Application.Features.Command.Delete.PermissionRequest;
using IkProject.Application.Features.Command.Put.PermissionRequest;
using IkProject.Application.Features.Queries.PermissionRequest.GetAllCompanyManagerPermissionRequest;
using IkProject.Application.Features.Queries.PermissionRequest.GetAllPermissionRequest;
using IkProject.Application.Features.Queries.PermissionType.GetAllPermissionType;
using IkProject.Application.Features.Queries.PermissionType.GetPermissonType;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace IkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PermissionController(IMediator mediator)
        {
            _mediator = mediator;
        }
        [Authorize("CompanyManagerOrPersonal")]
        [HttpGet("GetAllPermissionType")]
        public async Task<IActionResult> GetAllPermissionType([FromQuery] GetAllPermissionTypeQueryRequest request)
        {
            //var request = new GetAllPermissionTypeQueryRequest() {AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier)};
            request.TakeId(User.FindFirstValue(ClaimTypes.NameIdentifier));
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [Authorize("CompanyManagerOrPersonal")]
        [HttpGet("GetPermissionType")]
        public async Task<IActionResult> GetPermissionType([FromQuery] GetPermissionTypeQueryRequest request)
        {
            var response = await _mediator.Send(request);

            return StatusCode(StatusCodes.Status200OK, response);
        }
        [Authorize("CompanyManagerOrPersonal")]
        [HttpGet("GetAllPermissionRequest")]
        public async Task<IActionResult> GetAllPermissionRequest()
        {
            var request = new GetAllPermissionRequestQueryRequest() { AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier) };
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [Authorize("CompanyManagerOrPersonal")]
        [HttpGet("GetAllCompManagerPermissionRequest")]
        public async Task<IActionResult> GetAllCompManagerPermissionRequest()
        {
            var request = new GetAllCompanyManagerPermissionRequestQueryRequest();
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [Authorize("CompanyManagerRole")]
        [HttpPost("CreatePermissionType")]
        public async Task<IActionResult> CreatePermissionType(PermissionCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created);
        }
        [Authorize("CompanyManagerOrPersonal")]
        [HttpPost("CreatePermissionRequest")]
        public async Task<IActionResult> CreatePermissionRequest([FromBody] PermissionRequestCommand command)
        {
            command.AppUserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var result = await _mediator.Send(command);
            return StatusCode(StatusCodes.Status201Created, result);
        }
        [Authorize("CompanyManagerRole")]
        [HttpPatch("PermissionRequestApprovalStatus")]
        public async Task<IActionResult> PermissionRequestApprovalStatus([FromBody] PermissionRequestApprovalStatusCommand command)
        {

            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status200OK);
        }

        [Authorize("CompanyManagerOrPersonal")]
        [HttpDelete("DeletePermissionRequest")]
        public async Task<IActionResult> DeletePermissionRequest([FromQuery]PermissonRequestDeleteCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status200OK, "Basarili bir sekilde silindi");
        }

    }
}
