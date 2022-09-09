using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using QuanLyBanHangVer2.Application.Catalog.Products.Manage;
using QuanLyBanHangVer2.Application.Common;
using QuanLyBanHangVer2.Application.Helper;
using QuanLyBanHangVer2.Data.EF;
using QuanLyBanHangVer2.Data.Entities.Concrete;
using QuanLyBanHangVer2.ViewModel.Catalog.Products;
using QuanLyBanHangVer2.ViewModel.Common.Paging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.Application.Catalog.Manage.Products
{
    public class ManageProductService : IManageProductService
    {
        private readonly QuanLyBanHangVer2Context _context;
        private readonly IStorageService _storageService;

        public ManageProductService(
            QuanLyBanHangVer2Context context,
            IStorageService storageService)
        {
            _context = context;
            _storageService = storageService;
        }

        public async Task AddViewCount(int productId)
        {
            var product = await _context.Products.FindAsync(productId);
            product.ViewCount++;
            await _context.SaveChangesAsync();
        }

        public async Task<int> CreateProduct(ProductCreateRequest request)
        {
            var product = new Product()
            {
                Price = request.Price,
                OriginalPrice = request.OriginalPrice,
                Stock = request.Stock,
                ViewCount = 0,
                ProductTranslations = new List<ProductTranslation>()
                {
                    new ProductTranslation()
                    {
                        Name =request.Name,
                        Description =request.Description,
                        Details =request.Details,
                        SeoDescription =request.SeoDescription,
                        SeoTitle =request.SeoTitle,
                        SeoAlias =request.SeoAlias,
                        LanguageId =request.LanguageId,
                    }
                }
            };
            //save image
            if (request.ThumbnailImage != null)
            {
                product.ProductImages = new List<ProductImage>()
                {
                    new ProductImage()
                    {
                        Caption = "Thumbnail image",
                        ImagePath = await SaveFile(request.ThumbnailImage),
                        IsDefault = true,
                    }
                };
            }
            await _context.Products.AddAsync(product);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteProduct(int productId)
        {
            var product = await _context.Products.FindAsync(productId);

            if (product != null)
            {
                foreach (var item in product.ProductImages)
                {
                    await _storageService.DeleteFileAsync(item.ImagePath);
                }
                _context.Products.Remove(product);
            }

            return await _context.SaveChangesAsync();
        }

        public async Task<PagedResponse<List<ProductViewModel>>> GetAllPaging(ManageProductPagingRequest request)
        {
            var query = from p in _context.Products
                        join pt in _context.ProductTranslations on p.Id equals pt.ProductId
                        join pic in _context.productInCategories on p.Id equals pic.ProductId
                        join c in _context.Categories on pic.CategoryId equals c.Id
                        select new { p, pt, pic };
            if (!string.IsNullOrEmpty(request.Keyword))
            {
                query = query.Where(x => x.pt.Name.ToLower().Contains(request.Keyword.ToLower()));
            }
            if (request.CategoryId != null && request.CategoryId != 0)
            {
                query = query.Where(q => request.CategoryId == q.pic.CategoryId);
            }
            var validFilter = new PaginationFilter(request.PageNumber, request.PageSize);
            var totalRecords = await query.CountAsync();
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
            var pageResult = PaginationHelper.CreatePagedReponse(data, validFilter, totalRecords);
            return pageResult;
        }

        public async Task<int> UpdateProduct(ProductUpdateRequest request)
        {
            var product = await _context.Products.FindAsync(request.Id);
            var productTranslations = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == request.Id
            && x.LanguageId == request.LanguageId);
            if (product == null || productTranslations == null) throw new QuanLyBanHangVer2Exception($"Cannot find a product with id: {request.Id}");

            productTranslations.Name = request.Name;
            productTranslations.SeoAlias = request.SeoAlias;
            productTranslations.SeoDescription = request.SeoDescription;
            productTranslations.SeoTitle = request.SeoTitle;
            productTranslations.Description = request.Description;
            productTranslations.Details = request.Details;
            //update file
            if (request.ThumbnailImage != null)
            {
                var thumbnailImage = await _context.ProductImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
                if (thumbnailImage != null)
                {
                    thumbnailImage.ImagePath = await SaveFile(request.ThumbnailImage);
                    _context.ProductImages.Update(thumbnailImage);
                }
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<bool> UpdatePrice(int productId, decimal newPrice)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new QuanLyBanHangVer2Exception($"Cannot find a product with id: {productId}");

            product.Price = newPrice;
            return await _context.SaveChangesAsync() > 0;
        }

        public async Task<bool> UpdateStock(int productId, int newStock)
        {
            var product = await _context.Products.FindAsync(productId);
            if (product == null) throw new QuanLyBanHangVer2Exception($"Cannot find a product with id: {productId}");

            product.Stock = newStock;
            return await _context.SaveChangesAsync() > 0;
        }

        private async Task<string> SaveFile(IFormFile file)
        {
            var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
            var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
            await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
            return fileName;
        }

        public async Task<ProductViewModel> GetProductById(int productId, string languageId)
        {
            var product = await _context.Products.FindAsync(productId);
            var productTranslation = await _context.ProductTranslations.FirstOrDefaultAsync(x => x.ProductId == productId
            && x.LanguageId == languageId);

            var categories = await (from c in _context.Categories
                                    join ct in _context.CategoryTranslations on c.Id equals ct.CategoryId
                                    join pic in _context.productInCategories on c.Id equals pic.CategoryId
                                    where pic.ProductId == productId && ct.LanguageId == languageId
                                    select ct.Name).ToListAsync();

            var image = await _context.ProductImages.Where(x => x.ProductId == productId && x.IsDefault == true).FirstOrDefaultAsync();

            var productViewModel = new ProductViewModel
            {
                Id = product.Id,
                DateCreated = product.CreateDate,
                Description = productTranslation != null ? productTranslation.Description : null,
                LanguageId = productTranslation.LanguageId,
                Details = productTranslation != null ? productTranslation.Details : null,
                Name = productTranslation != null ? productTranslation.Name : null,
                OriginalPrice = product.OriginalPrice,
                Price = product.Price,
                SeoAlias = productTranslation != null ? productTranslation.SeoAlias : null,
                SeoDescription = productTranslation != null ? productTranslation.SeoDescription : null,
                SeoTitle = productTranslation != null ? productTranslation.SeoTitle : null,
                Stock = product.Stock,
                ViewCount = product.ViewCount,
            };
            return productViewModel;
        }

        public async Task<int> AddImages(int productId, List<IFormFile> files)
        {
            if (files.Count > 0)
            {
                foreach (var file in files)
                {
                    var productImage = new ProductImage()
                    {
                        ProductId = productId,
                    };
                    if (file != null)
                    {
                        productImage.ImagePath = await SaveFile(file);
                    }
                    _context.ProductImages.Add(productImage);
                }
            }
            else
            {
                return 0;
            }
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteImage(int imageId)
        {
            var productImage = _context.ProductImages.Find(imageId);
            _context.ProductImages.Remove(productImage);
            return await _context.SaveChangesAsync();
        }
    }
}