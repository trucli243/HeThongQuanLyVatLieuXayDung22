using HeThongQuanLyVatTuXayDung22.Common.DAL;
using HeThongQuanLyVatTuXayDung22.Common.Rsp;
using HeThongQuanLyVatTuXayDung22.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeThongQuanLyVatTuXayDung22.DAL
{
    public class OrderRep : GenericRep<QLVLXDContext, Order>
    {
        #region -- Overrides --
        //Lấy tất cả loại sp
        public override Order Read(int id)
        {
            var res = All.FirstOrDefault(p => p.OrderId == id);
            return res;
        }

        #endregion

        #region --Methods--

        public List<Order> SearchOrderByYear(int year)
        {
            return All.Where(order => order.OrderDate.Value.Year == year).ToList();

        }


        public List<Order> GetOrdersByYear(int year)
        {
            var context = new QLVLXDContext();
            return context.Orders
                .Where(order => order.OrderDate.Value.Year == year)
                .Include(order => order.OrderDetails)
                .ToList();
        }
        #endregion
    }
}
