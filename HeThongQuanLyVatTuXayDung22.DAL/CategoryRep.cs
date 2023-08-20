using HeThongQuanLyVatTuXayDung22.Common.DAL;
using HeThongQuanLyVatTuXayDung22.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeThongQuanLyVatTuXayDung22.DAL
{
    public class CategoryRep : GenericRep<QLVLXDContext, Category>
    {
        public CategoryRep()
        {

        }
        //Lấy tất cả loại sp
        public override Category Read(int id)
        {
            var res = All.FirstOrDefault(p => p.CategoryId == id);
            return res;
        }

    }
}
