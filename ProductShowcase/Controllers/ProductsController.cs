using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductShowcase.Service;

namespace ProductShowcase.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private IProductsService _productsService;

        public ProductsController(IProductsService productsService)
        {
            _productsService = productsService;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var products = _productsService.GetAllProducts();
            var serialized = JsonConvert.SerializeObject(products);

            return Ok(serialized);
        }
    }
}
