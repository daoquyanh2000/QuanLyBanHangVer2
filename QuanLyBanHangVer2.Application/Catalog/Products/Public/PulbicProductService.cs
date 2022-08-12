using QuanLyBanHangVer2.ViewModel.Catalog.Products;
using QuanLyBanHangVer2.ViewModel.Common;
using System;

namespace QuanLyBanHangVer2.Application.Catalog.Products.Public
{
    public class PulbicProductService : IPulbicProductService
    {
        public PagedResult<ProductViewModel> GetAllPaging(int categoryId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

    }
}
