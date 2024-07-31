using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IkProject.Application.Constants
{
    public static class Messages
    {
        public static readonly string UserNotFound = "Kullanıcı bulunamadı.";
        public static readonly string IsNotUser = "Kullanıcı eğer siz değilseniz lütfen bildiriniz";
        public static readonly string UserUpdateFailed = "Kullanıcı güncellenirken bir aksilik meydana geldi";
        public static readonly string UsernameOrPasswordInvalid = "Kullanıcı adı veya şifre hatalı";

        public static readonly string CompanyAlreadyExists = "Şirket zaten bulunmaktadır";
        public static readonly string DateInvalid = "Geçerli bir tarih giriniz, Geçerli tarih 01.01.1990 ve sonrasıdır";

        public static readonly string ExpenseNotFound = "Harcama talebi bulunamadi";
        public static readonly string AdvancePaymentNotFound = "Avans talebi bulunamadi";
        public static readonly string UserMustUseTurkishlira = "Bireysel kullanıcı sadece Türk Lirası isteği gönderebilir";
        public static readonly string AdvancePaymentOrCurrencyNotDefined = "Avans türü veya para birimi geçerli değil.";
        public static readonly string ExpenceorCurrencyNotDefined = "Harcama türü veya para birimi geçerli değil.";
        public static readonly string AdvancePaymentMustThisRange = "Avans miktarı 300₺ - 500.000₺ arasında olmalıdır.";
        public static readonly string ImageNotSaved = "Resim kaydedilemedi";
        public static readonly string ApprovalstatusNotDefined = "Onay durumu geçerli değil.";
        public static readonly string PermissionRequestNotFound = "Izin talebi bulunamadi";             
        public static readonly string PageAndCurrentSizeNotLessThanOne = "Geçersiz sayfa sayısı  veya veri sayısı";        
        public static readonly string FileTypeInvalid = "Dosya türü geçersiz";
        public static readonly string TokenNotFound = "Token Bulunamadi";

    }
}
