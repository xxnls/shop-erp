using Microsoft.EntityFrameworkCore;
using ShopERP.Models;
using ShopERP.Models.Contexts;
using ShopERP.ViewModels.BaseViewModels;
using ShopERP.ViewResources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopERP.ViewModels
{
    public class ProductsViewModel : BaseObjectViewModel<Product>
    {
        #region Properties and Fields
        public ObservableCollection<ProductCategory> ProductCategories { get; set; }
        public ObservableCollection<ProductUnit> ProductUnits { get; set; }

        #endregion
        public ProductsViewModel() : base(GlobalResources.Products)
        {
            ProductCategories = new ObservableCollection<ProductCategory>(GetProductCategories());
            ProductUnits = new ObservableCollection<ProductUnit>(GetProductUnits());
        }
        public override void Delete()
        {
            
        }

        public override void Edit()
        {
            
        }
        public override IEnumerable<Product> GetModels()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Products.Include(item => item.ProductCategory)
                                         .Include(item => item.ProductUnit)
                                         .Where(address => address.DateDeleted == null)
                                         .ToList();
            }
        }
        private IEnumerable<ProductCategory> GetProductCategories()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.ProductCategories.ToList();
            }
        }
        private IEnumerable<ProductUnit> GetProductUnits()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.ProductUnits.ToList();
            }
        }
        public override void Refresh()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
