using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        ProductService service;
        public ProductController(ProductService service)
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
            if (!IsAdmin() || IsCustomer())
            {
                return Unauthorized("Please Login");
            }
            var data = service.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Find(int id)
        {
            if (!IsAdmin() || !IsCustomer())
            {
                return Unauthorized("Please Login");
            }
            var data = service.Find(id);
            return Ok(data);
        }
        [HttpPost("add")]
        public IActionResult Add(ProductDTO c)
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
        public IActionResult Update(int id,ProductDTO c)
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
            if (res ==true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}
