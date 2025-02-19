using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyAspNetCoreApp.Wep.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        [Remote(action: "HasProductName",controller:"Products")]
        [StringLength(12, ErrorMessage = "En fazla 12 karater girilebilir")]
        [Required(ErrorMessage = "İsim Alanı Boş olamaz")]
        public string? Name { get; set; }


        [Required(ErrorMessage = "Fiyat Alanı Boş olamaz")]
        [Range(1, 2000, ErrorMessage = "1 ve 2000 aralağında olmalı")]
        public decimal? Price { get; set; }


        [Required(ErrorMessage = "Stok Alanı Boş olamaz")]
        [Range(1, 200, ErrorMessage = "1 ve 200 aralağında olmalı")]
        public int? Stock { get; set; }


        [Required(ErrorMessage = "Açıklama Alanı Boş olamaz")]
        [StringLength(300, MinimumLength = 50, ErrorMessage = "En fazla 300 en az 50 karater girilebilir")]
        public string Description { get; set; }



        [Required(ErrorMessage = "Renk Alanı Boş olamaz")]
        public string? Color { get; set; }


        [Required(ErrorMessage = "Yayınlanma Alanı Boş olamaz")]
        public DateTime? PublishDate { get; set; }



        public bool IsPublisy { get; set; }

        [Required(ErrorMessage = "Süre Alanı Boş olamaz")]
        public int? Expire { get; set; }


        [EmailAddress(ErrorMessage = "Email Alanını Uygun  Giriniz")]
        public string EmailAddress { get; set; }
    }
}
