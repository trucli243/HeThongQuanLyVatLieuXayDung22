using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HeThongQuanLyVatTuXayDung22.Common.DAL;
using HeThongQuanLyVatTuXayDung22.Common.Rsp;
using HeThongQuanLyVatTuXayDung22.DAL.Models;
using Microsoft.EntityFrameworkCore;


namespace HeThongQuanLyVatTuXayDung22.DAL
{
    public class ProductRep : GenericRep<QLVLXDContext, Product>
    {
        #region -- Overrides --

        public override Product Read(int id)
        {
            var res = All.FirstOrDefault(p => p.ProductId == id);
            return res;
        }

        public int Remove (int id)
        {
            var m = base.All.First(i => i.ProductId == id);
            m = base.Delete(m);
            return m.ProductId;
        }
        #endregion

        #region -- Method --
        public SingleRsp CreateProduct (Product product)
        {
            var res = new SingleRsp();
            using (var context = new QLVLXDContext())
            {
                using (var tran = context.Database.BeginTransaction())
                {
                    try
                    {
                        var p = context.Products.Add(product);
                        context.SaveChanges();
                        tran.Commit();
                    }
                    catch(Exception ex)
                    {
                        tran.Rollback();
                        res.SetError(ex.StackTrace);
                    }
                }    
            }
            return res;
        }

        public List<Product> SearchProduct(string keyWord)
        {
           
            return All.Where(a => a.ProductName.Contains(keyWord)).ToList();
        }
        public List<Product> GetProductsBySupplier(int supplierId)
        {
            var context = new QLVLXDContext();
            return context.Products.Where(p => p.SupplierId == supplierId).ToList();
        }
        #endregion
    }
}
