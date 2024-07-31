using IkProject.Domain.Identities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Abstractions.Services
{
    public interface IMailServices
    {
        //Mail gönderme metodu
        Task SendMessageAsync(string to, string subject, string body, bool isBodyHtml = true);
        Task SendMessageAsync(string[] tos, string subject, string body, bool isBodyHtml = true);
        Task SendPasswordResetMailAsycn(AppUser user, string resetToken);
        Task SendCompanyManagerResetPasswordAsycn (CompanyManger user, string resetToken);

    }
}
