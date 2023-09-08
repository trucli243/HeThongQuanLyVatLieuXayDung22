using HeThongQuanLyVatTuXayDung22.BLL;
using HeThongQuanLyVatTuXayDung22.Common.Req;
using HeThongQuanLyVatTuXayDung22.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeThongQuanLyVatTuXayDung22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ProductSvc productSvc;
        public ProductController()
        {
            productSvc = new ProductSvc();

        }
        [HttpPost("get-all")]
        public IActionResult getAllProduct()
        {
            var res = new SingleRsp();
            res.Data = productSvc.All;
            return Ok(res);
        }
        [HttpPost("get-by-id")]
        public IActionResult getProductById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = productSvc.Read(req.Id);
            return Ok(res);
        }

        [HttpPost("create-product")]
        public IActionResult CreateProduct([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.CreateProduct(productReq);
            return Ok(res);
        }

        [HttpPost("search-product")]
        public IActionResult SearchProduct([FromBody] SearchProductReq searchProductReq)
        {
            var res = new SingleRsp();
            res = productSvc.SearchProduct(searchProductReq);
            return Ok(res);
        }

<<<<<<< HEAD
        [HttpPost("update-product")]
        public IActionResult EditProduct([FromBody] ProductReq productReq)
        {
            var res = new SingleRsp();
            res = productSvc.UpdateProduct(productReq);
            return Ok(res);
        }
        [HttpPost("delete-product")]
        public IActionResult DeleteProduct([FromBody] int id)
        {
            var res = new SingleRsp();
            res = productSvc.DeleteProduct(id);
            return Ok(res);
        }
=======
        [HttpPost("GetProductsBySupplier")]
        public IActionResult GetProductsBySupplier([FromBody] int supplierId)
        {
            var res = productSvc.GetProductsBySupplier(supplierId);
            return Ok(res);
        }

>>>>>>> 5be62f9c85ac38366af5a2d8a2d002a51518b561
    }


}
