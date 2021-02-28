using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string Added = "Ekleme işlemi gerçekleştirildi.";
        public static string BrandNameInvalid = "Kayıt başarısız. Girilen Marka ismi 2 karakterden fazla olmalıdır.";
        public static string Deleted =  "Silme işlemi gerçekleştirildi.";
        public static string Listed = "Listelendi.";
        public static string Updated = "Güncelleme işlemi gerçekleştirildi.";
        public static string CarPriceInvalid = "Kayıt başarısız. Günlük ücret 0'dan büyük olmalıdır.";
        public static string RentalAddFailed = "Kayıt başarısız. Araç teslimi henüz gerçekleşmemiştir.";
    }
}
