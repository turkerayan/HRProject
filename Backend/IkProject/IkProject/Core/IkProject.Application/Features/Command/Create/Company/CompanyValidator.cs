using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace IkProject.Application.Features.Command.Create.Company
{
    public class CompanyValidator : AbstractValidator<CompanyCommand>
    {
        public CompanyValidator()
        {

            RuleFor(c => c.Name)
                .NotEmpty().WithMessage("İsim boş bırakılamaz");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("Email boş bırakılamaz");

            RuleFor(c => c.ImgPath)
                .NotEmpty()
                .WithMessage("Resim boş bırakılamaz")
                .Must(path => Regex.IsMatch(path.FileName, @"\.(jpg|jpeg|png)$"))
                .WithMessage("Resim yolu geçerli bir resim dosyası uzantısı ile bitmelidir.");

            RuleFor(c => c.Address)
                .NotEmpty().WithMessage("Adress boş bırakılamaz");

            RuleFor(c => c.TaxNo)
                .NotEmpty().WithMessage("Vergi numarasi boş bırakılamaz")
                .Length(10).WithMessage("Vergi numarasi 10 haneli olmalıdır")
                .Must(taxNo => !taxNo.StartsWith("0")).WithMessage("Vergi numarasi 0 ile başlayamaz");

            RuleFor(compnay => compnay.MersisNo)
                .Length(16).WithMessage("Mersis numarası 16 haneli olmalıdır")
                .NotEmpty().WithMessage("Mersis numarası boş bırakılamaz");


            RuleFor(company => company.EstablishmentDate)
                .NotEmpty().WithMessage("Kuruluş süresi boş bırakılamaz")
                .GreaterThanOrEqualTo(new DateTime(1900, 1, 1))
                .WithMessage("Kuruluş tarihi 1900 yılından küçük olamaz."); ;


            RuleFor(company => company.ContractStartDate)
                .NotEmpty()
                .WithMessage("Kontrant başlangıç tarihi boş bırakılamaz.")
                .GreaterThanOrEqualTo(new DateTime(1990, 1, 1))
                .WithMessage("Kontrant başlangıç tarihi 1990 yılından küçük olamaz.");

            RuleFor(company => company.ContractEndDate)
                .NotEmpty()
                .WithMessage("Kontrant bitiş tarihi boş bırakılamaz.")
                .GreaterThan(p => p.ContractStartDate)
                .WithMessage("Kontrant başlangıç tarihi kontrat bitiş tarihinden ileri bir tarih olmalıdır.");
        }
    }
}
