using ShopERP.Helpers;
using ShopERP.ViewModels.BaseViewModels;
using ShopERP.ViewResources;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace ShopERP.ViewModels
{
    public class MainWindowViewModel : BaseViewModel
    {
        #region TopAndSideMenuCommand

        public ICommand OpenAddressesView { get => new BaseCommand(() => CreateView(new AddressesViewModel())); }
        public ICommand OpenProductsView { get => new BaseCommand(() => CreateView(new ProductsViewModel())); }
        public ICommand OpenEmployeesView { get => new BaseCommand(() => CreateView(new EmployeesViewModel())); }
        public ICommand OpenShiftsView { get => new BaseCommand(() => CreateView(new ShiftsViewModel())); }
        public ICommand OpenCustomersView { get => new BaseCommand(() => CreateView(new CustomersViewModel())); }

        #endregion

        System.Windows.Threading.DispatcherTimer Timer = new System.Windows.Threading.DispatcherTimer();
        private string _actualTime;
        public string ActualTime
        {
            get => _actualTime;
            set
            {
                _actualTime = value;
                OnPropertyChanged(() => ActualTime);
            }
        }

        public MainWindowViewModel()
        {
            Commands = new(CreateCommands());
            Workspaces = new();
            Workspaces.CollectionChanged += OnWorkspacesChanged;
            Timer.Tick += new EventHandler(Timer_Click);
            Timer.Interval = new TimeSpan(0, 0, 1);
            Timer.Start();
        }

        private void Timer_Click(object sender, EventArgs e)
        {
            DateTime d = DateTime.Now;
            ActualTime = d.ToString("yyyy/MM/dd dddd HH:mm:ss");
        }

        #region Buttons in side bar

        public ReadOnlyCollection<CommandViewModel> Commands { get; set; }

        private List<CommandViewModel> CreateCommands()
        {
            return new()
            {
                new (GlobalResources.Addresses, OpenAddressesView),
                new (GlobalResources.Products, OpenProductsView),
                new (GlobalResources.Employees, OpenEmployeesView),
                new ("Shifts", OpenShiftsView),
                new ("Customers", OpenCustomersView)
            };
        }

        #endregion

        #region Tabs

        public ObservableCollection<WorkspaceViewModel> Workspaces { get; set; }
        private void OnWorkspacesChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null && e.NewItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.NewItems)
                    workspace.RequestClose += onWorkspaceRequestClose;

            if (e.OldItems != null && e.OldItems.Count != 0)
                foreach (WorkspaceViewModel workspace in e.OldItems)
                    workspace.RequestClose -= onWorkspaceRequestClose;
        }

        private void onWorkspaceRequestClose(object sender, EventArgs e)
        {
            WorkspaceViewModel? workspace = sender as WorkspaceViewModel;
            if (workspace != null)
            {
                Workspaces.Remove(workspace);
            }
        }

        #endregion

        #region Helpers

        private void CreateView(WorkspaceViewModel workspace)
        {
            Workspaces.Add(workspace);
            SetActiveWorkspace(workspace);
        }

        private void CreateListView<WorkspaceViewModelType>() where WorkspaceViewModelType : WorkspaceViewModel, new()
        {
            WorkspaceViewModel? workspace = Workspaces.FirstOrDefault(vm => vm is WorkspaceViewModelType);
            if (workspace == null)
            {
                workspace = new WorkspaceViewModelType();
                Workspaces.Add(workspace);
            }
            SetActiveWorkspace(workspace);
        }

        private void SetActiveWorkspace(WorkspaceViewModel workspace)
        {
            Debug.Assert(Workspaces.Contains(workspace));

            ICollectionView collectionView = CollectionViewSource.GetDefaultView(Workspaces);
            if (collectionView != null)
                collectionView.MoveCurrentTo(workspace);
        }

        #endregion
    }
}
