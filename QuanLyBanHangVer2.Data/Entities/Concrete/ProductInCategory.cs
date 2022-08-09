using QuanLyBanHangVer2.Data.Entities.Abstract;

namespace QuanLyBanHangVer2.Data.Entities.Concrete
{
    public class ProductInCategory
    {
        public int ProductId { get; set; }
        public Product Product { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}