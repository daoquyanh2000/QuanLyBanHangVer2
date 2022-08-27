﻿using Microsoft.AspNetCore.Http;
using QuanLyBanHangVer2.Data.Entities.Concrete;
using System.Collections.Generic;

namespace QuanLyBanHangVer2.ViewModel.Catalog.Products
{
    public class ProductCreateRequest
    {
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
        public int Stock { get; set; }
        public string Name { set; get; }
        public string Description { set; get; }
        public string Details { set; get; }
        public string SeoDescription { set; get; }
        public string SeoTitle { set; get; }
        public string SeoAlias { get; set; }
        public string LanguageId { set; get; }
        public IFormFile ThumbnailImage { set; get; }
    }
}
