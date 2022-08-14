using Microsoft.AspNetCore.Mvc;
using QuanLyBanHangVer2.Application.Catalog.Products.Public;
using System.Threading.Tasks;

namespace QuanLyBanHangVer2.BackendApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class  ProductController : ControllerBase
    {
        private readonly IPulbicProductService _pulbicProductService;

        public ProductController(IPulbicProductService pulbicProductService)
        {
            _pulbicProductService = pulbicProductService;
        }

        [HttpGet]
       public async Task<IActionResult> Get()
        {
            var product = await _pulbicProductService.GetAll();
            return Ok(product);
        }
    }
}
