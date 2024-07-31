using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.PermissionRequest
{
    public class PermissionValidator : AbstractValidator<PermissionRequestCommand>
    {
        public PermissionValidator()
        {
            RuleFor(p => p.PermissionStart)
                .NotEmpty()
                .WithMessage("İzin alınacak tarihi boş bırakılamaz.")
                .GreaterThanOrEqualTo(DateTime.Now.AddDays(1))
                .WithMessage("İzin alınacak tarih şimdi ki tarihten en az bir gün sonrası olmalıdır.");

            //RuleFor(p => p.PermissionEnd)
            //    .LessThan(p => p.PermissionEnd)
            //    .WithMessage("İzin bitiş tarihi izin alınan tarihten büyük olmalıdır.");
        }
    }
}
