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
    public class EmployeesViewModel : BaseObjectViewModel<Employee>
    {
        #region Properties and Fields
        public ObservableCollection<EmployeesRole> EmployeesRoles { get; set; }
        public ObservableCollection<Address> EmployeeAddresses { get; set; }

        private int _selectedEmployeeRoleId;
        public int SelectedEmployeeRoleId
        {
            get { return _selectedEmployeeRoleId; }
            set
            {
                if (_selectedEmployeeRoleId != value)
                {
                    _selectedEmployeeRoleId = value;
                    OnPropertyChanged(() => SelectedEmployeeRoleId);
                }
            }
        }

        private int _selectedEmployeeAddressId;
        public int SelectedEmployeeAddressId
        {
            get { return _selectedEmployeeAddressId; }
            set
            {
                if (_selectedEmployeeAddressId != value)
                {
                    _selectedEmployeeAddressId = value;
                    OnPropertyChanged(() => SelectedEmployeeAddressId);
                }
            }
        }

        private string _employeeFirstName;
        public string EmployeeFirstName
        {
            get { return _employeeFirstName; }
            set
            {
                if (_employeeFirstName != value)
                {
                    _employeeFirstName = value;
                    OnPropertyChanged(() => EmployeeFirstName);
                }
            }
        }

        private string _employeeLastName;
        public string EmployeeLastName
        {
            get { return _employeeLastName; }
            set
            {
                if (_employeeLastName != value)
                {
                    _employeeLastName = value;
                    OnPropertyChanged(() => EmployeeLastName);
                }
            }
        }

        private decimal _employeeWage;
        public decimal EmployeeWage
        {
            get { return _employeeWage; }
            set
            {
                if (_employeeWage != value)
                {
                    _employeeWage = value;
                    OnPropertyChanged(() => EmployeeWage);
                }
            }
        }

        private decimal _employeeSalary;
        public decimal EmployeeSalary
        {
            get { return _employeeSalary; }
            set
            {
                if (_employeeSalary != value)
                {
                    _employeeSalary = value;
                    OnPropertyChanged(() => EmployeeSalary);
                }
            }
        }
        #endregion
        public EmployeesViewModel() : base(GlobalResources.Employees)
        {
            EmployeesRoles = new ObservableCollection<EmployeesRole>(GetEmployeesRoles());
            EmployeeAddresses = new ObservableCollection<Address>(GetAddresses());
        }

        #region Methods
        public override void Save()
        {
            using (var dbContext = new DatabaseContext())
            {
                var employee = new Employee
                {
                    EmployeeRoleId = SelectedEmployeeRoleId,
                    AddressId = SelectedEmployeeAddressId,
                    EmployeeFirstName = EmployeeFirstName,
                    EmployeeLastName = EmployeeLastName,
                    EmployeeWage = EmployeeWage,
                    EmployeeSalary = EmployeeSalary,
                    DateCreated = DateTime.Now
                };
                dbContext.Employees.Add(employee);
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
                    var employee = dbContext.Employees.Find(SelectedModel.EmployeeId);
                    employee.DateDeleted = DateTime.Now;
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
                    var employee = dbContext.Employees.Find(SelectedModel.EmployeeId);
                    employee.EmployeeFirstName = SelectedModel.EmployeeFirstName;
                    employee.EmployeeLastName = SelectedModel.EmployeeLastName;
                    employee.EmployeeWage = SelectedModel.EmployeeWage;
                    employee.EmployeeSalary = SelectedModel.EmployeeSalary;
                    employee.EmployeeRoleId = SelectedModel.EmployeeRoleId;
                    employee.AddressId = SelectedModel.AddressId;
                    employee.DateEdited = DateTime.Now;
                    dbContext.SaveChanges();
                    SelectedModel = null;
                }
                Refresh();
            }
        }

        private IEnumerable<EmployeesRole> GetEmployeesRoles()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.EmployeesRoles.ToList();
            }
        }

        private IEnumerable<Address> GetAddresses()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Addresses.ToList();
            }
        }

        public override IEnumerable<Employee> GetModels()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Employees.Include(item => item.EmployeeRole)
                                          .Include(item => item.Address)
                                          .Where(employee => employee.DateDeleted == null)
                                          .ToList();
            }
        }
        #endregion
    }
}
