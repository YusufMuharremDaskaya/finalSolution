using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Entities.Concrete;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        IProductService _productService;
        public ProductsController(IProductService productService) {
            _productService = productService;
        }

        [HttpGet("getall")]
        public IActionResult Get(){
            var result = _productService.GetAll();
            if(result.Success==true){
                return Ok(result);
            }else{
                return BadRequest(result);
            }
            
        }


        [HttpGet("getbyid")]
        public IActionResult Get(int id){
            var result = _productService.GetById(id);
            if(result.Success==true){
                return Ok(result);
            }else{
                return BadRequest(result);
            }
            
        }

        [HttpGet("getbycategory")]
        public IActionResult GetByCategory(int id){
            var result = _productService.GetAllByCategoryId(id);
            if(result.Success==true){
                return Ok(result);
            }else{
                return BadRequest(result);
            }
            
        }

        [HttpPost("add")]
        public IActionResult Post(Product product){
            var result = _productService.Add(product); 
            if(result.Success==true){
                return Ok(result);
            }else{
                return BadRequest(result);
            }
        }
    }
}