using ShopERP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ShopERP.ViewModels.BaseViewModels
{
    public class WorkspaceViewModel : BaseViewModel
    {
        #region FieldsAndProperties
        public string DisplayName { get; set; } //this name of the tab
        private BaseCommand _CloseCommand; //this is command to close a tab

        public WorkspaceViewModel(string name)
        {
            DisplayName = name;
        }

        public ICommand CloseCommand
        {
            get
            {
                if (_CloseCommand == null)
                    _CloseCommand = new BaseCommand(() => OnRequestClose()); //this command calls method to close a tab
                return _CloseCommand;
            }
        }
        #endregion

        #region RequestClose [event]
        public event EventHandler RequestClose;
        private void OnRequestClose()
        {
            EventHandler handler = RequestClose;
            if (handler != null)
                handler(this, EventArgs.Empty);
        }
        #endregion 

    }
}
