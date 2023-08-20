using HeThongQuanLyVatTuXayDung22.Common.BLL;
using HeThongQuanLyVatTuXayDung22.Common.Rsp;
using HeThongQuanLyVatTuXayDung22.DAL;
using HeThongQuanLyVatTuXayDung22.DAL.Models;
using System;
using System.Collections.Generic;
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
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
    }
}
