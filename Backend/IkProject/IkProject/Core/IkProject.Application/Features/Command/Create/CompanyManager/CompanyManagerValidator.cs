using FluentValidation;
using IkProject.Application.Constants;
using IkProject.Application.Features.Command.Create.CreateCompanyManager;
using System.Text.RegularExpressions;

namespace IkProject.Application.Features.Command.Create.CompanyManager
{
    public class CompanyManagerValidator : AbstractValidator<CreateCompanyManagerCommend>
    {
        public CompanyManagerValidator()
        {
            RuleFor(p => p.Name)
                .NotEmpty()
                .WithMessage("İsim boş bırakılamaz");

            RuleFor(p => p.Surname)
                .NotEmpty()
                .WithMessage("Soy isim boş bırakılamaz");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("Email boş bırakılamaz.")
                .Must(email => email.EndsWith("@bilgeadam.com") || email.EndsWith("@bilgeadamboost.com"))
                .WithMessage("Email adresi @bilgeadam.com veya @bilgeadamboost.com ile bitmelidir.");

            RuleFor(p => p.Address)
                .NotEmpty()
                .WithMessage("Adres boş bırakılamaz");

            RuleFor(p => p.BirthDate)
                .NotEmpty().WithMessage("Doğum tarihi boş bırakılamaz.")
                .GreaterThan(DateTime.Now.AddYears(-70))
                .WithMessage("Doğum tarihi günümüzden en fazla 70 yıl öncesine kadar olabilir.");


            RuleFor(p => p.IdentityNo)
                .NotEmpty()
                .WithMessage("Tc kimlik numarası boş bırakılamaz")
                .Length(11)
                .WithMessage("Tc kimlik numarası 11 haneli olmalıdır")
                .Must(identityNo => TcKimlikNoValidator.Validate(identityNo)).WithMessage("Geçerli bir TC kimlik numarası giriniz.");

            RuleFor(p => p.Job)
                .NotEmpty()
                .WithMessage("Meslek boş bırakılamaz");

            RuleFor(p => p.Department)
                .NotEmpty()
                .WithMessage("Departmant boş bırakılamaz");

            RuleFor(p => p.ImgPath)
                .NotEmpty()
                .WithMessage("Resim boş bırakılamaz")
                .Must(path => Regex.IsMatch(path.FileName, @"\.(jpg|jpeg|png)$"))
                .WithMessage("Resim yolu geçerli bir resim dosyası uzantısı ile bitmelidir.");

            RuleFor(p => p.Wage)
                .NotEmpty().WithMessage("Maaş boş bırakılamaz.")
                .GreaterThan(17002.119m).WithMessage("Maaş 17.002,12 TL'den az olamaz.");

            RuleFor(p => p.StartAJob)
                .NotEmpty()
                .WithMessage("İş başlangıç tarihi boş bırakılamaz.")
                .GreaterThanOrEqualTo(new DateTime(1900, 1, 1))
                .WithMessage("İş başlangıç tarihi 1900 yılından küçük olamaz.")
                .GreaterThan(p => p.BirthDate.AddYears(18))
                .WithMessage("İş başlangıç tarihi doğum tarihinden en az 18 yıl sonrası olmalıdır.");

            RuleFor(p => p.LeavingJob)
                .GreaterThanOrEqualTo(new DateTime(1900, 1, 1))
                .WithMessage("İşten ayrılma tarihi 1900 yılından küçük olamaz.")
                .LessThanOrEqualTo(DateTime.Now)
                .WithMessage("İşten ayrılma tarihi bugünden ileri bir tarih olamaz.")
                .GreaterThan(p => p.StartAJob)
                .WithMessage("İşten ayrılma tarihi iş başlangıç tarihinden ileri bir tarih olmalıdır.");

         
        }
    }
}
