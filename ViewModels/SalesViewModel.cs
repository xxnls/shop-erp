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
    public class SalesViewModel : BaseObjectViewModel<Sale>
    {
        #region Properties and Fields
        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    _productId = value;
                    OnPropertyChanged(() => ProductId);
                }
            }
        }

        private DateTime _saleStartDate;
        public DateTime SaleStartDate
        {
            get { return _saleStartDate; }
            set
            {
                if (_saleStartDate != value)
                {
                    _saleStartDate = value;
                    OnPropertyChanged(() => SaleStartDate);
                }
            }
        }

        private DateTime _saleEndDate;
        public DateTime SaleEndDate
        {
            get { return _saleEndDate; }
            set
            {
                if (_saleEndDate != value)
                {
                    _saleEndDate = value;
                    OnPropertyChanged(() => SaleEndDate);
                }
            }
        }

        private double _saleDiscount;
        public double SaleDiscount
        {
            get { return _saleDiscount; }
            set
            {
                if (_saleDiscount != value)
                {
                    _saleDiscount = value;
                    OnPropertyChanged(() => SaleDiscount);
                }
            }
        }

        public override string this[string columnName] => throw new NotImplementedException();
        #endregion

        public SalesViewModel() : base("Sales")
        {

        }

        #region Methods
        public override void Save()
        {
            using (var dbContext = new DatabaseContext())
            {
                var sale = new Sale
                {
                    ProductId = ProductId,
                    SaleStartDate = SaleStartDate,
                    SaleEndDate = SaleEndDate,
                    SaleDiscount = SaleDiscount,
                    DateCreated = DateTime.Now
                };
                dbContext.Sales.Add(sale);
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
                    var sale = dbContext.Sales.Find(SelectedModel.SaleId);
                    sale.DateDeleted = DateTime.Now;
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
                    var sale = dbContext.Sales.Find(SelectedModel.SaleId);
                    sale.ProductId = SelectedModel.ProductId;
                    sale.SaleStartDate = SelectedModel.SaleStartDate;
                    sale.SaleEndDate = SelectedModel.SaleEndDate;
                    sale.SaleDiscount = SelectedModel.SaleDiscount;
                    sale.DateEdited = DateTime.Now;
                    dbContext.SaveChanges();
                    SelectedModel = null;
                }
                Refresh();
            }
        }

        public override IEnumerable<Sale> GetModels()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Sales.Include(s => s.Product)
                                      .Where(s => s.DateDeleted == null)
                                      .ToList();
            }
        }
        #endregion
    }
}
