using HeThongQuanLyVatTuXayDung22.Common.BLL;
using HeThongQuanLyVatTuXayDung22.DAL.Models;
using HeThongQuanLyVatTuXayDung22.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using HeThongQuanLyVatTuXayDung22.Common.Rsp;
using System.Linq;
using HeThongQuanLyVatTuXayDung22.Common.Req;

namespace HeThongQuanLyVatTuXayDung22.BLL
{
    public class OrderSvc : GenericSvc<OrderRep, Order>
    {
        private OrderRep orderRep;
        public OrderSvc()
        {
            orderRep = new OrderRep();
        }
        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        public override SingleRsp Update(Order m)
        {
            var res = new SingleRsp();

            var m1 = m.OrderId > 0 ? _rep.Read(m.OrderId) : _rep.Read(m.CustomerId );
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

        #region --Methods--

        //public SingleRsp SearchOrderByYear(int year)
        //{
        //    var res = new SingleRsp();
        //    var orders = orderRep.SearchOrderByYear(year);
        //    return res;
        //}
        public List<Order> SearchOrderByYear(int year)
        {
            return orderRep.SearchOrderByYear(year);
        }

        public List<Order> GetOrdersByYear(int year)
        {
            return orderRep.GetOrdersByYear(year);
        }
        #endregion
    }
}
