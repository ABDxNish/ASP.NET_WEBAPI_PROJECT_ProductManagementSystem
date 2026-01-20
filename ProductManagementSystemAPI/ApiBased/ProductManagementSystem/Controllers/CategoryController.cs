using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        CategoryService service;
        public CategoryController(CategoryService service)
        {
            this.service = service;
        }

        bool IsAdmin()
        {
            return Request.Cookies["admin"] == "true";
        }
        bool IsCustomer()
        {
            return Request.Cookies["customer"] == "true";
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            if (!IsAdmin())
            {
                return Unauthorized("Please Login");
            }
            var data = service.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Find(int id)
        {
            if (!IsAdmin())
            {
                return Unauthorized("Please Login");
            }
            var data = service.Find(id);
            return Ok(data);
        }
        [HttpPost("add")]
        public IActionResult Add(CategoryDTO c)
        {
            if (!IsAdmin())
            {
                return Unauthorized("Please Login As Admin");
            }
            var res = service.Add(c);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
        [HttpPost("update/{id}")]
        public IActionResult Update(int id,CategoryDTO c)
        {
            if (!IsAdmin())
            {
                return Unauthorized("Please Login As Admin");
            }
            var res = service.Update(id,c);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
        [HttpDelete("delete/{id}")]
        public IActionResult Delete(int id)
        {
            if (!IsAdmin())
            {
                return Unauthorized("Please Login As Admin");
            }
            var res = service.Delete(id);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }

        [HttpGet("fawp")]
        public IActionResult FindAllWithProducts()
        {
            if (!IsAdmin())
            {
                return Unauthorized("Please Login As Admin");
            }
            var res=service.FindAllWithProducts();
            if (res != null)
            {
                return Ok(res);
            }
            return NotFound("Data not found");

        }
        [HttpPost("fwn/{name}")]
        public IActionResult FindByName(string name)
        {
            if (!IsAdmin()|| !IsCustomer())
            {
                return Unauthorized("Please Login");
            }
            var res=service.FindByName(name);
            if(res != null)
            {
                return Ok(res);
            }
            return NotFound("Name doesn't contain any category");
        }
        [HttpGet("hwp")]
        public IActionResult HighestProduct() {
            if (!IsAdmin())
            {
                return Unauthorized("Please Login");
            }
            var res=service.HighestProdsucts();
            if (res != null) { 
            return Ok(res);
            }
            return NotFound("Error!");

        }
        [HttpPost("fwp/{id}")]
        public IActionResult FindWithProduct(int id)
        {
            if (!IsAdmin())
            {
                return Unauthorized("Please Login");
            }
            var res = service.FindWithProducts(id);
            if (res != null) 
            { 
                return Ok(res); 
            }
            return NotFound("id wrong");
        }

    }
}
