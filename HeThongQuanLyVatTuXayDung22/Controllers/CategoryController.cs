using HeThongQuanLyVatTuXayDung22.BLL;
using HeThongQuanLyVatTuXayDung22.Common.Req;
using HeThongQuanLyVatTuXayDung22.Common.Rsp;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HeThongQuanLyVatTuXayDung22.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private CategorySvc categorySvc;
        public CategoryController() 
        { 
            categorySvc = new CategorySvc();
        }
        [HttpPost("get-all")]
        public IActionResult getAllCategories()
        {
            var res = new SingleRsp();
            res.Data = categorySvc.All;
            return Ok(res);
        }
        [HttpPost("get-by-id")]
        public IActionResult getCategoryById([FromBody] SimpleReq req)
        {
            var res = new SingleRsp();
            res = categorySvc.Read(req.Id);
            return Ok(res);
        }
        [HttpPost("create-category")]
        public IActionResult CreateCategory([FromBody] CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            res = categorySvc.CreateCategory(categoryReq);
            return Ok(res);
        }
        // search category bằng CateName có phân trang
        [HttpPost("search-category")]
        public IActionResult SearchProduct([FromBody] SearchCategoryReq searchCategoryReq)
        {
            var res = new SingleRsp();
            res = categorySvc.SearchCategory(searchCategoryReq);
            return Ok(res);
        }
        [HttpPost("edit-category")]
        public IActionResult EditCategory([FromBody] CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            res = categorySvc.EditCategory(categoryReq);
            return Ok(res);
        }
        [HttpPost("delete-category")]
        public IActionResult DeleteCategory([FromBody] int id)
        {
            var res = new SingleRsp();
            res = categorySvc.DeleteCategory(id);
            return Ok(res);
        }
    }
}
