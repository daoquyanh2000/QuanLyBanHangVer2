using QuanLyBanHangVer2.Data.Entities.Abstract;
using System.Collections.Generic;

namespace QuanLyBanHangVer2.Data.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public decimal Price { get; set; }
        public decimal OriginalPrice { get; set; }
         public int Stock { get; set; }
        public int ViewCount { get; set; }

        public List<ProductInCategory> ProductInCategories {get;set;}

        public List<OrderDetail> OrderDetails { get; set; }

        public List<Cart> Carts { get; set; }
        public List<ProductImage> ProductImages { get; set; }

        public List<ProductTranslation> ProductTranslations { get; set; }
    }
}