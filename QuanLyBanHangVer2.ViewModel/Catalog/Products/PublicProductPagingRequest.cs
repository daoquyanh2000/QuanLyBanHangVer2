using QuanLyBanHangVer2.ViewModel.Common;
using System.Collections.Generic;

namespace QuanLyBanHangVer2.ViewModel.Catalog.Products
{
    public class PublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
    }
}
