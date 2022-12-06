using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shop.API.Filters;
using Shop.Core.DTOs;
using Shop.Core.Models;
using Shop.Core.Services;

namespace Shop.API.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CustomBaseController
    {
        private readonly IMapper _mapper;       
        private readonly IProductService _productService;

        public ProductsController(IMapper mapper, IService<Product> service, IProductService productService)
        {
              _mapper = mapper;
              _productService = productService;
        }

        //GET  api/products/GetProductsWithCategory
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductsWithCategory()
        {
            return CreateActionResult(await _productService.GetProductsWitCategoryAsync());

        }



       // GET / api / products
        [HttpGet]   
        public async Task<IActionResult> All()
        {
            var products = await _productService.GetAllAsync();
            var productsDtos=_mapper.Map<List<ProductDto>>(products.ToList());
            // return Ok(CustomResponseDto<List<ProductDto>>.Succes(200, productsDtos));
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Succes(200, productsDtos));
        }


        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        // GET / api / products/5
        [HttpGet("{id}")] //burda if vermezsek sadece aşağıdaki parametre olursa ?id=5 diye beklerdi
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            var productsDto = _mapper.Map<ProductDto>(product);
           
            return CreateActionResult(CustomResponseDto<ProductDto>.Succes(200, productsDto));
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            var product = await _productService.AddAsync(_mapper.Map<Product>(productDto));
            var productsDto = _mapper.Map<ProductDto>(product);

            return CreateActionResult(CustomResponseDto<ProductDto>.Succes(201, productsDto));
        }

        [HttpPut]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            await _productService.UpdateAsync(_mapper.Map<Product>(productDto));
            

            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }

        // Delete / api / products/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            
            if(product==null)
                return CreateActionResult(CustomResponseDto<NoContentDto>.Fail(404,"bu Id ye sahip ürün bulunamadı."));


            await _productService.RemoveAsync(product);
          

            return CreateActionResult(CustomResponseDto<NoContentDto>.Succes(204));
        }
        [HttpGet("[action]/{categoryId}")]
        public async Task<IActionResult> GetProductByCategoryId(int categoryId)
        {
            var products = await _productService.GetProductsByCategoryIdAsync(categoryId);
            var productsDtos = _mapper.Map<List<ProductDto>>(products.ToList());
            return CreateActionResult(CustomResponseDto<List<ProductDto>>.Succes(200, productsDtos));
        }


    }
}
