using IkProject.Application.Features.Command.Create.Company;
using IkProject.Application.Features.Command.Delete.DeleteCompany;
using IkProject.Application.Features.Command.Update.UpdateCompany;
using IkProject.Application.Features.Queries.Company.GetAllCompany;
using IkProject.Application.Features.Queries.Company.GetCompany;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace IkProject.API.Controllers
{
    [Route("api/[controller]")]
    [Authorize("SiteManagerRole")]
    [ApiController]
    public class CompanyController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CompanyController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("addcompany")]
        public async Task<IActionResult> CreateCompany(CompanyCommand request)
        {
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status201Created, response);
        }
        [HttpGet("getallcompany")]
        public async Task<IActionResult> GetAllCompany([FromQuery] GetAllCompanyRequest request)
        {
            var resposne = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, resposne);
        }
        [HttpGet("getcompany")]
        public async Task<IActionResult> GetCompany([FromQuery] Application.Features.Queries.Company.GetCompany.GetCompanyRequest request)
        {
            if(request.Id == Guid.Empty)
            {
                request.Id = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [HttpGet("getcompanysitemanager")]
        public async Task<IActionResult> GetCompanySiteManager([FromQuery] Application.Features.Queries.Company.GetCompanySiteManager.GetCompanySiteManagerRequest request)
        {
            if (request.Id == Guid.Empty)
            {
                request.Id = new Guid(User.FindFirstValue(ClaimTypes.NameIdentifier));
            }
            var response = await _mediator.Send(request);
            return StatusCode(StatusCodes.Status200OK, response);
        }
        [HttpPut("updatecompany")]
        public async Task<IActionResult> UpdateCompany(UpdateCompanyCommend commend)
        {
            await _mediator.Send(commend);
            return StatusCode(StatusCodes.Status202Accepted, "Güncelleme başarılı");
        }
        [HttpDelete("deletecompany")]
        public async Task<IActionResult> DeleteCompany([FromQuery] DeleteCompanyCommand command)
        {
            await _mediator.Send(command);
            return StatusCode(StatusCodes.Status200OK, "Başarılı bir şekilde silindi");
        }
    }
}
