using IkProject.Application.Features.Queries.GetAllExpense;
using IkProject.Application.Features.Queries.GetAllByUserExpense;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using IkProject.Application.Features.Command.Create.AddExpense;
using IkProject.Application.Features.Command.Update.UpdateExpense;
using IkProject.Application.Features.Command.Delete.DeleteExpense;

namespace IkProject.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("CompanyManagerOrPersonal")]

    public class ExpensesController : ControllerBase
    {
        private IMediator _mediator;

        public ExpensesController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost("add")]
        public async Task<IActionResult> Add(AddExpenseCommand request)
        {
            request.setUserId(new Guid(User.FindFirst(ClaimTypes.NameIdentifier)?.Value));

            var response = await _mediator.Send(request);

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [Authorize("CompanyManagerRole")]
        [HttpPatch("update")]
        public async Task<IActionResult> Update(UpdateExpenseCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("delete")]
        public async Task<IActionResult> Delete([FromQuery]DeleteExpenseCommand request)
        {
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("getall")]
        public async Task<IActionResult> GetAll(int currentPage, int pageSize)
        {
            var request = new GetAllExpenseRequest();
            request.CurrentPage = currentPage;
            request.PageSize = pageSize;
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpGet("getallbyuser")]
        public async Task<IActionResult> GetAllByUserId(int currentPage, int pageSize)
        {
            var request = new GetAllByUserExpenseRequest();
            request.CurrentPage = currentPage;
            request.PageSize = pageSize;
            request.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var response = await _mediator.Send(request);

            return Ok(response);
        }
    }
}
