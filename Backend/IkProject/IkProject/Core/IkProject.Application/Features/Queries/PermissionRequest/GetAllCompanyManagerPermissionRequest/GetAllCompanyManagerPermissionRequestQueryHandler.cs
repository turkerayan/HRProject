using Azure.Core;
using IkProject.Application.Abstractions;
using IkProject.Application.Features.Queries.GetAllExpense;
using IkProject.Application.UnitOfWorks;
using IkProject.Domain.Requests;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Queries.PermissionRequest.GetAllCompanyManagerPermissionRequest
{
    public class GetAllCompanyManagerPermissionRequestQueryHandler : IRequestHandler<GetAllCompanyManagerPermissionRequestQueryRequest, IList<GetAllCompanyManagerPermissionRequestQueryResponse>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCompanyManagerPermissionRequestQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<IList<GetAllCompanyManagerPermissionRequestQueryResponse>> Handle(GetAllCompanyManagerPermissionRequestQueryRequest request, CancellationToken cancellationToken)
        {
            var allPermissionRequest = await _unitOfWork.GetReadRepository<Domain.Requests.PermissionRequest>()
                .GetAllAsync(include: a => a.Include(p => p.AppUser), orderBy: a => a.OrderByDescending(a => a.Created));

            var permissionTypeList = await _unitOfWork.GetReadRepository<Domain.Requests.PermissionType>().GetAllAsync();
           

            var response = new List<GetAllCompanyManagerPermissionRequestQueryResponse>();

            try
            {
                foreach (var permissionReq in allPermissionRequest)
                {
                    response.Add
                        (new()
                        {
                            Id = permissionReq.Id,
                            PermissionStart = permissionReq.PermissionStart,
                            PermissionEnd = permissionReq.PermissionEnd,
                            Name = permissionReq.PermissionType.Name,
                            ApprovalStatus=permissionReq.ApprovalStatus,
                            ReplyDate= permissionReq.ReplyDate,
                            NumberOfDay = permissionReq.NumberOfDay,
                            UserEmail = permissionReq.AppUser.Email,
                            UserImage = permissionReq.AppUser.ImgPath,
                            UserFirstName = permissionReq.AppUser.Name,
                            UserSecondName = permissionReq.AppUser.SecondName,
                            UserSurname = permissionReq.AppUser.Surname,
                            UserSecondSurname = permissionReq.AppUser.SecondSurname,
                            Created=permissionReq.Created

                        });
                }
            }
            catch (Exception e)
            {

                throw e;
            }

            return response;
        }
    }
}
