using Microsoft.EntityFrameworkCore;
using QuanLyBanHangVer2.Application.Helper;
using QuanLyBanHangVer2.Data.EF;
using QuanLyBanHangVer2.ViewModel.Catalog.Products;
using QuanLyBanHangVer2.ViewModel.Common.Paging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.Application.Catalog.Products.Public
{
    public class PulbicProductService : IPulbicProductService
    {
        private readonly QuanLyBanHangVer2Context _context;

        public PulbicProductService(QuanLyBanHangVer2Context context)
        {
            _context = context;
        }

        public async Task<List<ProductViewModel>> GetAll()
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.productInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            var data = await query
            .Select(x => new ProductViewModel()
            {
                Id = x.p.Id,
                Name = x.pt.Name,
                DateCreated = x.p.CreateDate,
                Description = x.pt.Description,
                Details = x.pt.Details,
                LanguageId = x.pt.LanguageId,
                OriginalPrice = x.p.OriginalPrice,
                Price = x.p.Price,
                SeoAlias = x.pt.SeoAlias,
                SeoDescription = x.pt.SeoDescription,
                SeoTitle = x.pt.SeoTitle,
                Stock = x.p.Stock,
                ViewCount = x.p.ViewCount
            }).ToListAsync();
            return data;
        }

        public async Task<PagedResponse<List<ProductViewModel>>> GetAllPagingPublicAsync(PublicProductPagingRequest request)
        {
            //1.select join
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.productInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            //2.filter
            if (request.CategoryId != null)
            {
                query = query.Where(q => q.pic.CategoryId == request.CategoryId && q.pt.LanguageId == request.languagueId);
            }
            //3.paging
            var validFilter = new PaginationFilter(request.PageNumber, request.PageSize);
            int totalRecords = await query.CountAsync();
            var data = await query.Skip((validFilter.PageNumber - 1) * validFilter.PageSize).Take(validFilter.PageSize)
                .Select(x => new ProductViewModel()
                {
                    Id = x.p.Id,
                    Name = x.pt.Name,
                    DateCreated = x.p.CreateDate,
                    Description = x.pt.Description,
                    Details = x.pt.Details,
                    LanguageId = x.pt.LanguageId,
                    OriginalPrice = x.p.OriginalPrice,
                    Price = x.p.Price,
                    SeoAlias = x.pt.SeoAlias,
                    SeoDescription = x.pt.SeoDescription,
                    SeoTitle = x.pt.SeoTitle,
                    Stock = x.p.Stock,
                    ViewCount = x.p.ViewCount
                }).ToListAsync();
            //4. Select and projection
            var pagedResponse = PaginationHelper.CreatePagedReponse(data, validFilter, totalRecords);
            return pagedResponse;
        }
    }
}