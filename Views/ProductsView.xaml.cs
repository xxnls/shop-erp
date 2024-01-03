﻿using ShopERP.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ShopERP.Views
{
    /// <summary>
    /// Interaction logic for ProductsView.xaml
    /// </summary>
    public partial class ProductsView : UserControl
    {
        public ProductsView()
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
