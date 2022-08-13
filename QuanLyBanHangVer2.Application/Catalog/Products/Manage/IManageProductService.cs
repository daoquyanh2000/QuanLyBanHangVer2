using Microsoft.AspNetCore.Http;
using QuanLyBanHangVer2.ViewModel.Catalog.Products;
using QuanLyBanHangVer2.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.Application.Catalog.Products.Manage
{
    public interface IManageProductService
    {
        Task<int> Create(ProductCreateRequest request);
        Task<int> Update(ProductUpdateRequest request);
        Task<int> Delete(int productId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int newStock);

        Task AddViewCount(int productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(ProductPagingRequest request);
        Task<int> AddImages(int productId, List<IFormFile> files);

        Task<int> UpdateImage(int imageId, bool IsDefault,string caption);

        Task<bool> DeleteImage(int imageId);
        

    }
}
