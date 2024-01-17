using Microsoft.EntityFrameworkCore;
using ShopERP.Models;
using ShopERP.Models.Contexts;
using ShopERP.ViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace ShopERP.ViewModels
{
    public class ReviewsViewModel : BaseObjectViewModel<Review>
    {
        #region Properties and Fields
        private int _productId;
        public int ProductId
        {
            get { return _productId; }
            set
            {
                if (_productId != value)
                {
                    _productId = value;
                    OnPropertyChanged(() => ProductId);
                }
            }
        }

        private int _customerId;
        public int CustomerId
        {
            get { return _customerId; }
            set
            {
                if (_customerId != value)
                {
                    _customerId = value;
                    OnPropertyChanged(() => CustomerId);
                }
            }
        }

        private int? _rating;
        public int? Rating
        {
            get { return _rating; }
            set
            {
                if (_rating != value)
                {
                    _rating = value;
                    OnPropertyChanged(() => Rating);
                }
            }
        }

        private string? _reviewText;
        public string? ReviewText
        {
            get { return _reviewText; }
            set
            {
                if (_reviewText != value)
                {
                    _reviewText = value;
                    OnPropertyChanged(() => ReviewText);
                }
            }
        }

        public override string this[string columnName] => throw new NotImplementedException();
        #endregion

        public ReviewsViewModel() : base("Reviews")
        {

        }

        #region Methods
        public override void Save()
        {
            using (var dbContext = new DatabaseContext())
            {
                var review = new Review
                {
                    ProductId = ProductId,
                    CustomerId = CustomerId,
                    Rating = Rating,
                    ReviewText = ReviewText,
                    DateCreated = DateTime.Now
                };
                dbContext.Reviews.Add(review);
                dbContext.SaveChanges();
            }
            Refresh();
        }

        public override void Delete()
        {
            if (SelectedModel != null)
            {
                using (var dbContext = new DatabaseContext())
                {
                    var review = dbContext.Reviews.Find(SelectedModel.ReviewId);
                    review.DateDeleted = DateTime.Now;
                    dbContext.SaveChanges();
                }
                Refresh();
            }
        }

        public override void Edit()
        {
            if (SelectedModel != null)
            {
                using (var dbContext = new DatabaseContext())
                {
                    var review = dbContext.Reviews.Find(SelectedModel.ReviewId);
                    review.ProductId = SelectedModel.ProductId;
                    review.CustomerId = SelectedModel.CustomerId;
                    review.Rating = SelectedModel.Rating;
                    review.ReviewText = SelectedModel.ReviewText;
                    review.DateEdited = DateTime.Now;
                    dbContext.SaveChanges();
                    SelectedModel = null;
                }
                Refresh();
            }
        }

        public override IEnumerable<Review> GetModels()
        {
            using (var dbContext = new DatabaseContext())
            {
                return dbContext.Reviews.Include(r => r.Customer)
                                        .Include(r => r.Product)
                                        .Where(r => r.DateDeleted == null)
                                        .ToList();
            }
        }
        #endregion
    }
}
