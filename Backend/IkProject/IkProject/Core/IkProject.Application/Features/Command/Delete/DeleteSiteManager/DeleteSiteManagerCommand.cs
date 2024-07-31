using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Delete.DeleteCompany
{
    public class DeleteSiteManagerCommand : IRequest<Unit>
    {
        public Guid Id { get; set; }
    }
}
