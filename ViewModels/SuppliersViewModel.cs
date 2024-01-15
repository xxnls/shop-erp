using Microsoft.EntityFrameworkCore;
using ShopERP.Models;
using ShopERP.Models.Contexts;
using ShopERP.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShopERP.ViewModels
{
    public class SuppliersViewModel : BaseObjectViewModel<Supplier>
    {
        #region Properties and Fields
        private string _supplierName;
        public string SupplierName
        {
            get { return _supplierName; }
            set
            {
                if (_supplierName != value)
                {
                    _supplierName = value;
                    OnPropertyChanged(() => SupplierName);
                }
            }
        }

        private int _addressId;
        public int AddressId
        {
            get { return _addressId; }
            set
            {
                if (_addressId != value)
                {
                    _addressId = value;
                    OnPropertyChanged(() => AddressId);
                }
            }
        }
        #endregion

        public SuppliersViewModel() : base("Suppliers")
        {

        }

        #region Methods
        public override void Save()
        {
            using (var dbContext = new DatabaseContext())
            {
                var supplier = new Supplier
                {
                    SupplierName = SupplierName,
                    AddressId = AddressId,
                    DateCreated = DateTime.Now
                };
                dbContext.Suppliers.Add(supplier);
                dbContext.SaveChanges();
            }
            Refresh();
        }

        public override void Delete()
        {
            if (SelectedModel != null)
            {
                using (var dbContext = new DatabaseContext())
                {
                    var supplier = dbContext.Suppliers.Find(SelectedModel.SupplierId);
                    supplier.DateDeleted = DateTime.Now;
                    dbContext.SaveChanges();
                }
                Refresh();
            }
        }

        public override void Edit()
        {
            if (SelectedModel != null)
            {
                using (var dbContext = new DatabaseContext())
                {
                    var supplier = dbContext.Suppliers.Find(SelectedModel.SupplierId);
                    supplier.SupplierName = SelectedModel.SupplierName;
                    supplier.AddressId = SelectedModel.AddressId;
                    supplier.DateEdited = DateTime.Now;
                    dbContext.SaveChanges();
                    SelectedModel = null;
                }
                Refresh();
            }
        }

        public override IEnumerable<Supplier> GetModels()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Suppliers.Include(s => s.Address)
                                          .Where(s => s.DateDeleted == null)
                                          .ToList();
            }
        }
        #endregion
    }
}
