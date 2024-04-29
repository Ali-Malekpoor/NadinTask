using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Nadin.Application.Services.Interfaces;
using Nadin.Domain.DTOs;
using System.Threading.Tasks;


namespace Nadin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }


        /// <summary>
        /// لیست محصولات ها رو دریافت کنید
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Get()
        {
            var listOfProduct = _productService.GetAll().Select(p => new GetProductDTO
            {
                Id = p.Id,
                Name = p.Name,
                ManufactureEmail = p.ManufactureEmail,
                ManufacturePhone = p.ManufacturePhone,
                ProductDate = p.ProductDate,
                IsAvailable = p.IsAvailable,
                //HATEOAS
                Links = new List<LinkProduct>
                {
                     new LinkProduct
                     {
                          Href=Url.Action(nameof(Get),"Product",new {p.Id},Request.Scheme),
                          Rel="Self",
                          Method="Get"
                     },

                    new LinkProduct
                     {
                          Href=Url.Action(nameof(Delete),"Product",new {p.Id},Request.Scheme),
                          Rel="Delete",
                          Method="Delete"
                     },

                     new LinkProduct
                     {
                          Href=Url.Action(nameof(Put),"Product",Request.Scheme),
                          Rel="Update",
                          Method="Put"
                     },
                }
            }).ToList();

            return Ok(listOfProduct);
        }

        /// <summary>
        ///  محصول رو دریافت کنید
        /// </summary>
        /// <returns></returns>
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var product = _productService.GetById(id);

            return Ok(new GetProductDTO
            {
                Id = product.Id,
                Name = product.Name,
                ManufactureEmail = product.ManufactureEmail,
                ManufacturePhone = product.ManufacturePhone,
                ProductDate = product.ProductDate,
                IsAvailable = product.IsAvailable,
                //HATEOAS
                Links = new List<LinkProduct>
                {
                     new LinkProduct
                     {
                          Href=Url.Action(nameof(Get),"Product",new {product.Id},Request.Scheme),
                          Rel="Self",
                          Method="Get"
                     },

                    new LinkProduct
                     {
                          Href=Url.Action(nameof(Delete),"Product",new {product.Id},Request.Scheme),
                          Rel="Delete",
                          Method="Delete"
                     },

                     new LinkProduct
                     {
                          Href=Url.Action(nameof(Put),"Product",Request.Scheme),
                          Rel="Update",
                          Method="Put"
                     },
                }
            });
        }

        /// <summary>
        ///  محصول رو ایجاد کنید
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Post([FromBody] CreateProductDTO newproduct)
        {
            var result = _productService.Create(newproduct);

            string url = Url.Action(nameof(Get),
                                    "Tasks",
                                    new { Id = newproduct.Id },
                                    Request.Scheme);

            return Created(url, result);
        }

        /// <summary>
        ///  محصول رو ویرایش کنید
        /// </summary>
        /// <returns></returns>
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] UpdateProductDTO update )
        {
            var result = _productService.Update(update);

            return Ok(result);
        }

        /// <summary>
        ///  محصول رو حذف کنید
        /// </summary>
        /// <returns></returns>
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var result = _productService.Delete(id);    
            return Ok(result);
        }
    }
}
