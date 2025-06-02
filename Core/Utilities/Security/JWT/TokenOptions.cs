using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class TokenOptions
    {
        public string Audience { get; set; } // Token'ın hedef kitlesi
        public string Issuer { get; set; } // Token'ı veren kuruluş
        public int AccessTokenExpiration { get; set; } // Erişim token'ının geçerlilik süresi (dakika cinsinden)
        public string SecurityKey { get; set; } // Token'ın imzalanmasında kullanılan güvenlik anahtarı
        //public string RefreshTokenSecurityKey { get; set; } // Yenileme token'ının güvenlik anahtarı
        //public int RefreshTokenExpiration { get; set; } // Yenileme token'ının geçerlilik süresi (gün cinsinden)
    }
}
