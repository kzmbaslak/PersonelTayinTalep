using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static readonly string TransferTypeAdded = "TransferType Eklendi";
        public static readonly string TransferTypeNameInvaled = "TransferType İsmi Geçersiz";
        public static readonly string TransferTypeNameAlreadyExists = "Aynı isimde zaten bir TrasfferType var.";

        public static readonly string TransferRequestListed = "TransferRequest leri Listelendi";
        public static readonly string TransferRequestUpdated = "TransferRequest Güncellendi";

        public static readonly string CourthouseListed = "Adliyeler Listelendi.";
        public static readonly string CourthouseFinded = "Adliye Bulundu.";
        public static readonly string CourthouseNameAlredyExists = "Zaten bu isimde bir adliye var.";
        public static readonly string CourthouseNotFound = "Adliye Bulunamadı.";
        public static readonly string CourthouseUpdated = "Adliye Güncellendi.";
        public static readonly string CourthouseNameNotFound = "Adliye ismi bulunamadı.";


        public static readonly string CityNamAlredyExits= "Bu isimde bir şehir zaten var.";
        public static readonly string CityAdded = "Şehirler Eklendi.";
        public static readonly string CityDeleted = "Şehir silindi.";
        public static readonly string CityNotFound = "Şehir Bulunamadı.";
        public static readonly string CityUpdated = "Şehir Güncellendi.";


        public static readonly string TransferRequesAlredyExist = "Bu tayin talebi zaten mevcut.";
        public static readonly string TransferRequesNotExist = "Bu tayin talebi mevcut değildir.";


        public static readonly string AuthorizationDenied = "Yetkiniz Yoktur.";
        public static readonly string UserRegistered = "Kayıt oldu.";
        public static readonly string UserNotFound = "Kullanıcı Bulunamadı";
        public static readonly string PasswordError = "Parola Hatası";
        public static readonly string SuccessfulLogin = "Başarılı Giriş";
        public static readonly string UserAlreadyExists = "Kullanıcı Zaten Mevcut";
        public static readonly string AccessTokenCreated = "Access Token Oluşturuldu";
    }
}
