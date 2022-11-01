﻿namespace FinalProjectAPI.DTO
{
    public class ProductsDTO
    {
        public int رقم_الصنف { get; set; }
        public string? اسم_الصنف { get; set; }
        public double سعر_البيع { get; set; }
        public int اجمالي_الكميه { get; set; }
        public double سعر_الشراء { get; set; }
        public string? الوصف { get; set; }

        public ICollection<int>? ارقام_الفواتير { get; set; }

        public int الشراء_رقم_الصنف { get; set; }
        public int البيع_رقم_الصنف { get; set; }

        public int مرتجع_البيع_رقم_الصنف { get; set; }
        public int مرتجع_الشراء_رقم_الصنف { get; set; }
    }
}
