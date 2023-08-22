using HeThongQuanLyVatTuXayDung22.Common.BLL;
using HeThongQuanLyVatTuXayDung22.Common.Req;
using HeThongQuanLyVatTuXayDung22.Common.Rsp;
using HeThongQuanLyVatTuXayDung22.DAL;
using HeThongQuanLyVatTuXayDung22.DAL.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeThongQuanLyVatTuXayDung22.BLL
{
  public  class ProductSvc : GenericSvc<ProductRep, Product>
    {
        private ProductRep productRep;
        #region -- Overrides --

        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();
            var m = _rep.Read(id);
            res.Data = m;
            return res;
        }
        public ProductSvc()
        {
            productRep = new ProductRep();
        }

        public override SingleRsp Update(Product m)
        {
            var res = new SingleRsp();
            var m1 = m.ProductId > 0 ? _rep.Read(m.ProductId) : _rep.Read(m.ProductName);
            if(m1==null)
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
        public SingleRsp CreateProduct (ProductReq productReq)
        {
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductId = productReq.ProductId;
            product.ProductName = productReq.ProductName;
            product.UnitPrice = productReq.UnitPrice;
            product.UnitsInStock = productReq.UnitsInStock;
            res = productRep.CreateProduct(product);
            return res;

        }
    }
}
