using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.AddExpense
{
    public class ExpenseValidator : AbstractValidator<AddExpenseCommand>
    {
        public ExpenseValidator()
        {
            //RuleFor(e => e.RequestDate)
            //    .NotEmpty()
            //    .WithMessage("Gider tarihi boş bırakılamaz.")
            //    .GreaterThan(DateTime.Now.AddMonths(-3))
            //    .WithMessage("Gider tarihi şuandan 3 ay öncesi ve sonraki tarihler için geçerlidir.");

            RuleFor(e => e.Currency)
                .NotEmpty()
                .WithMessage("Para birimi boş bırakılamaz");

            RuleFor(e => e.Image)
               .NotEmpty()
                .WithMessage("Resim boş bırakılamaz")
                .Must(path => Regex.IsMatch(path.FileName, @"\.(jpg|jpeg|png)$"))
                .WithMessage("Resim yolu geçerli bir resim dosyası uzantısı ile bitmelidir.");

            RuleFor(e => e.Money)
                .NotEmpty()
                .WithMessage("İstenilen gider ücreti boş bırakılamaz.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("İstenilen gider ücreti 0 dan büyük olmalıdır.");
        }
    }
}
