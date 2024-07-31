using IkProject.Application.Features.Command.Create.AddAdvancePayment;
using IkProject.Application.Features.Command.Delete.DeleteAdvancePayment;
using IkProject.Application.Features.Command.Update.UpdateAdvancePayment;
using IkProject.Application.Features.Queries.GetAllAdvancePayment;
using IkProject.Application.Features.Queries.GetAllByUserAdvancePayment;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdvancePaymentsController : ControllerBase
    {
        private IMediator _mediator;

        public AdvancePaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [Authorize("PersonalRole")]
        [HttpPost("add")]
        public async Task<IActionResult> Add([FromBody] AddAdvancePaymentCommand request)
        {
            request.UserId = new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value);

            var response = await _mediator.Send(request);

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [Authorize("CompanyManagerRole")]
        [HttpPatch("update")]
        public async Task<IActionResult> Update([FromBody] UpdateAdvancePaymentCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize("PersonalRole")]
        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery] DeleteAdvancePaymentCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize("CompanyManagerOrPersonal")]
        [HttpGet("getall")]
        public async Task<IActionResult> GetAll(int currentPage, int pageSize)
        {
            var request = new GetAllAdvancePaymentRequest();
            request.CurrentPage = currentPage;
            request.PageSize = pageSize;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [Authorize("CompanyManagerOrPersonal")]
        [HttpGet("getallbyuser")]
        public async Task<IActionResult> GetAllByUserId(int currentPage, int pageSize)
        {
            var request = new GetAllByUserAdvancePaymentRequest();
            request.CurrentPage = currentPage;
            request.PageSize = pageSize;
            request.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
