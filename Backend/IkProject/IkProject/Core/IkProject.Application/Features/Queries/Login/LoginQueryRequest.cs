using MediatR;

namespace IkProject.Application.Features.Quaries.Login
{
    public class LoginQueryRequest : IRequest<LoginQueryResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
