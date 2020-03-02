using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ProductShowcase.Entities;
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
        [Route("sequencial")]
        public ActionResult GetSequencial()
        {
            var products = _productsService.GetAllProducts(CastingScheme.Sequencially);
            var serialized = JsonConvert.SerializeObject(products);

            return Ok(serialized);
        }

        [HttpGet]
        [Route("bychuncks")]
        public ActionResult GetByChuncks()
        {
            var products = _productsService.GetAllProducts(CastingScheme.ByChunks);
            var serialized = JsonConvert.SerializeObject(products);

            return Ok(serialized);
        }
    }
}
