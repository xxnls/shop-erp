using ShopERP.Helpers;
using System;
using System.Windows;
using System.Windows.Controls;

namespace ShopERP.Views
{
    public partial class SalesView : UserControl
    {
        public SalesView()
        {
            InitializeComponent();
        }
        private void FoldExpander_Click(object sender, RoutedEventArgs e)
        {
            addButton.IsChecked = false;
        }
        private void ClearTextboxes_Click(object sender, RoutedEventArgs e)
        {
            ExpanderHelper.ClearTextBoxesInExpander(expander);
        }
    }
}
