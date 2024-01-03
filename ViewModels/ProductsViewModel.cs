using ShopERP.Models;
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
    public class ProductsViewModel : BaseObjectViewModel<Product>
    {

        public ProductsViewModel() : base(GlobalResources.Products)
        {
        }
        public override void Delete()
        {
            throw new NotImplementedException();
        }

        public override void Edit()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Product> GetModels()
        {
            throw new NotImplementedException();
        }

        public override void Refresh()
        {
            throw new NotImplementedException();
        }

        public override void Save()
        {
            throw new NotImplementedException();
        }
    }
}
