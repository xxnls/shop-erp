using ShopERP.Helpers;
using System.Windows;
using System.Windows.Controls;

namespace ShopERP.Views
{
    public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
            InitializeComponent();
        }

        private void ClearTextboxes_Click(object sender, RoutedEventArgs e)
        {
            ExpanderHelper.ClearTextBoxesInExpander(expander);
        }

        private void FoldExpander_Click(object sender, RoutedEventArgs e)
        {
            addButton.IsChecked = false;
        }
    }
}
