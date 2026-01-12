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
        public AdminController(AdminService service)
        {
            this.service = service;
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
        [HttpPost("update")]
        public IActionResult Update(AdminDTO c)
        {
            var res = service.Update(c);
            if (res == true)
            {
                return Ok(res);
            }
            else
            {
                return BadRequest(res);
            }
        }
        [HttpPost("delete/{id}")]
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
    }
}
