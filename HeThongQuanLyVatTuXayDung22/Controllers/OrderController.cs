using HeThongQuanLyVatTuXayDung22.BLL;
using HeThongQuanLyVatTuXayDung22.Common.Req;
using HeThongQuanLyVatTuXayDung22.Common.Rsp;
using HeThongQuanLyVatTuXayDung22.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace HeThongQuanLyVatTuXayDung22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private OrderSvc orderSvc;
        public OrderController()
        {
            orderSvc = new OrderSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllOrder()
        {
            var res = new SingleRsp();
            res.Data = orderSvc.All;
            return Ok(res);
        }
        [HttpGet("get-by-id")]
        public IActionResult getOrderById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = orderSvc.Read(req.Id);
            return Ok(res);
        }
        //[HttpGet("search-order-by-year")]
        //public IActionResult GetOrdersByYear(int year)
        //{
        //    var res = new SingleRsp();
        //    res = orderSvc.SearchOrderByYear(year);
        //    return Ok(res);
        //}

        [HttpGet("revenue-by-year")]
        public IActionResult GetRevenueByYear(int year)
        {
            var orders = orderSvc.GetOrdersByYear(year);

            decimal totalRevenue = orders
                .SelectMany(o => o.OrderDetails)
                .Sum(d => d.Quantity * d.UnitPrice);

            return Ok(new { Year = year, TotalRevenue = totalRevenue });
        }
    }
}
