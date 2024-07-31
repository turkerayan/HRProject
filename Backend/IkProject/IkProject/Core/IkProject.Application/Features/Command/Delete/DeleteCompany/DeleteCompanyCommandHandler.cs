using IkProject.Application.UnitOfWorks;
using MediatR;
using SendGrid.Helpers.Errors.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Delete.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Unit>
    {
        private readonly IUnitOfWork _unitOfWork;

        public DeleteCompanyCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = await _unitOfWork.GetReadRepository<Domain.Company.Company>().GetByIdAsync(request.Id.ToString());
            if (company == null) throw new BadRequestException("Kullanıcı bulunamadı");
            await _unitOfWork.GetWriteRepository<Domain.Company.Company>().DeleteAsync(company);
            await _unitOfWork.SaveAsync();
            return Unit.Value;
        }
    }
}
