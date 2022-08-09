using QuanLyBanHangVer2.Data.Entities.Abstract;
using QuanLyBanHangVer2.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace QuanLyBanHangVer2.Data.Entities.Concrete
{
    public class OrderDetail
    {
        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}
