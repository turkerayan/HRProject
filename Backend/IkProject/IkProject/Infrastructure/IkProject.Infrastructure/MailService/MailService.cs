using IkProject.Application.Abstractions.Services;
using IkProject.Domain.Identities;
using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Text;
namespace IkProject.Infrastructure.Services
{
    public class MailService : IMailServices
    {
        readonly IConfiguration _configuration;
        public MailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public async Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true)
        {
            await SendMessageAsync(new[] { to }, subject, body, isBodyHtml);

        }
        public async Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true)
        {
            MailMessage mail = new();
            mail.IsBodyHtml = isBodyHtml;
            foreach (var to in tos)
                mail.To.Add(to);

            mail.Subject = subject;
            mail.Body = body;
            mail.From = new(_configuration["SmtpSettings:Epost"], "Ik Project", Encoding.UTF8);

            SmtpClient smtpClient = new();
            smtpClient.Credentials = new NetworkCredential(_configuration["SmtpSettings:Epost"], _configuration["SmtpSettings:Password"]);
            smtpClient.Port = 587;
            smtpClient.EnableSsl = true;
            smtpClient.Host = _configuration["SmtpSettings:Host"];

            await smtpClient.SendMailAsync(mail);
        }
        public async Task SendPasswordResetMailAsycn(AppUser user, string resetToken)
        {
            StringBuilder mail = new();
            mail.Append(@$"Merhaba <b>{user.Name} {user.SecondName} {user.Surname} {user.SecondSurname} </b> <br>");

            mail.AppendLine("Şifre değiştirme talebinde bulunduysanız aşağıda 'Onayla' butonuna tıklayınız. Eğer bu talep sizin tarafınızdan yapılmadıysa lütfen yardım servisimizle iletişime geçiniz.<br>");

            mail.AppendLine($"<a href='https://ikdeneme.azurewebsites.net/{user.Id}/{resetToken}'>Onayla</a>");
            mail.Append("<br> Eğer bu talebi siz yapmadıysanız veya herhangi bir sorunla karşılaşırsanız, lütfen hemen bizimle iletişime geçin:<br>");
            mail.Append($"<a href = 'mcuyazilim@gmail.com'>");
            mail.Append("<br>Güveliğiniz bizim için önemlidir<br><bold>Teşekkürler</bold>");
            await SendMessageAsync(user.Email, "Şifre Yenileme Talebi", mail.ToString());
        }

        public async Task SendCompanyManagerResetPasswordAsycn(CompanyManger user, string resetToken)
        {
            StringBuilder mail = new();
            mail.Append(@$"Merhaba <b>{user.Name} {user.SecondName} {user.Surname} {user.SecondSurname} </b> <br>");

            mail.AppendLine("Bulunmus oldugunuz projede sizi site yonetici yaptik. Ilk girisiniz oldugu icin sifre degistirmeniz gerekmektedir. Iyi gunler dileriz <br>");

            mail.AppendLine($"<a href='https://ikdeneme.azurewebsites.net/{user.Id}/{resetToken}'>Onayla</a>");
            mail.Append("<br> Eğer bu talebi siz yapmadıysanız veya herhangi bir sorunla karşılaşırsanız, lütfen hemen bizimle iletişime geçin:<br>");
            mail.Append($"<a href = 'mcuyazilim@gmail.com'>");
            mail.Append("<br>Güveliğiniz bizim için önemlidir<br><bold>Teşekkürler</bold>");
            await SendMessageAsync(user.Email, "Şifre Yenileme Talebi", mail.ToString());
        }
    }
}

