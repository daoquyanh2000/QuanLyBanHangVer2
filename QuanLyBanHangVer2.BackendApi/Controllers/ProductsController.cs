using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuanLyBanHangVer2.Application.Catalog.Products.Manage;
using QuanLyBanHangVer2.Application.Catalog.Products.Public;
using QuanLyBanHangVer2.ViewModel.Catalog.Products;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IPulbicProductService _pulbicProductService;
        private readonly IManageProductService _manageProductService;

        public ProductsController(IPulbicProductService pulbicProductService, IManageProductService manageProductService)
        {
            _pulbicProductService = pulbicProductService;
            _manageProductService = manageProductService;
        }

        [HttpGet("{productId}/{languagueId}")]
        public async Task<IActionResult> GetById(int productId, string languagueId)
        {
            var product = await _manageProductService.GetProductById(productId, languagueId);
            return Ok(product);
        }

        [HttpGet]
        public async Task<IActionResult> GetPaging([FromQuery] PublicProductPagingRequest request)
        {
            var product = await _pulbicProductService.GetAllPagingPublicAsync(request);
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromForm] ProductCreateRequest request)
        {
            var product = await _manageProductService.CreateProduct(request);
            if (product == 0) return BadRequest();
            return Ok(product);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromForm] ProductUpdateRequest request)
        {
            var product = await _manageProductService.UpdateProduct(request);
            if (product == 0) return BadRequest();
            return Ok(product);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleleProduct(int productId)
        {
            var product = await _manageProductService.DeleteProduct(productId);
            if (product == 0) return BadRequest();
            return Ok(product);
        }

        [HttpPatch("{productId}/price/{newPrice}")]
        public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice)
        {
            await _manageProductService.UpdatePrice(productId, newPrice);
            return Ok();
        }

        [HttpPatch("{productId}/stock/{newStock}")]
        public async Task<IActionResult> UpdateStock(int productId, int newStock)
        {
            var product = await _manageProductService.UpdateStock(productId, newStock);
            if (product == false) return BadRequest();
            return Ok(product);
        }

        [HttpPost("{productId}/images")]
        public async Task<IActionResult> AddImageToProduct(int productId, List<IFormFile> files)
        {
            int count = await _manageProductService.AddImages(productId, files);
            if (count > 0)
            {
                return Ok();
            }
            else return BadRequest();
        }

        [HttpDelete("Images/{imageId}")]
        public async Task<IActionResult> RemoveImage(int imageId)
        {
            int count = await _manageProductService.DeleteImage(imageId);
            if (count > 0)
            {
                return Ok();
            }
            else return BadRequest();
        }
    }
}