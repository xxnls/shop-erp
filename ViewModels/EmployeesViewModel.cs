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
            EmployeesRoles = new ObservableCollection<EmployeesRole>();
        }

        #region Methods
        public override void Save()
        {
            //using (var dbContext = new DatabaseContext())
            //{
            //    var employee = new Employee
            //    {
            //        EmployeeFirstName = EmployeeFirstName,
            //        EmployeeLastName = EmployeeLastName,
            //        EmployeeRoleId = SelectedEmployeeRoleId,
            //        EmployeeWage = EmployeeWage,
            //        EmployeeSalary = EmployeeSalary,
            //        EmployeeRoleId = SelectedEmployeeRoleId
            //    };
            //    dbContext.Addresses.Add(employee);
            //    dbContext.SaveChanges();
            //}
            //Refresh();
        }

        public override void Delete()
        {
            
        }

        public override void Edit()
        {
            
        }

        public override IEnumerable<Employee> GetModels()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Employees.Include(item => item.EmployeeRole)
                                          .Where(employee => employee.DateDeleted == null)
                                          .ToList();
            }
        }
        #endregion
    }
}
