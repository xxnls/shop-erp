using ShopERP.BusinessLogic;
using ShopERP.Helpers;
using ShopERP.Models;
using ShopERP.Models.Contexts;
using ShopERP.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopERP.ViewModels.Other
{
    public class ProductStatsViewModel : WorkspaceViewModel
    {
        #region FieldsAndProperties
        public DatabaseContext Database { get; set; }
        private int _SelectedProductId;
        public int SelectedProductId
        {
            get => _SelectedProductId;
            set
            {
                if (_SelectedProductId != value)
                {
                    _SelectedProductId = value;
                    OnPropertyChanged(() => SelectedProductId);
                }
            }
        }

        private DateTime _StartDate;
        public DateTime StartDate
        {
            get => _StartDate;
            set
            {
                if (_StartDate != value)
                {
                    _StartDate = value;
                    OnPropertyChanged(() => StartDate);
                }
            }
        }

        private DateTime _EndDate;
        public DateTime EndDate
        {
            get => _EndDate;
            set
            {
                if (_EndDate != value)
                {
                    _EndDate = value;
                    OnPropertyChanged(() => EndDate);
                }
            }
        }

        private decimal _TotalBasePrice;
        public decimal TotalBasePrice
        {
            get => _TotalBasePrice;
            set
            {
                if (_TotalBasePrice != value)
                {
                    _TotalBasePrice = value;
                    OnPropertyChanged(() => TotalBasePrice);
                }
            }
        }

        private decimal _TotalTaxAmount;
        public decimal TotalTaxAmount
        {
            get => _TotalTaxAmount;
            set
            {
                if (_TotalTaxAmount != value)
                {
                    _TotalTaxAmount = value;
                    OnPropertyChanged(() => TotalTaxAmount);
                }
            }
        }

        private decimal _TotalTaxedPrice;
        public decimal TotalTaxedPrice
        {
            get => _TotalTaxedPrice;
            set
            {
                if (_TotalTaxedPrice != value)
                {
                    _TotalTaxedPrice = value;
                    OnPropertyChanged(() => TotalTaxedPrice);
                }
            }
        }

        public List<Product> Products { get; set; }

        public ICommand CalculateCommand { get; set; }
        #endregion

        #region Constructors
        public ProductStatsViewModel() : base("Product Stats")
        {
            CalculateCommand = new BaseCommand(() => Calculate());
            Database = new();
            StartDate = DateTime.Now;
            EndDate = DateTime.Now;
            Products = Database.Products.Where(item => item.DateDeleted == null)
                                        .ToList();
        }
        #endregion

        #region Methods
        private void Calculate()
        {
            ModelStatistics modelStatistics = new();
            decimal totalBasePrice = 0, totalTaxAmount = 0, totalTaxedPrice = 0;
            modelStatistics.CalculateAllStats(SelectedProductId, StartDate, EndDate, ref totalBasePrice, ref totalTaxAmount, ref totalTaxedPrice);
            TotalBasePrice = totalBasePrice;
            TotalTaxAmount = totalTaxAmount;
            TotalTaxedPrice = totalTaxedPrice;
        }
        #endregion
    }
}
