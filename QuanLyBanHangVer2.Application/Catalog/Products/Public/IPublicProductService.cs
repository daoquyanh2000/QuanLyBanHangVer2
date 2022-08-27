using QuanLyBanHangVer2.ViewModel.Catalog.Products;
using QuanLyBanHangVer2.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.Application.Catalog.Products.Public
{
    public interface IPulbicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllPagingPublicAsync(PublicProductPagingRequest request);
        Task<List<ProductViewModel>> GetAll();

    }
}
