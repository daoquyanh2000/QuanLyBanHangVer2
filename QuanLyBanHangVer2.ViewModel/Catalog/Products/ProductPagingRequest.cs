using QuanLyBanHangVer2.ViewModel.Common;
using System.Collections.Generic;

namespace QuanLyBanHangVer2.ViewModel.Catalog.Products
{
    public class ProductPagingRequest : PagingRequestBase
    {
        public string Keyword { get; set; }
        public List<int> CategoryIds { get; set; }
    }
}
