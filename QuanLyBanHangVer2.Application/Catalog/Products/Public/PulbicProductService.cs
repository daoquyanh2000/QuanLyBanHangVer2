using QuanLyBanHangVer2.Data.EF;
using QuanLyBanHangVer2.ViewModel.Catalog.Products;
using QuanLyBanHangVer2.ViewModel.Common;
using System;

namespace QuanLyBanHangVer2.Application.Catalog.Products.Public
{
    public class PulbicProductService : IPulbicProductService
    {
        private readonly QuanLyBanHangVer2Context _context;
        public PulbicProductService(QuanLyBanHangVer2Context context)
        {
            _context = context;
        }

        public PagedResult<ProductViewModel> GetAllPaging(int categoryId, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }
    }
}
