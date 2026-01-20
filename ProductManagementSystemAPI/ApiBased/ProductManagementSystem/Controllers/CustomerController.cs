using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        CustomerService service;
        public CustomerController(CustomerService service)
        {
            this.service = service;
        }
        [HttpPost("login")]
        public IActionResult LogIn(CustomerDTO cus)
        {
            if (service.LogIn(cus))
            {
                Response.Cookies.Append("customer", "true");
                return Ok("Logged In Successfully");
            }
            else
            {
                return Unauthorized("customer Not Found");
            }

        }
   
        [HttpGet("logout")]
        public IActionResult LogOut()
        {
            Response.Cookies.Delete("customer");
            return Ok("Logout successfully");

        }
        [HttpPost("signup")]
        public IActionResult Create(CustomerDTO c)
        {
            var res = service.Add(c);
            if (res == true)
            {
                return Ok("Signup succedd now login");
            }
            else
            {
                return BadRequest(res);
            }
        }
    }
}
