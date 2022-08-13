using QuanLyBanHangVer2.ViewModel.Common;
using System.Collections.Generic;

namespace QuanLyBanHangVer2.ViewModel.Catalog.Products
{
    public class ManageProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public string LanguageId { get; set; }
        public int? CategoryId { get; set; }
    }
}
