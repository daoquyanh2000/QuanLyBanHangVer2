using Microsoft.AspNetCore.Http;
using QuanLyBanHangVer2.ViewModel.Catalog.ProductImages;
using QuanLyBanHangVer2.ViewModel.Catalog.Products;
using QuanLyBanHangVer2.ViewModel.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.Application.Catalog.Products.Manage
{
    public interface IManageProductService
    {
        Task<int> AddProduct(ProductCreateRequest request);
        Task<int> UpdateProduct(ProductUpdateRequest request);
        Task<int> DeleteProduct(int productId);
        Task<bool> UpdatePrice(int productId, decimal newPrice);
        Task<bool> UpdateStock(int productId, int newStock);

        Task AddViewCount(int productId);
        Task<PagedResult<ProductViewModel>> GetAllPaging(ManageProductPagingRequest request);
        Task<int> AddImages(int productId, ProductImageCreateRequest request);

        Task<int> UpdateImage(int imageId, bool IsDefault,string caption);

        Task<int> DeleteImage(int imageId);

    
    }
}
