using System.Threading.Tasks;
using Api.Core.Entities;
using Api.Core.Interfaces;
using Api.Core.Params;
using Api.Core.Specifications;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IGenericRepository<Product> _productRepository;
        public ProductsController(IGenericRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts([FromQuery] ProductParams productParams)
        {

            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);

            return Ok(await _productRepository.ListAsync(spec));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {

            var spec = new ProductsWithTypesAndBrandsSpecification(id);

            return Ok(await _productRepository.GetEntityWithSpec(spec));

        }
    }
}