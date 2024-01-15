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
    public class CustomersViewModel : BaseObjectViewModel<Customer>
    {
        #region Properties and Fields
        private string _customerFirstName;
        public string CustomerFirstName
        {
            get { return _customerFirstName; }
            set
            {
                if (_customerFirstName != value)
                {
                    _customerFirstName = value;
                    OnPropertyChanged(() => CustomerFirstName);
                }
            }
        }

        private string _customerLastName;
        public string CustomerLastName
        {
            get { return _customerLastName; }
            set
            {
                if (_customerLastName != value)
                {
                    _customerLastName = value;
                    OnPropertyChanged(() => CustomerLastName);
                }
            }
        }

        private bool _isCompany;
        public bool IsCompany
        {
            get { return _isCompany; }
            set
            {
                if (_isCompany != value)
                {
                    _isCompany = value;
                    OnPropertyChanged(() => IsCompany);
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

        public CustomersViewModel() : base("Customers")
        {

        }

        #region Methods
        public override void Save()
        {
            using (var dbContext = new DatabaseContext())
            {
                var customer = new Customer
                {
                    CustomerFirstName = CustomerFirstName,
                    CustomerLastName = CustomerLastName,
                    IsCompany = IsCompany,
                    AddressId = AddressId,
                    DateCreated = DateTime.Now
                };
                dbContext.Customers.Add(customer);
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
                    var customer = dbContext.Customers.Find(SelectedModel.CustomerId);
                    customer.DateDeleted = DateTime.Now;
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
                    var customer = dbContext.Customers.Find(SelectedModel.CustomerId);
                    customer.CustomerFirstName = SelectedModel.CustomerFirstName;
                    customer.CustomerLastName = SelectedModel.CustomerLastName;
                    customer.IsCompany = SelectedModel.IsCompany;
                    customer.AddressId = SelectedModel.AddressId;
                    customer.DateEdited = DateTime.Now;
                    dbContext.SaveChanges();
                    SelectedModel = null;
                }
                Refresh();
            }
        }

        public override IEnumerable<Customer> GetModels()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Customers.Include(c => c.Address)
                                          .Where(c => c.DateDeleted == null)
                                          .ToList();
            }
        }
        #endregion
    }
}
