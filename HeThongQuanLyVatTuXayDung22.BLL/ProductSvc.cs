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
    public class ProductSvc : GenericSvc<ProductRep, Product>
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

        public SingleRsp CreateProduct(ProductReq productReq)
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

        public SingleRsp SearchProduct(SearchProductReq q)
        {
            var res = new SingleRsp();
            //lấy danh sách theo từ khóa
            var products = productRep.SearchProduct(q.Keyword);
            //xử lí trang 
            int totalPages, pCount, offSet;
            offSet = q.Size * (q.Page - 1);
            pCount = products.Count;
            totalPages = (pCount % q.Size) == 0 ? pCount / q.Size : 1 + (pCount / q.Size);
            var oj = new
            {
                Data = products.Skip(offSet).Take(q.Size).ToList(),
                Page = q.Page,
                Size = q.Size
            };
            res.Data = oj;

            return res;
        }

        public SingleRsp UpdateProduct(ProductReq productReq)
        {
            var res = new SingleRsp();
            Product product = new Product();
            product.ProductId = productReq.ProductId;
            product.ProductName = productReq.ProductName;
            product.UnitPrice = productReq.UnitPrice;
            product.UnitsInStock = productReq.UnitsInStock;
            res = productRep.UpdateProduct(product);
            return res;
        }
        public SingleRsp DeleteProduct(int id)
        {
            var res = new SingleRsp();
            res = productRep.DeleteProduct(id);
            return res;
        }
        #endregion
    }
}
