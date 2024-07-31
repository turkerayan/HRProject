using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.AddAdvancePayment
{
    public class AdvancePaymentValidator : AbstractValidator<AddAdvancePaymentCommand>
    {
        public AdvancePaymentValidator()
        {
            RuleFor(a => a.Currency)
                .NotEmpty()
                .WithMessage("Para birimi boş bırakılamaz");

            //RuleFor(a => a.RequestDate)
            //    .NotEmpty()
            //    .WithMessage("Avans isteme tarihi boş bırakılamaz.")
            //    .GreaterThan(DateTime.Now.AddDays(2))
            //    .WithMessage("Avans isteme tarihi şuandan en az 2 gün sonra için atılmalıdır.");

            RuleFor(a => a.Money)
                .NotEmpty()
                .WithMessage("İstenilen avans ücreti boş bırakılamaz.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("İstenilen avans ücreti 0 dan büyük olmalıdır.");

            RuleFor(a => a.Description)
                .NotEmpty()
                .WithMessage("Açıklama boş bırakılamaz")
                .MinimumLength(20)
                .WithMessage("Açıklama en az 20 karakterden oluşmalıdır.")
                .MaximumLength(300)
                .WithMessage("Açıklama en fazla 300 karakterden oluşmalıdır.");

            RuleFor(a => a.Type)
                .NotEmpty()
                .WithMessage("Avans türü boş bırakılamaz");
        }
    }
}
