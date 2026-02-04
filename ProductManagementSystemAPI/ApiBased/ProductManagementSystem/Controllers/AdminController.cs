using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        AdminService service;
        OrderService ord;
        public AdminController(AdminService service, OrderService ord)
        {
            this.service = service;
            this.ord = ord;
        }
        [HttpPost("login")]
        public IActionResult LogIn(AdminDTO adm)
        {
            if (service.LogIn(adm)) {
                Response.Cookies.Append("admin", "true");
                return Ok("Logged In Successfully");
            }
            else
            {
                return Unauthorized("Admin Not Found");
            }

        }
        //public IActionResult Login(AdminDTO admin)
        //{
        //    var res = service.Login(admin);

        //    if (res)
        //    {
        //        Response.Cookies.Append(
        //            "admin",
        //            "true",
        //            new CookieOptions
        //            {
        //                Expires = DateTime.Now.AddMinutes(10)
        //            }
        //        );

        //        return Ok("Admin logged in");
        //    }

        //    return Unauthorized("Invalid username or password");
        //}
        [HttpGet("logout")]
        public IActionResult LogOut() {
            Response.Cookies.Delete("admin");
            return Ok("Logout successfully");
        
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            var data = service.GetAll();
            return Ok(data);
        }
        [HttpGet("{id}")]
        public IActionResult Find(int id)
        {
            var data = service.Find(id);
            return Ok(data);
        }
        [HttpPost("add")]
        public IActionResult Add(AdminDTO c)
        {

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

        [HttpPost("addadmin")]
        public IActionResult AddAdmin(AdminDTO c)
        {
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
        public IActionResult Update(int id,AdminDTO c)
        {
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
        [HttpGet("orders/customer/{id}")]
        public IActionResult OrdersByCustomer(int id)
        {
            if (Request.Cookies["admin"] != "true")
                return Unauthorized("Please Login As Admin");

            return Ok(ord.GetOrdersByCustomer(id));
        }

    }
}
