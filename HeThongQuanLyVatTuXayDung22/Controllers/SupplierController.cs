using HeThongQuanLyVatTuXayDung22.BLL;
using HeThongQuanLyVatTuXayDung22.Common.Req;
using HeThongQuanLyVatTuXayDung22.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeThongQuanLyVatTuXayDung22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SupplierController : ControllerBase
    {
        private SupplierSvc supplierSvc ;
        public SupplierController()
        {
            supplierSvc = new SupplierSvc();
        }
        [HttpGet("get-all")]
        public IActionResult getAllSupplier()
        {
            var res = new SingleRsp();
            res.Data = supplierSvc.All;
            return Ok(res);
        }
        [HttpGet("get-supplier-by-id")]
        public IActionResult getSupplierById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = supplierSvc.Read(req.Id);
            return Ok(res);
        }
        [HttpPost("create-supplier")]
        public IActionResult CreateSupplier([FromBody] SupplierReq supplierReq)
        {
            var res = new SingleRsp();
            res = supplierSvc.CreateSupplier(supplierReq);
            return Ok(res);
        }


        [HttpPut("edit-Supplier")]
        public IActionResult EditSupplier([FromBody] SupplierReq supplierReq)
        {
            var res = new SingleRsp();
            res = supplierSvc.EditSupplier(supplierReq);
            return Ok(res);
        }


    }
}
