using ShopERP.Models;
using ShopERP.ViewModels.BaseViewModels;
using ShopERP.ViewResources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopERP.ViewModels
{
    public class EmployeesViewModel : BaseObjectViewModel<Employee>
    {
        #region Properties and Fields
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

        private string _employeeWage;
        public string EmployeeWage
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

        private string _employeeSalary;
        public string EmployeeSalary
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

        }

        #region Methods
        public override void Save()
        {
            throw new NotImplementedException();
        }

        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Edit()
        {
            throw new NotImplementedException();
        }

        public override void Refresh()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Employee> GetModels()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
