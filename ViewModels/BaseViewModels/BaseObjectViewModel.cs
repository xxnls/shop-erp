using ShopERP.Helpers;
using ShopERP.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopERP.ViewModels.BaseViewModels
{
    /// <summary>
    /// Abstract class responsible for all view models with mostly CRUD operations.
    /// </summary>
    
    public abstract class BaseObjectViewModel<T> : WorkspaceViewModel, IDataErrorInfo where T : class
    {
        #region Properties and Fields
        public string Error { get { return null; } }

        private ObservableCollection<T> _models;
        public ObservableCollection<T> Models
        {
            get { return _models; }
            set
            {
                if (_models != value)
                {
                    _models = value;
                    OnPropertyChanged(() => Models);
                }
            }
        }
        public ICommand RefreshCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand FilterCommand { get; set; }
        public ICommand ClearCommand { get; set; }

        private string? _dataGridInfoText;
        public string? DataGridInfoText
        {
            get { return _dataGridInfoText; }
            set
            {
                if (_dataGridInfoText != value)
                {
                    _dataGridInfoText = value;
                    OnPropertyChanged(() => DataGridInfoText);
                }
            }
        }
        private string? _selectedFilterOption;
        public string? SelectedFilterOption
        {
            get { return _selectedFilterOption; }
            set
            {
                if (_selectedFilterOption != value)
                {
                    _selectedFilterOption = value;
                    OnPropertyChanged(() => SelectedFilterOption);
                }
            }
        }
        private string? _filterText;
        public string? FilterText
        {
            get { return _filterText; }
            set
            {
                if (_filterText != value)
                {
                    _filterText = value;
                    OnPropertyChanged(() => FilterText);
                }
            }
        }

        private T? _selectedModel;
        public T? SelectedModel
        {
            get { return _selectedModel; }
            set
            {
                if (_selectedModel != value)
                {
                    _selectedModel = value;
                    OnPropertyChanged(() => SelectedModel);
                }
            }
        }

        private string _refreshTime;
        public string RefreshTime
        {
            get { return _refreshTime; }
            set
            {
                if (_refreshTime != value)
                {
                    _refreshTime = value;
                    OnPropertyChanged(() => RefreshTime);
                }
            }
        }
        #endregion

        #region Constructors
        protected BaseObjectViewModel(string name) : base(name)
        {
            RefreshTime = DateTime.Now.ToString("HH:mm:ss");
            RefreshCommand = new BaseCommand(() => Refresh());
            SaveCommand = new BaseCommand(() => Save());
            DeleteCommand = new BaseCommand(() => Delete());
            EditCommand = new BaseCommand(() => Edit());
            FilterCommand = new BaseCommand(() => Filter());
            ClearCommand = new BaseCommand(() => Clear());
            Models = new ObservableCollection<T>(GetModels());
        }
        #endregion

        #region Methods
        public abstract void Save();
        public abstract void Delete();
        public abstract void Edit();
        public abstract IEnumerable<T> GetModels();
        public abstract string this[string columnName] { get; }
        public abstract void Filter();
        public void DataGridCheck()
        {
            if (Models.Count == 0)
            {
                DataGridInfoText = "No data to display.";
            }
            else
            {
                DataGridInfoText = null;
            }
        }
        public void Clear()
        {
            FilterText = null;
            Refresh();
        }

        public void Refresh()
        {
            RefreshTime = DateTime.Now.ToString("HH:mm:ss");
            Models.Clear();
            foreach (var model in GetModels())
            {
                Models.Add(model);
            }
            DataGridCheck();
        }
        
        #endregion
    }
}
