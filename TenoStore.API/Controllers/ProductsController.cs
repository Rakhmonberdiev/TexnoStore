using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TenoStore.API.Dtos;
using TenoStore.API.Errors;
using TenoStore.API.Helpers;
using TexnoStore.Core.Entities;
using TexnoStore.Core.Interfaces;
using TexnoStore.Core.Specifications;

namespace TenoStore.API.Controllers
{
    public class ProductsController : BaseApiController
    {
        private readonly IGenericRepository<Product> productsRepo;
        private readonly IGenericRepository<ProductBrand> productBrandRepo;
        private readonly IGenericRepository<ProductType> productTypeRepo;
        private readonly IMapper mapper;

        public ProductsController(IGenericRepository<Product> productsRepo, IGenericRepository<ProductBrand> productBrandRepo, IGenericRepository<ProductType> productTypeRepo, IMapper mapper)
        {
            this.productsRepo = productsRepo;
            this.productBrandRepo = productBrandRepo;
            this.productTypeRepo = productTypeRepo;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<Pagination<ProductToReturnDto>>> GetProducts([FromQuery]ProductSpecParams productParams)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(productParams);
            var countSpec  = new ProductWithFiltersForCountSpec(productParams);
            var totalItems = await productsRepo.CountAsync(countSpec);

            var products = await productsRepo.ListAsync(spec);
             
            var data = mapper.Map<IReadOnlyList<Product>, IReadOnlyList<ProductToReturnDto>>(products);
            return Ok(new Pagination<ProductToReturnDto>(productParams.PageSize,productParams.PageIndex,totalItems,data)); 
        }


        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
        public async Task<ActionResult<ProductToReturnDto>> GetProduct(int id)
        {
            var spec = new ProductsWithTypesAndBrandsSpecification(id);
            var product = await productsRepo.GetEntityWithSpec(spec);
            if(product == null)
            {
                return NotFound(new ApiResponse(404));
            }
            return mapper.Map<Product, ProductToReturnDto>(product);

        }

        [HttpGet("brands")]
        public async Task<ActionResult<IReadOnlyList<ProductBrand>>> GetProductBrands()
        {
            return Ok(await productBrandRepo.ListAllAsync());
        }
        [HttpGet("types")]
        public async Task<ActionResult<IReadOnlyList<ProductType>>> GetProductTypes()
        {
            return Ok(await productTypeRepo.ListAllAsync());
        }

    }
}
