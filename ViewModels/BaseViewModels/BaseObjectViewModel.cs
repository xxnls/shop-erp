﻿using ShopERP.Helpers;
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
        public string Error => null;
        public ObservableCollection<T> Models { get; set; }
        public ICommand RefreshCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public ICommand DeleteCommand { get; set; }
        public ICommand EditCommand { get; set; }

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

        public string this[string columnName] => throw new NotImplementedException();
        #endregion

        protected BaseObjectViewModel(string name) : base(name)
        {
            RefreshTime = DateTime.Now.ToString("HH:mm:ss");
            RefreshCommand = new BaseCommand(() => Refresh());
            SaveCommand = new BaseCommand(() => Save());
            DeleteCommand = new BaseCommand(() => Delete());
            EditCommand = new BaseCommand(() => Edit());
            Models = new ObservableCollection<T>(GetModels());
        }

        public abstract void Save();
        public abstract void Delete();
        public abstract void Edit();
        public void Refresh()
        {
            RefreshTime = DateTime.Now.ToString("HH:mm:ss");
            Models.Clear();
            foreach (var model in GetModels())
            {
                Models.Add(model);
            }
        }
        public abstract IEnumerable<T> GetModels();
    }
}
