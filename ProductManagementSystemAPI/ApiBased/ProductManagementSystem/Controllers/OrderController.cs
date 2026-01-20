using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ProductManagementSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        OrderService service;
        public OrderController(OrderService service)
        {
            this.service = service;
        }

        [HttpPost("place")]
        public IActionResult Place(CustOrderDTO o)
        {
            if (Request.Cookies["customer"] != "true")
                return Unauthorized("Login required");

            var result = service.PlaceOrder(o);
            return Ok(result);
        }
        [HttpPost("pay/{id}")]
        public IActionResult Pay(int id)
        {
            if (Request.Cookies["customer"] != "true")
                return Unauthorized("Login required");

            try
            {
                var result = service.PayOrder(id);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpGet("paid")]
        public IActionResult PaidOrders()
        {
            if (Request.Cookies["admin"] != "true")
                return Unauthorized("Admin login required");

            var result = service.GetPaidOrdersForAdmin();
            return Ok(result);
        }
        [HttpGet("pending")]
        public IActionResult PendingOrders()
        {
            if (Request.Cookies["admin"] != "true")
                return Unauthorized("Admin login required");

            var result = service.GetPendingOrdersForAdmin();
            return Ok(result);
        }


    }
}
