using QuanLyBanHangVer2.Data.Entities.Abstract;
using System.Collections.Generic;

namespace QuanLyBanHangVer2.Data.Entities.Concrete
{
    public class Category : BaseEntity
    {
        public int SortOrder { get; set; }
        public bool IsShowOnHome { get; set; }
        public int? ParentId { get; set; }
        public List<ProductInCategory> ProductInCategories { get; set; }
        public List<CategoryTranslation> CategoryTranslations { get; set; }
    }
}