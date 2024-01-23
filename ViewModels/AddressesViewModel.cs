using ShopERP.ViewResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using ShopERP.Models;
using ShopERP.Models.Contexts;
using System.Windows.Input;
using Microsoft.EntityFrameworkCore;
using ShopERP.Helpers;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.IO;
using ShopERP.ViewModels.BaseViewModels;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text.RegularExpressions;

namespace ShopERP.ViewModels
{
    public class AddressesViewModel : BaseObjectViewModel<Address>
    {
        #region Properties and Fields
        public Dictionary<string, string> ErrorCollection { get; private set; } = new();
        public ObservableCollection<Country> Countries { get; set; }
        public ObservableCollection<string> FilterOptions { get; set; }

        private int _selectedCountryId;
        public int SelectedCountryId
        {
            get { return _selectedCountryId; }
            set
            {
                if (_selectedCountryId != value)
                {
                    _selectedCountryId = value;
                    OnPropertyChanged(() => SelectedCountryId);
                }
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                if (_city != value)
                {
                    _city = value;
                    OnPropertyChanged(() => City);
                }
            }
        }
        private string _postalCode;
        public string PostalCode
        {
            get { return _postalCode; }
            set
            {
                if (_postalCode != value)
                {
                    _postalCode = value;
                    OnPropertyChanged(() => PostalCode);
                }
            }
        }
        private string _streetName;
        public string StreetName
        {
            get { return _streetName; }
            set
            {
                if (_streetName != value)
                {
                    _streetName = value;
                    OnPropertyChanged(() => StreetName);
                }
            }
        }
        private string _buildingNumber;
        public string BuildingNumber
        {
            get { return _buildingNumber; }
            set
            {
                if (_buildingNumber != value)
                {
                    _buildingNumber = value;
                    OnPropertyChanged(() => BuildingNumber);
                }
            }
        }
        private string _contactNumber;
        public string ContactNumber
        {
            get { return _contactNumber; }
            set
            {
                if (_contactNumber != value)
                {
                    _contactNumber = value;
                    OnPropertyChanged(() => ContactNumber);
                }
            }
        }
        #endregion

        #region Constructors
        public AddressesViewModel() : base(GlobalResources.Address)
        {
            Countries = new ObservableCollection<Country>(GetCountries());
            FilterOptions = new ObservableCollection<string> { "ID", "City", "Country", "Street", "Postal Code" };
        }
        #endregion

        #region Validation
        public override string this[string columnName]
        {
            get
            {
                string result = null;

                switch (columnName)
                {
                    case nameof(SelectedCountryId):
                        if (SelectedCountryId == 0)
                            result = "Country is required.";
                        else
                            ErrorCollection.Remove(nameof(SelectedCountryId));
                        break;
                    case nameof(City):
                        if (string.IsNullOrEmpty(City))
                            result = "City name is required.";
                        else
                            ErrorCollection.Remove(nameof(City));
                        break;
                    case nameof(PostalCode):
                        if (string.IsNullOrEmpty(PostalCode))
                            result = "Postal code is required.";
                        else if (!Regex.IsMatch(PostalCode, @"^\d+$"))
                            result = "Postal code must contain only numbers.";
                        else
                            ErrorCollection.Remove(nameof(PostalCode));
                        break;
                    case nameof(StreetName):
                        if (string.IsNullOrEmpty(StreetName))
                            result = "Street name is required.";
                        else
                            ErrorCollection.Remove(nameof(StreetName));
                        break;
                    case nameof(BuildingNumber):
                        if (string.IsNullOrEmpty(BuildingNumber))
                            result = "Building number is required.";
                        else if (!Regex.IsMatch(BuildingNumber, @"^\d+$"))
                            result = "Building number must contain only numbers.";
                        else
                            ErrorCollection.Remove(nameof(BuildingNumber));
                    break;
                    case nameof(ContactNumber):
                        if (string.IsNullOrEmpty(ContactNumber))
                            result = "Contact number is required.";
                        else if (!Regex.IsMatch(ContactNumber, @"^\d+$"))
                            result = "Contact number must contain only numbers.";
                        else
                            ErrorCollection.Remove(nameof(ContactNumber));
                        break;
            }

                if(ErrorCollection.ContainsKey(columnName))
                {
                    ErrorCollection[columnName] = result;
                }
                else if(result != null)
                {
                    ErrorCollection.Add(columnName, result);
                }

                OnPropertyChanged(() => ErrorCollection);

                return result;
            }
        }
        #endregion

        #region Methods
        public override IEnumerable<Address> GetModels()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Addresses.Include(item => item.Country)
                                          .Where(address => address.DateDeleted == null)
                                          .ToList();
            }
        }
        private IEnumerable<Country> GetCountries()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Countries.ToList();
            }
        }
        public override void Filter(ObservableCollection<Address> models)
        {
            switch (SelectedFilterOption)
            {
                case "ID":
                    Models = new ObservableCollection<Address>(models.Where(item => item.AddressId.Equals(FilterText)));
                    break;
                case "Country":
                    Models = new ObservableCollection<Address>(models.Where(item => item.CountryId.Equals(FilterText)));
                    break;
                case "City":
                    Models = new ObservableCollection<Address>(models.Where(item => item.City.Contains(FilterText)));
                    break;
                case "Street":
                    Models = new ObservableCollection<Address>(models.Where(item => item.StreetName.Contains(FilterText)));
                    break;
                case "Postal Code":
                    Models = new ObservableCollection<Address>(models.Where(item => item.PostalCode.Contains(FilterText)));
                    break;
            }
            DataGridCheck();
        }
        public override void Save()
        {
            if (ErrorCollection.Count == 0)
            {
                using (var dbContext = new DatabaseContext())
                {
                    var address = new Address
                    {
                        CountryId = SelectedCountryId,
                        City = City,
                        PostalCode = PostalCode,
                        StreetName = StreetName,
                        BuildingNumber = BuildingNumber,
                        ContactNumber = ContactNumber,
                        DateCreated = DateTime.Now
                    };
                    dbContext.Addresses.Add(address);
                    dbContext.SaveChanges();
                }
                Refresh();
            }
            else
            {
                string errorMessage = string.Join("\n", ErrorCollection.Values);
                MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        
        public override void Edit()
        {
            if (ErrorCollection.Count == 0)
                if (SelectedModel != null)
                {
                    using (var dbContext = new DatabaseContext())
                    {
                        var address = dbContext.Addresses.Find(SelectedModel.AddressId);
                        address.CountryId = SelectedModel.CountryId;
                        address.City = SelectedModel.City;
                        address.PostalCode = SelectedModel.PostalCode;
                        address.StreetName = SelectedModel.StreetName;
                        address.BuildingNumber = SelectedModel.BuildingNumber;
                        address.ContactNumber = SelectedModel.ContactNumber;
                        address.DateEdited = DateTime.Now;
                        dbContext.SaveChanges();
                        SelectedModel = null;
                    }
                    Refresh();
                }
            else
            {
               string errorMessage = string.Join("\n", ErrorCollection.Values);
               MessageBox.Show(errorMessage, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public override void Delete()
        {
            if (SelectedModel != null)
            {
                using (var dbContext = new DatabaseContext())
                {
                    var address = dbContext.Addresses.Find(SelectedModel.AddressId);
                    address.DateDeleted = DateTime.Now;
                    dbContext.SaveChanges();
                }
                Refresh();
            }
        }
        #endregion
    }
}
