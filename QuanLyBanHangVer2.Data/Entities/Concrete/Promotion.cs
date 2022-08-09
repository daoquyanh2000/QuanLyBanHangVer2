using QuanLyBanHangVer2.Data.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.Data.Entities.Concrete
{
    public class Promotion  
    {
        public int Id { set; get; }
        public DateTime FromDate { set; get; }
        public DateTime ToDate { set; get; }
        public bool ApplyForAll { set; get; }
        public int? DiscountPercent { set; get; }
        public decimal? DiscountAmount { set; get; }
        public int ProductIds { set; get; }
        public string ProductCategoryIds { set; get; }
        public Status Status { set; get; }
        public string Name { set; get; }
    }
}
