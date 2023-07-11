using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Business.Abstract;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        ICategoryService _categoryService;

        public CategoriesController(ICategoryService categoryService)  
        {
            _categoryService = categoryService;
        }

        [HttpGet("getall")]
        public IActionResult Get(){
            var result = _categoryService.GetAll();
            if(result.Success==true){
                return Ok(result);
            }else{
                return BadRequest(result);
            }
            
        }
    }
}