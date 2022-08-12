using QuanLyBanHangVer2.ViewModel.Catalog.Products;
using QuanLyBanHangVer2.ViewModel.Common;

namespace QuanLyBanHangVer2.Application.Catalog.Products.Public
{
    public interface IPulbicProductService
    {
        PagedResult<ProductViewModel> GetAllPaging(int categoryId, int pageIndex, int pageSize);

    }
}
