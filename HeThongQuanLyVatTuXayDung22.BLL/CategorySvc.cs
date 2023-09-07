using HeThongQuanLyVatTuXayDung22.Common.BLL;
using HeThongQuanLyVatTuXayDung22.Common.Req;
using HeThongQuanLyVatTuXayDung22.Common.Rsp;
using HeThongQuanLyVatTuXayDung22.DAL;
using HeThongQuanLyVatTuXayDung22.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeThongQuanLyVatTuXayDung22.BLL
{
    public class CategorySvc : GenericSvc<CategoryRep, Category>
    {
        private CategoryRep categoryRep;
        public CategorySvc() 
        {
            categoryRep = new CategoryRep();
        }
        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        public override SingleRsp Update(Category m)
        {
            var res = new SingleRsp();

            var m1 = m.CategoryId > 0 ? _rep.Read(m.CategoryId) : _rep.Read(m.Description);
            if (m1 == null)
            {
                res.SetError("EZ103", "No data.");
            }
            else
            {
                res = base.Update(m);
                res.Data = m;
            }

            return res;
        }
        #endregion

        #region -- Methods --
        public SingleRsp CreateCategory (CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            Category category = new Category();
            category.CategoryId = categoryReq.CategoryId;
            category.CategoryName = categoryReq.CategoryName;
            category.Description = categoryReq.Description;
            res = categoryRep.CreateCategory(category);
            return res;
        }
        public SingleRsp SearchCategory(SearchCategoryReq searchCategoryReq)
        {
            var res = new SingleRsp();
            //Lấy danh sách theo từ khóa
            var categories = categoryRep.SearchCategory(searchCategoryReq.Keyword);
            // xử lý phân trang
            var offset = (searchCategoryReq.Page - 1) * searchCategoryReq.Size;
            var total = categories.Count();
            int totalPage = (total % searchCategoryReq.Size) == 0 ? (int)(total / searchCategoryReq.Size) :
                (int)(1 + (total / searchCategoryReq.Size));
            var data = categories.OrderBy(x => x.CategoryId).Skip(offset).Take(searchCategoryReq.Size).ToList();
            var p = new
            {
                Data = data,
                TotalRecord = total,
                TotalPages = totalPage,
                Page = searchCategoryReq.Page,
                Size = searchCategoryReq.Size
            };
            res.Data = p;
            return res;
        }
        public SingleRsp EditCategory(CategoryReq categoryReq)
        {
            var res = new SingleRsp();
            Category category = new Category();
            category.CategoryId = categoryReq.CategoryId;
            category.CategoryName = categoryReq.CategoryName;
            category.Description = categoryReq.Description;
            res = categoryRep.EditCategory(category);
            return res;
        }
        public SingleRsp DeleteCategory(int id)
        {
            var res = new SingleRsp();
            res = categoryRep.DeleteCategory(id);
            return res;
        }
        #endregion
    }
}
