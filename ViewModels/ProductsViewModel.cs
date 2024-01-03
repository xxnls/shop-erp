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

        private int _selectedProductCategoryId;
        public int SelectedProductCategoryId
        {
            get { return _selectedProductCategoryId; }
            set
            {
                if (_selectedProductCategoryId != value)
                {
                    _selectedProductCategoryId = value;
                    OnPropertyChanged(() => SelectedProductCategoryId);
                }
            }
        }

        private int _selectedProductUnitId;
        public int SelectedProductUnitId
        {
            get { return _selectedProductUnitId; }
            set
            {
                if (_selectedProductUnitId != value)
                {
                    _selectedProductUnitId = value;
                    OnPropertyChanged(() => SelectedProductUnitId);
                }
            }
        }

        private string _productName;
        public string ProductName
        {
            get { return _productName; }
            set
            {
                if (_productName != value)
                {
                    _productName = value;
                    OnPropertyChanged(() => ProductName);
                }
            }
        }
        private int _productPrice;
        public int ProductPrice
        {
            get { return _productPrice; }
            set
            {
                if (_productPrice != value)
                {
                    _productPrice = value;
                    OnPropertyChanged(() => ProductPrice);
                }
            }
        }
        private int _productQuantity;
        public int ProductQuantity
        {
            get { return _productQuantity; }
            set
            {
                if (_productQuantity != value)
                {
                    _productQuantity = value;
                    OnPropertyChanged(() => ProductQuantity);
                }
            }
        }
        #endregion
        public ProductsViewModel() : base(GlobalResources.Products)
        {
            ProductCategories = new ObservableCollection<ProductCategory>(GetProductCategories());
            ProductUnits = new ObservableCollection<ProductUnit>(GetProductUnits());
        }
        public override void Delete()
        {
            if (SelectedModel != null)
            {
                using (var dbContext = new DatabaseContext())
                {
                    var address = dbContext.Products.Find(SelectedModel.ProductId);
                    address.DateDeleted = DateTime.Now;
                    dbContext.SaveChanges();
                }
                Refresh();
            }
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
            RefreshTime = DateTime.Now.ToString("HH:mm:ss");
            Models.Clear();
            foreach (var model in GetModels())
            {
                Models.Add(model);
            }
        }

        public override void Save()
        {
            using (var dbContext = new DatabaseContext())
            {
                var product = new Product
                {
                    ProductName = ProductName,
                    ProductCategoryId = SelectedProductCategoryId,
                    ProductUnitId = SelectedProductUnitId,
                    ProductPrice = ProductPrice,
                    ProductQuantity = ProductQuantity,
                    DateCreated = DateTime.Now
                };
                dbContext.Products.Add(product);
                dbContext.SaveChanges();
            }
            Refresh();
        }
    }
}
