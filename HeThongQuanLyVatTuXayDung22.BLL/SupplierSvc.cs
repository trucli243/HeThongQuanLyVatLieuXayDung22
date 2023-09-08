using HeThongQuanLyVatTuXayDung22.Common.BLL;
using HeThongQuanLyVatTuXayDung22.DAL.Models;
using HeThongQuanLyVatTuXayDung22.DAL;
using System;
using System.Collections.Generic;
using System.Text;
using HeThongQuanLyVatTuXayDung22.Common.Rsp;
using HeThongQuanLyVatTuXayDung22.Common.Req;

namespace HeThongQuanLyVatTuXayDung22.BLL
{
    public class SupplierSvc : GenericSvc<SupplierRep, Supplier>
    {
        private SupplierRep supplierRep;
        public SupplierSvc()
        {
            supplierRep = new SupplierRep();
        }
        #region -- Overrides --
        public override SingleRsp Read(int id)
        {
            var res = new SingleRsp();

            var m = _rep.Read(id);
            res.Data = m;

            return res;
        }
        public override SingleRsp Update(Supplier m)
        {
            var res = new SingleRsp();

            var m1 = m.SupplierId > 0 ? _rep.Read(m.SupplierId) : _rep.Read(m.CompanyName);
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
        public SingleRsp CreateSupplier(SupplierReq supplierReq)
        {
            var res = new SingleRsp();
            Supplier supplier = new Supplier();
            supplier.CompanyName = supplierReq.CompanyName;
            supplier.ContactName = supplierReq.ContactName;
            supplier.ContactTitle = supplierReq.ContactTitle;
            supplier.Address = supplierReq.Address;
            supplier.City = supplierReq.City;
            supplier.Country = supplierReq.Country;
            supplier.Phone = supplierReq.Phone;
            res = supplierRep.CreateSupplier(supplier);
            return res;
        }

        public SingleRsp UpdateSupplier(SupplierReq supplierReq)
        {
            var res = new SingleRsp();
            Supplier supplier = new Supplier();
            supplier.CompanyName = supplierReq.CompanyName;
            supplier.ContactName = supplierReq.ContactName;
            supplier.ContactTitle = supplierReq.ContactTitle;
            supplier.Address = supplierReq.Address;
            supplier.City = supplierReq.City;
            supplier.Country = supplierReq.Country;
            supplier.Phone = supplierReq.Phone;
            res = supplierRep.UpdateSupplier(supplier);
            return res;
        }
        #endregion
    }
}
