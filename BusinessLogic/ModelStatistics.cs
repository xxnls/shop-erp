using ShopERP.Models.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopERP.BusinessLogic
{
    public class ModelStatistics
    {
        public DatabaseContext Database { get; set; }

        public ModelStatistics()
        {
            Database = new DatabaseContext();
        }

        //public int GetNewestID<T>() where T : class
        //{
        //    int newestID = 0;
        //    if (Database.Set<T>().Count() > 0)
        //    {
        //        newestID = Database.Set<T>().OrderByDescending(x => x.GetType().GetProperty("ID").GetValue(x, null)).First().GetType().GetProperty("ID").GetValue(Database.Set<T>().OrderByDescending(x => x.GetType().GetProperty("ID").GetValue(x, null)).First(), null).GetHashCode();
        //    }
        //    return newestID;
        //}

        //public int GetActiveIDsCount<T>() where T : class
        //{
        //    int activeIDsCount = 0;
        //    if (Database.Set<T>().Count() > 0)
        //    {
        //        activeIDsCount = Database.Set<T>().Where(x => x.DateDeleted == null).Count();
        //    }
        //    return activeIDsCount;
        //}

        //calculate how much will there be money if all products are sold in a period of time
        public decimal CalculateTotalBasePrice(int productId, DateTime startDate, DateTime endDate)
        {
            return Database.Products.Where(item => item.DateDeleted == null
                                                && item.ProductId == productId
                                                && item.DateCreated >= startDate
                                                && item.DateCreated <= endDate)
                                    .Sum(item => item.ProductPrice * (decimal)item.ProductQuantity);
        }

        public decimal CalculateTotalTaxAmount(int productId, DateTime startDate, DateTime endDate)
        {
            return Database.Products.Where(item => item.DateDeleted == null
                                                && item.ProductId == productId
                                                && item.DateCreated >= startDate
                                                && item.DateCreated <= endDate)
                                    .Sum(item => item.ProductPrice * (decimal)item.ProductQuantity * (decimal)0.23);
        }

        public void CalculateAllStats(int productId, DateTime startDate, DateTime endDate, ref decimal totalBasePrice, ref decimal totalTaxAmount, ref decimal totalTaxedPrice)
        {
            totalBasePrice = CalculateTotalBasePrice(productId, startDate, endDate);
            totalTaxAmount = CalculateTotalTaxAmount(productId, startDate, endDate);
            totalTaxedPrice = totalBasePrice + totalTaxAmount;
        }
    }
}
