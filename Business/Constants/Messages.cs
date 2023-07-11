using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities.Concrete;

namespace Business.Constants
{
    // Hazır mesajların tutulduğu sınıf
    public static class Messages
    {
        // Genel
        public static string ProductAdded = "Ürün Eklendi";
        public static string ProductDeleted = "Ürün Silindi";
        /// Hata mesajları
        public static string ProductNameInvalid = "Ürün ismi geçersiz";
        public static string ProductNameShort = "Ürün ismi en az iki karakter olmalıdır";
        public static string MaintainceTime = "Sistem Bakımda";
        public static string ProductNameAlreadyExist = "Bu isimde başka bir ürün var";
        public static string ProductCountOfCategory = "Bu kategoriye daha fazla ürün eklenemez";
        public static string CategoryCount = "Kategori sayısı bu kadar fazlayken yeni ürün eklenemez";
        public static string AuthorizationDenied = "Yetkiniz yok";
        public static string UserRegistered = "Kullanıcı Kaydedildi";
        public static string UserNotFound = "Kullanıcı bulunamadı";
        public static string PasswordError = "Şifre Hatası";
        public static string SuccessfulLogin = "Başarıyla giriş yapıldı";
        public static string UserAlreadyExists = "Kullanıcının başka bir hesabı var";
        public static string AccessTokenCreated = "Token Oluşturuldu";
    }
}