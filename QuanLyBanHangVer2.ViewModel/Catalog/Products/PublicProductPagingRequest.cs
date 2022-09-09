using QuanLyBanHangVer2.ViewModel.Common.Paging;
using QuanLyBanHangVer2.ViewModel.Common.Request;
using System.Collections.Generic;

namespace QuanLyBanHangVer2.ViewModel.Catalog.Products
{
    public class PublicProductPagingRequest : PagingRequestBase
    {
        public int? CategoryId { get; set; }
        public string languagueId { get; set; }
    }
}
