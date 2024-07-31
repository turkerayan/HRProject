using IkProject.Application.Abstractions;
using IkProject.Application.Features.Command.Register;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Identities;
using IkProject.Domain.RequestL;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IkProject.Application.Features.Command.AddRequestLeave
{
    public class RequestLeaveCommandHandler :IRequestHandler<RequestLeaveCommand,Unit>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileHelper _fileHelper;

        public RequestLeaveCommandHandler( IMapper mapper, IUnitOfWork unitOfWork, IFileHelper fileHelper)
        {
            _mapper = mapper;
            _fileHelper=fileHelper;
            _unitOfWork=unitOfWork;
        }


        public async Task<Unit> Handle(RequestLeaveCommand request, CancellationToken cancellationToken)
        {
            var leave = _mapper.Map<RequestLeave, RequestLeaveCommand>(request);

            if (leave.StartingDate >= DateTime.Now && (leave.EndDate>leave.StartingDate))
            {
                var leaveWriteRepo = _unitOfWork.GetWriteRepository<RequestLeave>();
                await leaveWriteRepo.AddAsync(leave);
                await _unitOfWork.SaveAsync();
            }
           
            return Unit.Value;
        }
    }
}
